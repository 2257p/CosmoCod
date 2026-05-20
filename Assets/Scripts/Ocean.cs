using UnityEngine;
using UnityEngine.InputSystem;

public class Ocean : MonoBehaviour
{
    
    public  GameObject TopSlab;
    public  GameObject BottomSlab;
    public  GameObject Goal;

    void Start()
    {
        TopSlab.SetActive(false);
        BottomSlab.SetActive(false);
        Goal.SetActive(false);

    }

    void Update()
    {
        if(Player.inOcean == true && Keyboard.current[Player.interactKey].wasPressedThisFrame)
        {
            showFishingMech();
        }
    }

    public void showFishingMech()
    {
        TopSlab.SetActive(true);
        BottomSlab.SetActive(true);
        Goal.SetActive(true);
    }

}
