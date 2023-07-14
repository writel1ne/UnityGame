using UnityEngine;

public class CollectablePickUp : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.GetComponent<CollectedTrigger>()?.Invoke(nameof(CollectedTrigger.DestroyCollectedItem), 0.1f);
	}
}
