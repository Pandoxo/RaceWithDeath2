using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI textComponent;
    public PersonScriptableObject character;

    public float textSpeed;
    private int index;
    private Coroutine autoAdvanceCoroutine; // Store the coroutine to reset if necessary

    public void SetPerson(PersonScriptableObject person)
    {
        Debug.Log(person.personName);
        character = person;
        nameTMP.text = person.personName;
        textComponent.text = string.Empty;
    }

    void Update()
    {
        if (character == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == character.lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = character.lines[index];
                RestartAutoAdvance(); // Reset the auto-advance timer
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty; // Clear text before typing
        foreach (char c in character.lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Start the auto-advance timer after typing finishes
        StartAutoAdvance();
    }

    void NextLine()
    {
        if (index < character.lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StopAutoAdvance(); // Stop any existing auto-advance timer
            StartCoroutine(TypeLine());
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            StopAutoAdvance(); // Stop auto-advance when dialogue ends
        }
    }

    void StartAutoAdvance()
    {
        // Start a coroutine to call NextLine after 3 seconds
        autoAdvanceCoroutine = StartCoroutine(AutoAdvance());
    }

    void StopAutoAdvance()
    {
        // Stop the coroutine if it's running
        if (autoAdvanceCoroutine != null)
        {
            StopCoroutine(autoAdvanceCoroutine);
            autoAdvanceCoroutine = null;
        }
    }

    void RestartAutoAdvance()
    {
        // Reset the auto-advance timer
        StopAutoAdvance();
        StartAutoAdvance();
    }

    IEnumerator AutoAdvance()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        NextLine(); // Automatically progress to the next line
    }
}

