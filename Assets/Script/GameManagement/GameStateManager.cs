using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private GameState _gameState;
    
    //default state
    [SerializeField] private GameStateEvent FirstStateLoaded;

    [SerializeField] private GameStateEnumVariable currentStateName;



    // Start is called before the first frame update
    void Start()
    {
        FirstStateLoaded.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        _gameState.Tick();
    }
    
    public void ChangeState(GameState newState)
    {
        if (_gameState != null)
        {
            _gameState.OnStateExit();
        }

        _gameState = newState;

        currentStateName.Value = _gameState.StatesName;
        _gameState.OnStateEnter();
    }
}
