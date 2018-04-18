using System;

namespace Domain.MSC
{
	public class LocalHighscoreItem {

		//private static final long serialVersionUID = 4138462132635780439L;

		private long timeMs;
		private int score;
		private bool isNew;

		public LocalHighscoreItem(int score, bool isNew) {
			this.score = score;
			this.isNew = isNew;
			this.timeMs = (long)(new DateTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;
		}

		public bool IsNew() {
			return isNew;
		}

		public void setIsNew(bool isNew) {
			this.isNew = isNew;
		}

		public DateTime getDate() {
			return new DateTime(timeMs);
		}

		public int getHighscore() {
			return score;
		}
	}

}

