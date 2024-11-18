using System.Collections.Specialized;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Person_ : MonoBehaviour
{
    public PersonScriptableObject person;

    string name_;
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    public string[] lines;
    GameObject dialogueBox;
    DialogueBox dialogueBoxScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        name_ = person.name;
        sprite = person.sprite;
        lines = person.lines;
        spriteRenderer = GetComponent<SpriteRenderer>();   
        spriteRenderer.sprite = sprite;
        dialogueBox = GameObject.FindWithTag("dialog");
        dialogueBoxScript = dialogueBox.GetComponent<DialogueBox>();


    }

    public void DisplayText()
    {
        dialogueBoxScript.SetPerson(person);
        dialogueBoxScript.StartDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            DisplayText();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
