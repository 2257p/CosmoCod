using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryFish : MonoBehaviour
{

    public GameObject textPrefab;

    public Fish fish;
    private int inventoryIndex;
    public Sprite spr;

    private float lerpingVar = 0f;
    private float lerpingMax = 2f;
    private float lerpingMin = 1f;
    private float lerpingTime = 0f;
    private bool lerpingOut = false;

    public static GameObject fishNameText;
    public static GameObject fishSprite;
    public static GameObject fishValueText;
    public static GameObject fishMassText;

    private void Start()
    {

        for(int i = 0; i < Inventory.maxInventorySpace; i++)
        {
            if (Inventory.inventory[i] == fish)
            {
                inventoryIndex = i;
                break;
            }
        }

        Physics2D.queriesHitTriggers = true;

        //name text
        if(fishNameText == null)
        {
            fishNameText = Instantiate(textPrefab);
            fishNameText.transform.position = InventoryLoader.inventoryBg.transform.position + new Vector3(3.7f, 3);
            fishNameText.transform.parent = InventoryLoader.inventoryBg.transform;
        }
        
        //fish sprite
        if(fishSprite == null)
        {
            fishSprite = new GameObject("InventoryDescSprite");
            fishSprite.AddComponent<SpriteRenderer>();
            fishSprite.GetComponent<SpriteRenderer>().sprite = spr;
            fishSprite.transform.localScale = new Vector3(4, 4);
            fishSprite.transform.position = InventoryLoader.inventoryBg.transform.position + new Vector3(5.5f, 2);
            fishSprite.transform.parent = InventoryLoader.inventoryBg.transform;
        }

        //value text
        if(fishValueText == null)
        {
            fishValueText = Instantiate(textPrefab);
            fishValueText.transform.position = InventoryLoader.inventoryBg.transform.position + new Vector3(3.5f, 2f);
            fishValueText.transform.parent = InventoryLoader.inventoryBg.transform;
        }

        //mass text
        if(fishMassText == null)
        {
            fishMassText = Instantiate(textPrefab);
            fishMassText.transform.position = InventoryLoader.inventoryBg.transform.position + new Vector3(3.5f, 1.5f);
            fishMassText.transform.parent = InventoryLoader.inventoryBg.transform;
        }

    }

    private void Update()
    {
        if (lerpingTime < 1)
        {
            lerpingTime += Time.deltaTime;
        }
        Debug.Log(lerpingVar);

        if(Player.selectorX + (-Player.selectorY*3) == inventoryIndex)
        {
            if (lerpingOut == false)
            {
                lerpingTime = 1 - lerpingTime;
                lerpingOut = true;
            }

            fishNameText.GetComponent<TMP_Text>().text = this.fish.getName();
            fishSprite.GetComponent<SpriteRenderer>().sprite = spr;
            fishValueText.GetComponent<TMP_Text>().text = "Value: " + this.fish.getValue().ToString();
            fishMassText.GetComponent<TMP_Text>().text = "Mass: " + this.fish.getMass().ToString();

            if(lerpingVar < 1)
            {
                lerpingVar += Mathf.Pow(2, -5*(lerpingTime+0.3f));
            }

        } else
        {
            if(lerpingOut == true) 
            {
                lerpingTime = 1 - lerpingTime;
                lerpingOut = false;
            }            

            if(lerpingVar > 0)
            {
                lerpingVar -= Mathf.Pow(2, -5 * (lerpingTime + 0.3f));
            }
        }

        this.transform.localScale = new Vector3(Mathf.Lerp(lerpingMin, lerpingMax, lerpingVar), Mathf.Lerp(lerpingMin, lerpingMax, lerpingVar));

    }

    /*
    void OnMouseEnter()
    {
        Debug.Log("SDLFKJ");
        justHovered = true;
        fishNameText.GetComponent<TMP_Text>().text = this.fish.getName();
        fishSprite.GetComponent<SpriteRenderer>().sprite = spr;
        fishValueText.GetComponent<TMP_Text>().text = this.fish.getValue().ToString();
        fishMassText.GetComponent<TMP_Text>().text = this.fish.getMass().ToString();
    }
        
    

    void OnMouseExit()
    {
        Debug.Log("no");
        if(justHovered == true)
        {
            justHovered = false;
            fishNameText.GetComponent<TMP_Text>().text = "";
            fishSprite.GetComponent<SpriteRenderer>().sprite = null;
            fishValueText.GetComponent<TMP_Text>().text = "";
            fishMassText.GetComponent<TMP_Text>().text = "";
        }
    }
    */


}
