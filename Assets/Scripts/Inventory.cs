using UnityEngine;

//Fish has a composite relationship with Inventory (Fish objects get destroyed when inventory gets destroyed)
public class Inventory : MonoBehaviour
{

    //stuff pertaining to fish
    public static int maxInventorySpace = 15;
    public int numberOfFish = 0;
    public static Fish[] inventory = new Fish[maxInventorySpace];

    //stuff pertaining to money
    public float money = 0f;


    private void Start()
    {
        
        addFish(new Fish("Cod", 0, 8, 2));
        addFish(new Fish("Salmon", 0, 6, 3));
        addFish(new Fish("Salmon", 2, 8, 4));
        addFish(new Fish("Cod", 0, 4, 1));
        numberOfFish = 4;

        sortByValuePerMass();

        //Debug.Log(inventoryToString());
        

    }

    public string inventoryToString() //for testing
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

    public void addFish(Fish newFish)
    {
        if (numberOfFish < maxInventorySpace)
        {
            inventory[numberOfFish] = newFish;
            numberOfFish++;
        }
    }

    public void sellFish(int index)
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
    }
    public void sellAllFish()
    {
        foreach(Fish fish in inventory)
        {
            if (fish != null)
            {
                money += fish.getValue();
                
            }
        }

        for(int i = 0; i < maxInventorySpace; i++)
        {
            inventory[i] = null;
        }

    }

    public void sortByValue()
    {
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
                }
            }
        }
    }

    public void sortByMass()
    {
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
                }
            }
        }
    }

    public void sortByValuePerMass()
    {
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
