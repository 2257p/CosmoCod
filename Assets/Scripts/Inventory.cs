using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

//Fish has a composite relationship with Inventory (Fish objects get destroyed when inventory gets destroyed)
public class Inventory : MonoBehaviour
{

    //stuff pertaining to fish
    public static int maxInventorySpace = 15;
    public static int numberOfFish = 0;
    public static Fish[] inventory = new Fish[maxInventorySpace];

    //stuff pertaining to money
    public static float money;

    //stuff pertaining to inventory
    public static int sortingMethod; //0 is value, 1 is mass, 2 is value/mass

    private void Start()
    {
        sortingMethod = 2;
        sortByValuePerMass();
    }

    public static string inventoryToString() //for testing
    {
        string r = "";
        foreach(Fish f in inventory)
        {
            if(f != null)
            {
                r += f.getName();
                r += " " + f.getValue();
                r += ", ";
            }
        }
        return r;
    }

    public static void addFish(Fish newFish)
    {
        if (numberOfFish < maxInventorySpace)
        {
            inventory[numberOfFish] = newFish;
            numberOfFish++;
        }
        //InventoryLoader.reloadFish();
    }

    public static void sellFish(int index)
    {
        if (inventory[index] != null)
        {
            money += inventory[index].getValue();
            inventory[index] = null;
            numberOfFish -= 1;
            for (int i = index; i < maxInventorySpace - 1; i++)
            {
                inventory[i] = inventory[i + 1];
            }
            inventory[maxInventorySpace - 1] = null;
        }
        InventoryLoader.reloadMoney();
    }

    public static void sellFish(Fish f)
    {
        for (int j = 0; j < maxInventorySpace; j++)
        {
            if (inventory[j] == f)
            {
                money += f.getValue();
                f = null;
                numberOfFish -= 1;

                for(int i = j; i < maxInventorySpace - 1; i++)
                {
                    inventory[i] = inventory[i + 1];
                }
                inventory[maxInventorySpace - 1] = null;

                break;

            }
        }
        InventoryLoader.reloadMoney();
    }

    public static void sellAllFish()
    {
        foreach(Fish fish in inventory)
        {
            if (fish != null)
            {
                money += fish.getValue();
                
            }
        }

        Inventory.numberOfFish = 0;

        for(int i = 0; i < maxInventorySpace; i++)
        {
            inventory[i] = null;
        }
        InventoryLoader.reloadMoney();
    }

    public static float ReturnMoney()
    {
        return money;
    }

    //sorting method 0 (By Value)
    public static void sortByValue()
    {
        sortingMethod = 0;
        for(int i = 0; i < maxInventorySpace - 1; i++)
        {
            for(int j = 0; j < maxInventorySpace - 1; j++)
            {
                if (inventory[j] != null && inventory[j + 1] != null)
                {
                    if (inventory[j].getValue() > inventory[j + 1].getValue())
                    {
                        Fish temp = inventory[j];
                        inventory[j] = inventory[j + 1];
                        inventory[j + 1] = temp;
                    }
                    if (inventory[j].getValue() == inventory[j + 1].getValue())
                    {
                        if (inventory[j].getMass() > inventory[j + 1].getMass())
                        {
                            Fish temp = inventory[j];
                            inventory[j] = inventory[j + 1];
                            inventory[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }

    //sorting method 1 (By Mass)
    public static void sortByMass()
    {
        sortingMethod = 1;
        for (int i = 0; i < maxInventorySpace - 1; i++)
        {
            for (int j = 0; j < maxInventorySpace - 1; j++)
            {
                if (inventory[j] != null && inventory[j + 1] != null)
                {
                    if (inventory[j].getMass() > inventory[j + 1].getMass())
                    {
                        Fish temp = inventory[j];
                        inventory[j] = inventory[j + 1];
                        inventory[j + 1] = temp;
                    }
                    if (inventory[j].getMass() == inventory[j + 1].getMass())
                    {
                        if (inventory[j].getValue() > inventory[j + 1].getValue())
                        {
                            Fish temp = inventory[j];
                            inventory[j] = inventory[j + 1];
                            inventory[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }

    //sorting method 2 (By Value Per Mass)
    public static void sortByValuePerMass()
    {
        sortingMethod = 2;
        for (int i = 0; i < maxInventorySpace - 1; i++)
        {
            for (int j = 0; j < maxInventorySpace - 1; j++)
            {
                if (inventory[j] != null && inventory[j + 1] != null)
                {
                    if (inventory[j].getValue() / inventory[j].getMass() > inventory[j + 1].getValue() / inventory[j + 1].getMass())
                    {
                        Fish temp = inventory[j];
                        inventory[j] = inventory[j + 1];
                        inventory[j + 1] = temp;
                    }
                    else if (inventory[j].getValue() / inventory[j].getMass() == inventory[j + 1].getValue() / inventory[j + 1].getMass())
                    {
                        if (inventory[j].getValue() > inventory[j + 1].getValue())
                        {
                            Fish temp = inventory[j];
                            inventory[j] = inventory[j + 1];
                            inventory[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }

}
