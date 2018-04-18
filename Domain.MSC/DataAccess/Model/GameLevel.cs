using System;
using SQLite;

namespace Domain.MSC
{
	public class GameLevel: Entity
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public override int EntityID => ID;

		public int GameID { get; set; }

		public int LevelNr { get; set; } = 1;

		public int LevelScore { get; set; }

		public bool IsSuccess { get; set; }
	}
}

