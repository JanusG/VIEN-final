using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject displayItems;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        setColor(Color.red);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setColor(Color newColor)
    {
        mat.SetColor("_Color", newColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        float leftTrigger = Input.GetAxis("Axis9_LeftTrigger");
        if (leftTrigger > 0.5) {
            setColor(Color.green);
            displayItems.SendMessage("useItem");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        setColor(Color.red);
    }
}
