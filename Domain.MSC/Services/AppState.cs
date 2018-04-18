using System;
using MathSpeedChallenge;
using System.Linq;

namespace Domain.MSC
{
	public class AppState
	{
		private static AppState appState;
		private DataAccess dal;

		public AppState ()
		{
			dal = new DataAccess ();
		}

		// TODO improve, keep in memory
		public Game LastGame { get { return dal.GetLast (); } }

		public bool HasLastGame { get { return dal.GetLast () != null; } }


		public bool HasHighscore { get { return dal.GetAll ().Any (); } }


		public GameManager CurrentGame { get; set; }

		public bool HasCurrentGame { get; set; }


		public GameManager NewGame (GameType gameType)
		{
			CurrentGame = new GameManager (dal);
			CurrentGame.NewGame (gameType);

			return CurrentGame;
		}


		public void Stop ()
		{
			CurrentGame?.FailGame ();
			CurrentGame = null; 
		}

		public void GameFinished ()
		{
			CurrentGame = null;
		}

		public Highscore[] GetHighscore (GameType gameType, bool highlightLast)
		{			
			var lastGameResultID = dal.GetLast ()?.ID;

			var highscore = dal.GetAll ()
				.Where (gameResult => gameResult.FinalScore > 0 && gameResult.GameType == gameType)
				.OrderByDescending (gameResult => gameResult.FinalScore)
				.Select (gameResult => new Highscore {
				Date = gameResult.Finished,
				Score = gameResult.FinalScore.ToString (),
				IsHighlighted = highlightLast && gameResult.ID == lastGameResultID
			}).ToArray ();

			return highscore;
		}

		public static AppState Instance {
			get {
				if (appState == null)
					appState = new AppState ();

				return appState;
			}
		}
	}
}

