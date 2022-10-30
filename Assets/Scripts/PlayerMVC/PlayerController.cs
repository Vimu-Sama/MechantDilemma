using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        PlayerView playerView;
        PlayerModel playerModel;


        public PlayerController(PlayerView _playerView, PlayerModel _playerModel)
        {
            this.playerView = playerView = GameObject.Instantiate<PlayerView>(_playerView);
            this.playerModel = _playerModel;
            this.playerView.SetPlayerController(this);
            this.playerModel.SetPlayerController(this);
        }

        public void MovePlayer(float keyInput)
        {
            if (keyInput != 0)
            {
                playerView.transform.position += new Vector3(playerModel.PlayerSpeed() * keyInput, 0f, 0f);
            }
        }

        public void AddPlayerJmp(bool canJmp)
        {
            if (canJmp)
            {
                playerView.GetComponent<Rigidbody2D>().
                    AddForce(new Vector2(0f, playerModel.PlayerJumpForce()), ForceMode2D.Impulse);
                
            }
        }


    }
}