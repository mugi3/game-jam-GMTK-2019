using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
    public float distance;
    public bool iniDialgueDone = false;
    public bool can_interact = false;
    public GameObject player;
    public DialogueManager DM;
    public GameManager GM;
    [TextArea(3,10)]
    public string[] startingDialogue;
    [TextArea(3, 10)]
    public string endDialogue;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DM = GameObject.FindObjectOfType<DialogueManager>();
        GM = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(StartGame());
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
            GM.DialogueBoxIsOn = true;
            GM.InitiateFinalPhase();
        }
    }
    IEnumerator StartGame()
    {
        int i = 0;
        while (i<=startingDialogue.Length - 1)
        {
            bool done = false;
            DM.DisplayDialogue(startingDialogue[i]);
            i++;
            while (!done)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    done = true;
                }
                yield return null;
            }
        }
        GM.playerMovements.can_move = true;
        yield return null;
    }
}
