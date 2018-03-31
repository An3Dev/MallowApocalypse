using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField] Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Vector3 thrusterForce = Vector3.zero;

    private float rotX;
    private float rotY;
    private Vector3 origRot;

    [SerializeField]
    float rotSpeed = 0.1f;


    [SerializeField]
    public float dir = -1;

    [SerializeField]
    GameObject player;

    private float cameraSmoothness = 10;

    private Rigidbody rb;

    private Touch initTouch = new Touch();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    void FixedUpdate()
    {
        PerformMovement();
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            PerformRotation();
        }
        
        // If on mobile use different touch dynamics
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            foreach(Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    initTouch = touch;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    // swiping action
                    float deltaX = initTouch.position.x - touch.position.x;
                    float deltaY = initTouch.position.y - touch.position.y;
                    rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                    rotY += deltaX * Time.deltaTime * rotSpeed * dir;

                    Mathf.Clamp(rotX, -45f, 45f);

                    player.transform.eulerAngles = new Vector3(rotX, rotY , 0f);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    initTouch = new Touch();
                }
            }
        }

    }

    // Gets a movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // Gets a rotation vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    // Gets a rotation vector
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    void PerformMovement()
    {
       rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    // Perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, rb.rotation * Quaternion.Euler((rotation + -cameraRotation).normalized), cameraSmoothness));
        //Quaternion.Slerp(rb.rotation, rb.rotation * Quaternion.Euler((rotation + -cameraRotation).normalized), cameraSmoothness);

        // Lock the z axis
        float z = transform.eulerAngles.z;
        rb.MoveRotation(rb.rotation * Quaternion.Euler( new Vector3(0, 0, -z)));

        if (cam != null)
        {
            //cam.transform.Rotate(-cameraRotation);

        }
    }

    // Get a force vector for the thruster
    public void ApplyThruster(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }

}
