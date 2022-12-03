using System.Collections.Generic;
using UnityEngine;
using Collectible;
using Events;

namespace Player.PackageManager
{
    public class PackageManager : GenericSingleton<PackageManager>
    {
        [SerializeField] int numOfPackagesInScene= 2;
        Queue<Collectibles> packageQueue = new Queue<Collectibles>();
        Collectibles tempCollectible;

        private void Start()
        {
            EventService.Instance.PackageSubmitted+= PackageSubmitted;
        }

        public void Enqueue(Collectibles poolObjectToBeQueued)
        {
            poolObjectToBeQueued.gameObject.SetActive(false);
            packageQueue.Enqueue(poolObjectToBeQueued);
        }
        public Collectibles Dequeue()
        {
            tempCollectible = packageQueue.Peek();
            packageQueue.Dequeue();
            tempCollectible.gameObject.SetActive(true);
            return tempCollectible;
        }

        private void PackageSubmitted()
        {
            numOfPackagesInScene-- ;
            if (numOfPackagesInScene == 0)
                EventService.Instance.LevelCompleted?.Invoke();
        }

    }

}