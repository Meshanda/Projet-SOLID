using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;
using Debug = UnityEngine.Debug;

public class SaveSystem : MonoBehaviour
{
    private static Stopwatch _stopWatch = new Stopwatch();
    [SerializeField] private GameObject levelPrefab;
    
    [Header("Events to raise")]
    [SerializeField] private GameStateEvent finishSaveEvent;
    [SerializeField] private GameStateEvent finishLoadEvent;
    
    [Header("Save File")] 
    [SerializeField] private string saveFilePath;
    [SerializeField] private string saveFileExtension;
    [SerializeField] private string saveFileName;

    [Header("Scriptable Objects")] 
    [SerializeField] private PlayerClasses playerClasses;
    [SerializeField] private PlayerDirections playerDirections;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerNames playerNames;
    [SerializeField] private PlayerPositions playerPositions;
    [SerializeField] private Tiles tilesPositions;
    
    
    public async void SaveData()
    {  
        SaveData data = GetData();
        
        await WriteData(data);

        StartCoroutine(TestCoroutine(finishSaveEvent));
    }

    public async void LoadData()
    {
        SaveData data = await ReadData();
        EmptyData();
        RecreateData(data);
        ReloadGame();
        
        StartCoroutine(TestCoroutine(finishLoadEvent));
    }

    private void ReloadGame()
    {
        DestroyGame();
        //TODO Replace this Instantiate with a RecreateMapAtGivenPos and RecreatePlayerAtGivenPos scripts
        Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
    }

    private void DestroyGame()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Game");
        foreach (var obj in gameObjects)
        {
            Destroy(obj);
        }
    }

    private void EmptyData()
    {
        playerClasses.PlayerClassesList.Clear();
        playerDirections.Directions.Clear();
        playerHealth.MaxHealth = 0;
        playerHealth.PlayerHealthList.Clear();
        playerNames.Names.Clear();
        playerPositions.SetPositionList(new List<Vector2Int>());
        tilesPositions.TileList.Clear();
    }

    private void RecreateData(SaveData data)
    {
        for (int i = 0; i < data.ListPlayerClasses.Count; i++)
        {
            var stringClass = data.ListPlayerClasses;
            foreach (var playerClass in playerClasses.AvailableClasses)
            {
                if (stringClass[i] == playerClass.name)
                {
                    playerClasses.PlayerClassesList.Add(playerClass);
                }
            }
        }

        playerDirections.Directions = data.ListPlayerDirections;
        playerHealth.MaxHealth = data.MaxHealth;
        playerHealth.PlayerHealthList = data.ListPlayerHealth;
        playerNames.Names = data.ListPlayerNames;
        playerPositions.SetPositionList(data.ListPlayerPositions);
        tilesPositions.TileList = data.ListTilePositions;
    }

    private async Task<SaveData> ReadData()
    {
        var data = new SaveData();
        
        string directoryPath = Path.Combine(Application.persistentDataPath, saveFilePath);
        string filePath = Path.Combine(directoryPath, saveFileName + saveFileExtension);

        if (!File.Exists(filePath))
        {
            throw new Exception("No save file was found");
        }

        byte[] bytes;
        
        using (var filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            bytes = new byte[filestream.Length];
            await filestream.ReadAsync(bytes, 0, bytes.Length);
        }

        data = await Task.Run(() =>
        {
            string stringData = Encoding.Unicode.GetString(bytes);
            return JsonUtility.FromJson<SaveData>(stringData);
        });

        return data;
    }

    private IEnumerator TestCoroutine(GameStateEvent eventToRaise)
    {
        yield return StartCoroutine(WaitCoroutine());
        eventToRaise.Raise();
    }
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1);
    }

    private SaveData GetData()
    {

        SaveData data = new SaveData
        {
            ListPlayerClasses = new List<string>(),
            ListPlayerDirections = playerDirections.Directions,
            MaxHealth = playerHealth.MaxHealth,
            ListPlayerHealth = playerHealth.PlayerHealthList,
            ListPlayerNames = playerNames.Names,
            ListPlayerPositions = playerPositions.GetPositionList(),
            ListTilePositions = tilesPositions.TileList
        };

        foreach (var playerClass in playerClasses.PlayerClassesList)
        {
            var myString = "";

            myString = playerClass.name;
            
            data.ListPlayerClasses.Add(myString);
        }
        
        
        return data;
    }
    
    private async Task WriteData(SaveData data)
    {
        
        var directoryPath = Path.Combine(Application.persistentDataPath, saveFilePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        
        var filePath = Path.Combine(directoryPath, saveFileName + saveFileExtension);

        byte[] bytes = await Task.Run(() =>
        {
            string jsonData = JsonUtility.ToJson(data);
            return Encoding.Unicode.GetBytes(jsonData);
        });
        
        using (var filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
           await filestream.WriteAsync(bytes, 0, bytes.Length);
        }
        
    }
}
