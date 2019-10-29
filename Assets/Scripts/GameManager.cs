using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerCar;
    [SerializeField] private Transform playerResetPosition;
    [SerializeField] private int cpCount = 1;
    [SerializeField] private int cpID = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxis("Axis12 RightGrip") > 0.5f) {
            
            resetPlayer();
        }
    }

    private void OnTriggerEnter(Collider other) {
        playerResetPosition = other.gameObject.transform;
    }

    private void setResetPosition(Transform newPos) {
        playerResetPosition = newPos.transform;
    }

    private void resetPlayer() {        
        //Debug.Log("Boop!");
        playerCar.transform.position = playerResetPosition.position;
        playerCar.transform.rotation = playerResetPosition.rotation;
    }
}
