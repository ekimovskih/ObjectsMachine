using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;
    private float _rotationX = 0;
    private float LRInput;
    private float FBInput;
    public float Mspeed = 1f;
    public float yvalue = 1f;
    void Start()
    {
        Cursor.visible = false;
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }
    void Update()
    {
        CamRotation();
        CamMovement();

    }

    void CamMovement()
    {
        LRInput = Input.GetAxis("Horizontal");
        FBInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(LRInput, 0, FBInput) * Mspeed*Time.deltaTime);
        transform.position = new Vector3(transform.position.x, yvalue, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), yvalue, Mathf.Clamp(transform.position.z, -3f, 3f));
    }

    void CamRotation()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
