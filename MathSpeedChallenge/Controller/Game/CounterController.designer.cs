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
	[Register ("CounterController")]
	partial class CounterController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Countdown { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Level { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel LevelInstructions { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Countdown != null) {
				Countdown.Dispose ();
				Countdown = null;
			}
			if (Level != null) {
				Level.Dispose ();
				Level = null;
			}
			if (LevelInstructions != null) {
				LevelInstructions.Dispose ();
				LevelInstructions = null;
			}
		}
	}
}
