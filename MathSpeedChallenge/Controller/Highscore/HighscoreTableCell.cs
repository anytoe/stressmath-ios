using System;

using Foundation;
using UIKit;

namespace MathSpeedChallenge
{
	//	[Register ("HighscoreTableCell")]
	public partial class HighscoreTableCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("HighscoreTableCell");
		public static readonly UINib Nib;

		public HighscoreTableCell (IntPtr handle) : base (handle)
		{
		}

		public Highscore Model { 
			set {
				Score.Text = value.Score;
				Date.Text = value.Date.ToString ("dd.MM.yyyy");
				if (value.IsHighlighted) {
					Score.TextColor = UIColor.Clear.FromHexString ("#BF3141", 1.0f);
					Date.TextColor = Score.TextColor;
				}
			}
		}

		public static HighscoreTableCell Create ()
		{
			var arr = NSBundle.MainBundle.LoadNib (Key, null, null);
			return ObjCRuntime.Runtime.GetNSObject<HighscoreTableCell> (arr.ValueAt (0));
		}


	}
}
