using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameManagement/GameState/FadeState")]
public class FadeState : GameState
{
    [SerializeField] private BoolVariable fadeOutFinished;
    [SerializeField] private GameStateEvent startEvent;
    public override void Tick()
    {
        if (fadeOutFinished.Value)
        {
            startEvent.Raise();
            DefaultNextState.Raise();
        }
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }
}
