using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private PlayerController playerController;
        private float playerSpeed;
        private float jumpForce;
        private float packageThrowForce;
        private int packageCarryLimit;
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
        public void SetPlayerController(PlayerController _temp)
        {
            playerController = _temp;
        }

    }

}