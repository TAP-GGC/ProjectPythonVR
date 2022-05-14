using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandLogic : MonoBehaviour
{
    public GameObject handRay;
    public bool isGripHeld;
    private InputDevice targetDevice;
    public InputDeviceCharacteristics controllerCharacteristics;

    private void Start()
    {
        isGripHeld = false;
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    private void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            if(gripValue > 0f)
            {
                isGripHeld = true;
            }
            else
            {
                isGripHeld = false;
            }
        }
        else
        {
            isGripHeld = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "grabbable" && isGripHeld)
        {
            this.GetComponent<SphereCollider>().enabled = false;
            handRay.SetActive(false);
        }
        else
        {
            this.GetComponent<SphereCollider>().enabled = true;
            handRay.SetActive(true);
        }
    }
}
