using UnityEngine;

public class CollectedTrigger : MonoBehaviour
{
    public void DestroyCollectedItem()
    {
        Destroy(gameObject);
    }
}