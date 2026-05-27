using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform player;
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        float diffX = player.position.x - transform.position.x;
        float diffY = player.position.y - transform.position.y;

        float newX = transform.position.x;
        float newY = transform.position.y;

        // only move camera in the direction of the player
        if (diffX > 0) newX += diffX;
        if (diffX < 0) newX += diffX;
        if (diffY > 0) newY += diffY;
        if (diffY < 0) newY += diffY;

        // clamp to bounds
        newX = Mathf.Clamp(newX, minX, maxX);
        newY = Mathf.Clamp(newY, minY, maxY);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}