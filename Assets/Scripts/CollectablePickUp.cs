using UnityEngine;

public class CollectablePickUp : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.GetComponent<CollectedTrigger>()?.Invoke("DestroyCollectedItem", 0);
	}
}
