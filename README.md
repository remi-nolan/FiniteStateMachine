# FiniteStateMachine
A versatile Finite State Machine for C#

# Usage
Duphus' Finite State Machine was designed for MonoGame however should (in theory) work with the Unity Engine.
Simply drag this anywhere into a Visual Studio Project.
The following will create and setup a basic FiniteStateMachine:

```cs
using Dupus.FSM;

namespace YourNamespace
{
  public enum EnumState
  {
    StateOne,
    StateTwo,
    StateThree
  }

  public class ExampleClass
  {
    private FiniteStateMachine fsm;
    
    public ExampleClass()
    {
      fsm = new FiniteStateMachine(EnumState.StateTwo, new State(EnumState.StateOne, StateOne, "State No. 1"), new State(EnumState.StateTwo, StateTwo, "State No. 2"), new State(EnumState.StateThree, StateThree, "State No. 3"));
    }
    
    public bool StateOne()
    {
      Console.WriteLine(fsm.GetState().name);
      fsm.SetState(EnumState.StateThree);
      return true; //We handled this state callback
    }
    
    public bool StateTwo()
    {
      Console.WriteLine(fsm.GetState().name);
      fsm.SetState(EnumState.StateOne);
      return true; //We handled this state callback
    }
    
    public bool StateThree()
    {
      Console.WriteLine(fsm.GetState().name);
      fsm.SetState(EnumState.StateTwo);
      return true; //We handled this state callback
    }
  }
}
```
