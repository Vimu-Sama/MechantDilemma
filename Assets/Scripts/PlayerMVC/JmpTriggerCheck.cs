using UnityEngine;
using Events;

namespace Player
{
    public class JmpTriggerCheck : GenericSingleton<JmpTriggerCheck>
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.GetComponent<PlayerView>()==null)
            {
                EventService.Instance.EnableJump?.Invoke();
            }
        }
    }
}