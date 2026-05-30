using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform player;
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        float difX = player.position.x - transform.position.x;
        float difY = player.position.y - transform.position.y;
        float newX = transform.position.x;
        float newY = transform.position.y;

        if (difX > 0) newX += difX;
        if (difX < 0) newX += difX;
        if (difY > 0) newY += difY;
        if (difY < 0) newY += difY;

        // AI
        newX = Mathf.Clamp(newX, minX, maxX);
        newY = Mathf.Clamp(newY, minY, maxY);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}