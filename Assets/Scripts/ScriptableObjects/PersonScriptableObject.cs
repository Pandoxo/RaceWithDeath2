using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "People")]
public class PersonScriptableObject : ScriptableObject
{
    public string personName;
    public string[] lines;
    public Sprite sprite;
    public float timeAtBegin;



}
