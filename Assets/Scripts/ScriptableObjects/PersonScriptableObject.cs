using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "People")]
public class PersonScriptableObject : ScriptableObject
{
    public string Name;
    public string[] lines;
    public Sprite sprite;



}
