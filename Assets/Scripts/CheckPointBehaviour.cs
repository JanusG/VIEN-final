using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour
{
    [SerializeField] private int checkPointID;
    [SerializeField] private GameObject gm;
    [SerializeField] private GameObject nextCP;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            gm.SendMessage("setResetPosition", tr);
            nextCP.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
}
