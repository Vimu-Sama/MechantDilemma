using UnityEngine;
using Player.UI;
using Collectible;
using Events;

namespace Player
{
    public class PlayerController
    {
        PlayerView playerView;
        PlayerModel playerModel;
        private int packageCount = 0;

        public PlayerController(PlayerView _playerView, PlayerModel _playerModel, Camera cam)
        {
            this.playerView = playerView = GameObject.Instantiate<PlayerView>(_playerView);
            this.playerModel = _playerModel;
            this.playerView.SetPlayerController(this);
            this.playerModel.SetPlayerController(this);
            cam.transform.SetParent(this.playerView.transform, false);
            EventService.Instance.ObjectPickedUp += IncreamentPackageCounter;
            EventService.Instance.ObjectDropped += DecreamentPackageCounter;
        }


        private void IncreamentPackageCounter(GameObject collectibleGameObject)
        {
            if (packageCount >= playerModel.PackageCarryLimit())
                return;
            packageCount++;
            UiService.Instance.UpdateInventoryValue(packageCount);
            playerView.DestroyGameObject(collectibleGameObject);
        }

        private void DecreamentPackageCounter()
        {
            packageCount--;
            UiService.Instance.UpdateInventoryValue(packageCount);
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

        public void DropPackage(Collectibles collectibles)
        {
            if (packageCount > 0)
            {
                GameObject.Instantiate(collectibles, playerView.transform.position, Quaternion.identity);
                EventService.Instance.ObjectDropped();
            }
            else
            {
                Debug.Log("Nothing to throw!!");
            }
        }


    }
}