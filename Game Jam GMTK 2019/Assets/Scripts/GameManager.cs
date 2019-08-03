using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region Declaration
    public SpawnPoint[] SpawnPoints;
    public List<GameObject> Spawnables;
    public List<GameObject> Spawns;
    public List<Clues_SO> Clues;
    public Suspects_SO murderer;
    public List<Suspects_SO> Suspects;
    public Movements playerMovements;
    public DialogueManager DM;

    //Final Phase Declare
    public GameObject final_screen;
    public bool DialogueBoxIsOn = false;
    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovements = GameObject.FindObjectOfType<Movements>();
        playerMovements.can_move = false;
        DM = GameObject.FindObjectOfType<DialogueManager>();
        murderer = Suspects[Random.Range(0,Suspects.Count)];
        Debug.Log(murderer.name);
        Debug.Log(murderer.suspectName);
        Debug.Log(murderer.suspectId);
        SpawnStuff();
    }
    #region Spawning
    public void SpawnStuff()
    {
        foreach (GameObject spawnable in Spawnables)
        {
            bool done = false;
            while (!done)
            {
                int i = Random.Range(0, SpawnPoints.Length - 1);
                if(SpawnPoints[i].vacant)
                {
                    GameObject go = Instantiate(spawnable, SpawnPoints[i].gameObject.transform.position,Quaternion.identity);
                    Spawns.Add(go);
                    SpawnPoints[i].vacant = false;
                    done = true;
                }
            }
        }
        Debug.Log(Spawns.Count);
    }
    #endregion
    public void InitiateFinalPhase()
    {
        playerMovements.can_move = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        final_screen.SetActive(true);
    }
}
