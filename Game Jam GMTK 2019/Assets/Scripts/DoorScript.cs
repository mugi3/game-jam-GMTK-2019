using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform teleportTo;
    public GameObject player;
    public Animator fade_Screen;
    GameManager GM;
  //  public bool can_teleport = false;
    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TeleportPlayer());
       // can_teleport = true;
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.E) && can_teleport)
        //{
        //    StartCoroutine(TeleportPlayer());
        //}
    }
    IEnumerator TeleportPlayer()
    {
        fade_Screen.SetTrigger("FadeIn");
        GM.playerMovements.can_move = false;
        yield return new WaitForSeconds(1);
        player.transform.position = teleportTo.transform.position;
        fade_Screen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(.6f);
        GM.playerMovements.can_move = true;
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    can_teleport = false;
    //}
}
