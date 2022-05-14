using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseMovementMainMenu : MonoBehaviour
{
    //player variables
    public float mouseSense = 100;
    public Transform playerBody;
    public float xRotation = 0;
    public float distanceToSee;
    RaycastHit whatIHit;
    public Image buttonPressHand;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        handleRotation();
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
            if (whatIHit.collider.tag == "MenuButton")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    whatIHit.collider.GetComponent<MenuController3D>().Invoke("loadLevel", 0);
                }
            }
            else
            {
                buttonPressHand.enabled = false;
            }
        }
    }

    private void handleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

