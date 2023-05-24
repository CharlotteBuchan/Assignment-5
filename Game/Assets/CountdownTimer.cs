using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime =0f;
    float startingTime =10f;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        currentTime -= 1 * Time.deltaTime;
        print(currentTime);
        if (currentTime <= 10) { countdownText.color = Color.red; }
    }
}
