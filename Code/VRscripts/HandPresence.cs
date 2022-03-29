using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    private GameObject spawnedHandModel;
    private InputDevice targetDevice;
    private Animator handAnimator;
    public bool isGripHeld;
    void Start()
    {
        isGripHeld = false;
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        spawnedHandModel = Instantiate(handModelPrefab, transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
    }
    void Update()
    {
        UpdateHandAnimation();
    }

    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
            isGripHeld = true;
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
            isGripHeld = false;
        }
    }
}