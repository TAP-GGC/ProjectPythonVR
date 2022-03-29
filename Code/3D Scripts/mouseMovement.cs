using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseMovement : MonoBehaviour
{
    //player variables
    public float mouseSense = 100;
    public Transform playerBody;
    public float xRotation = 0;

    //player raycast
    public float distanceToSee = 0;
    RaycastHit whatIHit;
    RaycastHit whatIHit2;

    //hold logic variables
    public GameObject holdPosition;
    private Transform holdLocation;
    public GameObject heldObject;
    public GameObject boxDropLocation;
    private Transform heldObjectTransform;
    public bool holding = false;
    public bool pressed;

    //UI images
    public Image openHand;
    public Image closedHand;
    public Image buttonPressHand;

    //drop locations
    public GameObject robotHandsDrop;
    public GameObject boxDrop;
    public GameObject boxDropY;
    private bool showDrop;

    //Spawning from buttons
    public GameObject intSpawn;
    public GameObject floatSpawn;
    public GameObject boolSpawn;
    public GameObject stringSpawn;
    public GameObject checkAnswer;
    public GameObject resetLevel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        openHand.enabled = false;
        closedHand.enabled = false;
        buttonPressHand.enabled = false;
        showDrop = false;
    }

    void Update()
    {
        holdLocation = holdPosition.GetComponent<Transform>();
        handleRotation();
        holdingObject();
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        //Debug.Log(LayerMask.GetMask("UI"));
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

    public void holdingObject()
    {
        if (holding == false)
        {
            RayCastPickUp();
            robotHandsDrop.SetActive(false);
            boxDrop.SetActive(false);
            boxDropY.SetActive(false);
        }
        else if(holding == true)
        {
            if (showDrop)
            {
                robotHandsDrop.SetActive(true);
                boxDrop.SetActive(true);
                boxDropY.SetActive(true);
            }
            heldObjectTransform = heldObject.GetComponent<Transform>();
            heldObject.GetComponent<Collider>().enabled = false;
            heldObjectTransform.position = holdLocation.position;
            heldObjectTransform.rotation = holdLocation.rotation;

            if (Input.GetMouseButtonDown(0))
            {
                heldObject.GetComponent<Collider>().enabled = true;
                RayCastDrop();
                heldObject = null;
                holding = false;
            }
        }
    }

    private void RayCastPickUp()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
            
            //handles UI toggling
            if ((whatIHit.collider.tag == "Value") && holding == false)
            {
                openHand.enabled = true;
                closedHand.enabled = false;
            }
            else if (whatIHit.collider.tag == "Button" && holding == false)
            {
                buttonPressHand.enabled = true;
                openHand.enabled = false;
                closedHand.enabled = false;
            }
            else if (holding == false)
            {
                openHand.enabled = false;
                closedHand.enabled = false;
                buttonPressHand.enabled = false;
            }

            //Debug.Log("I am hitting a " + whatIHit.collider.gameObject.name);
            if (Input.GetMouseButtonDown(0))
            {
                if (whatIHit.collider.tag == "Value")
                {
                    heldObject = whatIHit.collider.gameObject;
                    showDrop = true;
                    openHand.enabled = false;
                    closedHand.enabled = true;
                    holding = true;
                }
                /*else if (whatIHit.collider.tag == "Button")
                {
                    pressed = true;
                }*/
                else
                {
                    Debug.Log("Can't be picked up");
                    holding = false;
                    openHand.enabled = false;
                    closedHand.enabled = false;
                }
            }

            //Messy but works button logic
            if (whatIHit.collider.tag == "MainMenu")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    whatIHit.collider.GetComponent<ReturnToMenu3D>().Invoke("loadMainMenu", 0);
                }
            }
            else if (whatIHit.collider.tag == "Int")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    intSpawn.GetComponent<SpawnInt3D>().Invoke("spawnIntegerOrb", 0);
                }
            }
            else if (whatIHit.collider.tag == "Float")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    floatSpawn.GetComponent<SpawnFloat3D>().Invoke("spawnFloatOrb", 0);
                }
            }
            else if (whatIHit.collider.tag == "Bool")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    boolSpawn.GetComponent<SpawnBool3D>().Invoke("spawnBoolOrb", 0);
                }
            }
            else if (whatIHit.collider.tag == "String")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    stringSpawn.GetComponent<SpawnString3D>().Invoke("spawnStringOrb", 0);
                }
            }
            else if (whatIHit.collider.tag == "Check")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    checkAnswer.GetComponent<Solution>().Invoke("checkAnswer", 0);
                }
            }
            else if (whatIHit.collider.tag == "Reset")
            {
                buttonPressHand.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    resetLevel.GetComponent<Reset>().Invoke("resetLevel", 0);
                }
            }
        }
    }

    private void RayCastDrop()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit2, distanceToSee, 512, QueryTriggerInteraction.Collide))
        {
            //Debug.Log("I am hitting a " + whatIHit2.collider.gameObject.name);
                if (whatIHit2.collider.isTrigger && whatIHit2.collider.tag == "Hold" || whatIHit2.collider.tag == "Box")
                {
                    heldObject.transform.position = whatIHit2.collider.gameObject.transform.position;
                    heldObject.transform.rotation = whatIHit2.collider.gameObject.transform.rotation;
                    heldObject = null;
                }
            
        }
    }
}

