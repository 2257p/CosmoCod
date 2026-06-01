using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopBuy : MonoBehaviour
{

    //4 tiers of fishing rod: starter, 3 more
    public static int rodTier = 0;
    public static bool inShopBuy = false;

    int rod1Price = 200;
    int rod2Price = 1000;
    int rod3Price = 3000;

    public GameObject textPrefab;
    public Sprite inventoryBg;
    public Sprite inventorySelector;
    public Sprite rod1;
    public Sprite rod2;
    public Sprite rod3;

    public static GameObject player;
    public static GameObject bg;
    public static GameObject rod1parent;
    public static GameObject rod2parent;
    public static GameObject rod3parent;
    public static GameObject rod1text;
    public static GameObject rod1priceText;
    public static GameObject rod2text;
    public static GameObject rod2priceText;
    public static GameObject rod3text;
    public static GameObject rod3priceText;

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
        bg.transform.position = player.transform.position + new Vector3(-2, 0);

    }

    public static void CloseShopBuy()
    {
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
        rod1parent.transform.position = bg.transform.position + new Vector3(0, 2f);
        rod1parent.transform.parent = bg.transform;
        rod2parent.transform.position = bg.transform.position;
        rod2parent.transform.parent = bg.transform;
        rod3parent.transform.position = bg.transform.position + new Vector3(0, -2f);
        rod3parent.transform.parent = bg.transform;

        //rod1text
        rod1text = Instantiate(textPrefab);
        rod1text.transform.position = rod1parent.transform.position + new Vector3(1, 0);
        rod1text.GetComponent<TMP_Text>().text = "tier 1 rod";
        rod1text.transform.parent = bg.transform;
        rod1priceText = Instantiate(textPrefab);
        rod1priceText.transform.position = rod1parent.transform.position + new Vector3(1, 1);
        rod1priceText.transform.parent = rod1parent.transform;
        rod1priceText.GetComponent<TMP_Text>().text = "$" + rod1Price;


        //rod2text

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
