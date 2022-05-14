using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderToggle : MonoBehaviour
{
    public BoxCollider boxCol;
    float timeToDisable = 1f;
    void Start()
    {
        boxCol = this.GetComponent<BoxCollider>();
        boxCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(boxCol.enabled == true)
        {
            while(timeToDisable != 0)
            {
                timeToDisable -= 1 * Time.deltaTime;
            }
            if (timeToDisable == 0)
            {
                boxCol.enabled = false;
                timeToDisable = 1f;
            }
        }
    }
}
