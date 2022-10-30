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
        private bool canJmp; 


        private void Start()
        {
            horizontalSpeed = 0f;
            canJmp = false;
            EventService.Instance.EnableJump += SetJumpTrue;
        }
        

        private void SetJumpTrue()
        {
            canJmp = true;
        }


        private void Update()
        {
            horizontalSpeed = Input.GetAxisRaw("Horizontal");
            playerController.MovePlayer(horizontalSpeed * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerController.AddPlayerJmp(canJmp);
                canJmp = false;
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                playerController.DropPackage(collectibleSpawn);
            }
        }

        public void SetPlayerController(PlayerController temp)
        {
            playerController = temp;
        }

        public void DestroyGameObject(GameObject temp)
        {
            Destroy(temp);
        }


    }
}