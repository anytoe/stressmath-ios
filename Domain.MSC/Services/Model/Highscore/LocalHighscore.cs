using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.MSC
{
	public class LocalHighscore {

		private List<LocalHighscoreItem> items;

		public LocalHighscore() {
			items = new List<LocalHighscoreItem>();
		}

		public void add(LocalHighscoreItem highscore) {

			foreach (LocalHighscoreItem item in items) 
			{
				item.setIsNew(false);
			}

			items.Add(highscore);
			items = items.OrderBy(item => item.getHighscore()).ToList();
			//Collections.sort(items, new CustomComparator());

			if (items.Count > 20) {
				items.Remove(items.Last());
			}
		}

		public bool hasHighscore() {
			return items.Count > 0;
		}

		public List<LocalHighscoreItem> GetLocalHighscoreList() {
			return items;
		}

//		public class CustomComparator: Comparator<LocalHighscoreItem> {
//
//			@Override
//			public int compare(LocalHighscoreItem highscore1, LocalHighscoreItem highscore2) {
//				int compareResult = highscore2.getHighscore() - highscore1.getHighscore();
//				return compareResult;
//			}
//		}

	}
}

