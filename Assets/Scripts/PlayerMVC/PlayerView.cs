using UnityEngine;
using Collectible;
using Events;

namespace Player
{
    public class PlayerView : GenericSingleton<PlayerView>
    {
        [SerializeField] private Collectibles collectibleSpawn;
        private PlayerController playerController;
        float horizontalSpeed;
        private bool canJump; 


        private void Start()
        {
            horizontalSpeed = 0f;
            canJump = false;
            EventService.Instance.EnableJump += SetJumpTrue;
        }
        

        private void SetJumpTrue()
        {
            canJump = true;
        }


        private void Update()
        {
            horizontalSpeed = Input.GetAxisRaw("Horizontal");
            playerController.MovePlayer(horizontalSpeed * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerController.AddPlayerJump(canJump);
                canJump = false;
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                playerController.DropPackage(collectibleSpawn);
            }
        }

        public void SetPlayerController(PlayerController _temp)
        {
            playerController = _temp;
        }

        public void DestroyGameObject(GameObject _temp)
        {
            Destroy(_temp);
        }


    }
}