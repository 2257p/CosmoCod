using UnityEngine;

public class Shop : MonoBehaviour
{
    public static bool inShop = false;

    public static void Interact()
    {
        Debug.Log("Shop opened");
        InventoryLoader.ShopOpenInventory();
    }
}