using UnityEngine;
using System;
using Collectible;


namespace Events
{
    public class EventService : GenericSingleton<EventService>
    {
        public Action EnableJump;
        public Action<Collectibles> PackagePickedUp;
        public Action PackageDropped;
        public Action PackageSubmitted;
        public Action PackageDestroyed ;
        public Action PlayerDied;
        public Action LevelCompleted;
    }
}