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
            EventService.Instance.PlayerDied += PlayerDied;
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
                playerController.DropPackage();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 8)
                EventService.Instance.PlayerDied?.Invoke(); 
        }

        public void SetPlayerController(PlayerController _temp)
        {
            playerController = _temp;
        }

        public void PlayerDied()
        {
            this.enabled = false;
        }

    }
}