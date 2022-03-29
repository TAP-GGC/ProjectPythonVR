using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnFloat : MonoBehaviour
{
    public GameObject prefab;
    private GameObject clone;
    private Transform spawnPos;

    private void OnEnable()
    {
        spawnPos = transform;
        spawnFloatOrb();
        this.GetComponent<SpawnFloat>().enabled = false;
    }

    private void spawnFloatOrb()
    {
        clone = Instantiate(prefab, spawnPos);
        clone.GetComponent<ValueLogicFloat>().rightCon = GameObject.Find("RightHand Controller");
        clone.GetComponent<ValueLogicFloat>().leftCon = GameObject.Find("LeftHand Controller");
        clone.GetComponentInChildren<TextMeshPro>().text = (Random.Range(1f, 10f).ToString("F1"));
    }
}
