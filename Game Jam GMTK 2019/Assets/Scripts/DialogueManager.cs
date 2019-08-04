using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Animator dialogboxAnimator;
    public Text dialogueBox;
    GameManager GM;
    public AudioSource audiocl;
    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    public void DisplayDialogue(string dialogue)
    {
        audiocl.Play();
        dialogboxAnimator.SetTrigger("DBoxIn");
        StopAllCoroutines();
        StartCoroutine(TypeDialogue(dialogue));
    }
    IEnumerator TypeDialogue(string dialogueToDisplay)
    {
        dialogueBox.text = "";
        bool done = false;
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in dialogueToDisplay.ToCharArray())
        {
            dialogueBox.text += letter;
            yield return null;
        }
        while(!done)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                done = true;
                EndDialogue();
            }
            yield return null;
        }
    }
    public void EndDialogue()
    {
        StopAllCoroutines();
        dialogboxAnimator.SetTrigger("DBoxOut");
        GM.DialogueBoxIsOn = false;
    }
}