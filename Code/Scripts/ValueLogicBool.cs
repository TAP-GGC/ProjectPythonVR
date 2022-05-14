using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueLogicBool : MonoBehaviour
{
    public bool value;
    public GameObject rightCon;
    public float rightGrip;
    public GameObject leftCon;
    public float leftGrip;
    Rigidbody rb;
    public bool isNotUsing = true;

    void Start()
    {
        TextMeshPro mText = gameObject.GetComponentInChildren<TextMeshPro>();

        if (mText.text == "True")
        {
            value = true;
            mText.color = Color.green;
        }
        if (mText.text == "False")
        {
            value = false;
            mText.color = Color.red;
        }

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rightGrip = rightCon.GetComponent<ControllerInput>().gripValue;
        leftGrip = leftCon.GetComponent<ControllerInput>().gripValue;

        if (isNotUsing)
        {
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box") && rightGrip == 0)
        {
            other.gameObject.GetComponent<ObjectLogicBool>().valueInBox = value;
            other.gameObject.GetComponent<ObjectLogicBool>().putInside = true;
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Box") && leftGrip == 0)
        {
            other.gameObject.GetComponent<ObjectLogicBool>().valueInBox = value;
            other.gameObject.GetComponent<ObjectLogicBool>().putInside = true;
            Destroy(this.gameObject);
        }
    }
}
