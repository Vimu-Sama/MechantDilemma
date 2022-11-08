using System.Collections;
using UnityEngine;
using Player;
using Events;

namespace Collectible
{
    public class Collectibles : MonoBehaviour
    {
        [SerializeField] private float timeBeforeTriggerActivate= 0.5f;
        BoxCollider2D boxCollider2D;
        WaitForSeconds waitForSeconds;

        private void Start()
        {
            waitForSeconds = new WaitForSeconds(timeBeforeTriggerActivate);
            boxCollider2D= GetComponent<BoxCollider2D>() ;
            boxCollider2D.enabled= false;
            StartCoroutine(ActivateSoon());
        }

        IEnumerator ActivateSoon()
        {
            yield return waitForSeconds;
            boxCollider2D.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerView>() != null)
            {
                EventService.Instance.ObjectPickedUp(gameObject);
            }
        }
    }
}