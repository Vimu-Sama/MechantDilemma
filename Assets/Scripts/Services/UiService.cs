using UnityEngine;
using TMPro;
using Events;


namespace Player.UI
{
    public class UiService : GenericSingleton<UiService>
    {
        [SerializeField] private TextMeshProUGUI inventoryText;

        private void Start()
        {
            inventoryText.text = "Inventory Count: " + 0;
        }

        public void UpdateInventoryValue(int count)
        {
            inventoryText.text = "Inventory Count: " + count.ToString();
        }


    }
}