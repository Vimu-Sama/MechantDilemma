using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerView : GenericSingleton<PlayerView>
    {
        PlayerController playerController;
        float horizontalSpeed, verticalSpeed;

        private void Start()
        {
            horizontalSpeed = 0f;
        }

        private void Update()
        {
            horizontalSpeed = Input.GetAxisRaw("Horizontal");
            Debug.Log(horizontalSpeed);
            Debug.Log(verticalSpeed) ;
            playerController.MovePlayer(horizontalSpeed * Time.deltaTime);
        }

        public void SetPlayerController(PlayerController temp)
        {
            playerController = temp;
        }

    }
}