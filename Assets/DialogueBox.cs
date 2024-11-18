
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
using TMPro;



public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI textComponent;
    public PersonScriptableObject character;
    Transform transform;
    public float textSpeed;
    private int index;


    public void SetPerson(PersonScriptableObject person)
    {
        
        character = person;
        name.text = person.name;
        textComponent.text = string.Empty;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && character != null)
        {
          if(textComponent.text == character.lines[index])
          {
            NextLine();
          }
          else
          {
            StopAllCoroutines();
            textComponent.text = character.lines[index];
          }
        }
    }


    public void StartDialogue()
    {
      index = 0;
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
      StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
      foreach(char c in character.lines[index].ToCharArray())
      {
        textComponent.text += c;
        yield return new WaitForSeconds(textSpeed);
      }
    }

    void NextLine()
    {
      if (index < character.lines.Length - 1)
      {
        index++;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
      }
      else
      {
        
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
      }
    }

}
