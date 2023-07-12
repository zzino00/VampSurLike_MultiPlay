using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerCharacter[] player;
    public int PlayerNum;

 
    void Awake()
    {
        player = new PlayerCharacter[5];
        instance = this;
    }
}
