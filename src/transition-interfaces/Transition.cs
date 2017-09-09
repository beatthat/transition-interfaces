using System;

namespace BeatThat.Anim
{
	// TODO: Transition is really that same as a Request except that can be force completed on demand. Transition now implements Request. Next step should be to get rid of redundant methods, e.g. Transition::StartTransition is the same as Request::Execute


	/// <summary>
	/// A <c>Transition</c> starts and then runs to it's completion. A <c>Transition</c> can also be forced to complete early.
	/// 
	/// Common examples are transitions to bring in or send out a UI panel.
	/// </summary>
	public interface Transition : Request
	{
		event Action<Transition> Completed; // TODO: replace with UnityEvent, possibly have a no-arg event option (for auto unbind)
		
		/// <summary>
		/// Name/id for this transition
		/// </summary>
		string transitionName { get; set; }
		
		/// <summary>
		/// Starts and runs the transition
		/// </summary>
		void StartTransition();
		
		/// <summary>
		/// Starts the transition using the GlobalTransitionRunner
		/// </summary>
		/// <param name='time'>
		/// Generally use Time.time, but having time as a param allow alternative time models
		/// </param>
		void StartTransition(float time);
		
		/// <summary>
		/// Starts the transition leaving the option to *NOT*
		/// add the transition to the GlobalTransitionRunner.
		/// This allows a transitions to start and update/control child transitions.
		/// </summary>
		/// <param name='time'>
		/// Time.
		/// </param>
		/// <param name='andRun'>
		/// If TRUE, will run this transition on the GlobalTransitionRunner.
		/// If FALSE, will start the transition, but NOT run it,
		/// meaning someone other than the GlobalTransitionRunner
		/// will be responsible for updating this Transition to completion.
		/// </param>
		void StartTransition(float time, bool andRun);
		
		void UpdateTransition(float time, float deltaTime);
		
		void Complete();
		
		void CompleteEarly();

		/// <summary>
		/// TRUE if the transition was ever started
		/// </summary>
		bool didTransitionStart { get; } 

		/// <summary>
		/// TRUE if the transition reached completion. 
		/// </summary>
		bool isTransitionComplete { get; } 

		/// <summary>
		/// TRUE if the transition is running. False if it is finished, cancelled, was never started etc.
		/// </summary>
		bool isTransitionRunning { get; } 
		
		Transition WithCompletedAction(Action<Transition> a);
		
		Transition WithName(string name); 
		
		T WithName<T>(string name) where T : class, Transition;
		
	}
	
}


