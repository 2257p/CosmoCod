using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopBuy : MonoBehaviour
{

    //4 tiers of fishing rod: starter, 3 more
    public static int rodTier = 0;
    public static bool inShopBuy = false;

    public static bool shopBuyJustOpened = false;
    public static int selectorIndex = 1;

    static int rod1Price = 200;
    static int rod2Price = 1000;
    static int rod3Price = 3000;

    bool rod1Bought = false;
    bool rod2Bought = false;
    bool rod3Bought = false;

    public GameObject textPrefab;
    public Sprite inventoryBg;
    public Sprite inventorySelector;
    public Sprite rod1;
    public Sprite rod2;
    public Sprite rod3;

    public static GameObject player;
    public static GameObject bg;
    public static GameObject selectorObj;
    public static GameObject rod1parent;
    public static GameObject rod2parent;
    public static GameObject rod3parent;
    public static GameObject rod1text;
    public static GameObject rod1priceText;
    public static GameObject rod1Spr;
    public static GameObject rod2text;
    public static GameObject rod2priceText;
    public static GameObject rod2Spr;
    public static GameObject rod3text;
    public static GameObject rod3priceText;
    public static GameObject rod3Spr;

    public static void InteractShopBuy()
    {
        if(inShopBuy == false)
        {
            inShopBuy = true;
            OpenShopBuy();
        }
        else if(inShopBuy == true) 
        {
            inShopBuy = false;
            CloseShopBuy();
        }
    }

    public static void OpenShopBuy()
    {
        shopBuyJustOpened = true;
        inShopBuy = true;
        bg.transform.position = player.transform.position + new Vector3(-2, 0);

    }

    public static void CloseShopBuy()
    {
        inShopBuy = false;
        bg.transform.position = player.transform.position + new Vector3(100, 100);
    }

    //instantiate ui of shopbuy
    private void Start()
    {
        if (player == null)
        {
            GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            foreach (GameObject obj in allObjects)
            {
                if (obj.CompareTag("Player"))
                {
                    player = obj;
                    break;
                }
            }
        }

        //background
        bg = new GameObject("ShopBackground");
        bg.AddComponent<SpriteRenderer>();
        bg.GetComponent<SpriteRenderer>().sprite = inventoryBg;
        Color t = bg.GetComponent<SpriteRenderer>().color;
        t /= 2;
        bg.GetComponent<SpriteRenderer>().color = t;
        bg.GetComponent<SpriteRenderer>().sortingOrder = 1;
        bg.transform.localScale = new Vector3(1.2f, 1);
        bg.transform.parent = player.transform;
        bg.transform.position = player.transform.position + new Vector3(100, 100);

        //rod parents
        rod1parent = new GameObject("rod1parent");
        rod2parent = new GameObject("rod2parent");
        rod3parent = new GameObject("rod3parent");
        rod1parent.transform.position = bg.transform.position + new Vector3(0, 1.5f);
        rod1parent.transform.parent = bg.transform;
        rod2parent.transform.position = bg.transform.position;
        rod2parent.transform.parent = bg.transform;
        rod3parent.transform.position = bg.transform.position + new Vector3(0, -1.5f);
        rod3parent.transform.parent = bg.transform;

        //rod1text
        rod1text = Instantiate(textPrefab);
        rod1text.transform.position = rod1parent.transform.position + new Vector3(0.7f, 0.25f);
        rod1text.GetComponent<TMP_Text>().text = "good rod";
        rod1text.transform.parent = rod2parent.transform;
        rod1priceText = Instantiate(textPrefab);
        rod1priceText.transform.position = rod1parent.transform.position + new Vector3(1, 1);
        rod1priceText.transform.parent = rod1parent.transform;
        if (rodTier < 1)
        {
            rod1priceText.GetComponent<TMP_Text>().text = "$" + rod1Price;
        }
        else
        {
            rod1priceText.GetComponent<TMP_Text>().text = "bought";
        }

            //rod2text
            rod2text = Instantiate(textPrefab);
        rod2text.transform.position = rod2parent.transform.position + new Vector3(0.8f, 0.25f);
        rod2text.GetComponent<TMP_Text>().text = "great rod";
        rod2text.transform.parent = rod2parent.transform;
        rod2priceText = Instantiate(textPrefab);
        rod2priceText.transform.position = rod2parent.transform.position + new Vector3(1, 1);
        if (rodTier < 2)
        {
            rod2priceText.GetComponent<TMP_Text>().text = "$" + rod2Price;
        }
        else
        {
            rod2priceText.GetComponent<TMP_Text>().text = "bought";
        }
        rod2priceText.transform.parent = rod2parent.transform;

        //rod3text
        rod3text = Instantiate(textPrefab);
        rod3text.transform.position = rod3parent.transform.position + new Vector3(0.75f, 0.25f);
        rod3text.GetComponent<TMP_Text>().text = "godrod";
        rod3text.transform.parent = rod3parent.transform;
        rod3priceText = Instantiate(textPrefab);
        rod3priceText.transform.position = rod3parent.transform.position + new Vector3(1, 1);
        if (rodTier < 3)
        {
            rod3priceText.GetComponent<TMP_Text>().text = "$" + rod3Price;
        }
        else
        {
            rod3priceText.GetComponent<TMP_Text>().text = "bought";
        }
        rod3priceText.transform.parent = rod3parent.transform;

        //selector
        selectorObj = new GameObject("shop selector");
        selectorObj.AddComponent<SpriteRenderer>();
        selectorObj.GetComponent<SpriteRenderer>().sprite = inventorySelector;
        selectorObj.GetComponent<SpriteRenderer>().sortingOrder = 1;
        selectorObj.transform.position = rod1parent.transform.position + new Vector3(0, 0.6f);
        selectorObj.transform.parent = bg.transform;
        selectorObj.transform.localScale = new Vector3(4, 2);

        //rod1 sprite
        rod1Spr = new GameObject("rod1spr");
        rod1Spr.AddComponent<SpriteRenderer>();
        rod1Spr.GetComponent<SpriteRenderer>().sprite = rod1;
        rod1Spr.transform.position = rod1parent.transform.position + new Vector3(-0.75f, 0.5f);
        rod1Spr.transform.localScale = new Vector3(3, 3);
        rod1Spr.transform.parent = rod1parent.transform;

        //rod2 sprite
        rod2Spr = new GameObject("rod2spr");
        rod2Spr.AddComponent<SpriteRenderer>();
        rod2Spr.GetComponent<SpriteRenderer>().sprite = rod2;
        rod2Spr.transform.position = rod2parent.transform.position + new Vector3(-0.75f, 0.5f);
        rod2Spr.transform.localScale = new Vector3(3, 3);
        rod2Spr.transform.parent = rod2parent.transform;

        //rod3 sprite
        rod3Spr = new GameObject("rod3spr");
        rod3Spr.AddComponent<SpriteRenderer>();
        rod3Spr.GetComponent<SpriteRenderer>().sprite = rod3;
        rod3Spr.transform.position = rod3parent.transform.position + new Vector3(-0.75f, 0.5f);
        rod3Spr.transform.localScale = new Vector3(3, 3);
        rod3Spr.transform.parent = rod3parent.transform;
    }

    public static void reloadShopBuy()
    {
        if (rodTier == 0)
        {
            rod1priceText.GetComponent<TMP_Text>().text = "$" + rod1Price;
            rod2priceText.GetComponent<TMP_Text>().text = "$" + rod2Price;
            rod3priceText.GetComponent<TMP_Text>().text = "$" + rod3Price;
        }
        else if (rodTier == 1)
        {
            rod1priceText.GetComponent<TMP_Text>().text = "bought";
            rod2priceText.GetComponent<TMP_Text>().text = "$" + rod2Price;
            rod3priceText.GetComponent<TMP_Text>().text = "$" + rod3Price;
        }
        else if (rodTier == 2)
        {
            rod1priceText.GetComponent<TMP_Text>().text = "bought";
            rod2priceText.GetComponent<TMP_Text>().text = "bought";
            rod3priceText.GetComponent<TMP_Text>().text = "$" + rod3Price;
        }
        else if (rodTier == 3)
        {
            rod1priceText.GetComponent<TMP_Text>().text = "bought";
            rod2priceText.GetComponent<TMP_Text>().text = "bought";
            rod3priceText.GetComponent<TMP_Text>().text = "bought";
        }
    }

    private void Update()
    {

        if(shopBuyJustOpened == true && !Keyboard.current[Player.interactKey].wasPressedThisFrame)
        {
            shopBuyJustOpened = false;
        }

        if (Keyboard.current[Player.interactKey].wasPressedThisFrame && inShopBuy == true && shopBuyJustOpened == false)
        {

            if(selectorIndex == 1 && rod1Bought == false && Inventory.money >= rod1Price)
            {
                rod1priceText.GetComponent<TMP_Text>().text = "bought";
                rodTier = 1;
                rod1Bought = true;
                Inventory.money -= rod1Price;
                InventoryLoader.reloadMoney();
            }

            if(selectorIndex == 2 && rod2Bought == false && Inventory.money >= rod2Price)
            {
                rod2priceText.GetComponent<TMP_Text>().text = "bought";
                rod1priceText.GetComponent<TMP_Text>().text = "bought";
                rodTier = 2;
                rod1Bought = true;
                rod2Bought = true;
                Inventory.money -= rod2Price;
                InventoryLoader.reloadMoney();

            }

            if (selectorIndex == 3 && rod3Bought == false && Inventory.money >= rod3Price)
            {
                rod2priceText.GetComponent<TMP_Text>().text = "bought";
                rod1priceText.GetComponent<TMP_Text>().text = "bought";
                rod3priceText.GetComponent<TMP_Text>().text = "bought";
                rodTier = 3;
                rod1Bought = true;
                rod2Bought = true;
                rod3Bought = true;
                Inventory.money -= rod3Price;
                InventoryLoader.reloadMoney();

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.inShopBuyArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.inShopBuyArea = false;
        }
    }

}
