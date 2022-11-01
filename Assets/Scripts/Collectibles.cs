using System.Collections;
using UnityEngine;
using Player;
using Events;

namespace Collectible
{
    public class Collectibles : MonoBehaviour
    {
        [SerializeField] private float timeBeforeTriggerActivate= 0f;
        WaitForSeconds waitForSeconds;

        private void Start()
        {
            waitForSeconds = new WaitForSeconds(timeBeforeTriggerActivate);
            this.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(ActivateSoon());
        }

        IEnumerator ActivateSoon()
        {
            yield return waitForSeconds;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerView>() != null)
            {
                EventService.Instance.ObjectPickedUp(this.gameObject);
            }
            //else if(collision.gameObject.GetComponent<objectSubmit>()!-=null)
            //{
            //    EventService.Instance.
            //}
        }
    }
}