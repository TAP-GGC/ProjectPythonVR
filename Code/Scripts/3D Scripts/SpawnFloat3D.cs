using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnFloat3D : MonoBehaviour
{
    public GameObject prefab;
    private GameObject clone;
    private Transform spawnPos;

    private void OnEnable()
    {
        spawnPos = transform;
        spawnFloatOrb();
        this.GetComponent<SpawnFloat3D>().enabled = false;
    }

    private void spawnFloatOrb()
    {
        clone = Instantiate(prefab, spawnPos);
        clone.GetComponent<ValueLogicFloat3D>().hands = GameObject.Find("Camera");
        clone.GetComponentInChildren<TextMeshPro>().text = (Random.Range(1f, 10f).ToString("F1"));
    }
}
