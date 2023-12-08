using UnityEngine;
using WebXR;

public class Player : MonoBehaviour
{
    public WebXRController controller;
    public GameObject panelKills;
    private void Start()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 100);
    }
    void FixedUpdate()
    {
        Vector3 vector = controller.GetAxis2D(WebXRController.Axis2DTypes.Touchpad);
        transform.position += Vector3.ProjectOnPlane(3f * Time.deltaTime * new Vector3(vector.x, 0, vector.y), Vector3.up);

        if (controller.GetButtonDown(WebXRController.ButtonTypes.Touchpad))
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.up * 200);
            controller.Pulse(5, 1);
        }
    }
}
