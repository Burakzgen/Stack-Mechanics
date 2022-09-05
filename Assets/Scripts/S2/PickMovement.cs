using UnityEngine;

public class PickMovement : MonoBehaviour
{
    public Transform connectedPick;
    [SerializeField] private float pickSpeed = 20;
    private void FixedUpdate()
    {
        transform.position = new Vector3
            (
            Mathf.Lerp(transform.position.x, connectedPick.position.x, Time.fixedDeltaTime * pickSpeed),
            connectedPick.position.y,
            connectedPick.position.z + 1.5f
            );
    }
}
