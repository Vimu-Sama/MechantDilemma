using UnityEngine;
using System;


namespace Events
{
    public class EventService : GenericSingleton<EventService>
    {
        public Action EnableJump;
        public Action ObjectPickedUp;
        public Action ObjectDropped;
    }
}