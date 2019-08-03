using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float speed = 2;
    Rigidbody2D rb;
    public bool can_move = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        if (!can_move)
            rb.velocity = Vector2.zero;
    }
    void MovePlayer()
    {
        if (!can_move)
            return;
        float hori = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float verti = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector2 movements = new Vector2(hori, verti);
        rb.velocity = movements;
    }
}