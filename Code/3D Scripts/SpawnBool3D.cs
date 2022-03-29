using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnBool3D : MonoBehaviour
{
    public GameObject prefab;
    private GameObject clone;
    private Transform spawnPos;

    private void OnEnable()
    {
        spawnPos = transform;
        spawnBoolOrb();
        this.GetComponent<SpawnBool3D>().enabled = false;
    }

    private void spawnBoolOrb()
    {
        clone = Instantiate(prefab, spawnPos);
        clone.GetComponent<ValueLogicBool3D>().hands = GameObject.Find("Camera");
        int num = Random.Range(1, 3);
        if (num == 1)
        {
            clone.GetComponentInChildren<TextMeshPro>().color = Color.green;
            clone.GetComponentInChildren<TextMeshPro>().text = "True";
        }
        else
        {
            clone.GetComponentInChildren<TextMeshPro>().color = Color.red;
            clone.GetComponentInChildren<TextMeshPro>().text = "False";
        }
    }
}
