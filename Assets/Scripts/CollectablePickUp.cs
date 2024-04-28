using UnityEngine;

public class CollectablePickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent(out CollectedTrigger collectedTrigger);
        collectedTrigger.Invoke(nameof(CollectedTrigger.DestroyCollectedItem), 0.1f);
    }
}