using System;
using System.Collections.Generic;
using System.Linq;

namespace Duphus.FSM
{
    //The State Struct is a basic struct that associates a name and callback with a value from an Enumeration.
    public struct State
    {
        ///<summary>
        ///The enumerated value that this should all be tied to.
        ///</summary>
        public Enum value;
        ///<summary>
        //The callback function for this state.
        //(really this is just what is called when this state is currently active and the update function is called)
        ///</summary>
        public Func<bool> callback;
        ///<summary>
        ///The name of the state.
        ///This is never used (by this anything in this file) and is purely for the end-user
        ///</summary>
        public string name;

        ///<summary>
        ///A simple pass-through constructor for one-line initializations.
        ///</summary>
        ///<param name="value">The enumerated value that this should all be tied to.</param>
        ///<param name="callback">The callback function for this state.</param>
        ///<param name="name">The name of this state.</param>
        public State(Enum value, Func<bool> callback, string name)
        {
            this.value = value;
            this.callback = callback;
            this.name = name;
        }
        
        //A basic method of comparing two states.
        public static bool operator == (State a, State b)
        {
            //Limits the equality to the name and the (enumerated) value (Checking the callback would be expensive)
            return a.name == b.name || a.value == b.value;
        }

        //A basic method of comparing two states
        public static bool operator != (State a, State b)
        {
            //Limits the inequality to the name and the (enumerated) value (Checking the callback would be expensive)
            return a.name != b.name || a.value != b.value;
        }

        //This is overrided to please the compiler
        public override bool Equals(object obj)
        {
            return (obj.GetType() == GetType()) ? (name == ((State)(obj)).name) ? true : false : false;
        }
    }

    public class FiniteStateMachine
    {
        ///<summary>
        ///A list of the states.
        ///Currently using a generic list. Will (eventually) replace this with a custom list.
        ///</summary>
        private List<State> states;
        ///<summary>
        ///The currently active state (in the list).
        ///</summary>
        private int current;

        ///<summary>
        ///Creates a new FiniteStateMachine.
        ///</summary>
        ///<param name="currentState">The state to start at</param>
        ///<param name="states">An array of State structs that define how the state machine works (can be multiple parameters)</param>
        public FiniteStateMachine(Enum currentState, params State[] states)
        {
            this.states = new List<State>(states.AsEnumerable());
            current = (int)GetStateIndexWithEnum(currentState);
        }

        ///<summary>
        ///Adds a new state into the mix.
        ///</summary>
        ///<param name="state">The state you want to add</param>
        public void AddState(State state)
        {
            states.Add(state);
        }
        
        ///<summary>
        ///Iterates through the states, and gets the index of the state with the matching (enumerated) value. 
        ///</summary>
        ///<param name="e">The (enumerated) value to check against.</param>
        private int? GetStateIndexWithEnum(Enum e)
        {
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].value == e)
                {
                    return i;
                }
            }
            return null;
        }

        ///<summary>
        ///Get the state that is currently active.
        ///</summary>
        ///<returns>The current state</returns>
        public State GetState()
        {
            return states[current];
        }

        ///<summary>
        ///Sets the state with the (enumerated) value provided
        ///</summary>
        ///<param name="e">The (enumerated)v value provided</param>
        public void SetState(Enum e)
        {
            current = (int)GetStateIndexWithEnum(e);
        }
        
        ///<summary>
        ///Call the current state's callback.
        ///</summary>
        ///<returns>The current state's (enumerated) value</returns>
        public Enum Update()
        {
            return states[current].callback() ? null : states[current].value;
        }
    }
}
