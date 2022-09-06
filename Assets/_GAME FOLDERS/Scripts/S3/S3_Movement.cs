using UnityEngine;

public class S3_Movement : MonoBehaviour
{
    [SerializeField] private float swipeSpeed;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Vector2 clampValues = new Vector2(-2, 2);

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
    }
    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.transform.localPosition.z;

        Ray ray = _camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 250))
        {
            GameObject firstObject = ATMRush.Instance.cubes[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstObject.transform.localPosition.y;
            hitVec.z = firstObject.transform.localPosition.z;

            firstObject.transform.localPosition = Vector3.MoveTowards
                (
                    firstObject.transform.localPosition, //Current
                    hitVec, //Target
                    Time.deltaTime * swipeSpeed // Distance Delta
                );
        }
    }

}
