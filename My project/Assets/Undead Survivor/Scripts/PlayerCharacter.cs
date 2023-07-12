using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCharacter : MonoBehaviourPunCallbacks, IPunObservable
{
    Rigidbody2D Rigid;
    public float speed;
    public Vector2 InputVec;

    SpriteRenderer Spriter;
    //public Text NickNameText;
    Animator Anim;
    public PhotonView PV;
    GameObject Center;
    Vector2 NextVec;
    public float MoveLimitX;
    public float MoveLimitY;

    void Awake()
    {
       // NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        Rigid = GetComponent<Rigidbody2D>();
        Spriter = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        Center = GameObject.Find("Center");
        NextVec = Vector2.zero;
        MoveLimitX = 15.5f;
        MoveLimitY = 13.5f;
    }

   

   void Update()
    {
    
        float axis = Input.GetAxisRaw("Horizontal");

       
        if (PV.IsMine)
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
        // 컴퓨터 성능에 상관없이 속도를 일정하게 하기위해 fixedDeltaTime사용, Normalize는 InputSystem에서 자체적으로 제공하기 때문에 사용할필요없음
        NextVec += InputVec * speed * Time.fixedDeltaTime;

        NextVec.x = Mathf.Clamp(NextVec.x, Center.transform.position.x - MoveLimitX, Center.transform.position.x + MoveLimitX);
        NextVec.y = Mathf.Clamp(NextVec.y, Center.transform.position.y - MoveLimitY, Center.transform.position.y + MoveLimitY);
        if (PV.IsMine)
        {
            

            transform.position = NextVec;
        }
      

       // Rigid.MovePosition(Rigid.position + NextVec);
        
    }

    [PunRPC]
    void Flip(float  axis)
    {
            Spriter.flipX = axis == -1; // InputVe.x<0의 반환값이 바로 flipX에 들어감
    }

   
    void OnMove(InputValue Value)
    {
        InputVec = Value.Get<Vector2>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
    }
}

