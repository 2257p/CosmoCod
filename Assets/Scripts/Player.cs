using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    float walkSpd = 0.005f;
    bool inOcean = false;

    Key upKey = Key.UpArrow;
    Key downKey = Key.DownArrow;
    Key leftKey = Key.LeftArrow;
    Key rightKey = Key.RightArrow;
    Key interactKey = Key.Z;
    public static Key showInventoryKey = Key.E;

    public static bool inCutscene = false;

    //inventory stuff
    public static int selectorX = 0;
    public static int selectorY = 0;

    void Start()
    {
        
    }

    void Update()
    {
        playerMovement();

        if (Keyboard.current[interactKey].isPressed && inOcean == true)
        {
            Debug.Log("It works");
        }

        if (InventoryLoader.inventoryOpen == false)
        {
            playerMovement();
        }
        else if (InventoryLoader.inventoryOpen == true)
        {
            inventorySelection();
        }
    }

    private void playerMovement()
    {
        if (inCutscene == false)
        {
            if (Keyboard.current[upKey].isPressed)
            {
                this.transform.position += Vector3.up * walkSpd;
            }
            if (Keyboard.current[downKey].isPressed)
            {
                this.transform.position += Vector3.down * walkSpd;
            }

            if (Keyboard.current[rightKey].isPressed)
            {
                this.transform.position += Vector3.right * walkSpd;
            }
            if (Keyboard.current[leftKey].isPressed)
            {
                this.transform.position += Vector3.left * walkSpd;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ocean"))
        {
            inOcean = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ocean"))
        {
            inOcean = false;
        }
    }
    
    //selectorX ranges from 0 to 2
    //selectorY ranges from 0 to -4
    //InventoryLoader.inventoryFishSelector
    private void inventorySelection()
    {
        if (Keyboard.current[rightKey].wasPressedThisFrame && selectorX < 2)
        {
            selectorX++;
            InventoryLoader.inventoryFishSelector.transform.position += new Vector3(1, 0);
        }
        if (Keyboard.current[leftKey].wasPressedThisFrame && selectorX > 0)
        {
            selectorX--;
            InventoryLoader.inventoryFishSelector.transform.position += new Vector3(-1, 0);
        }
        if (Keyboard.current[downKey].wasPressedThisFrame && selectorY > -4)
        {
            selectorY--;
            InventoryLoader.inventoryFishSelector.transform.position += new Vector3(0, -1);
        }
        if (Keyboard.current[upKey].wasPressedThisFrame && selectorY < 0)
        {
            selectorY++;
            InventoryLoader.inventoryFishSelector.transform.position += new Vector3(0, 1);
        }
    }
}