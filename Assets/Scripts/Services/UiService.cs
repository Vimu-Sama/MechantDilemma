using UnityEngine;
using TMPro;
using Events;


namespace Player.UI
{
    public class UiService : GenericSingleton<UiService>
    {
        [SerializeField] private TextMeshProUGUI inventoryText;
        private int inventoryItemCount = 0;

        private void Start()
        {
            inventoryItemCount = 0; 
            EventService.Instance.ObjectPickedUp += IncreamentInvertoryCounter;
            EventService.Instance.ObjectDropped += DecreamentInventoryCounter;
        }

        public int GetInventoryCount()
        {
            return inventoryItemCount;
        }

        private void IncreamentInvertoryCounter()
        {
            inventoryItemCount++;
            inventoryText.text = "Inventory Count: "+ inventoryItemCount.ToString();
        }

        private void DecreamentInventoryCounter()
        {
            inventoryItemCount--;
            inventoryText.text= "Inventory Count: "+ inventoryItemCount.ToString();
        }


    }
}