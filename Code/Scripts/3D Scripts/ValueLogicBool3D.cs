using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueLogicBool3D : MonoBehaviour
{
    public bool value;
    Rigidbody rb;
    public bool isNotUsing = true;
    public GameObject hands;

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
        if (other.gameObject.CompareTag("Box") && hands.GetComponent<mouseMovement>().heldObject == null)
        {
            other.gameObject.GetComponent<ObjectLogicBool>().valueInBox = value;
            other.gameObject.GetComponent<ObjectLogicBool>().putInside = true;
            Destroy(this.gameObject);
        }
    }
}
