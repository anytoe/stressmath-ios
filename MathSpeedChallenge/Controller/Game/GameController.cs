using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Threading;
using Domain.MSC;

namespace MathSpeedChallenge
{
	partial class GameController : UIViewController
	{
		private Timer timer;
		private bool timeUpTriggered;

		public GameController (IntPtr handle) : base (handle)
		{
			this.NavigationItem.SetHidesBackButton (true, false);
			this.Title = "Let's go!";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			answerButton1.TouchUpInside += AnswerEvent;
			answerButton2.TouchUpInside += AnswerEvent;
			answerButton3.TouchUpInside += AnswerEvent;
			answerButton4.TouchUpInside += AnswerEvent;		

			AppState.Instance.CurrentGame.GameFinished += GameCompleted;
			AppState.Instance.CurrentGame.GameNextQuestion += ChangeTask;
			AppState.Instance.CurrentGame.GameNextLevel += LevelCompleted;

			var mathProblem = AppState.Instance.CurrentGame.StartLevel ();

			ChangeTask (mathProblem);
		}

		private void ChangeTask (MathProblem mathProblem)
		{
			this.Title = string.Format ("Score: {0}", AppState.Instance.CurrentGame.Score);

			remainingTimeBar.SetProgress (1, false);
			setMathChallenge (mathProblem);

			InitTimer (mathProblem);
		}

		private void InitTimer (MathProblem mathProblem)
		{
			StopTimer ();
			
			var timerDelegate = new TimerCallback (UpdateRemainingTimeBar);

			var timerState = new GameTimer ();
			timerState.Debug = mathProblem.getProblem ();
			timerState.TimeLeftMs = AppState.Instance.CurrentGame.TimeToSolveMs;
			timerState.TotalTimeMs = timerState.TimeLeftMs;
			timerState.TimeStepMs = 50;

			timer = new Timer (timerDelegate, timerState, 0, timerState.TimeStepMs);
		}

		private void StopTimer ()
		{
			if (timer != null)
				timer.Dispose ();
		}


		public void AnswerEvent (object sender, EventArgs e)
		{	
			timer.Dispose ();

			var button = (UIButton)sender;
			var answer = button.CurrentTitle;
			float answerFactor = remainingTimeBar.Progress;

			AppState.Instance.CurrentGame.Answer (answer.ToString (), answerFactor);
		}

		private void setMathChallenge (MathProblem mathProblem)
		{
			questionLabel.Text = mathProblem.getProblem () + " = ?";
			var randomizedAnswers = mathProblem.getRandomizedAnswers ();
			answerButton1.SetTitle (randomizedAnswers [0], UIControlState.Normal);
			answerButton2.SetTitle (randomizedAnswers [1], UIControlState.Normal);
			answerButton3.SetTitle (randomizedAnswers [2], UIControlState.Normal);
			answerButton4.SetTitle (randomizedAnswers [3], UIControlState.Normal);
		}

		public void UpdateRemainingTimeBar (object state)
		{
			var timerState = (GameTimer)state;
			timerState.Decrement ();

			UIDevice.CurrentDevice.BeginInvokeOnMainThread (() => {
				remainingTimeBar.SetProgress (timerState.TimeFraction, true);
			});

			if (timerState.IsFinished && !timeUpTriggered) {
				timeUpTriggered = true;
				AppState.Instance.CurrentGame.FailGame ();
			}
				
		}

		private async void LevelCompleted ()
		{
			timeUpTriggered = true;
			StopTimer ();
			AppState.Instance.CurrentGame.ClearListener ();
			UIDevice.CurrentDevice.BeginInvokeOnMainThread (async () => {
				var gameResult = this.Storyboard.InstantiateViewController ("CounterController") as CounterController;
				this.NavigationController.PushViewController (gameResult, true);
			});
		}

		private async void GameCompleted (bool isSuccess)
		{
			timeUpTriggered = true;
			StopTimer ();
			AppState.Instance.CurrentGame.ClearListener ();
			AppState.Instance.GameFinished ();
			UIDevice.CurrentDevice.BeginInvokeOnMainThread (async () => {
				var gameResult = this.Storyboard.InstantiateViewController ("GameResultController") as GameResultController;
				this.NavigationController.PushViewController (gameResult, true);
			});
		}
	}


}
