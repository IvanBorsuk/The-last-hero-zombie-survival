using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    Human human;




    

    void Awake()
    {
        player = this;
    }


    void Start()
    {
        human = GetComponent<Human>();
    }

    
    void Update()
    {
        human.moveSpeed = Mathf.Abs(Input.GetAxis("Horizontal"))+Mathf.Abs(Input.GetAxis("Vertical"));
        human.anim.SetFloat("speed",human.moveSpeed);
        human.RotatePlayer();
        if(Input.GetKey("w"))
        {
            human.Move(Vector3.up, human.speedCharter);
        }
        if(Input.GetKey("s"))
        {
            human.Move(Vector3.down, human.speedCharter);
        }
        if(Input.GetKey("a"))
        {
            human.Move(Vector3.left, human.speedCharter);
        }
        if (Input.GetKey("d"))
        {
            human.Move(Vector3.right, human.speedCharter);
        }
        if (Input.GetMouseButtonDown(0))
        {
            human.Shot();
        }
    }

    
}
