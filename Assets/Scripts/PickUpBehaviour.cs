using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    [SerializeField] private float xAngle, yAngle, zAngle;
    [SerializeField] private float timer = 1000;
    private float showWhen = 0.0f;
    private bool isHidden = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHidden)
        {
            if (Time.time > showWhen)
            {
                toggleBox(true);
            }
        }
        else
        {
            transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        }
    }

    private void toggleBox(bool toggle)
    {
        isHidden = !toggle;
        showWhen = Time.time + timer;
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(toggle);
        }
    }
}
