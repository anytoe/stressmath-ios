using System;
using SQLite;

namespace Domain.MSC
{
	public class Game: Entity
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public override int EntityID => ID;

		public GameType GameType { get; set; }

		public DateTimeOffset Started { get; set; }

		public DateTimeOffset Finished { get; set; }

		public int FinalScore { get; set; }
	}
}

