using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueScript : MonoBehaviour
{
    public Clues_SO clue;
    public float distance;
    public bool iniDialgueDone = false;
    public bool can_interact = false;
    public GameObject player;
    public DialogueManager DM;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DM = GameObject.FindObjectOfType<DialogueManager>();
    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= 1.2f)
        {
            can_interact = true;
        }
        else can_interact = false;

        if(can_interact && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }

    }
    void StartDialogue()
    {
        if (!iniDialgueDone)
        {
            DM.DisplayDialogue(clue.dialogueInitial);
            iniDialgueDone = true;
        }
        else if(iniDialgueDone)
        {
            int i = Random.Range(0, clue.dialoguelater.Length);
            DM.DisplayDialogue(clue.dialoguelater[i]);
        }
    }

}
