using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red, Green, Gold
}

public class Key : PickUp
{
    [SerializeField] private KeyColor color;

    public override void PickedUp()
    {
        GameManager.gameManager.AddKey(color);
        base.PickedUp();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
