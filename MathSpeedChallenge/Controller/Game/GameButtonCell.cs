using System;

using Foundation;
using UIKit;

namespace MathSpeedChallenge
{
	// [Register("GameButtonCell")]
	public partial class GameButtonCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString ("GameButtonCell");
		public static readonly UINib Nib;

		public GameButtonCell (IntPtr handle) : base (handle)
		{
		}

		public string Text { 
			set { AnswerButton.SetTitle (value, UIControlState.Normal); }
		}

		public static GameButtonCell Create ()
		{
			var arr = NSBundle.MainBundle.LoadNib (Key, null, null);
			return ObjCRuntime.Runtime.GetNSObject<GameButtonCell> (arr.ValueAt (0));
		}
	}
}
