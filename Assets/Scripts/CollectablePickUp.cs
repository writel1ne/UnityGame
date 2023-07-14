using UnityEngine;

public class CollectablePickUp : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "CollectableItem")
		{
			Destroy(collision.gameObject);
		}
	}
}
