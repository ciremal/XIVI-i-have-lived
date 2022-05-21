using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KazooBook : MonoBehaviour

{
    public LibraryIsInInventory inventory;
    public GameObject item;
    public ClickManager manager;
    public GameObject kazoo;
    public GameObject kazooBook;
    public bool test = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(test);
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
                if (hit.collider.gameObject.name == "Kazoo Book")
                {
                    kazooBook = hit.collider.gameObject;
                    item = GameObject.Find("Kazoo Book Key");
                    kazoo = GameObject.Find("Safety Kazoo");
                    if (inventory.InInventory(item) == true)
                    {
                        kazoo.transform.position = new Vector3(kazoo.transform.position.x, kazoo.transform.position.y - 9f, kazoo.transform.position.z);
                        manager.setMenuInactive(kazooBook);
                    }
                }
            }
        }
    }
}
