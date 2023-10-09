using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverLapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") playerIsOverLapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") playerIsOverLapping = false;
    }

    private void Teleportation()
    {
        if (playerIsOverLapping)
        {

        }
    }
}
