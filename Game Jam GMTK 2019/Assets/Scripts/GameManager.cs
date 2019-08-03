using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public SpawnPoint[] SpawnPoints;
    public List<GameObject> Spawnables;
    public List<Clues_SO> Clues;
    public Suspects_SO murderer;
    public List<Suspects_SO> Suspects;
    public Movements playerMovements;
    public DialogueManager DM;
    public List<GameObject> Spawns;
    public bool DialogueBoxIsOn = false;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        playerMovements = GameObject.FindObjectOfType<Movements>();
        DM = GameObject.FindObjectOfType<DialogueManager>();
        murderer = Suspects[Random.Range(0,Suspects.Count)];
        Debug.Log(murderer.name);
        Debug.Log(murderer.suspectName);
        Debug.Log(murderer.suspectId);
        SpawnStuff();
    }
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
}
