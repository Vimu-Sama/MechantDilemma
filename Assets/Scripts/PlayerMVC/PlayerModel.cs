using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        PlayerController playerController;
        float playerSpeed;
        float jumpForce;
        public PlayerModel(float _playerSpeed, float _playerJumpForce)
        {
            playerSpeed = _playerSpeed;
            jumpForce = _playerJumpForce;
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