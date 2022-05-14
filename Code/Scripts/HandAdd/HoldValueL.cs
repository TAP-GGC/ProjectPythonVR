using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldValueL : MonoBehaviour
{
    public bool isHoldingLeft;
    public int intVal;
    public float floatVal;
    public string stringVal;
    public GameObject objectInHandLeft;
    public Vector3 holdT;
    public Quaternion holdR;

    public GameObject rightCon;
    public float rightGrip;
    public GameObject leftCon;
    public float leftGrip;

    private void Start()
    {
        isHoldingLeft = false;
        holdT = transform.position;
        holdR = transform.rotation;
    }
    private void Update()
    {
        rightGrip = rightCon.GetComponent<ControllerInput>().gripValue;
        leftGrip = leftCon.GetComponent<ControllerInput>().gripValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Value") && isHoldingLeft == false && rightGrip == 0)
        {
            intVal = other.gameObject.GetComponent<ValueLogicInt>().value;
            floatVal = other.gameObject.GetComponent<ValueLogicFloat>().value;
            stringVal = other.gameObject.GetComponent<ValueLogicString>().value;
            isHoldingLeft = true;
            objectInHandLeft = other.gameObject;
            other.gameObject.transform.position = holdT;
            other.gameObject.transform.rotation = holdR;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Value"))
        {
            isHoldingLeft = false;
            intVal = 0;
            floatVal = 0;
            stringVal = "";
            objectInHandLeft = null;
        }
    }
}
