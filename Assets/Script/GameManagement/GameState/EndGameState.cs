using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "GameManagement/GameState/EndGameState")]
public class EndGameState : GameState
{
    [SerializeField] private GameStateEvent endScene;
    
    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
        endScene.Raise();
    }
}
