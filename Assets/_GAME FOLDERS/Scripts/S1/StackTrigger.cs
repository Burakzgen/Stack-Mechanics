using UnityEngine;

public class StackTrigger : MonoBehaviour
{
    [SerializeField] private bool change;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick"))
        {
            if (change)
            {
                StackManager.Instance.PickUp(other.gameObject, true, "Untagged");
            }
            else
                StackManager.Instance.Stairs(other.gameObject, true, "Untagged");
        }
    }
}
