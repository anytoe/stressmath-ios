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
	[Register ("GameController")]
	partial class GameController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton answerButton1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton answerButton2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton answerButton3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton answerButton4 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel questionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIProgressView remainingTimeBar { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (answerButton1 != null) {
				answerButton1.Dispose ();
				answerButton1 = null;
			}
			if (answerButton2 != null) {
				answerButton2.Dispose ();
				answerButton2 = null;
			}
			if (answerButton3 != null) {
				answerButton3.Dispose ();
				answerButton3 = null;
			}
			if (answerButton4 != null) {
				answerButton4.Dispose ();
				answerButton4 = null;
			}
			if (questionLabel != null) {
				questionLabel.Dispose ();
				questionLabel = null;
			}
			if (remainingTimeBar != null) {
				remainingTimeBar.Dispose ();
				remainingTimeBar = null;
			}
		}
	}
}
