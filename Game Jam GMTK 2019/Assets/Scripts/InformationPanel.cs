using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{

    public List<Clues_SO> InfoList;
    public Text preb;
    public List<GameObject> infolistGameObjects;
    public Clues_SO test;
    public Transform parent;
    public GameManager GM;
    private void Awake()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {
        Debug.Log(InfoList.Count);
        UpdateUI();
        
    }
    public void UpdateUI()
    {
        if (GM.clueInfoPanel == null)
            return;
       
        foreach (Clues_SO cluefound in GM.clueInfoPanel)
        {
            InfoList.Add(cluefound);
        }
        if (InfoList == null)
            return;
        foreach (Clues_SO clues in InfoList)
        {
            Text temp;
            temp = Instantiate(preb, parent);
            temp.text = clues.objectName;
            infolistGameObjects.Add(temp.gameObject);
        }
    }
    private void OnDisable()
    {
        if (InfoList == null)
            return;
        InfoList.Clear();
        foreach(GameObject infogameob in infolistGameObjects)
        {
            Destroy(infogameob);
        }
        infolistGameObjects.Clear();
        Debug.Log(InfoList.Count);
        Debug.Log("List Cleared");

    }

}
