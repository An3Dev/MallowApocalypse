using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField] Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    GameObject player;

    private float cameraSmoothness = 10;

    private Rigidbody rb;




    private void Start()
    {
        rb = GetComponent<Rigidbody>();


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
