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
    public GameManager GM;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DM = GameObject.FindObjectOfType<DialogueManager>();
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= 1.2f)
        {
            can_interact = true;
        }
        else can_interact = false;

        if (can_interact && Input.GetKeyDown(KeyCode.E) && !GM.DialogueBoxIsOn)
        {
            StartDialogue();
            GM.DialogueBoxIsOn = true;
        }

    }
    void StartDialogue()
    {
        if (!iniDialgueDone)
        {
            if (clue.activeName == null)
            {
                DM.DisplayDialogue(clue.dialogueInitial);
                iniDialgueDone = true;
                GM.clueInfoPanel.Add(clue);
            }
            else
            {
                DM.DisplayDialogue(clue.dialogueInitialActive);
                iniDialgueDone = true;
                GM.clueInfoPanel.Add(clue);
            }
        }
        else if(iniDialgueDone)
        {
            int i = Random.Range(0, clue.dialoguelater.Length);
            DM.DisplayDialogue(clue.dialoguelater[i]);
        }
    }

}
