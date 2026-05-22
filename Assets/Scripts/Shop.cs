using UnityEngine;
using UnityEngine.InputSystem;

public class Shop : MonoBehaviour
{
    public static bool inShop = false;
    public static bool shopJustOpened = false;

    private void Update()
    {
        if(shopJustOpened && !Keyboard.current[Player.interactKey].wasPressedThisFrame)
        {
            shopJustOpened = false;
        }
    }

    public static void Interact()
    {
            shopJustOpened = true;
            InventoryLoader.ShopOpenInventory();
    }

    public static void CloseShop()
    {
        if(inShop == true)
        {
            InventoryLoader.ShopCloseInventory();
        }
    }
}