using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Clues_SO> Clues;
    private void Start()
    {
        ListAllClues();
    }
    public void ListAllClues()
    {
        foreach (Clues_SO clue in Clues)
        {
            Debug.Log(clue.dialogue);
        }
    }
}
