using System;
using SQLite;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Domain.MSC
{
	public class DataAccess
	{
		private string dbPath;

		public DataAccess()
		{
			dbPath = GetDbPath("stressmath.db3");

			if (!File.Exists(dbPath))
				CreateDatabase();
		}

		private string GetDbPath(string name)
		{
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "..", "Library");
			return Path.Combine(libraryPath, name);
		}

		public void CreateDatabase()
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				connection.CreateTable<GameState>();
				connection.CreateTable<Game>();
				connection.CreateTable<GameLevel>();

				connection.Insert(new GameState());

				connection.Close();
			}
		}

		public void DropDatabase()
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				connection.DropTable<GameState>();
				connection.DropTable<Game>();
				connection.DropTable<GameLevel>();

				connection.Close();
			}
		}

		public Game GetGame(int ID)
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				var entity = connection.Get<Game>(ID);
				connection.Close();

				return entity;
			}
		}

		public void AddOrUpdate<T>(T dbObject) where T : Entity
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				if (dbObject.EntityID == 0)
					connection.Insert(dbObject);
				else
					connection.Update(dbObject);
				connection.Close();
			}
		}

		public List<Game> GetAll()
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				var result = connection.Table<Game>();
				var list = new List<Game>();
				foreach (var gr in result)
					list.Add(gr);

				connection.Close();

				return list;
			}
		}

		public Game GetLast()
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				var result = connection.Table<Game>().OrderByDescending(gameResult => gameResult.Finished).FirstOrDefault();
				connection.Close();

				return result;
			}
		}

		public GameState GetGameState()
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				var gameState = connection.Table<GameState>().First();
				connection.Close();

				return gameState;
			}
		}

		public GameLevel GetLastLevel(Game game)
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				var result = connection.Table<GameLevel>()
					.Where(GameLevel => GameLevel.GameID == game.ID)
					.OrderByDescending(level => level.LevelNr)
					.FirstOrDefault();
				connection.Close();

				return result;
			}
		}

		public bool HasGameResults()
		{
			using (var connection = new SQLiteConnection(dbPath))
			{
				var hasGameResults = connection.Table<Game>().Where(gr => gr.FinalScore > 0).Count() > 0;
				connection.Close();

				return hasGameResults;
			}
		}
	}
}

