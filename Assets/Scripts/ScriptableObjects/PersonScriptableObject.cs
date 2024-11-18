using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "People")]
public class PersonScriptableObject : ScriptableObject
{
    public string name;
    public string[] lines;
    public Sprite sprite;



}
