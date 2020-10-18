using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class StatesTransition
    {
        /// <summary>
        /// The transition method
        /// </summary>
        public delegate void TransitionDelegate();

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesTransition"/> class.
        /// </summary>
        /// <param name="startState">The start state.</param>
        /// <param name="signal">The signal.</param>
        /// <param name="transitionDelegate">The transition delegate.</param>
        /// <param name="targetState">State of the target.</param>
        public StatesTransition(State startState, Signal signal, TransitionDelegate transitionDelegate, State targetState)
        {
            StartState = startState;
            Signal = signal;
            TransitionDelegateMethod = transitionDelegate;
            TargetState = targetState;
        }

        /// <summary>
        /// Gets the start state.
        /// </summary>
        public State StartState { get; private set; }

        /// <summary>
        /// Gets the signal.
        /// </summary>
        public Signal Signal { get; private set; }

        /// <summary>
        /// Gets the transition delegate method.
        /// </summary>
        public TransitionDelegate TransitionDelegateMethod { get; private set; }

        /// <summary>
        /// Gets the state of the target.
        /// </summary>
        public State TargetState { get; private set; }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return StartState.ToString().GetHashCode() ^ Signal.ToString().GetHashCode();
        }
    }
}
