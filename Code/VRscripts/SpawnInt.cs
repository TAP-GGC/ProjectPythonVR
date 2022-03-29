using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnInt : MonoBehaviour
{
    public GameObject prefab;
    private GameObject clone;
    private Transform spawnPos;

    private void OnEnable()
    {
        spawnPos = transform;
        spawnIntegerOrb();
        this.GetComponent<SpawnInt>().enabled = false;
    }

    private void spawnIntegerOrb()
    {
        clone = Instantiate(prefab, spawnPos);
        clone.GetComponent<ValueLogicInt>().rightCon = GameObject.Find("RightHand Controller");
        clone.GetComponent<ValueLogicInt>().leftCon = GameObject.Find("LeftHand Controller");
        clone.GetComponentInChildren<TextMeshPro>().text = (Random.Range(1, 10)).ToString();
    }
}
