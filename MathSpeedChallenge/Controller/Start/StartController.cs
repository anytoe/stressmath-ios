using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Domain.MSC;

namespace MathSpeedChallenge
{
	partial class StartController : UIViewController
	{
		public StartController (IntPtr handle) : base (handle)
		{
			this.NavigationItem.SetHidesBackButton (true, false);
			//3858CC
		}

		public override void ViewDidLoad ()
		{
			HighscoreButton.SetTitleColor (UIColor.Gray, UIControlState.Disabled);

			HighscoreButton.Enabled = AppState.Instance.HasHighscore;

			base.ViewDidLoad ();
		}

		partial void Addition_Click (UIButton sender)
		{
			AppState.Instance.NewGame (GameType.Addition);
		}

		partial void Subtraction_Click (UIButton sender)
		{
			AppState.Instance.NewGame (GameType.Subtraction);
		}

		partial void Multiplication_Click (UIButton sender)
		{
			AppState.Instance.NewGame (GameType.Multiplication);
		}

		partial void Division_Click (UIButton sender)
		{
			AppState.Instance.NewGame (GameType.Division);
		}

		partial void MixedMode_Click (UIButton sender)
		{
			AppState.Instance.NewGame (GameType.MixedMode);
		}

	}
}
