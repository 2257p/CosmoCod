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

    public Rigidbody2D rb;
    Vector2 move;

    Shop nearbyShop;

    void Update()
    {
        move = Vector2.zero;

        if (!inCutscene)
        {
            if (Keyboard.current[upKey].isPressed)
                move.y += 1;
            if (Keyboard.current[downKey].isPressed)
                move.y -= 1;
            if (Keyboard.current[rightKey].isPressed)
                move.x += 1;
            if (Keyboard.current[leftKey].isPressed)
                move.x -= 1;

            if (Keyboard.current[interactKey].wasPressedThisFrame && nearbyShop != null)
            {
                nearbyShop.Interact();
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move.normalized * walkSpd);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Shop shop))
        {
            nearbyShop = shop;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Shop shop))
        {
            if (nearbyShop == shop)
                nearbyShop = null;
        }
    }
}