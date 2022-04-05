using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoundCommandHistory : MySingleton<RoundCommandHistory>
{
    private List<TurnCommandsHistory> _allTurns = new List<TurnCommandsHistory>(3);
    [SerializeField] private FloatVariable _timeBtwTurns;

    [SerializeField] public FloatVariable PlayerDelay;

    protected override bool DoDestroyOnLoad => true;
    //temporary
    public BoolVariable endRound;
    
    public bool endTurn;

    private void Start()
    {
        Init();
    }

    public void ExecuteRound()
    {
        endRound.Value = false;
        UpdateRoundDelay();
        StartCoroutine(ExecuteRoundTimed());
    }

    //TODO Check if in the right state
    public void AddCommand(string playerPseudo, PlayerCommand playerCommand)
    {
        foreach (var turn in _allTurns)
        {
            var response = turn.AddCommand(playerPseudo, playerCommand);
            if (response)
                return;
        }
    }

    private IEnumerator ExecuteRoundTimed()
    {
        foreach (var turn in _allTurns)
        {
            endTurn = false;
            StartCoroutine(turn.ExecuteCommands(PlayerDelay.Value));
            yield return new WaitUntil(() => endTurn);
        }
        ClearTurnsCommands();
        endRound.Value = true;
        yield return null;
    }

    private void UpdateRoundDelay()
    {
        _timeBtwTurns.Value = 0;
        foreach (var turn in _allTurns)
        {
            _timeBtwTurns.Value += turn.NumberOfActions() * PlayerDelay.Value;
        }
    }

    private void ClearTurnsCommands()
    {
        foreach (var turn in _allTurns)
        {
            turn.ClearCommands();
        }
    }

    private void Init()
    {
        for (int i = 0; i < 3; i++)
        {
            _allTurns.Add(new TurnCommandsHistory());
        }
    }
}
