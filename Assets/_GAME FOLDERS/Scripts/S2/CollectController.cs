using UnityEngine;

public class CollectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick"))
        {
            other.gameObject.transform.position = gameObject.transform.position + Vector3.forward;
            Destroy(gameObject.GetComponent<CollectController>());
            other.gameObject.AddComponent<CollectController>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<PickMovement>();
            other.gameObject.GetComponent<PickMovement>().connectedPick = transform;
            other.gameObject.tag = "Stick";
        }
    }
}
