
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
    public Person character;
    public float textSpeed;
    private int index;


    public void SetPerson(Person person)
    {
        character = person;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      name.text = character.name;
      textComponent.text = string.Empty;
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
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
        gameObject.SetActive(false);
      }
    }

}
