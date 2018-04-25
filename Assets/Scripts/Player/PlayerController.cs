using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitivity = 5f;

    [SerializeField]
    private float thrusterForce = 0;

    [Header("Spring Settings:")]
    [SerializeField]
    private float jointSpring = 0;
    [SerializeField]
    private float jointMaxForce = 0;

    private PlayerMotor motor;

    float yRot;
    //private ConfigurableJoint joint;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        //joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        // Calculate movement velocity as a 3D vector
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * yMov;

        // Final movement vector;
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        // Apply movement
        motor.Move(velocity);


        // Calculate rotation as a 3D vector3 (turning around)


        


        //if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.mousePosition.x > Screen.width / 4)
            {
                yRot = Input.GetAxis("Mouse X");
            }
            
        }

        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            yRot = Input.GetAxis("Mouse X");
        }
            
        //}

        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    // if mouse is in left part of screen
        //    if (Input.mousePosition.x < Screen.width / 4 * 3)
        //    {
        //        yRot = Input.GetAxis("Mouse X");

        //    }
        //    else
        //    {
        //        yRot = 0;
        //    }
        //}

        Vector3 rotation = new Vector3(0, yRot, 0) * lookSensitivity;

        // Apply rotation
        motor.Rotate(rotation);

        // Calculate camera rotation as a 3D vector3 (turning around)
        float xRot = Input.GetAxis("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * lookSensitivity;

        // Apply camera rotation
        motor.RotateCamera(cameraRotation);

        // Calculate thruster force from player input
        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
        }

        // Apply thruster force
        motor.ApplyThruster(_thrusterForce);

    }

    //private void SetJointSettings()
    //{

    //}
}
