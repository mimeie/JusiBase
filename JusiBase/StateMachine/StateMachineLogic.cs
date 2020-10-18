using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class StateMachineLogic
    {
        private static readonly object SyncLock = new object();
        public readonly List<StatesTransition> _transitions;

        public State CurrentState { get; set; }

        /// <summary>
        /// Gets a value indicating whether [first contactiong done].
        /// </summary>
        public bool FirstContactiongDone { get; private set; }

        public StateMachineLogic()
        {
            _transitions = new List<StatesTransition>();
        }

        public void ExecuteAction(Signal signal)
        {
            lock (SyncLock)
            {
                foreach (var transition in _transitions)
                {
                    if (transition.GetHashCode() == (CurrentState.ToString().GetHashCode() ^ signal.ToString().GetHashCode()))
                    {
                        CurrentState = transition.TargetState;
                        if (transition.TransitionDelegateMethod != null)
                        {
                            transition.TransitionDelegateMethod();
                        }

                        Console.WriteLine(String.Format("ChangeOfState - Signal: {0}, StartState: {1}, TargetState {2}.", transition.Signal, transition.StartState, transition.TargetState));
                        return;
                    }
                }

                Console.WriteLine(String.Format("WrongTransition - Signal: {0}, CurrentState: {1}.", signal, CurrentState));
            }
        }
    }
}
