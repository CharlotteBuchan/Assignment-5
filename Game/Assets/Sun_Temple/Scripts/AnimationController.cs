using SunTemple;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Walking");
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsSitting", false);
        }
        else
        {
            Debug.Log("Idle");
            anim.SetBool("IsWalking", false);
        }
        
        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("Sitting");
            if (anim.GetBool("IsSitting") == false)
            {
                anim.SetBool("IsSitting", true);
            }
            else
            {
                anim.SetBool("IsSitting", false);
            }

        }
    }
}
