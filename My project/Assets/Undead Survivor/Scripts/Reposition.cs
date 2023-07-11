using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{

    Vector3 PlayerPos;
    Vector3 myPos;
    Vector3 PlayerDir;
    public PhotonView PV;

    void OnTriggerExit2D(Collider2D Collision)
    {
        if (!Collision.CompareTag("Area"))
        {
            return;
        }

        PV.RPC("MoveMap", RpcTarget.AllBuffered);
    }


    [PunRPC]
    void MoveMap()
    {
        if (GameManager.instance.player[0] != null)
        {
            if (GameManager.instance.player[0] == PhotonNetwork.IsMasterClient)
            {
                PlayerPos = GameManager.instance.player[0].transform.position;
                PlayerDir = GameManager.instance.player[0].InputVec;
            }
            else if (GameManager.instance.player[0] != PhotonNetwork.IsMasterClient)
            {
                PlayerPos = new Vector3(0, 0, 0);
                PlayerDir = new Vector3(0, 0, 0);
            }
        }

        myPos = transform.position;
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
       

        float DisX = Mathf.Abs(PlayerPos.x - myPos.x);// Abs는 절대값을 구함 음수가 없다
        float DisY = Mathf.Abs(PlayerPos.y - myPos.y);
        float DirX = PlayerDir.x < 0 ? -1 : 1;
        float DirY = PlayerDir.y < 0 ? -1 : 1;


        switch (transform.tag)
        {
            case "Ground":
                if (DisX > DisY)
                {
                    transform.Translate(Vector3.right * DirX * 40);// Translate은 이동을 얼마만큼 이동할지 양으로 정한다
                    Debug.Log("Move Distance:" + (Vector3.right * DirX * 40));
                }
                else if (DisX < DisY)
                {
                    transform.Translate(Vector3.up * DirY * 40);//
                    Debug.Log("Move Distance:" + (Vector3.up * DirY * 40));
                }
                break;

            case "Enemy":

                break;
        }

    }


}   
   






   
     
    

