using UnityEngine;
using Player.UI;
using Collectible;
using Events;

namespace Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;
        private int packageCount = 0;
        private Collectibles droppedPackage;

        public PlayerController(PlayerView _playerView, PlayerModel _playerModel, Camera cam)
        {
            this.playerView = playerView = GameObject.Instantiate<PlayerView>(_playerView);
            this.playerModel = _playerModel;
            this.playerView.SetPlayerController(this);
            this.playerModel.SetPlayerController(this);
            cam.transform.SetParent(this.playerView.transform, true);
            cam.transform.localPosition = new Vector3(0f, 0f, -10f);
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
                Vector2 packageTransform= new Vector2(playerView.transform.position.x, playerView.transform.position.y);
                droppedPackage=  GameObject.Instantiate(collectibles,packageTransform, Quaternion.identity);
                droppedPackage.gameObject.GetComponent<Rigidbody2D>().AddForce
                    (new Vector2(0f,playerModel.PackageThrowForce()), ForceMode2D.Impulse);
                EventService.Instance.ObjectDropped();
            }
            else
            {
                Debug.Log("Nothing to throw!!");
            }
        }


    }
}