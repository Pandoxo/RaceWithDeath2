using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    public float timeLeft = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(timeLeft);

        //here backslash is must to tell that colon is
        //not the part of format, it just a character that we want in output
        string str = time.ToString(@"mm\:ss");

        textElement.text = str;
    }
}
