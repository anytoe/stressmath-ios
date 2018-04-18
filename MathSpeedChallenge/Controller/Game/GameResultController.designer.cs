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
	[Register ("GameResultController")]
	partial class GameResultController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TableView { get; set; }

		[Action ("NewGameButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void NewGameButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
