using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float movementSpeed;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontal * Time.fixedDeltaTime * horizontalSpeed, 0, movementSpeed*Time.fixedDeltaTime));
    }
}
