using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectLogicBool : MonoBehaviour
{
    public bool valueInBox;
    public Text txt;
    public bool putInside = false;
    [SerializeField] string valueEquals;

    private void Update()
    {
        if (putInside)
        {
            txt.text = valueEquals + valueInBox;
            if (valueInBox)
            {
                txt.text = valueEquals + "True";
            }
            else if (!valueInBox)
            {
                txt.text = valueEquals + "False";
            }
            putInside = false;
        }
    }

}
