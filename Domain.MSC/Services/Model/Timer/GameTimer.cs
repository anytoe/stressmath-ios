using System;

namespace Domain.MSC
{
	public class GameTimer
	{
		public string Debug { get; set;}

		public int TotalTimeMs { get; set; }

		public int TimeLeftMs { get; set; }

		public int TimeStepMs { get; set; }

		public float TimeFraction { 
			get{ return TimeLeftMs / (float)TotalTimeMs; }
		}

		public void Decrement ()
		{
			TimeLeftMs -= TimeStepMs;
			if (TimeLeftMs < 0)
				TimeLeftMs = 0;
		}

		public bool IsFinished {
			get { return TimeLeftMs == 0; }
		}

		public override string ToString ()
		{
			return string.Format ("[TimerState: Debug={0}, TotalTimeMs={1}, TimeLeftMs={2}, TimeStepMs={3}, TimeFraction={4}, IsFinished={5}]", Debug, TotalTimeMs, TimeLeftMs, TimeStepMs, TimeFraction, IsFinished);
		}
	}
}

