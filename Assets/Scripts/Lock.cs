using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool canOpen = false;

    Animator key;
    bool locked = false;
    public KeyColor myColor;
    public Door[] doors;

    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !locked) key.SetBool("useKey", CheckTheKey());
    }

    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.OpenClose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
            Debug.Log("Możesz otworzyć drzwi");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            Debug.Log("Nie możesz już otworzyć drzwi");
        }
    }

    public bool CheckTheKey()
    {
        if (myColor == KeyColor.Red)
        {
            return Change_key(ref GameManager.gameManager.redKey);

        }
        else if (myColor == KeyColor.Gold)
        {
            return Change_key(ref GameManager.gameManager.goldKey);
        }
        else if (myColor == KeyColor.Green)
        {
            return Change_key(ref GameManager.gameManager.greenKey);
        }
        else
        {
            Debug.Log("Coś poszło nie tak D:");
            return false;
        }
    }

    private bool Change_key(ref int nr_key)
    {
        if (nr_key <= 0) return false;
        nr_key--;
        locked = true;
        return true;
    }
}
