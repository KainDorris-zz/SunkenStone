using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int playerLevel;
    public int playerGold;
    public ArrayList playerProgression;

    //Constructor, takes data from save system and jams it in there
    public PlayerData (Player player){
        playerLevel = player.GetLevel();
        playerGold = player.GetGold();

    }
}
