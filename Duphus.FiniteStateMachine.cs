using System;
using System.Collections.Generic;
using System.Linq;

namespace Duphus.FiniteStateMachine
{
    public struct State
    {
        public Enum value;
        public Func<bool> callback;
        public string name;

        public State(Enum value, Func<bool> callback, string name)
        {
            this.value = value;
            this.callback = callback;
            this.name = name;
        }

        public static bool operator == (State a, State b)
        {
            return a.name == b.name || a.value == b.value;
        }

        public static bool operator != (State a, State b)
        {
            return a.name != b.name || a.value != b.value;
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == GetType()) ? (name == ((State)(obj)).name) ? true : false : false;
        }
    }

    public class FiniteStateMachine
    {
        private Enum currentState;
        private List<State> states;
        private int current;

        public FiniteStateMachine(Enum currentState, params State[] states)
        {
            this.currentState = currentState;
            this.states = new List<State>(states.AsEnumerable());
            current = (int)GetStateIndexWithEnum(currentState);
        }

        public void AddState(State state)
        {
            states.Add(state);
        }

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

        public State GetState()
        {
            return states[current];
        }

        public void SetState(Enum e)
        {
            current = (int)GetStateIndexWithEnum(e);
        }

        public Enum Update()
        {
            return states[current].callback() ? null : states[current].value;
        }
    }
}
