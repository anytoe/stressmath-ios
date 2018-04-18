using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ObjCRuntime;
using Domain.MSC;

namespace MathSpeedChallenge
{
	partial class HighscoreView : UIView
	{
		public HighscoreView (IntPtr handle) : base (handle)
		{
			// nothing to do
		}

		public Highscore[] Highscore { 
			set {				
				Table.Source = new HigscoreTableSource (value);
			}
		}

		public static HighscoreView Create ()
		{
			var array = NSBundle.MainBundle.LoadNib ("HighscoreView", null, null);
			var highscoreView = Runtime.GetNSObject<HighscoreView> (array.ValueAt (0));		

			//Table.BackgroundView.BackgroundColor = UIColor.Clear.FromHexString ("#3858CC", 1.0f);

			return highscoreView;
		}

	}
}
