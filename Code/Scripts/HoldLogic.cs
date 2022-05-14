using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLogic : MonoBehaviour
{
    public bool isHolding;
    public Vector3 holdT;
    public Quaternion holdR;
    public GameObject heldObject;

    [SerializeField]public int intVal;
    [SerializeField]public float floatVal;
    public string stringVal;

    void Start()
    {
        holdT = transform.position;
        holdR = transform.rotation;
        isHolding = false;
    }

}
