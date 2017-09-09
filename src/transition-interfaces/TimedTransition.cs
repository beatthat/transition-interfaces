using UnityEngine;

namespace BeatThat
{
	namespace Anim 
	{
		public delegate float EasingFunction(float start, float distance, float elapsedTime, float duration);
		
		public interface TimedTransition : Transition
		{
			/// <summary>
			/// How far the transition has progressed in seconds
			/// </summary>
			float timeIn { get; }

			/// <summary>
			/// How long until the transition completes in seconds
			/// </summary>
			float timeRem { get; }

			/// <summary>
			/// What percent complete is the transition
			/// </summary>
			float pctComplete { get; }

			/// <summary>
			/// Length of the transition in seconds
			/// </summary>
			float dur { get; set; }

			/// <summary>
			/// Delays this amount in seconds after transition starts before actually beginning the transition
			/// </summary>
			float delay { get; set; }
			
			TimedTransition WithDelay(float delay);

		}
	}
}
