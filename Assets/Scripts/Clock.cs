using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    [SerializeField] private bool addTime;
    [SerializeField] private uint time = 5;

    public override void PickedUp()
    {
        int sign = addTime ? 1 : -1;

        GameManager.gameManager.AddTime((int)time * sign);
        base.PickedUp();

    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
