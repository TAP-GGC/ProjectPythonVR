using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueLogicString : MonoBehaviour
{
    public string value;
    public GameObject rightCon;
    public float rightGrip;
    public GameObject leftCon;
    public float leftGrip;
    Rigidbody rb;
    public bool isNotUsing = true;

    void Start()
    {
        TextMeshPro mText = gameObject.GetComponentInChildren<TextMeshPro>();
        value = mText.text;

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
        if (other.gameObject.CompareTag("Hold") && !other.gameObject.GetComponent<HoldLogic>().isHolding && rightGrip == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.velocity = Vector3.zero;
            isNotUsing = false;
            transform.position = other.gameObject.GetComponent<HoldLogic>().holdT;
            transform.rotation = other.gameObject.GetComponent<HoldLogic>().holdR;
            other.gameObject.GetComponent<HoldLogic>().isHolding = true;
            other.gameObject.GetComponent<HoldLogic>().stringVal = value;
            other.gameObject.GetComponent<HoldLogic>().heldObject = this.gameObject;
        }
        else if (other.gameObject.CompareTag("Box") && rightGrip == 0)
        {
            other.gameObject.GetComponent<ObjectLogicString>().valueInBox = value;
            other.gameObject.GetComponent<ObjectLogicString>().putInside = true;
            Destroy(this.gameObject);
        }

        else if (other.gameObject.CompareTag("Hold") && !other.gameObject.GetComponent<HoldLogic>().isHolding && leftGrip == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.velocity = Vector3.zero;
            isNotUsing = false;
            transform.position = other.gameObject.GetComponent<HoldLogic>().holdT;
            transform.rotation = other.gameObject.GetComponent<HoldLogic>().holdR;
            other.gameObject.GetComponent<HoldLogic>().isHolding = true;
            other.gameObject.GetComponent<HoldLogic>().stringVal = value;
            other.gameObject.GetComponent<HoldLogic>().heldObject = this.gameObject;
        }
        else if (other.gameObject.CompareTag("Box") && leftGrip == 0)
        {
            other.gameObject.GetComponent<ObjectLogicString>().valueInBox = value;
            other.gameObject.GetComponent<ObjectLogicString>().putInside = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hold"))
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            other.gameObject.GetComponent<HoldLogic>().floatVal = 0;
            other.gameObject.GetComponent<HoldLogic>().isHolding = false;
            other.gameObject.GetComponent<HoldLogic>().heldObject = null;
            isNotUsing = true;
        }
    }
}
