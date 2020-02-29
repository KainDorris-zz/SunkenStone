using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{

    //configs, where to save the data at for each element
    public static string playerSavePath = Application.persistentDataPath + "/player.state";


    //Save player function,
    // Takes a player object that asumes some data points
    // Creates a binary formatter to save the data
    // Opens the file stream to write to a file at the specified path
    // Converts the data into binary and then writes it to the file
    //Closes the stream because that's what Brackey's told me
    public static void SavePlayer(Player player){
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerSavePath, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();




    }


    //PlayerLoad function
    //Does basically the same as the save function but opens the file and reads from it. 
    //Hands data to the PlayerData Constructor function since it's static and can be called from there (player data script)
    public static PlayerData LoadPlayer(){
        if(File.Exists(playerSavePath)){
            BinaryFormatter formatter = new BinaryFormatter;
            FileStream stream = new FileStream(playerSavePath, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
            
        }
        else{
            Debug.LogError("Save file not found at" + playerSavePath);
            return null;
        }

    }
    
}
