using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal otherPortal;

    public Transform renderSurface;
    public Transform portalCollider;
    private GameObject player;
    private PortalTeleport portalTeleport;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.portalCollider;
    }
}
