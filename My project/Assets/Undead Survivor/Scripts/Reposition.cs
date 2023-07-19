using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;
    Vector3 PlayerPos;
    Vector3 myPos;
    Vector3 PlayerDir;
    public PhotonView PV;
    PhotonTest photonTest;
    GameObject Area;
    GameObject Center;
    public MapCenter MapCenter;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D Collision)
    {
     
        if (!Collision.CompareTag("Area"))
        {
            return;
        }
        Area = Collision.gameObject;

        Debug.Log(Area.transform.parent.gameObject);

        if (GameManager.instance.player[0] != null)
        {
            if (Area.transform.parent.gameObject == GameManager.instance.player[0].gameObject)
            {
                PlayerPos = GameManager.instance.player[0].transform.position;
                PlayerDir = GameManager.instance.player[0].InputVec;
                Debug.Log("MasterClient Triggered");
            }
            else
            {
                PlayerPos = new Vector3(0, 0, 0);
                PlayerDir = new Vector3(0, 0, 0);
                Debug.Log("Client Triggered");
            }
        }

        myPos = transform.position;
    


        float DisX = Mathf.Abs(PlayerPos.x - myPos.x);// Abs�� ���밪�� ���� ������ ����
        float DisY = Mathf.Abs(PlayerPos.y - myPos.y);
        float DirX = PlayerDir.x < 0 ? -1 : 1;
        float DirY = PlayerDir.y < 0 ? -1 : 1;

    
      
            Center = GameObject.Find("Center");
        
       

        



        switch (transform.tag)
        {
            case "Ground":

                if (Area.transform.parent.gameObject == GameManager.instance.player[0].gameObject)
                {

                    if (DisX > DisY)
                    {
                        transform.Translate(Vector3.right * DirX * 40);// Translate�� �̵��� �󸶸�ŭ �̵����� ������ ���Ѵ�
                        Center.transform.Translate(Vector3.right * DirX * 10);
                        Debug.Log("Move Distance:" + (Vector3.right * DirX * 40));
                    }
                    else if (DisX < DisY)
                    {
                        transform.Translate(Vector3.up * DirY * 40);//
                        Center.transform.Translate(Vector3.up * DirY * 10);
                        Debug.Log("Move Distance:" + (Vector3.up * DirY * 40));
                    }
                }

                break;

            case "Enemy": // Enemy�� �ʹ����� ������� �÷��̾� ��ó�� ������ġ�� �̵� 
                if (coll.enabled)
                {
                    transform.Translate(PlayerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));                
                }
                break;
        }

    }

}


  
   






   
     
    

