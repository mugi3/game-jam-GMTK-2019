using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Clue",menuName ="Add New Info" , order = 1)]
[System.Serializable]
public class Clues_SO : ScriptableObject
{
    [TextArea(3, 10)]
    public string dialogue;
    
}
