using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHandler : MonoBehaviour
{
    public Text txt;

    private void Start()
    {
        txt.text = "x = ";
        txt.color = Color.red;
        GetComponent<UITextHandler>().enabled = false;
    }
}
