using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueLogicInt3D : MonoBehaviour
{
    public int value;
    Rigidbody rb;
    public bool isNotUsing = true;
    public GameObject hands;

    void Start()
    {
        TextMeshPro mText = gameObject.GetComponentInChildren<TextMeshPro>();
        value = int.Parse(mText.text);

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
        if (other.gameObject.CompareTag("Hold") && !other.gameObject.GetComponent<HoldLogic>().isHolding)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.velocity = Vector3.zero;
            isNotUsing = false;
            transform.position = other.gameObject.GetComponent<HoldLogic>().holdT;
            transform.rotation = other.gameObject.GetComponent<HoldLogic>().holdR;
            other.gameObject.GetComponent<HoldLogic>().isHolding = true;
            other.gameObject.GetComponent<HoldLogic>().intVal = value;
            other.gameObject.GetComponent<HoldLogic>().heldObject = this.gameObject;
        }
        else if (other.gameObject.CompareTag("Box") && hands.GetComponent<mouseMovement>().heldObject == null)
        {
            other.gameObject.GetComponent<ObjectLogicInt>().valueInBox = value;
            other.gameObject.GetComponent<ObjectLogicInt>().putInside = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hold"))
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            other.gameObject.GetComponent<HoldLogic>().intVal = 0;
            isNotUsing = true;
            other.gameObject.GetComponent<HoldLogic>().isHolding = false;
            other.gameObject.GetComponent<HoldLogic>().heldObject = null;
        }
    }
}