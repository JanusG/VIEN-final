using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool hasItem;
    private bool skidding;
    private bool justspawned;
    private float forward;
    [SerializeField] private float timer = 3;
    private float timeLeft = 0.0f;
    [SerializeField] private GameObject itemDisplay;
    [SerializeField] private GameObject wheels;
    [SerializeField] private GameObject[] items;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeLeft)
        {
            for (int a = 0; a < wheels.transform.childCount; a++)
            {
                WheelCollider wheel = wheels.transform.GetChild(a).gameObject.GetComponent<WheelCollider>();
                WheelFrictionCurve myWfc;
                myWfc = wheel.sidewaysFriction;
                myWfc.extremumSlip = 0.2f;
                myWfc.extremumValue = 10f;
                wheel.sidewaysFriction = myWfc;

                myWfc = wheel.forwardFriction;
                myWfc.extremumSlip = 0.4f;
                wheel.forwardFriction = myWfc;
            }
        }
        forward = rb.velocity.z;
        //Debug.Log(forward);
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "PickUp")
        {

            if (!hasItem)
            {
                other.SendMessage("toggleBox", false);
                itemDisplay.SendMessage("setItem", true);
                hasItem = true;
            }
        }
        else if (other.tag == "Tar")
        {
            if (!justspawned)
            {
                skidding = true;
                timeLeft = Time.time + timer;

                for (int a = 0; a < wheels.transform.childCount; a++)
                {
                    WheelCollider wheel = wheels.transform.GetChild(a).gameObject.GetComponent<WheelCollider>();
                    WheelFrictionCurve myWfc;
                    myWfc = wheel.sidewaysFriction;
                    myWfc.extremumSlip = 5f;
                    myWfc.extremumValue = 2f;
                    wheel.sidewaysFriction = myWfc;

                    myWfc = wheel.forwardFriction;
                    myWfc.extremumSlip = 2f;
                    wheel.forwardFriction = myWfc;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (justspawned)
        {
            justspawned = false;
        }
    }

    private void ItemUsed()
    {
        hasItem = false;
    }

    private void deployTar(int i)
    {
        spawnItem(i);
        hasItem = false;
        justspawned = true;
    }

    private void shootRocket(int i)
    {
        GameObject rocket = spawnItem(i);
        //todo: change velosity of the rocket to shoot forward
        //todo: ignore collision
    }

    private GameObject spawnItem(int i)
    {
        Quaternion rotation = transform.rotation;
        Vector3 position = transform.position;
        rotation.y = rotation.y - 90;
        rotation.z = rotation.z - 90;
        return Instantiate(items[i], position, rotation);

    }

}
