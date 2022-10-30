using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        PlayerController playerController;
        float playerSpeed;
        float jumpForce;
        int packageCarryLimit;
        public PlayerModel(float _playerSpeed, float _playerJumpForce, int _packageCarryLimit)
        {
            playerSpeed = _playerSpeed;
            jumpForce = _playerJumpForce;
            packageCarryLimit = _packageCarryLimit;
        }

        public float PackageCarryLimit()
        {
            return packageCarryLimit;
        }

        public float PlayerSpeed()
        {
            return playerSpeed;
        }

        public float PlayerJumpForce()
        {
            return jumpForce;
        }
        public void SetPlayerController(PlayerController temp)
        {
            this.playerController = temp;
        }

    }

}