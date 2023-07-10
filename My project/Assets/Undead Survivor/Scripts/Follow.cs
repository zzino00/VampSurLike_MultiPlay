using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    
    public void FindPlayer()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            transform.position = Target.position + offset;
        }
        
    }
}
