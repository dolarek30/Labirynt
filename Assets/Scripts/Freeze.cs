using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    [SerializeField] private int freezeTime = 10;

    public override void PickedUp()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        Destroy(this.gameObject);
    }

    void Update()
    {
        Rotation();
    }
}
