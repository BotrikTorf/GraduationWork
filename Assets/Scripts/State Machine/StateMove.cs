public class StateMove : States
{
    public StateMove(UnitGame unitGame)
    {
        AnimatorState = unitGame.Animator;
        UnitGame = unitGame;
    }
    public override void StartState()
    {
        AnimatorState.enabled = true;
        //AnimatorState.speed = UnitGame.SpeedPlayer;
        AnimatorState.Play($"AnimationUnit{UnitGame.Name}Run");
    }

    public override void ExitState() => AnimatorState.enabled = false;

    public override void LogicUpdate() => UnitGame.Move();

}
