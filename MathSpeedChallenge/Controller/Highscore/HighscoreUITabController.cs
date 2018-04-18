using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Domain.MSC;

namespace MathSpeedChallenge
{
	partial class HighscoreUITabController : UITabBarController
	{
		public HighscoreUITabController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			CreateTabs ();
		}

		private UIViewController CreateTab (GameType gameType, string name, string iconName)
		{
			var tab = new UIViewController ();
			tab.TabBarItem = new UITabBarItem ();
			tab.TabBarItem.Image = UIImage.FromFile (iconName);
			tab.TabBarItem.Title = name;

			var hsView = HighscoreView.Create ();
			hsView.Highscore = AppState.Instance.GetHighscore (gameType, false);

			tab.View = hsView;

			return tab;
		}

		private void CreateTabs ()
		{
			var tab1 = CreateTab (GameType.Addition, "Addition", "Images/plus_40.png");
			var tab2 = CreateTab (GameType.Subtraction, "Subtraction", "Images/minus_40.png");
			var tab3 = CreateTab (GameType.Multiplication, "Multiplication", "Images/multiply_40.png");
			var tab4 = CreateTab (GameType.Division, "Division", "Images/divide_40.png");
			var tab5 = CreateTab (GameType.MixedMode, "Mixed Mode", "Images/qmark_40.png");

			var tabs = new UIViewController[] {
				tab1, tab2, tab3, tab4, tab5
			};

			ViewControllers = tabs;
		}
	}
}
