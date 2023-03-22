using UnityEngine;

public abstract class States 
{
    private protected Animator AnimatorState;
    private protected UnitGame UnitGame;
    public abstract void StartState();

    public abstract void ExitState();

    public abstract void LogicUpdate();
}
