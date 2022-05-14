using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float gripValue;
    [SerializeField]InputActionReference controllerActionGrip;
    public GameObject orbLocations;
    public GameObject boxOrb;
    public GameObject boxOrbY;

    private void Awake()
    {
        controllerActionGrip.action.performed += GripPress;
        controllerActionGrip.action.canceled += GripReleased;
    }

    private void GripReleased(InputAction.CallbackContext obj)
    {
        gripValue = obj.ReadValue<float>();
    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        gripValue = obj.ReadValue<float>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Value") && gripValue != 0)
        {
            orbLocations.SetActive(true);
            boxOrb.SetActive(true);
            boxOrbY.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Value") && gripValue == 0)
        {
            orbLocations.SetActive(false);
            boxOrb.SetActive(false);
            boxOrbY.SetActive(false);
        }
    }
}
