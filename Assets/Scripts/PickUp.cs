using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void PickedUp()
    {
        Debug.Log("PickedUp");
        GameManager.gameManager.CheckPickUps();
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, 0.5f));
    }
}
