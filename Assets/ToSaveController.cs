using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
using TMPro;
using System;

public class ToSaveController : MonoBehaviour
{
    public TextMeshProUGUI toSave;
    public MainState mainState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toSave.text = mainState.getPeopleToSaveCount().ToString();
    }
}
