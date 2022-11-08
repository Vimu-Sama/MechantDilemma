using UnityEngine;
using Events;

namespace Player
{
    public class JumpTriggerCheck: MonoBehaviour
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