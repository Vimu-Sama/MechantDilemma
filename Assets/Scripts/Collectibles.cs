using System.Collections;
using UnityEngine;
using Player;
using Events;
using UnityEngine.UI;

namespace Collectible
{
    public class Collectibles : MonoBehaviour
    {
        [SerializeField] private float timeBeforeTriggerActivate = 0.5f;
        [SerializeField] private float timeBeforeCollectibleDestroy = 2f;
        [SerializeField] private ParticleSystem packageParticleEffect;
        private BoxCollider2D boxCollider2D;
        private SpriteRenderer spriteRenderer;
        private WaitForSeconds waitForSeconds;
        private WaitForSeconds waitSecondToDestroyCollectible;
        private EventService eventService = null;
        private GameObject collisonGameObject;

        private void Awake()
        {
            waitForSeconds = new WaitForSeconds(timeBeforeTriggerActivate);
            waitSecondToDestroyCollectible = new WaitForSeconds(timeBeforeCollectibleDestroy);
            boxCollider2D = GetComponent<BoxCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (!eventService)
                eventService = EventService.Instance;
            boxCollider2D.enabled = false;
            StartCoroutine(ActivateSoon());
        }

        IEnumerator ActivateSoon()
        {
            yield return waitForSeconds;
            boxCollider2D.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collisonGameObject = collision.gameObject;
            if (collisonGameObject.GetComponent<PlayerView>() != null)
            {
                eventService.PackagePickedUp?.Invoke(this);
            }
            else if (collisonGameObject.layer == 7)
            {
                this.transform.SetParent(null);
                eventService.PackageSubmitted?.Invoke();
                DisableCollectible();
            }
            else if(collisonGameObject.layer==8)
            {
                eventService.PackageDestroyed?.Invoke();
            }
        }

        public void DisableCollectible()
        {
            packageParticleEffect.Play();
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            StartCoroutine(DestroyCollectible());
        }

        private IEnumerator DestroyCollectible()
        {
            yield return waitSecondToDestroyCollectible;
            Destroy(gameObject);
        }

    }
}