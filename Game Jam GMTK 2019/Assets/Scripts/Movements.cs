using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float speed = 2;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float verti = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector2 movements = new Vector2(hori,verti);
        //transform.Translate(hori, verti, 0);
        rb.velocity = movements;
    }
}
