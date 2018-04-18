using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Linq;
using SQLite;
using Domain.MSC;

namespace MathSpeedChallenge
{
	partial class GameResultController : UIViewController
	{
		private GameType lastGameType;

		public GameResultController (IntPtr handle) : base (handle)
		{
			this.NavigationItem.SetHidesBackButton (true, false);
		}

		public override void ViewDidLoad ()
		{
			EdgesForExtendedLayout = UIRectEdge.None;

			this.NavigationItem.SetRightBarButtonItem (
				new UIBarButtonItem (UIBarButtonSystemItem.Done, (sender, args) => {
					UIDevice.CurrentDevice.BeginInvokeOnMainThread (async () => {
						var viewController = this.Storyboard.InstantiateViewController ("StartController");
						this.NavigationController.PushViewController (viewController, true);
					});
				})
				, true);						

			base.ViewDidLoad ();

			TableView.BackgroundView = new UIView ();
			TableView.BackgroundView.BackgroundColor = UIColor.Clear.FromHexString ("#3858CC", 1.0f);
				
			init ();
		}

		public async void init ()
		{
			var lastGameResult = AppState.Instance.LastGame;
			lastGameType = lastGameResult.GameType;
			var tableItems = AppState.Instance.GetHighscore (lastGameResult.GameType, true);
		
			if (lastGameResult.FinalScore > 0) {
				this.Title = "Your Score: " + lastGameResult.FinalScore;
			} else {
				this.Title = "No points, no fame!";
			}

			if (tableItems.Length > 0) {
				TableView.Source = new HigscoreTableSource (tableItems);

				var scrollToIndex = Array.FindIndex (tableItems, hs => hs.IsHighlighted);
				if (scrollToIndex > -1) {
					var path = NSIndexPath.FromRowSection (scrollToIndex, 0);				
					TableView.ScrollToRow (path, UITableViewScrollPosition.Top, true);
				}
			}
		}

		partial void NewGameButton_TouchUpInside (UIButton sender)
		{
			AppState.Instance.NewGame (lastGameType);
		}
	}
}
