using UnityEngine;



public class VRNavigation : MonoBehaviour
{



    UnityEngine.XR.InputDevice device;



    private Vector3 initialPosition;

    private Quaternion initialRotation;

    private bool isPressed = false;

    private Vector2 primary2DAxis;



    void Start()
    {

        device = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftHand);

        // mémorisation de la position et orientation initiales

        initialPosition = transform.position;

        initialRotation = transform.rotation;

    }



    // Update is called once per frame

    void Update()
    {

        // reset de position et orientation

        device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out isPressed); // X button

        if (isPressed)
        {

            transform.SetPositionAndRotation(initialPosition, initialRotation);

        }

        device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out isPressed); // Y button

        if (isPressed)
        {

            transform.Translate(0, 0, -5f);

        }

        // translation

        isPressed = device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out primary2DAxis); // Joystick

        if (isPressed)
        {

            transform.Translate(0, 0, primary2DAxis.y);

            transform.Rotate(0, primary2DAxis.x, 0);

        }

    }



}