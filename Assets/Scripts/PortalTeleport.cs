using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverLapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerIsOverLapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerIsOverLapping = false;
    }

    private void Teleportation()
    {
        if (playerIsOverLapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;

            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;

                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;

                positionOffset *= 2;

                float player_y = player.position.y;

                Vector3 final_vector = receiver.position + positionOffset;
                Vector3 final_vector = receiver.position + positionOffset;

                player.position = receiver.position + positionOffset;

                playerIsOverLapping = false;
            }
        }
    }

    void FixedUpdate()
    {
        Teleportation();
    }
}
