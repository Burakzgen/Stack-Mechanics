using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager Instance { get; private set; }

    [SerializeField] private float distanceBeetweenObjects;
    [SerializeField] private float speed;
    [SerializeField] private Transform parentObject;
    [SerializeField] private Transform prevPickObject;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
    private void Start()
    {
        distanceBeetweenObjects = prevPickObject.localScale.y;
    }
    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 pos = new Vector3(horizontal, 0, vertical);

        transform.Translate(pos.x * speed * Time.deltaTime, 0, pos.z * speed * Time.deltaTime);
    }
    public void PickUp(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
            pickedObject.tag = tag;
        pickedObject.transform.parent = parentObject;

        Vector3 pos = prevPickObject.localPosition;
        pos.y += downOrUp ? distanceBeetweenObjects : -distanceBeetweenObjects;
        pickedObject.transform.localPosition = pos;

        prevPickObject = pickedObject.transform;
    }
    public void Stairs(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
            pickedObject.tag = tag;
        pickedObject.transform.parent = parentObject;

        Vector3 pos = prevPickObject.localPosition;
        pos.y += downOrUp ? distanceBeetweenObjects : -distanceBeetweenObjects;
        pos.z += pickedObject.transform.localScale.z;
        pickedObject.transform.localPosition = pos;

        prevPickObject = pickedObject.transform;
    }
}
