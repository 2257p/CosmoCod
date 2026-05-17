using TMPro;
using UnityEngine;

public class InventoryFish : MonoBehaviour
{

    public GameObject textPrefab;

    private bool cursorIsHovering;
    public Fish fish;

    public static GameObject fishNameText;
    public static GameObject fishValueText;
    public static GameObject fishMassText;

    private void Start()
    {
        //name text
        if(fishNameText == null)
        {
            fishNameText = Instantiate(textPrefab);
        }
        fishNameText.transform.position = InventoryLoader.inventoryBg.transform.position + new Vector3(2, 3);
        fishNameText.transform.parent = InventoryLoader.inventoryBg.transform;
        fishNameText.GetComponent<TMP_Text>().text = fish.getName();
        
        //fish sprite


    }

    void Update()
    {
        showDetails();
    }

    private void showDetails()
    {
        if (cursorIsHovering)
        {



        }
    }

    private void OnMouseEnter()
    {
        cursorIsHovering = true;
    }

    private void OnMouseExit()
    {
        cursorIsHovering = false;
    }

}
