using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public List<Clues_SO> Clues;
    public List<Suspects_SO> Suspects;
    public Movements playerMovements;
    public DialogueManager DM;
    private void Start()
    {
        playerMovements = GameObject.FindObjectOfType<Movements>();
        DM = GameObject.FindObjectOfType<DialogueManager>();
    }
}
