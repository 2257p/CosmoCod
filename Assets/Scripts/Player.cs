using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float walkSpd = 6f;

    public static bool inOcean = false;
    public static bool inShopArea = false;
    public static bool inShopBuyArea = false;

    Key upKey = Key.UpArrow;
    Key downKey = Key.DownArrow;
    Key leftKey = Key.LeftArrow;
    Key rightKey = Key.RightArrow;

    public static Key interactKey = Key.Z;
    public static Key showInventoryKey = Key.C;
    public static Key cancelKey = Key.X;

    public static bool inCutscene = false;

    // inventory stuff
    public static int selectorX = 0;
    public static int selectorY = 0;
    public static bool upperButtons = false;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    public static float posX;
    public static float posY;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = new Vector2(posX, posY);
    }

    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;

        if (Keyboard.current[interactKey].wasPressedThisFrame)
        {
            if (inOcean == true && InventoryLoader.inventoryOpen == false)
            {
                SceneManager.LoadScene("Fish Function");
                InventoryLoader.inventoryFishSelector.transform.position = InventoryLoader.inventoryBg.transform.position + new Vector3(-0.5f, 2);

            }

            if (inShopArea == true &&
                Shop.inShop == false &&
                InventoryLoader.inventoryOpen == false)
            {
                Shop.Interact();
            }

            if(inShopArea == false && Shop.inShop == false && inShopBuyArea == true && InventoryLoader.inventoryOpen == false)
            {
                ShopBuy.inShopBuy = true;
                ShopBuy.OpenShopBuy();
            }

        }

        

        if ((Keyboard.current[showInventoryKey].wasPressedThisFrame ||
             Keyboard.current[cancelKey].wasPressedThisFrame)
             && Shop.inShop == true)
        {
            Shop.CloseShop();
        }

        if (InventoryLoader.inventoryOpen == false &&
            Shop.inShop == false &&
            inCutscene == false && ShopBuy.inShopBuy == false)
        {
            playerMovement();
        }
        else if (InventoryLoader.inventoryOpen == true ||
                 Shop.inShop == true)
        {
            moveInput = Vector2.zero;

            // IDLE ANIMATION
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 0f);

            inventorySelection();
        }
    }

    void FixedUpdate()
    {
        if (InventoryLoader.inventoryOpen == false &&
            inCutscene == false)
        {
            rb.MovePosition(
                rb.position +
                moveInput * walkSpd * Time.fixedDeltaTime
            );
        }
    }

    private void playerMovement()
    {
        if (inCutscene == false)
        {
            float x = 0f;
            float y = 0f;

            if (Keyboard.current[upKey].isPressed)
            {
                y += 1f;
            }

            if (Keyboard.current[downKey].isPressed)
            {
                y -= 1f;
            }

            if (Keyboard.current[rightKey].isPressed)
            {
                x += 1f;
            }

            if (Keyboard.current[leftKey].isPressed)
            {
                x -= 1f;
            }

            moveInput = new Vector2(x, y).normalized;

            // SEND VALUES TO ANIMATOR
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }
        
        else
        {
            moveInput = Vector2.zero;

            // IDLE
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ocean"))
        {
            inOcean = true;
        }

        if (other.CompareTag("Shop"))
        {
            inShopArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ocean"))
        {
            inOcean = false;
        }

        if (other.CompareTag("Shop"))
        {
            inShopArea = false;
        }
    }

    private void inventorySelection()
    {
        if (upperButtons == false)
        {
            if (Keyboard.current[rightKey].wasPressedThisFrame &&
                selectorX < 2)
            {
                selectorX++;
                InventoryLoader.inventoryFishSelector.transform.position +=
                    new Vector3(1, 0);
            }

            if (Keyboard.current[leftKey].wasPressedThisFrame &&
                selectorX > 0)
            {
                selectorX--;
                InventoryLoader.inventoryFishSelector.transform.position +=
                    new Vector3(-1, 0);
            }

            if (Keyboard.current[downKey].wasPressedThisFrame &&
                selectorY > -4)
            {
                selectorY--;
                InventoryLoader.inventoryFishSelector.transform.position +=
                    new Vector3(0, -1);
            }

            if (Keyboard.current[upKey].wasPressedThisFrame &&
                selectorY < 0)
            {
                selectorY++;
                InventoryLoader.inventoryFishSelector.transform.position +=
                    new Vector3(0, 1);
            }
            else if (Keyboard.current[upKey].wasPressedThisFrame &&
                     selectorY == 0)
            {
                upperButtons = true;
                selectorY++;

                if ((selectorX == 0 || selectorX == 1) &&
                    Shop.inShop == true)
                {
                    selectorX = 0;

                    InventoryLoader.inventoryFishSelector.transform.position =
                        InventoryLoader.inventoryBg.transform.position +
                        new Vector3(-0.5f, 3);
                }
                else
                {
                    selectorX = 2;

                    InventoryLoader.inventoryFishSelector.transform.position =
                        InventoryLoader.inventoryBg.transform.position +
                        new Vector3(1.5f, 3);
                }
            }
        }

        if (upperButtons == true)
        {
            if (Shop.inShop == true &&
                Keyboard.current[leftKey].wasPressedThisFrame &&
                selectorX == 2)
            {
                selectorX = 0;

                InventoryLoader.inventoryFishSelector.transform.position +=
                    new Vector3(-2, 0);
            }

            if (Shop.inShop == true &&
                Keyboard.current[rightKey].wasPressedThisFrame &&
                selectorX == 0)
            {
                selectorX = 2;

                InventoryLoader.inventoryFishSelector.transform.position +=
                    new Vector3(2, 0);
            }

            if (Keyboard.current[downKey].wasPressedThisFrame)
            {
                selectorY--;
                upperButtons = false;

                InventoryLoader.inventoryFishSelector.transform.position +=
                    new Vector3(0, -1);
            }
        }
    }

    private void shopBuySelection()
    {

    }

}