using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Events;
using Collectible;


namespace Player.UI
{
    public class UiManager : GenericSingleton<UiManager>
    {
        [SerializeField] private TextMeshProUGUI inventoryText;
        [SerializeField] private TextMeshProUGUI packageSubmitted;
        [SerializeField] private TextMeshProUGUI gameStateText;
        [SerializeField] private GameObject GameOverCanvasPanel;
        private int maxPackageCount;
        private int currPackageCount = 0;


        private void Start()
        {
            currPackageCount = 0;
            inventoryText.text = "0";
            EventService.Instance.PackagePickedUp += IncreamentPackageCounter;
            EventService.Instance.PackageDropped += DecreamentPackageCounter;
            EventService.Instance.PackageDestroyed += DestroyPackage;
            EventService.Instance.PlayerDied += PlayerDied;
            EventService.Instance.LevelCompleted += LevelOver;
            maxPackageCount = PlayerService.Instance.PackageCarryLimit ;
        }


        private void IncreamentPackageCounter(Collectibles temp)
        {
            if (currPackageCount >= maxPackageCount)
                return;
            currPackageCount++;
            UpdateInventoryValue();
        }

        private void DecreamentPackageCounter()
        {
            currPackageCount--;
            UpdateInventoryValue();
        }

        private void UpdateInventoryValue()
        {
            inventoryText.text = currPackageCount.ToString();
        }

        private void DestroyPackage()
        {
            SetGameOverUIActive("Package Destroyed!!");
        }

        private void PlayerDied()
        {
            SetGameOverUIActive("Player Died!!");
        }

        private void LevelOver()
        {
            SetGameOverUIActive("Level Finished");
        }

        private void SetGameOverUIActive(string s)
        {
            GameOverCanvasPanel.SetActive(true);
            gameStateText.text = s;
            gameStateText.enabled = true;
        }
    }
}