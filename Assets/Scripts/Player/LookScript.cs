using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LookScript : MonoBehaviour
{

    //public FixedJoystick MoveJoystick;
    public FixedButton ShootButton;
    public FixedTouchField TouchField;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            var fps = GetComponent<RigidbodyFirstPersonController>();
            var playerShoot = GetComponent<PlayerShoot>();
            //fps.RunAxis = MoveJoystick.inputVector;
            playerShoot.ShootAxis = ShootButton.Pressed;
            fps.mouseLook.LookAxis = TouchField.TouchDist;
        }
    }
}
