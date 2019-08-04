using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Clue",menuName ="Add New Clue" , order = 1)]
[System.Serializable]
public class Clues_SO : ScriptableObject
{
    public string objectName;
    public string activeName;
    public int objectId;
    [TextArea(3, 10)]
    public string dialogueInitial;
    [TextArea(3, 10)]
    public string dialogueInitialActive;
    [TextArea(3, 10)]
    public string[] dialoguelater;

}
