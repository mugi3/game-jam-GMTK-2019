using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    [Range(0,1)]
    public float followSpeed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector2 cameraMovements= Vector2.Lerp(transform.position, player.transform.position, followSpeed);
        transform.position = cameraMovements;
    }
}
