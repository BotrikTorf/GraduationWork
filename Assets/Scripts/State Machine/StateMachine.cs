public class StateMachine
{
    public States CurrentStates { get; private set; }

    public void Initialize(States startingStates)
    {
        CurrentStates = startingStates;
        CurrentStates.StartState();
    }

    public void ChangesSate(States state)
    {
        CurrentStates.ExitState();
        CurrentStates = state;
        CurrentStates.StartState();
    }
}
