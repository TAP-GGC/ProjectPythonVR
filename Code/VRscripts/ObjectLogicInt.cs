using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectLogicInt : MonoBehaviour
{
    public int valueInBox;
    public Text txt;
    public bool putInside = false;
    [SerializeField] string valueEquals;

    private void Update()
    {
        if (putInside)
        {
            txt.text = valueEquals + valueInBox;
            putInside = false;
        }
    }
}
