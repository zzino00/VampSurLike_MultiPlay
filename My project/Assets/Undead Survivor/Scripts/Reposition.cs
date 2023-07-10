using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
   
    void OnTriggerExit2D(Collider2D Collision)
    {
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
        if(!Collision.CompareTag("Area"))
        {
            return;
        }

        if ()
        {
            Vector3 PlayerPos = GameManager.instance.player[0].transform.position;
            Vector3 myPos = transform.position;
            float DisX = Mathf.Abs(PlayerPos.x - myPos.x);// Abs는 절대값을 구함 음수가 없다
            float DisY = Mathf.Abs(PlayerPos.y - myPos.y);

            Vector3 PlayerDir = GameManager.instance.player[0].InputVec;
            float DirX = PlayerDir.x < 0 ? -1 : 1;
            float DirY = PlayerDir.y < 0 ? -1 : 1;

            Debug.Log(DirX);
            Debug.Log(DirY);
            switch (transform.tag)
            {
                case "Ground":
                    if (DisX > DisY)
                    {
                        transform.Translate(Vector3.right * DirX * 40);// Translate은 이동을 얼마만큼 이동할지 양으로 정한다
                    }
                    else if (DisX < DisY)
                    {
                        transform.Translate(Vector3.up * DirY * 40);//
                    }
                    break;

                case "Enemy":

                    break;
            }
        }






    }
     
    
}
