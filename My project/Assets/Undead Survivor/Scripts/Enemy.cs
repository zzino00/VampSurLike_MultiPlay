using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    Rigidbody2D Target;
    bool isLive;
    Rigidbody2D Rigid;
    SpriteRenderer Spriter;


    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Spriter = GetComponent<SpriteRenderer>();
        Speed = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(Target != null) 
        {
            Vector2 dirVec = Target.position - Rigid.position;
            Vector2 NextVec = dirVec.normalized * Speed * Time.fixedDeltaTime;
            Rigid.MovePosition(Rigid.position + NextVec);
            Rigid.velocity = Vector2.zero;
        }
      
    }

    private void LateUpdate()
    {
        if(Target != null) 
        {
            Spriter.flipX = Target.position.x < Rigid.position.x;
        }
      
    }

    public void SetTarget()
    {
        Target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }
}
