using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Target;

    bool isLive;
    Rigidbody2D Rigid;
    SpriteRenderer Spriter;


    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Spriter = GetComponent<SpriteRenderer>();   
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
