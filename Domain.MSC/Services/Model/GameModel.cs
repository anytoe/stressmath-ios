using System;
using System.Linq;

namespace Domain.MSC
{
	// Create a seperate level model
	public abstract class GameModel
	{
		protected short wrongAnswersGiven = 0;
		protected short correctAnswersGiven = 0;
		protected short gameScoreFactor = 0;

		public GameModel (short gameScoreFactor, short?  levelCount)
		{
			this.gameScoreFactor = gameScoreFactor;
			LevelCount = levelCount;
		}

		public int AnswersGiven { get { return correctAnswersGiven + wrongAnswersGiven; } }

		public short? LevelCount { get; protected set; }

		public bool HasLevels { get { return LevelCount != null && LevelCount > 1; } }

		public short QuestionCount {get { return (short)ProblemGeneratorParam.Operateurs.Sum (op => op.Frequency);}}

		public int TimeToSolveMs { get; protected set; }

		public int Score  { get ; protected set; }

		public int? CurrentLevel { get; protected set; }

		public string CurrentLevelMessage { get; protected set; }

		public bool IsGameOver { get; protected set; }

		public bool IsGameCompleted { get { return !IsGameOver && HasLevels && LevelCount <= CurrentLevel; } }

		public bool IsLevelCompleted { get { return !IsGameOver && QuestionCount <= AnswersGiven; } }


		public ProblemGeneratorParam ProblemGeneratorParam { get; protected set; }

		public abstract void NextLevel (int level);

		public void Result (bool isCorrectAnswer, float timeFactor)
		{
			if (isCorrectAnswer) {
				correctAnswersGiven++;

				// Update Time
				var maxTimePenaltyPercentage = 0.2f;
				var penalty = (1 - timeFactor) * maxTimePenaltyPercentage;
				TimeToSolveMs -= (int)(TimeToSolveMs * penalty);

				// Update Score
				Score = (int)(Score + (correctAnswersGiven * timeFactor) * 10);
			} else
				wrongAnswersGiven++;

			IsGameOver = !isCorrectAnswer;
		}

		protected void Reset(){
			correctAnswersGiven = 0;
			wrongAnswersGiven = 0;
			ProblemGeneratorParam = new ProblemGeneratorParam ();
		}			

		public static GameModel GetGameModel (GameType type)
		{
			switch (type) {
			case GameType.Addition:
				return new AdditionGame ();
			case GameType.Subtraction:
				return new SubtractionGame ();
			case GameType.Multiplication:
				return new MultiplicationGame ();
			case GameType.Division:
				return new DivisionGame ();
			case GameType.MixedMode:
				return new MixedMode ();
			default:
				throw new Exception ("Unknown Game Mode");
			}

		}
	}
}

