using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollhouseIsInInventory : MonoBehaviour
{
    public Vector2[] inventorySlot;

    public bool InInventory(GameObject item)
    {
        Vector2 itemPosition = item.transform.position;

        // Slots in "test scene" all have y == -0.5, edit if slot positions have changed
        if (itemPosition.x == 9f)
        {
            // Array of slot positions
            inventorySlot = new Vector2[4];

            inventorySlot[0] = new Vector2(9f, 2f);
            inventorySlot[1] = new Vector2(9f, 1f);
            inventorySlot[2] = new Vector2(9f, 0f);
            inventorySlot[3] = new Vector2(9f, -1f);

            foreach (Vector2 i in inventorySlot)
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
        // Item position != Slot position
        return false;
    }
}