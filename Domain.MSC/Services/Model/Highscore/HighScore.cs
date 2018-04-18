using System;
using System.Collections.Generic;

namespace Domain.MSC
{
	public class HighScore {

		public static List<HighScoreItem> ITEMS = new List<HighScoreItem>();
		public static List<HighScoreItem> ITEMS_CHANGED = new List<HighScoreItem>();


//		static {
//			addItem(new HighScoreItem(1, "Jan", 232));
//			addItem(new HighScoreItem(2, "Andreas", 123, true));
//			addItem(new HighScoreItem(3, "Peter", 66));
//
//			addItemChanged(new HighScoreItem(1, "Jan", 232));
//			addItemChanged(new HighScoreItem(2, "Andreas", 123, false));
//			addItemChanged(new HighScoreItem(3, "Peter", 66));
//		}

		private static void addItem(HighScoreItem item) {
			ITEMS.Add(item);
		}

		private static void addItemChanged(HighScoreItem item) {
			ITEMS_CHANGED.Add(item);
		}

		public class HighScoreItem{

			public int ranking;
			public String displayName;
			public int highScore;
			public bool isEditableUser;
			public bool isUser;

			public HighScoreItem(int ranking, String displayName, int highScore) {
				this.ranking = ranking;
				this.displayName = displayName;
				this.highScore = highScore;
				this.isEditableUser = false;
				this.isUser = false;
			}

			public HighScoreItem(int ranking, String displayName, int highScore, bool isEditableUser) {
				this.ranking = ranking;
				this.displayName = displayName;
				this.highScore = highScore;
				this.isEditableUser = isEditableUser;
				this.isUser = true;
			}
		}
	}

}

