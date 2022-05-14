using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplyNewValue : MonoBehaviour
{
    public int multInts;
    public float multFloats;
    public string multStrings;

    public int leftInt;
    public float leftFloat;
    public string leftString;

    public int rightInt;
    public float rightFloat;
    public string rightString;

    [SerializeField] GameObject leftHand;
    private HoldLogic leftHold;
    [SerializeField] GameObject rightHand;
    private HoldLogic rightHold;

    public GameObject prefabInt;
    public GameObject prefabFloat;
    public GameObject prefabString;

    public GameObject spawn;
    public Vector3 spawnPos;
    public Quaternion spawnRot;

    private GameObject clone;

    private void Start()
    {
        leftHold = leftHand.GetComponent<HoldLogic>();
        rightHold = rightHand.GetComponent<HoldLogic>();
        spawnPos = spawn.transform.position;
        spawnRot = spawn.transform.rotation;
    }

    private void Update()
    {
        leftInt = leftHold.intVal;
        leftFloat = leftHold.floatVal;
        leftString = leftHold.stringVal;

        rightInt = rightHold.intVal;
        rightFloat = rightHold.floatVal;
        rightString = rightHold.stringVal;

        if (leftHold.isHolding && rightHold.isHolding)
        {
            ifLadder();
            leftHold.heldObject.GetComponent<Destroy>().enabled = true;
            rightHold.heldObject.GetComponent<Destroy>().enabled = true;
            rightHold.intVal = 0;
            rightHold.floatVal = 0;
            rightHold.stringVal = "";
            leftHold.intVal = 0;
            leftHold.floatVal = 0;
            leftHold.stringVal = "";
            leftHold.isHolding = false;
            rightHold.isHolding = false;
        }
    }

    private void ifLadder()
    {
        if ((rightInt != 0 && rightFloat == 0 && rightString == "") && (leftInt != 0 && leftFloat == 0 && leftString == ""))
        {
            clone = Instantiate(prefabInt, spawnPos, spawnRot);
            clone.GetComponentInChildren<TextMeshPro>().text = (rightInt * leftInt).ToString();
            clone.GetComponent<ValueLogicInt>().rightCon = GameObject.Find("RightHand Controller");
            clone.GetComponent<ValueLogicInt>().leftCon = GameObject.Find("LeftHand Controller");
        }
        else if ((rightInt != 0 && rightFloat == 0 && rightString == "") && (leftInt == 0 && leftFloat != 0 && leftString == ""))
        {
            Debug.Log("Calling mult");
            clone = Instantiate(prefabFloat, spawnPos, spawnRot);
            clone.GetComponentInChildren<TextMeshPro>().text = ((float)rightInt * leftFloat).ToString();
            clone.GetComponent<ValueLogicFloat>().rightCon = GameObject.Find("RightHand Controller");
            clone.GetComponent<ValueLogicFloat>().leftCon = GameObject.Find("LeftHand Controller");
        }
        else if ((rightInt != 0 && rightFloat == 0 && rightString == "") && (leftInt == 0 && leftFloat == 0 && leftString != ""))
        {
            clone = Instantiate(prefabString, spawnPos, spawnRot);
            string addedStrings = rightString;
            string removeQuotes = "\"";
            addedStrings = addedStrings.Replace(removeQuotes, "");
            string output = "";
            for (int x = 0; x < leftInt; x++)
            {
                output += addedStrings;
                Debug.Log("adding strings");
            }
            string newString = "\"" + output + "\"";
            clone.GetComponentInChildren<TextMeshPro>().text = newString;
            clone.GetComponent<ValueLogicString>().rightCon = GameObject.Find("RightHand Controller");
            clone.GetComponent<ValueLogicString>().leftCon = GameObject.Find("LeftHand Controller");
        }
        else if ((rightInt == 0 && rightFloat != 0 && rightString == "") && (leftInt != 0 && leftFloat == 0 && leftString == ""))
        {
            clone = Instantiate(prefabFloat, spawnPos, spawnRot);
            clone.GetComponentInChildren<TextMeshPro>().text = (rightFloat * (float)leftInt).ToString();
            clone.GetComponent<ValueLogicFloat>().rightCon = GameObject.Find("RightHand Controller");
            clone.GetComponent<ValueLogicFloat>().leftCon = GameObject.Find("LeftHand Controller");
        }
        else if ((rightInt == 0 && rightFloat != 0 && rightString == "") && (leftInt == 0 && leftFloat != 0 && leftString == ""))
        {
            clone = Instantiate(prefabFloat, spawnPos, spawnRot);
            clone.GetComponentInChildren<TextMeshPro>().text = (rightFloat * leftFloat).ToString();
            clone.GetComponent<ValueLogicFloat>().rightCon = GameObject.Find("RightHand Controller");
            clone.GetComponent<ValueLogicFloat>().leftCon = GameObject.Find("LeftHand Controller");
        }
        else if ((rightInt == 0 && rightFloat != 0 && rightString == "") && (leftInt == 0 && leftFloat == 0 && leftString != ""))
        {
            Debug.Log("Can't add string with float");
        }
        else if ((rightInt == 0 && rightFloat == 0 && rightString != "") && (leftInt != 0 && leftFloat == 0 && leftString == ""))
        {
            clone = Instantiate(prefabString, spawnPos, spawnRot);
            string addedStrings = rightString;
            string removeQuotes = "\"";
            addedStrings = addedStrings.Replace(removeQuotes, "");
            string output = "";
            for (int x = 0; x < leftInt; x++)
            {
                output += addedStrings;
                Debug.Log("adding strings");
            }
            string newString = "\"" + output + "\"";
            clone.GetComponentInChildren<TextMeshPro>().text = newString;
            clone.GetComponent<ValueLogicString>().rightCon = GameObject.Find("RightHand Controller");
            clone.GetComponent<ValueLogicString>().leftCon = GameObject.Find("LeftHand Controller");
        }
        else if ((rightInt == 0 && rightFloat == 0 && rightString != "") && (leftInt == 0 && leftFloat != 0 && leftString == ""))
        {
            Debug.Log("Can't add string with float");
        }
        else if ((rightInt == 0 && rightFloat == 0 && rightString != "") && (leftInt == 0 && leftFloat == 0 && leftString != ""))
        {

        }
        else
        {
            Debug.Log("You should not see this error");
        }
    }
}
