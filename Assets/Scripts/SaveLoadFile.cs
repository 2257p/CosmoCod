using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class SaveLoadFile
{

    public int day;
    public float money;
    public Fish[] inventory = new Fish[Inventory.maxInventorySpace];
    public int numberOfFish;

    private static string saveDataFilePath = Application.persistentDataPath + "/saveData.json";

    public static void Save()
    {
        SaveLoadFile save = new SaveLoadFile();

        //still need to add day
        save.money = Inventory.money;
        save.inventory = Inventory.inventory;
        save.numberOfFish = Inventory.numberOfFish;

        string json = JsonUtility.ToJson(save);
        File.WriteAllText(saveDataFilePath, json);
    }

    public static void Load()
    {
        if(File.Exists(saveDataFilePath))
        {
            string json = File.ReadAllText(saveDataFilePath);
            SaveLoadFile save = JsonUtility.FromJson<SaveLoadFile>(json);

            Inventory.money = save.money;
            //Inventory.inventory = save.inventory;
            Inventory.numberOfFish = save.numberOfFish;

        }
    }

}
