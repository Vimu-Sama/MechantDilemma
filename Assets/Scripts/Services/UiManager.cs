using UnityEngine;
using TMPro;
using Events;


namespace Player.UI
{
    public class UiManager : GenericSingleton<UiManager>
    {
        [SerializeField] private TextMeshProUGUI inventoryText;
        private int currPackageCount = 0;
        private string inventoryAdditionalText; 

        private void Start()
        {
            currPackageCount = 0;
            inventoryAdditionalText = "Inventory Count: ";
            inventoryText.text = inventoryAdditionalText + 0;
            EventService.Instance.ObjectPickedUp += IncreamentPackageCounter;
            EventService.Instance.ObjectDropped += DecreamentPackageCounter;
        }


        private void IncreamentPackageCounter(GameObject temp)
        {
            currPackageCount++;
            UpdateInventoryValue();
        }

        private void DecreamentPackageCounter()
        {
            currPackageCount --;
            UpdateInventoryValue();
        }

        private void UpdateInventoryValue()
        {
            inventoryText.text = inventoryAdditionalText + currPackageCount.ToString();
        }
    }
}