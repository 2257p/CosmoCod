using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    float walkSpd = 0.05f;
    Key upKey = Key.UpArrow;
    Key downKey = Key.DownArrow;
    Key leftKey = Key.LeftArrow;
    Key rightKey = Key.RightArrow;
    Key interactKey = Key.Z;


    bool inCutscene = false;

    void Start()
    {
        
    }

    void Update()
    {

        playerMovement();

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

}
