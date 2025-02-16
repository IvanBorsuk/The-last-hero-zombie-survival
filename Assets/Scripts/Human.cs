using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{

     Rigidbody2D rb;
    [NonSerialized]public Animator anim;
    SpriteRenderer sp;

    [NonSerialized]public float speed;
    [NonSerialized]public float moveSpeed;

        
    [Header("Charter settings")]
    [SerializeField] float speedCharter;
    [Range(0,100)]
    [SerializeField] int armorCharter;
    [Range(0,100)]
    [SerializeField] int healthCharter;

    [Header("Weapons settings")]
    [SerializeField] int countShot;
    [SerializeField] float distansShot;

    [SerializeField] Transform directionShot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    
    public void Move(Vector3 _diretion, float _speed)
    {

        transform.position += _diretion * _speed * Time.deltaTime;

    }

    public void Shot()
    {
        anim.SetTrigger("shot");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionShot.position,distansShot);
        GL.Begin(GL.LINES);
        for (float i = 0; i < distansShot; ++i)
        {
            float a = i / (float)distansShot;
            float angle = a * Mathf.PI * 2;
            // Vertex colors change from red to green
            GL.Color(new Color(a, 1 - a, 0, 0.8F));
            // One vertex at transform position
            GL.Vertex3(0, 0, 0);
            // Another vertex at edge of circle
            GL.Vertex3(Mathf.Cos(angle) * 3, Mathf.Sin(angle) * 3, 0);
        }
        GL.End();
    }

    public void RotatePlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, directionShot.position);
    }

      

}
