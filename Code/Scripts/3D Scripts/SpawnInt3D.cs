using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnInt3D : MonoBehaviour
{
    public GameObject prefab;
    private GameObject clone;
    private Transform spawnPos;

    private void OnEnable()
    {
        spawnPos = transform;
        spawnIntegerOrb();
        this.GetComponent<SpawnInt3D>().enabled = false;
    }

    public void spawnIntegerOrb()
    {
        clone = Instantiate(prefab, spawnPos);
        clone.GetComponent<ValueLogicInt3D>().hands = GameObject.Find("Camera");
        clone.GetComponentInChildren<TextMeshPro>().text = (Random.Range(1, 10)).ToString();
    }
}
