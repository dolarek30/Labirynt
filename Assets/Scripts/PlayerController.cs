using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 velocity;
    private CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void PlayerMove ()
    {
        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    speed = 12;
                    break;
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
            }
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp") hit.gameObject.GetComponent<PickUp>().PickedUp();
    }
}
