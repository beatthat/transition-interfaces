using UnityEngine;
using System.Collections;

namespace BeatThat.Anim
{
	/// <summary>
	/// Service-Provider implementation that drives the singleton TransitionRunner
	/// </summary>
	public interface TransitionRunnerImpl
	{
		event System.Action<TransitionRunnerImpl> Destroyed;

		void AddTransition(Transition t);
		
	}
}
