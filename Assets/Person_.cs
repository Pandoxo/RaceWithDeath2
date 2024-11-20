using System.Collections.Specialized;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Person_ : MonoBehaviour
{
    public PersonScriptableObject person;

    public string name_;
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    public string[] lines;
    GameObject dialogueBox;
    DialogueBox dialogueBoxScript;
    public bool hasBeenSelected = false;

    GameObject mainState;
    MainState mainStateScript;


    GameObject timer;
    TimerScript timerScript;
    public float timeLeft = 0;

    public bool AlreadySpoken = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Get atributes of specific person
        name_ = person.name;
        sprite = person.sprite;
        lines = person.lines;
        timeLeft = person.timeAtBegin;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        dialogueBox = GameObject.FindWithTag("dialog");
        dialogueBoxScript = dialogueBox.GetComponent<DialogueBox>();

        mainState = GameObject.FindWithTag("MainState");
        mainStateScript = mainState.GetComponent<MainState>();

        timer = GameObject.FindWithTag("Timer");
        timerScript = timer.GetComponent<TimerScript>();


    }

    public void DisplayText()
    {
        dialogueBoxScript.SetPerson(person);
        dialogueBoxScript.StartDialogue();
    }

    public void GrabPerson()
    {

    }

    public void DropPerson()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!AlreadySpoken)
            {
                DisplayText();
                AlreadySpoken = true;
            }



        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBeenSelected)
        {
            // Update the time to die   
            timeLeft -= Time.deltaTime;
            timerScript.timeLeft = timeLeft;

            if(timeLeft < 0)
            {
                mainStateScript.PersonDied(gameObject);
            }
        }
    }
}
