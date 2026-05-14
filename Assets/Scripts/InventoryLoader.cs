using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryLoader : MonoBehaviour
{

    public GameObject player;
    public Sprite inventoryBgSprite;
    public GameObject inventoryBg;
    public bool inventoryOpen = false;


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
                inventoryBg.transform.position = player.transform.position;

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

        inventoryBg = new GameObject();
        inventoryBg.AddComponent<SpriteRenderer>();
        inventoryBg.GetComponent<SpriteRenderer>().sprite = inventoryBgSprite;
        Color t = inventoryBg.GetComponent<SpriteRenderer>().color;
        t /= 2;
        inventoryBg.GetComponent<SpriteRenderer>().color = t;

        inventoryBg.transform.parent = player.transform;
        inventoryBg.transform.position = player.transform.position + new Vector3(100, 100);

        for (int i = 0; i < Inventory.maxInventorySpace; i++)
        {

            if (Inventory.inventory[i] != null)
            {

                if (Inventory.inventory[i].getName() == "Salmon")
                {

                    GameObject temp = new GameObject("Fish");
                    temp.transform.parent = inventoryBg.transform;
                    temp.AddComponent<SpriteRenderer>();
                    temp.GetComponent<SpriteRenderer>().sprite = salmonSprite;
                    temp.GetComponent<SpriteRenderer>().sortingOrder = 1;

                }

                if (Inventory.inventory[i].getName() == "Cod")
                {

                    GameObject temp = new GameObject("Fish");
                    temp.transform.parent = inventoryBg.transform;
                    temp.AddComponent<SpriteRenderer>();
                    temp.GetComponent<SpriteRenderer>().sprite = codSprite;
                    temp.GetComponent<SpriteRenderer>().sortingOrder = 1;


                }

            }

        }
    }
}
