using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimationHandler : MonoBehaviour
{
	//Instantiate Componenets
	private InputDevice targetDevice;
	public InputDeviceCharacteristics controllerCharacteristics;
	private Animator handAnimator;
	public GameObject handObject;
	private GameObject spawnedHandModel;

	void Start()
    {
		TryInitialize();
	}

	void TryInitialize()
    {
		List<InputDevice> devices = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
		targetDevice = devices[0];

		spawnedHandModel = Instantiate(handObject, transform);
		handAnimator = spawnedHandModel.GetComponent<Animator>();
	}

    void Update()
    {
        if (!targetDevice.isValid)
        {
			TryInitialize();
        }
        else
        {
			UpdateHandAnimation();
		}
    }

	void UpdateHandAnimation()
	{
		if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
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
		}
		else
		{
			handAnimator.SetFloat("Grip", 0);
		}
	}
}
