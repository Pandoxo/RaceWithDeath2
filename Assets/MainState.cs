using UnityEngine;


public class MainState : MonoBehaviour
{
    public int peopleSaved = 0;
    public int peopleDied = 0;
    private const int peopleTotal = 10;
    private const int peopleDiedGameOverCondition = 3;
    public Person_[] peopleObjects = {};
    private Person_ currentPerson;

    public bool hasWon()
    {
        if(peopleSaved > peopleTotal - peopleDiedGameOverCondition )
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

    }

    public void PersonSaved()
    {
        Debug.Log(peopleSaved);
        peopleSaved++;
    }

    public void PersonDied()
    {
        peopleDied++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {

        if(hasWon())
        {
            // We win

        }
        else if(hasLost())
        {
            // We loose
        }


    }
}
