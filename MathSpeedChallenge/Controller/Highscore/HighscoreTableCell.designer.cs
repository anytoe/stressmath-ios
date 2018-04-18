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
    [Register ("HighscoreTableCell")]
    partial class HighscoreTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Date { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Score { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Date != null) {
                Date.Dispose ();
                Date = null;
            }

            if (Score != null) {
                Score.Dispose ();
                Score = null;
            }
        }
    }
}