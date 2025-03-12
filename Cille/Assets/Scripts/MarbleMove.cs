using UnityEngine;

public class MarbleMove : MonoBehaviour
{
    private Rigidbody rb;

    public Transform cilleLike;
    public Transform arrow;
    public Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(0, 0, 20), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, 0, cam.transform.position.y - cilleLike.transform.position.y));

        Vector3 direction = (mouseWorldPos - cilleLike.position).normalized;

        arrow.position = cilleLike.position - direction * 2f;
        arrow.forward = -direction;
    }
}
