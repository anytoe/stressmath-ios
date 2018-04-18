// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MathSpeedChallenge
{
	[Register ("StartController")]
	partial class StartController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton HighscoreButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton NewGameButton { get; set; }

		[Action ("Addition_Click:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void Addition_Click (UIButton sender);

		[Action ("Division_Click:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void Division_Click (UIButton sender);

		[Action ("MixedMode_Click:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void MixedMode_Click (UIButton sender);

		[Action ("Multiplication_Click:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void Multiplication_Click (UIButton sender);

		[Action ("Subtraction_Click:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void Subtraction_Click (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (HighscoreButton != null) {
				HighscoreButton.Dispose ();
				HighscoreButton = null;
			}
			if (NewGameButton != null) {
				NewGameButton.Dispose ();
				NewGameButton = null;
			}
		}
	}
}
