using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnString : MonoBehaviour
{
    public GameObject prefab;
    private GameObject clone;
    private Transform spawnPos;

    private void OnEnable()
    {
        spawnPos = transform;
        spawnStringOrb();
        this.GetComponent<SpawnString>().enabled = false;
    }

    private void spawnStringOrb()
    {
        clone = Instantiate(prefab, spawnPos);
        clone.GetComponent<ValueLogicString>().rightCon = GameObject.Find("RightHand Controller");
        clone.GetComponent<ValueLogicString>().leftCon = GameObject.Find("LeftHand Controller");
        int num = Random.Range(1, 11);
        switch (num)
        {
            case 1:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"apple\"";
                break;
            case 2:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"banana\"";
                break;
            case 3:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Delaware\"";
                break;
            case 4:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Corgi\"";
                break;
            case 5:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Program\"";
                break;
            case 6:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Thief\"";
                break;
            case 7:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Dylan\"";
                break;
            case 8:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Planet\"";
                break;
            case 9:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Stars\"";
                break;
            case 10:
                clone.GetComponentInChildren<TextMeshPro>().text = "\"Robot\"";
                break;
        }
    }
}
