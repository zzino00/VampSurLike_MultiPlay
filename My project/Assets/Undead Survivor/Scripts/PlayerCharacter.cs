using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class PlayerCharacter : MonoBehaviourPunCallbacks, IPunObservable
{
    Rigidbody2D Rigid;
    public float speed;
    public Vector2 InputVec;

    SpriteRenderer Spriter;
    //public Text NickNameText;
    Animator Anim;
    public PhotonView PV;
    void Awake()
    {
       // NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        Rigid = GetComponent<Rigidbody2D>();
        Spriter = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>(); 
    }

   void Update()
    {

        float axis = Input.GetAxisRaw("Horizontal");
      
        if(PV.IsMine)
        {
            if(InputVec.x !=0)
            {
                Anim.SetFloat("Speed", InputVec.magnitude);
                PV.RPC("Flip", RpcTarget.AllBuffered, axis);
            }
          
        }
       
    }
    void FixedUpdate()
    {
        // ��ǻ�� ���ɿ� ������� �ӵ��� �����ϰ� �ϱ����� fixedDeltaTime���, Normalize�� InputSystem���� ��ü������ �����ϱ� ������ ������ʿ����
        Vector2 NextVec = InputVec* speed * Time.fixedDeltaTime;
        Rigid.MovePosition(Rigid.position + NextVec);
    }

    [PunRPC]
    void Flip(float  axis)
    {
            Spriter.flipX = axis == -1; // InputVe.x<0�� ��ȯ���� �ٷ� flipX�� ��
    }

    void OnMove(InputValue Value)
    {
        InputVec = Value.Get<Vector2>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
    }
}

