using UnityEngine;

public class StackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick"))
        {
            StackManager.Instance.PickUp(other.gameObject, true, "Untagged");
            //StackManager.Instance.Stairs(other.gameObject, true, "Untagged");
        }
    }
}
