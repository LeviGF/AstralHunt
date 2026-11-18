using UnityEngine;

public class MinimapCamara : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10f);
        }
    }
}