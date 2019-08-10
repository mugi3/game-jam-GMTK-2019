using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspect_script : MonoBehaviour
{
    public Suspects_SO suspect;
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
            DM.DisplayDialogue(suspect.dialogueInitial);
            iniDialgueDone = true;
        }
        else if (iniDialgueDone)
        {
            int i = Random.Range(0, suspect.dialoguelater.Length);
            DM.DisplayDialogue(suspect.dialoguelater[i]);
        }
    }
    public void ClickedMe()
    {
        if (suspect.suspectId == GM.murderer.suspectId)
            DM.DisplayDialogue("Your answer Was Correct. Congratulations");
        else
            DM.DisplayDialogue("Opps You got the wrong person. Murderer was " + GM.murderer.suspectName + "!");


        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

}
