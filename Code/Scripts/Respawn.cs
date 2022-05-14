using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 spawnPos;
    public Quaternion spawnRot;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        spawnRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            rb.velocity = Vector3.zero;
            transform.position = spawnPos;
            transform.rotation = spawnRot;
        }
    }
}
