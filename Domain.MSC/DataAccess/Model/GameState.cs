using SQLite;

namespace Domain.MSC
{
	public class GameState: Entity
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public override int EntityID => ID;

		public int CurrentGameID { get; set; }			
	}
}

