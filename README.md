# FiniteStateMachine
A re-usable Finite State Machine for C#

# Usage
Duphus' Finite State Machine was designed for MonoGame however should (in theory) work with the Unity Engine.
Simply drag this anywhere into a Visual Studio Project.
The following will create and setup a basic FiniteStateMachine:

```cs
using Dupus.FiniteStateMachine;

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
    
    public void StateOne()
    {
      Console.WriteLine(fsm.GetState().name);
      fsm.SetState(EnumState.StateThree);
    }
    
    public void StateTwo()
    {
      Console.WriteLine(fsm.GetState().name);
      fsm.SetState(EnumState.StateOne);
    }
    
    public void StateThree()
    {
      Console.WriteLine(fsm.GetState().name);
      fsm.SetState(EnumState.StateTwo);
    }
  }
}
```
