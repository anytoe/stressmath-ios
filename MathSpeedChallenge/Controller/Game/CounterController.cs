using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Threading;
using Domain.MSC;

namespace MathSpeedChallenge
{
	partial class CounterController : UIViewController
	{
		private Timer timer;

		public CounterController (IntPtr handle) : base (handle)
		{
			this.NavigationItem.SetHidesBackButton (true, false);
			this.Title = "Ready?";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var timerDelegate = new TimerCallback (UpdateCountdown);
			var countdownState = new CountdownTimer{ };

			timer = new Timer (timerDelegate, countdownState, 1000, 1000);

			Countdown.Text = countdownState.CurrentValue.ToString ();

			Level.Hidden = !AppState.Instance.CurrentGame.HasLevel;
			if (!Level.Hidden) {
				Level.Text = "Level " + (AppState.Instance.CurrentGame.LevelNr);
			}

			LevelInstructions.Text = AppState.Instance.CurrentGame.LevelInstructions;
		}

		public void UpdateCountdown (object state)
		{
			var countdownState = (CountdownTimer)state;
			countdownState.Decrement ();

			if (countdownState.IsFinished) {
				StartGame ();
			} else {
				UIDevice.CurrentDevice.BeginInvokeOnMainThread (async () => {
					Countdown.Text = countdownState.CurrentValue.ToString ();
				});
			}
		}

		private void StopTimer ()
		{
			if (timer != null)
				timer.Dispose ();
		}

		private void StartGame ()
		{
			StopTimer ();

			UIDevice.CurrentDevice.BeginInvokeOnMainThread (async () => {
				var game = this.Storyboard.InstantiateViewController ("GameController") as GameController;
				this.NavigationController.PushViewController (game, true);
			});
		}
	}
}
