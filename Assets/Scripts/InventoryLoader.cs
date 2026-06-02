using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class InventoryLoader : MonoBehaviour
{
    public GameObject textPrefab;

    public Sprite salmonSprite, codSprite, pikeSprite, blueySprite, redfinSprite,
             sparklefinSprite, starfinSprite, bubblefinSprite, clownfishSprite,
             firefishSprite, anglerfishSprite, beefishSprite, frostkingSprite,
             goldkingSprite, rainbowkingSprite, sunkingSprite;

    private Dictionary<string, Sprite> fishSprites;

    public static GameObject inventoryLoader;
    public static GameObject player;
    public static GameObject inventoryBg;
    public static GameObject inventoryTitle;
    public static GameObject inventoryFishSelector;
    public static GameObject detailsPanel;
    public static GameObject sortingButton;
    public static GameObject sellAllButton;
    public static GameObject sellAllText;
    public static GameObject sortingText;
    public static GameObject moneyText;
    public static bool inventoryOpen = false;

    public Sprite inventoryFishSelectorSprite;
    public Sprite inventoryBgSprite;
    public Sprite sortingMethodSwitchButton;
    public Sprite moneyBagIcon;

    private void Start()
    {
        fishSprites = new Dictionary<string, Sprite>
        {
            { "Salmon", salmonSprite },
            { "Cod", codSprite },
            { "Pike", pikeSprite },
            { "Bluey", blueySprite },
            { "Redfin", redfinSprite },
            { "Sparklefin", sparklefinSprite },
            { "Starfin", starfinSprite },
            { "Bubblefin", bubblefinSprite },
            { "Clownfish", clownfishSprite },
            { "Firefish", firefishSprite },
            { "Anglerfish", anglerfishSprite },
            { "Beefish", beefishSprite },
            { "Frostking", frostkingSprite },
            { "Goldking", goldkingSprite },
            { "Rainbowking", rainbowkingSprite },
            { "Sunking", sunkingSprite },
        };

        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("Player"))
            {
                player = obj;
            }
            else if (obj.CompareTag("InventoryLoader"))
            {
                inventoryLoader = obj;
            }
        }

        reloadInventory();
    }

    // Update is called once per frame
    void Update()
    {
        OpenCloseInventory();
        SortingButtonDetect();
        SellButtonDetect();
    }

    

    void OpenCloseInventory()
    {
        if (Keyboard.current[Player.showInventoryKey].wasPressedThisFrame && ShopBuy.inShopBuy == false)
        {
            
            if(Player.inCutscene == false && inventoryOpen == false && Shop.inShop == false)
            {
                inventoryOpen = true;
                inventoryBg.transform.position = player.transform.position + new Vector3(-2, 0);

            }
            else if (Player.inCutscene == false && inventoryOpen == true && Shop.inShop == false)
            {
                inventoryOpen = false;
                inventoryBg.transform.position = player.transform.position + new Vector3(100, 100);
            }
        }

        //another option to close inventory
        if (Keyboard.current[Player.cancelKey].wasPressedThisFrame && inventoryOpen == true && ShopBuy.inShopBuy == false)
        {
            inventoryOpen = false;
            inventoryBg.transform.position = player.transform.position + new Vector3(100, 100);

        }
    }
    
    //for use by the shop script
    public static void ShopOpenInventory()
    {
        Shop.inShop = true;
        inventoryBg.transform.position = player.transform.position + new Vector3(-2, 0);
        sellAllButton.SetActive(true);
        sellAllText.SetActive(true);
        inventoryTitle.GetComponent<TMP_Text>().text = "Sell";
    }

    //for use by the shop script
    public static void ShopCloseInventory()
    {
        Shop.inShop = false;
        inventoryBg.transform.position = player.transform.position + new Vector3(100, 100);
        sellAllButton.SetActive(false);
        sellAllText.SetActive(false);
        inventoryTitle.GetComponent<TMP_Text>().text = "Inventory";
    }

    void SortingButtonDetect()
    {
        if(Player.selectorX == 2 && Player.selectorY == 1 && Keyboard.current[Player.interactKey].wasPressedThisFrame)
        {
            if(Inventory.sortingMethod == 2)
            {
                Inventory.sortingMethod = 0;
                Inventory.sortByValue();
                sortingText.GetComponent<TMP_Text>().text = "Sort:\nValue";
                reloadFish();
            }
            else if (Inventory.sortingMethod == 1)
            {
                Inventory.sortingMethod = 2;
                Inventory.sortByValuePerMass();
                sortingText.GetComponent<TMP_Text>().text = "Sort:\nValue/Mass";
                reloadFish();
            }
            else if (Inventory.sortingMethod == 0)
            {
                Inventory.sortingMethod = 1;
                Inventory.sortByMass();
                sortingText.GetComponent<TMP_Text>().text = "Sort:\nMass";
                reloadFish();
            }
        }
    }

    void SellButtonDetect()
    {
        if(Player.selectorX == 0 && Player.selectorY == 1 && Keyboard.current[Player.interactKey].wasPressedThisFrame && Shop.inShop == true)
        {
            Inventory.sellAllFish();
            reloadFish();
        }
    }

    public static void reloadFish()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach(GameObject g in allObjects)
        {
            if (g.CompareTag("Fish"))
            {
                Destroy(g);
            }
        }

        inventoryLoader.GetComponent<InventoryLoader>().loadFish();
    }

    public static void reloadMoney()
    {
        moneyText.GetComponent<TMP_Text>().text = "$" + Inventory.money;
    }

    void reloadInventory()
    {
        if (inventoryBg != null) { 
            Destroy(inventoryBg);
        }
        loadInventory();
    }

    void loadInventory()
    {

        //inventory background
        inventoryBg = new GameObject("InventoryBackground");
        inventoryBg.AddComponent<SpriteRenderer>();
        inventoryBg.GetComponent<SpriteRenderer>().sprite = inventoryBgSprite;
        Color t = inventoryBg.GetComponent<SpriteRenderer>().color;
        t /= 2;
        inventoryBg.GetComponent<SpriteRenderer>().color = t;
        inventoryBg.GetComponent<SpriteRenderer>().sortingOrder = 1;
        inventoryBg.transform.localScale = new Vector3(1.2f, 1);
        inventoryBg.transform.parent = player.transform;
        inventoryBg.transform.position = player.transform.position + new Vector3(100, 100);

        //inventory title
        inventoryTitle = Instantiate(textPrefab);
        inventoryTitle.transform.parent = inventoryBg.transform;
        inventoryTitle.transform.position = inventoryBg.transform.position + new Vector3(-1.8f, 0f);
        inventoryTitle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        inventoryTitle.transform.localScale = new Vector3(2f, 1.3f);
        if (Shop.inShop == false)
        {
            inventoryTitle.GetComponent<TMP_Text>().text = "Inventory";
        }
        else if (Shop.inShop == true)
        {
            inventoryTitle.GetComponent<TMP_Text>().text = "Sell";
        }

        sellAllButton = new GameObject("SellFishButton");
        sellAllButton.AddComponent<SpriteRenderer>();
        sellAllButton.GetComponent<SpriteRenderer>().sprite = moneyBagIcon;
        sellAllButton.GetComponent<SpriteRenderer>().sortingOrder = 1;
        sellAllButton.transform.position = inventoryBg.transform.position + new Vector3(-0.5f, 3);
        sellAllButton.transform.parent = inventoryBg.transform;
        sellAllButton.transform.localScale = new Vector3(0.6f, 0.6f);

        sellAllText = Instantiate(textPrefab);
        sellAllText.transform.localScale = new Vector3(0.5f, 0.5f);
        sellAllText.transform.position = inventoryBg.transform.position + new Vector3(-1.3f, 3);
        sellAllText.transform.parent = inventoryBg.transform;
        sellAllText.GetComponent<TMP_Text>().text = "sell\nall";

        if(Shop.inShop == false)
        {
            sellAllButton.SetActive(false);
            sellAllText.SetActive(false);
        }
        
        //money amount text
        moneyText = Instantiate(textPrefab);

        //moneyText.transform.localScale = new Vector3(0.5f, 0.5f);
        moneyText.transform.position = inventoryBg.transform.position + new Vector3(-5.5f, -3.5f);
        moneyText.transform.parent = inventoryBg.transform;
        moneyText.GetComponent<TMP_Text>().text = "$" + Inventory.money;

        //sort text
        sortingText = Instantiate(textPrefab);
        sortingText.transform.localScale = new Vector3(0.5f, 0.5f);
        sortingText.transform.position = inventoryBg.transform.position + new Vector3(0.4f, 3f);
        sortingText.transform.parent = inventoryBg.transform;

        if(Inventory.sortingMethod == 0)
        {
            sortingText.GetComponent<TMP_Text>().text = "Sort:\nValue";
        }
        else if (Inventory.sortingMethod == 1)
        {
            sortingText.GetComponent<TMP_Text>().text = "Sort:\nMass";
        }
        else if (Inventory.sortingMethod == 2)
        {
            sortingText.GetComponent<TMP_Text>().text = "Sort:\nValue/Mass";
        }

        //inventory details panel
        detailsPanel = new GameObject("DetailsPanel");
        detailsPanel.AddComponent<SpriteRenderer>();
        detailsPanel.GetComponent<SpriteRenderer>().sprite = inventoryBgSprite;
        Color c = detailsPanel.GetComponent<SpriteRenderer>().color;
        c /= 2;
        detailsPanel.GetComponent<SpriteRenderer>().color = c;
        detailsPanel.GetComponent<SpriteRenderer>().sortingOrder = 1;
        detailsPanel.transform.position = inventoryBg.transform.position + new Vector3(5f, 0);
        detailsPanel.transform.parent = inventoryBg.transform;

        //fish selector
        inventoryFishSelector = new GameObject("Selector");
        inventoryFishSelector.AddComponent<SpriteRenderer>();
        inventoryFishSelector.GetComponent<SpriteRenderer>().sprite = inventoryFishSelectorSprite;
        inventoryFishSelector.GetComponent<SpriteRenderer>().sortingOrder = 2;
        inventoryFishSelector.transform.position = inventoryBg.transform.position + new Vector3(-0.5f, 2);
        inventoryFishSelector.transform.parent = inventoryBg.transform;

        //change sorting button
        sortingButton = new GameObject("sortingButton");
        sortingButton.AddComponent<SpriteRenderer>();
        sortingButton.GetComponent<SpriteRenderer>().sprite = sortingMethodSwitchButton;
        sortingButton.GetComponent<SpriteRenderer>().sortingOrder = 1;
        sortingButton.transform.localScale = new Vector3(0.6f, 0.6f);
        sortingButton.transform.position = inventoryBg.transform.position + new Vector3(1.5f, 3);
        sortingButton.transform.parent = inventoryBg.transform;

        loadFish();
    }

    public void loadFish()
    {
        for (int i = 0; i < Inventory.maxInventorySpace; i++)
        {
            if (Inventory.inventory[i] != null)
            {
                string name = Inventory.inventory[i].getName();

                if (fishSprites.TryGetValue(name, out Sprite sprite))
                {
                    GameObject temp = new GameObject("Fish");
                    temp.AddComponent<InventoryFish>();
                    temp.GetComponent<InventoryFish>().fish = Inventory.inventory[i];
                    temp.GetComponent<InventoryFish>().textPrefab = textPrefab;
                    temp.GetComponent<InventoryFish>().spr = sprite;
                    temp.AddComponent<BoxCollider2D>();
                    temp.GetComponent<BoxCollider2D>().size = new Vector3(0.5f, 0.5f);
                    temp.GetComponent<BoxCollider2D>().isTrigger = true;
                    temp.tag = "Fish";
                    temp.transform.position = inventoryBg.transform.position + new Vector3(-0.5f, 2) + new Vector3(i % 3, -i / 3);
                    temp.transform.parent = detailsPanel.transform;
                    temp.AddComponent<SpriteRenderer>();
                    temp.GetComponent<SpriteRenderer>().sprite = sprite;
                    temp.transform.localScale = new Vector3(2, 2);
                    temp.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
            }
        }
    }
}