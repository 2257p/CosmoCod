using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishCheck : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isInsideSquare = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            isInsideSquare = true;
            StartCoroutine(CheckDuration());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            isInsideSquare = false;
        }
    }

    IEnumerator CheckDuration()
    {
        yield return new WaitForSeconds(3f);

        if (isInsideSquare)
        {
            Debug.Log("test");
        }
    }
}
