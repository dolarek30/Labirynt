using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    [SerializeField] private int points = 5;

    public override void PickedUp()
    {
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
        Debug.Log("fdsfs");
    }

    void Update()
    {
        Rotation();
    }
}
