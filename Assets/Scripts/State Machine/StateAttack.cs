using UnityEngine;
public class StateAttack: States
{
    private float _timeAttack = 2.1f;
    private bool _isAtack;
    public StateAttack(UnitGame unitGame)
    {
        AnimatorState = unitGame.Animator;
        UnitGame = unitGame;
    }
    public override void StartState()
    {
        AnimatorState.enabled = true;
        _timeAttack = 2.1f;
    }

    public override void ExitState()
    {
        AnimatorState.enabled = false;
        _timeAttack = 2.1f;
    }

    public override void LogicUpdate()
    {
        if (_timeAttack >= 2f)
        {
            AnimatorState.Play($"AnimationUnit{UnitGame.Name}Atack");
            _isAtack = true;
            _timeAttack = 0;
        }

        if (_isAtack && _timeAttack >= 0.3f)
        {
            UnitGame.TakeShot(UnitGame.Target);
            _isAtack = false;
        }

        _timeAttack += Time.deltaTime;
    }
}
