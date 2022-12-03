using UnityEngine;
using Events;

namespace LevelManager
{
    public class SubLevelManager : GenericSingleton<SubLevelManager>
    {
        [SerializeField] private GameObject[] subLevels;
        int currInd = 0;

        private void Start()
        {
            EventService.Instance.PackageSubmitted += ActivateNextSubLevel;
            for (int i = 1; i < subLevels.Length; i++)
                subLevels[i].SetActive(false);
            subLevels[0].SetActive(true);
        }
        private void ActivateNextSubLevel()
        {
            if ((currInd + 1) == subLevels.Length)
                return;
            subLevels[currInd].SetActive(false);
            currInd++;
            subLevels[currInd].SetActive(true);
        }
    }
}