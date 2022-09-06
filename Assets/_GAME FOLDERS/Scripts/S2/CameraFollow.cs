using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, 2 * Time.deltaTime);
    }
}
