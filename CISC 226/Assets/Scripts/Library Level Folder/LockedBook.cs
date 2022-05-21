using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBook : MonoBehaviour

{
    public LibraryIsInInventory inventory;
    public GameObject item;
    public ClickManager manager;
    public GameObject specialBook;
    public GameObject lockedBook;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);

            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

            // A collider is clicked
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Locked Book")
                {
                    lockedBook = hit.collider.gameObject;
                    item = GameObject.Find("Locked Book Key");
                    specialBook = GameObject.Find("Special Book");
                    if (inventory.InInventory(item) == true && BookStack.bookState == 2)
                    {
                        specialBook.transform.position = new Vector3(specialBook.transform.position.x, specialBook.transform.position.y - 9f, specialBook.transform.position.z);
                        manager.setMenuInactive(lockedBook);
                    }
                }
            }
        }
    }
}
