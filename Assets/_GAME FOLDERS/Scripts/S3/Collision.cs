using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (!ATMRush.Instance.cubes.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.GetComponent<Rigidbody>().isKinematic = true;

                ATMRush.Instance.StackCube(other.gameObject, ATMRush.Instance.cubes.Count - 1);
            }
        }
    }
}
