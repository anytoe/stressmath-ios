using System;
using UIKit;
using Foundation;

namespace MathSpeedChallenge
{
	public class HigscoreTableSource : UITableViewSource
	{

		private Highscore[] tableItems;

		public HigscoreTableSource (Highscore[] items)
		{
			tableItems = items;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (HighscoreTableCell)tableView.DequeueReusableCell (HighscoreTableCell.Key);
			if (cell == null) {
				cell = HighscoreTableCell.Create ();
			}
			cell.Model = tableItems [indexPath.Row];

			return cell;
		}
	}

	public class Highscore
	{
		public int Ranking { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Score { get; set; }

		public bool IsHighlighted { get; set; }
	}
}

