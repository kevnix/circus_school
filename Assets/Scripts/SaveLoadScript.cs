using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveLoadScript : MonoBehaviour
{
    string saveFileName = "saveFile.json";

    [Serializable]
    public class GameData
    {
        public int characterIndex;
        public string playerName;
        //Other stats
    }

    private GameData gameData = new GameData();

    public void SaveGame(int character, string name)
    {
        gameData.characterIndex = character;
        gameData.playerName = name;

        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/" + saveFileName, json);

        Debug.Log("Game saved to: " + Application.persistentDataPath + "/" + saveFileName);
    }

    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;

        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Game loaded from: " + filePath + "\nCharacter index: " + gameData.characterIndex + "\nPlayer name: " + gameData.playerName);
        }
        else
        {
            Debug.LogError("Save file not found in: " + filePath);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
