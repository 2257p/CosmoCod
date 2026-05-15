using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InventoryLoader : MonoBehaviour
{
    public GameObject textPrefab;

    public GameObject player;
    public static GameObject inventoryBg;
    public bool inventoryOpen = false;

    public Sprite inventoryBgSprite;
    public Sprite codSprite;
    public Sprite salmonSprite;

    private void Start()
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

        loadInventory();


    }

    // Update is called once per frame
    void Update()
    {

        OpenCloseInventory();



    }

    void OpenCloseInventory()
    {
        if (Keyboard.current[Player.showInventoryKey].wasPressedThisFrame)
        {
            
            if(Player.inCutscene == false && inventoryOpen == false)
            {

                inventoryOpen = true;
                inventoryBg.transform.position = player.transform.position + new Vector3(-2, 0);

            }
            else if (Player.inCutscene == false && inventoryOpen == true)
            {
                inventoryOpen = false;
                inventoryBg.transform.position = player.transform.position + new Vector3(100, 100);
            }

        }
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
        inventoryBg.transform.parent = player.transform;
        inventoryBg.transform.position = player.transform.position + new Vector3(100, 100);

        //inventory title
        GameObject inventoryTitle = Instantiate(textPrefab);
        inventoryTitle.transform.parent = inventoryBg.transform;
        inventoryTitle.transform.position = inventoryBg.transform.position + new Vector3(-0.75f, 3f);
        inventoryTitle.GetComponent<TMP_Text>().text = "Inventory";

        //inventory details panel
        GameObject detailsPanel = new GameObject("DetailsPanel");
        detailsPanel.AddComponent<SpriteRenderer>();
        detailsPanel.GetComponent<SpriteRenderer>().sprite = inventoryBgSprite;
        Color c = detailsPanel.GetComponent<SpriteRenderer>().color;
        c /= 2;
        detailsPanel.GetComponent<SpriteRenderer>().color = c;
        detailsPanel.transform.position = inventoryBg.transform.position + new Vector3(5, 0);
        detailsPanel.transform.parent = inventoryBg.transform;


        for (int i = 0; i < Inventory.maxInventorySpace; i++)
        {

            if (Inventory.inventory[i] != null)
            {

                if (Inventory.inventory[i].getName() == "Salmon")
                {

                    GameObject temp = new GameObject("Fish");
                    temp.AddComponent<InventoryFish>();
                    temp.GetComponent<InventoryFish>().fish = Inventory.inventory[i];
                    temp.GetComponent<InventoryFish>().textPrefab = textPrefab;
                    temp.AddComponent<BoxCollider2D>();
                    temp.GetComponent<BoxCollider2D>().isTrigger = true;
                    temp.tag = "Fish";
                    temp.transform.position = inventoryBg.transform.position + new Vector3(-1, 2) + new Vector3(i%3, -i/3);
                    temp.transform.parent = inventoryBg.transform;
                    temp.AddComponent<SpriteRenderer>();
                    temp.GetComponent<SpriteRenderer>().sprite = salmonSprite;
                    temp.transform.localScale = new Vector3(2, 2);
                    temp.GetComponent<SpriteRenderer>().sortingOrder = 1;

                }

                if (Inventory.inventory[i].getName() == "Cod")
                {

                    GameObject temp = new GameObject("Fish");
                    temp.AddComponent<InventoryFish>();
                    temp.GetComponent<InventoryFish>().fish = Inventory.inventory[i];
                    temp.GetComponent<InventoryFish>().textPrefab = textPrefab;
                    temp.AddComponent<BoxCollider2D>();
                    temp.GetComponent<BoxCollider2D>().isTrigger = true;
                    temp.tag = "Fish";
                    temp.transform.position = inventoryBg.transform.position + new Vector3(-1, 2) + new Vector3(i%3, -i/3);
                    temp.transform.parent = inventoryBg.transform;
                    temp.AddComponent<SpriteRenderer>();
                    temp.GetComponent<SpriteRenderer>().sprite = codSprite;
                    temp.transform.localScale = new Vector3(2, 2);
                    temp.GetComponent<SpriteRenderer>().sortingOrder = 1;

                }

            }

        }
    }
}
