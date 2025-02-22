using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Human : MonoBehaviour
{

     Rigidbody2D rb;
    [NonSerialized]public Animator anim;
    SpriteRenderer sp;

        
    [Header("Charter settings")]
    public float speedCharter;
    [NonSerialized] public float moveSpeed;
    [Range(0,100)]
    [SerializeField] int armorCharter;
    [Range(0,100)]
    [SerializeField] int healthCharter;

    [Header("Weapons settings")]
    [NonSerialized] public int countShot;
    [SerializeField] int ammunition;
    [SerializeField] float distansShot;
    [SerializeField] float timeReloadingWeapon;
    [SerializeField] Transform directionShot;

    

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        countShot = ammunition;
    }

    
    public void Move(Vector3 _diretion, float _speed)
    {

        transform.position += _diretion * _speed * Time.deltaTime;

    }

    public void Shot()
    {

        if(countShot != 0)
        {
            anim.SetTrigger("shot");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionShot.position, distansShot);
            Debug.DrawLine(transform.position, directionShot.position);
            countShot--;
            if(countShot == 0)
            {
                Debug.Log("Reloading...");
                StartCoroutine("WeaponsReload");
            }
            if(hit.collider != null && hit.collider.tag == "zombie")
            {
                Debug.Log("Is shot");
            }
        }
       
    }

    public void RotatePlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    public IEnumerator WeaponsReload()
    {
        yield return new WaitForSeconds(timeReloadingWeapon);
        {
            countShot=ammunition;
            Debug.Log("Reload is done");
        }
    }
  

}
