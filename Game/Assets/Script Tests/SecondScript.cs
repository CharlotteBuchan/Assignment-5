using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondScript : MonoBehaviour
{
    public FirstScript first;

    void Start()
    {
        // some code
    }

    void Update()
    {
        // calling SayHello() method every frame
        first.SayHello();
    }

}