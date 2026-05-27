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

    public string[] fishNames = new string[Inventory.maxInventorySpace];
    public int[] fishRarities = new int[Inventory.maxInventorySpace];
    public float[] fishValues = new float[Inventory.maxInventorySpace];
    public float[] fishMasses = new float[Inventory.maxInventorySpace];

    public int numberOfFish;

    private static string saveDataFilePath = Application.persistentDataPath + "/saveData.json";

    public static void Save()
    {
        SaveLoadFile save = new SaveLoadFile();

        //still need to add day
        save.money = Inventory.money;
        save.numberOfFish = Inventory.numberOfFish;
        for(int i = 0; i < Inventory.numberOfFish; i++)
        {
            if (Inventory.inventory[i] != null)
            {
                save.fishNames[i] = Inventory.inventory[i].getName();
                save.fishRarities[i] = Inventory.inventory[i].getRarity();
                save.fishValues[i] = Inventory.inventory[i].getValue();
                save.fishMasses[i] = Inventory.inventory[i].getMass();
            }
        }

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
            Inventory.numberOfFish = save.numberOfFish;
            for(int i = 0; i < Inventory.maxInventorySpace; i++)
            {
                if (save.fishNames[i] != "")
                {
                    Inventory.inventory[i] = new Fish(save.fishNames[i], save.fishRarities[i], save.fishValues[i], save.fishMasses[i]);
                }
            }
            InventoryLoader.reloadFish();
            InventoryLoader.reloadMoney();
        }
    }

}
