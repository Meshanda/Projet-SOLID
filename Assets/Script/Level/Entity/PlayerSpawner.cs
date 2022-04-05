using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : OrdonedMonoBehaviour
{
    public GameObject PlayerPrefab;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public Vector2IntListVariable SpawnPositions;
    public PlayerPositions PlayerPositions;
    public PlayerNames PlayerNames;
    public GameEvent AddedNewPlayer;
    public bool Loaded = false;

    [SerializeField] private TwitchAcountCredentials twitchAcountCredentials;
    [SerializeField] private RoundCommand addAction;
    [SerializeField] private List<KeyCode> _keyPressed;
    [SerializeField] private List<PlayerCommand> _commands;

    public override void DoAwake()
    {
        for (int i = 0; i < PlayerNames.Names.Count; i++)
        {
            SpawnPlayer(i);
        }
    }
    public override void DoUpdate()
    {

    }

    private void SpawnPlayer(int Index)
    {
        if (!SpawnPositions) { return; }
        if (!Tiles) { return; }
        if (!TileEntities) { return; }
        if (!PlayerPrefab) { return; }
        bool CanSpawn = false;
        Vector2Int SpawnPosition = Vector2Int.zero;
        for (int i = 0; i < SpawnPositions.Value.Count; i++)
        {
            SpawnPosition = Loaded ? PlayerPositions.GetPosition(i) : SpawnPositions.Value[i];

            if (Tiles.Exists(SpawnPosition) && TileEntities.TilePlayer(SpawnPosition) == -1)
            {
                CanSpawn = true;
                break;
            }
        }

        if (!CanSpawn) { return; }
        GameObject Player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);
        Player.name = PlayerNames.Names[Index];

        //add script to the local player who has the acount twitch name
        if (Player.name == twitchAcountCredentials.TwitchAcountName)
        {
            var localPlayerMove = Player.AddComponent<LocalPlayerMove>();
            localPlayerMove._roundCommand = addAction;
            localPlayerMove._keyPressed = _keyPressed;
            localPlayerMove._commands = _commands;
        }

        AddedNewPlayer.Raise();

        PlayerMove PlayerMove = Player.GetComponent<PlayerMove>();
        if (!PlayerMove) { return; }
        PlayerMove.MoveTo(SpawnPosition);
    }
}
