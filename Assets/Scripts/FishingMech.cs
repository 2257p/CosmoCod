using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Keyboard Keys")]
    public Key jumpKey;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FishingMechanism();
    }

    private void FishingMechanism()
    {
        bool notCeiling = false;
        bool jumpPressed = false;
        
        jumpPressed = Keyboard.current[jumpKey].wasPressedThisFrame;

        if (rb.position.y < 1)
        {
            notCeiling = true;
        }

        if (jumpPressed && notCeiling)
        {
             rb.linearVelocity = new Vector2(rb.linearVelocity.x, 3f);     
        }
    }
}
