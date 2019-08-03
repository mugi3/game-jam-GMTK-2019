using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Suspect",menuName ="Add New Suspect",order =2)]
public class Suspects_SO : ScriptableObject
{
    public string suspectName;
    public int suspectId;
    [TextArea(3,10)]
    public string dialogue;
}
