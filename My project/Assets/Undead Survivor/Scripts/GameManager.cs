using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerCharacter[] player;
    public int PlayerNum;

    public void FindPlayer()
    {
        if(PlayerNum<player.Length)
        {
            player[PlayerNum] = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
        }
      
    }
    void Awake()
    {
     
        instance = this;
    }
}
