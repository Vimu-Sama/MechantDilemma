using UnityEngine;
using System;


namespace Events
{
    public class EventService : GenericSingleton<EventService>
    {
        public Action EnableJump;
        public Action<GameObject> ObjectPickedUp;
        public Action ObjectDropped;
    }
}