using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Photon.Pun.UtilityScripts;

public class PhotonTest : MonoBehaviourPunCallbacks
{
    TMP_InputField m_InputField;
    TextMeshProUGUI m_textConnectLog;
    TextMeshProUGUI m_textPlayerList;
    public GameObject DisconnectPanel;
    public Follow F_Camera;
    public GameManager GameManager;
    GameObject TPlayer;
    
   // TextMeshProUGUI NickNameText;
  
    void Awake()
    {
        Screen.SetResolution(960, 600, false); // PC 실행 시 해상도 설정
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        m_InputField = GameObject.Find("Canvas/DisconnectPanel/InputField").GetComponent<TMP_InputField>();
        m_textPlayerList = GameObject.Find("Canvas/TextPlayerList").GetComponent<TextMeshProUGUI>();
        m_textConnectLog = GameObject.Find("Canvas/TextConnectLog").GetComponent<TextMeshProUGUI>();
       // NickNameText = m_InputField.GetComponent<TextMeshProUGUI>();
        m_textConnectLog.text = "Log\n";
        PhotonNetwork.AuthValues = new Photon.Realtime.AuthenticationValues();
        GameManager.PlayerNum = 0;
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions(); // 방옵션설정
        options.MaxPlayers = 5; // 최대인원 설정
        PhotonNetwork.LocalPlayer.NickName = m_InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null); // 방이 있으면 입장하고 
                                                                // 없다면 방을 만들고 입장합니다.
    }

    public override void OnJoinedRoom()
    {
        updatePlayer();
        m_textConnectLog.text += m_InputField.text;
        m_textConnectLog.text += " Join the Room.\n";
        DisconnectPanel.SetActive(false);
        Spawn();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        updatePlayer();
        m_textConnectLog.text += newPlayer.NickName;
        m_textConnectLog.text += " Entered.\n";
      

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        updatePlayer();
        m_textConnectLog.text += otherPlayer.NickName;
        m_textConnectLog.text += " Leaved.\n";
    }

    public void Connect()
    {
     
        PhotonNetwork.ConnectUsingSettings();
    }
    public void Spawn()
    {
        TPlayer = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        F_Camera.FindPlayer();
        GameManager.player[GameManager.PlayerNum] = TPlayer.GetComponent<PlayerCharacter>();
        Debug.Log("PlayerNum: "+ GameManager.PlayerNum);
        GameManager.PlayerNum++;
        


    }

    void updatePlayer()
    {
        m_textPlayerList.text = "PlayerList";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            m_textPlayerList.text += "\n";
            m_textPlayerList.text += PhotonNetwork.PlayerList[i].NickName;
         
        }
    }

}