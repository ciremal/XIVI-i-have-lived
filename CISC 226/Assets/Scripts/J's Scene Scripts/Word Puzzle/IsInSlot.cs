using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInSlot : MonoBehaviour
{
    public Vector2[] pumpkinSlot;

    public bool InSlot (GameObject item)
    {
        Vector2 itemPosition = item.transform.position;
      
        // Array of slot positions
        pumpkinSlot = new Vector2[4];
        pumpkinSlot[0] = GameObject.Find("Pumpkin Slot 1").transform.position;
        pumpkinSlot[1] = GameObject.Find("Pumpkin Slot 2").transform.position;
        pumpkinSlot[2] = GameObject.Find("Pumpkin Slot 3").transform.position;
        pumpkinSlot[3] = GameObject.Find("Pumpkin Slot 4").transform.position;

        foreach (Vector2 i in pumpkinSlot)
        {
            // Item position == Slot position
            if (itemPosition == i)
            {
                return true;
            }
        }
      
        // Item position != Slot position
        return false;
    }
}
