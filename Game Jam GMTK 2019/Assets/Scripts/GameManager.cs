using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region Declaration
    public List<Clues_SO> clueInfoPanel;
    public GameObject InfoPanel;
    bool infoPanelIsActive = false;

    public SpawnPoint[] SpawnPoints;
    public List<GameObject> Spawnables;
    public List<GameObject> Spawns;
    public List<Clues_SO> Clues;
    public int[] possibleClues;
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
        foreach (Clues_SO clue in Clues)
        {
            clue.activeName = null;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovements = GameObject.FindObjectOfType<Movements>();
        playerMovements.can_move = false;
        DM = GameObject.FindObjectOfType<DialogueManager>();
        AssignMurderer();
        Debug.Log(murderer.suspectName);
        foreach (Clues_SO clue in Clues)
        {
            Debug.Log(clue.objectName);
        }

        SpawnStuff();


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !infoPanelIsActive)
        {
            InfoPanel.SetActive(true);
            infoPanelIsActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && infoPanelIsActive)
        {
            InfoPanel.SetActive(false);
            infoPanelIsActive = false;
        }

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
                if (SpawnPoints[i].vacant)
                {
                    GameObject go = Instantiate(spawnable, SpawnPoints[i].gameObject.transform.position, Quaternion.identity);
                    Spawns.Add(go);
                    SpawnPoints[i].vacant = false;
                    done = true;
                }
            }
        }
    }
    #endregion
    public void InitiateFinalPhase()
    {
        playerMovements.can_move = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        final_screen.SetActive(true);
    }
    #region Assigning The Murderer and Clues
    public void AssignMurderer()
    {
        murderer = Suspects[Random.Range(0, Suspects.Count)];

        for (int i = 0; i < 3; i++)
        {
            possibleClues[i] = murderer.possibleCluesId[i];
            switch(possibleClues[i])
            {
                case 101:
                    {
                        foreach(Clues_SO clue in Clues)
                        {
                            if(clue.objectId == 101)
                            {
                                clue.activeName = "Empty Poison container";
                            }
                        }
                        break;
                    }
                case 102:
                    {
                        foreach (Clues_SO clue in Clues)
                        {
                            if (clue.objectId == 102)
                            {
                                clue.activeName = "Perfume with Blood on it";
                            }
                        }
                        break;
                    }
                case 103:
                    {
                        foreach (Clues_SO clue in Clues)
                        {
                            if (clue.objectId == 103)
                            {
                                clue.activeName = "Empty Wine Glass with Blood on it";
                            }
                        }
                        break;
                    }
                case 104:
                    {
                        foreach (Clues_SO clue in Clues)
                        {
                            if (clue.objectId == 104)
                            {
                                clue.activeName = "Recently used Rope";
                            }
                        }
                        break;
                    }
                case 105:
                    {
                        foreach (Clues_SO clue in Clues)
                        {
                            if (clue.objectId == 105)
                            {
                                clue.activeName = "Knife with blood on it";
                            }
                        }
                        break;
                    }
                case 106:
                    {
                        foreach (Clues_SO clue in Clues)
                        {
                            if (clue.objectId == 106)
                            {
                                clue.activeName = "Mr. Sunflower's Coat with Blood on it";
                            }
                        }
                        break;
                    }
                case 107:
                    {
                        foreach (Clues_SO clue in Clues)
                        {
                            if (clue.objectId == 107)
                            {
                                clue.activeName = "Red Wine Bottle with stench of poison";
                            }
                        }
                        break;
                    }
            }
        }
        
    }
    #endregion
}
