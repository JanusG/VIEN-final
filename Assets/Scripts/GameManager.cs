using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerCar;
    [SerializeField] private Transform playerResetPosition;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Axis11 LeftGrip") > 0.5f)
        {

            resetPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerResetPosition = other.gameObject.transform;
    }

    private void setResetPosition(Transform newPos)
    {
        playerResetPosition = newPos.transform;
    }

    private void resetPlayer()
    {
        //Debug.Log("Boop!");
        playerCar.transform.position = playerResetPosition.position;
        playerCar.transform.rotation = playerResetPosition.rotation;
    }
}
