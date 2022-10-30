using UnityEngine;

namespace Player
{
    public class PlayerService : GenericSingleton<PlayerService>
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] private float playerSpeed;
        [SerializeField] private float jumpForce;
//        [SerializeField] private 
        private PlayerController playerController;
        private PlayerModel playerModel;

        private void Awake()
        {
            playerModel = new PlayerModel(playerSpeed, jumpForce);
            playerController = new PlayerController(playerView, playerModel);
        }

    }
}
