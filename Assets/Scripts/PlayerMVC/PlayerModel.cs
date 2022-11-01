using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        PlayerController playerController;
        float playerSpeed;
        float jumpForce;
        float packageThrowForce;
        int packageCarryLimit;
        public PlayerModel(float _packageThrowForce, float _playerSpeed, float _playerJumpForce, int _packageCarryLimit)
        {
            packageThrowForce = _packageThrowForce;
            playerSpeed = _playerSpeed;
            jumpForce = _playerJumpForce;
            packageCarryLimit = _packageCarryLimit;
        }

        public float PackageThrowForce()
        {
            return packageThrowForce;
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