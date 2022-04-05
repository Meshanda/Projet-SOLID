using UnityEngine;

namespace Script.CommandPattern
{
    [CreateAssetMenu (menuName = "GameCommand/PlayerCommand/Move")]
    public class MovePlayerCommand : PlayerCommand
    {
        public DirectionMove _direction;
        
        [SerializeField] private PlayerNames _playerNames;
        [SerializeField] private PlayerGO _playerGO;
        
        public override void Execute(string playerName)
        {
            if(_playerNames.Contains(playerName))
            {
                PlayerMove player = CatchPlayer(playerName);
                if(player)
                    player.MoveInDirection(VectorDirectionMove.FetchDirection(_direction));
            }
        }

        private PlayerMove CatchPlayer(string playerName)
        {
            int index = _playerNames.GetPlayerIndex(playerName);
            GameObject playerObject = _playerGO.GameObjects[index];
            return playerObject?.GetComponent<PlayerMove>();
        }
    }
}