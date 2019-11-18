using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class LeftHandScript : MonoBehaviour
{
    private Animator anim;
    private int gripping;
    private int point;
    public bool isGripping = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        gripping = Animator.StringToHash("Hold");
        point = Animator.StringToHash("Point");
    }

    // Update is called once per frame
    void Update()
    {
        float leftTrigger = CrossPlatformInputManager.GetAxis("Axis9_LeftTrigger");
        if (leftTrigger > 0.5)
        {
            if (isGripping)
            {
                //todo: set animation to gripping and position to handle
                anim.SetBool(gripping, true);
                //todo: make platform able to move.
            }
            else
            {
                anim.SetBool(point, true);
            }
        }
        else
        {
            anim.SetBool(gripping, false);
            anim.SetBool(point, false);
        }
    }
    private void setIsGripping(bool b)
    {
        isGripping = b;
    }
}
