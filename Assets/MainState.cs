using UnityEngine;
using System;

public class MainState : MonoBehaviour
{
    public int peopleSaved = 0;
    public int peopleDied = 0;
    private const int peopleTotal = 10;
    private const int peopleDiedGameOverCondition = 1;
    public Person_[] peopleObjects = {};
    public GameObject YouLostScreen;
    public GameObject YouWinScreen;


    private Person_ currentPerson;

    public bool hasWon()
    {
        if(getPeopleToSaveCount() <= 0 )
        {
            return true;
        }
        return false;
    }

    public bool hasLost()
    {
        if(peopleDied >= peopleDiedGameOverCondition )
        {
            return true;
        }
        return false;
    }

    public void addAnotherPerson()
    {
        int limit = 0;
        // Find a new person that wasn't selected before'
        do
        {
            System.Random rnd = new System.Random();
            int randomIndex = rnd.Next(0, peopleObjects.Length);
            currentPerson = peopleObjects[randomIndex];
            limit++;
        }
        while(currentPerson.hasBeenSelected && limit < 20);

        // Select it
        currentPerson.hasBeenSelected = true;
        Debug.Log(currentPerson.name_);



        currentPerson.gameObject.SetActive(true);
        Debug.Log(currentPerson.name_);
    }

    public void PersonSaved(GameObject person)
    {
        Debug.Log(peopleSaved);

        peopleSaved++;
        Destroy(person);
        if (hasWon())
        {
            DispalyWinScreen();
        }
        addAnotherPerson();
        
    }

    public void PersonDied(GameObject person)
    {
        peopleDied++;
        Destroy(person);
        if (hasLost())
        {
            DispalyLooseScreen();
        }
        addAnotherPerson();

    }

    public int getPeopleToSaveCount()
    {
        return peopleTotal - peopleDiedGameOverCondition - peopleSaved;
    }

    void DispalyWinScreen()
    {
        YouWinScreen.SetActive(true);
    }
    void DispalyLooseScreen()
    {
        YouLostScreen.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addAnotherPerson();
    }




    // Update is called once per frame
    void Update()
    {

        // if(hasWon())
        // {
        //     // We win

        // }
        // else if(hasLost())
        // {
        //     // We loose
        // }


    }
}
