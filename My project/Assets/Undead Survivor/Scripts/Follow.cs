using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    GameObject Center;
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
            Center = GameObject.Find("Center");
            Vector3 targetPos = new Vector3(Target.position.x, Target.position.y, this.transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, Center.transform.position.x-10, Center.transform.position.x + 10);
            targetPos.y = Mathf.Clamp(targetPos.y, Center.transform.position.y - 10, Center.transform.position.y + 10);
            transform.position = new Vector3(targetPos.x, targetPos.y, -10.0f);

        }
        

    }
}
