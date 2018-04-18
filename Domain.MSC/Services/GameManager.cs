using System;
using MathSpeedChallenge;
using System.Linq;

namespace Domain.MSC
{
	public class GameManager
	{
		private GameState state;
		private ProblemGenerator problemGen;
		private DataAccess dal;
		private GameModel gameModel;

		public GameManager (DataAccess dal)
		{
			this.dal = dal;
			state = dal.GetGameState ();
		}

		private Game game;

		private GameLevel level;

		public int TimeToSolveMs { get { return gameModel.TimeToSolveMs; } }

		public int Score  { get { return gameModel.Score; } }

		public bool HasLevel { get { return gameModel.HasLevels; } }

		public int? LevelNr { get { return gameModel.CurrentLevel; } }

		public string LevelInstructions { get { return gameModel.CurrentLevelMessage; } }


		public delegate void GameFinishedDelegate (bool IsSuccess);

		public event GameFinishedDelegate GameFinished;

		public delegate void GameNextQuestionDelegate (MathProblem problem);

		public event GameNextQuestionDelegate GameNextQuestion;

		public delegate void GameNextLevelDelegate ();

		public event GameNextLevelDelegate GameNextLevel;


		public Game NewGame (GameType gameType)
		{
			game = new Game ();
			game.GameType = gameType;

			dal.AddOrUpdate (game);

			state.CurrentGameID = game.ID;

			dal.AddOrUpdate (state);

			level = new GameLevel ();
			gameModel = GameModel.GetGameModel (game.GameType);			

			return game;
		}

		public MathProblem StartLevel ()
		{
			gameModel.NextLevel (level.LevelNr);
			problemGen = new ProblemGenerator (gameModel.ProblemGeneratorParam);	

			return problemGen.MathProblems [gameModel.AnswersGiven];
		}

		public void Answer (string answer, float answerFactor)
		{
			var isCorrectAnswer = problemGen.MathProblems [gameModel.AnswersGiven].IsAnswerCorrect (answer);
			gameModel.Result (isCorrectAnswer, answerFactor);

			if (!gameModel.IsGameOver) {
				if (gameModel.IsLevelCompleted) {
					if (gameModel.IsGameCompleted) {
						// game over
						CompleteGame (true);
					} else {
						// level over
						CompleteLevel ();
					}
				} else {
					// next question
					var nextProblem = problemGen.MathProblems [gameModel.AnswersGiven];
					GameNextQuestion?.Invoke (nextProblem);
				}
			} else {
				// game over
				CompleteGame (false);
			}
		}

		public void FailGame ()
		{
			CompleteGame (false);
		}

		private void CompleteLevel ()
		{
			level.IsSuccess = true;
			level.LevelScore = Score;

			game.Finished = DateTimeOffset.Now;
			game.FinalScore += Score;

			Save ();

			var previousLevel = level?.LevelNr ?? 0;

			level = new GameLevel ();
			level.GameID = game.ID;
			level.LevelNr = previousLevel + 1;	

			GameNextLevel?.Invoke ();
		}

		private void CompleteGame (bool isSuccess)
		{
			level.IsSuccess = isSuccess;
			level.LevelScore = Score;

			game.Finished = DateTimeOffset.Now;
			game.FinalScore += Score;

			state.CurrentGameID = 0;

			Save ();

			GameFinished?.Invoke (isSuccess);
			GameFinished = null;
		}

		private void Save ()
		{
			if (game != null)
				dal.AddOrUpdate (game);

			if (level != null)
				dal.AddOrUpdate (level);

			if (state != null)
				dal.AddOrUpdate (state);
		}

		public void ClearListener ()
		{
			GameFinished = null;
			GameNextLevel = null;
			GameNextQuestion = null;
		}

	}
}

