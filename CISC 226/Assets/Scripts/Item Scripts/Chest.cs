using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour

{
    public IsInInventory inventory;
    public GameObject item;
    public ClickManager manager;
    public GameObject goldKazoo;
    public GameObject chest;

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
                if (hit.collider.gameObject.name == "Chest")
                {
                    chest = hit.collider.gameObject;
                    item = GameObject.Find("Key");
                    goldKazoo = GameObject.Find("Gold Kazoo");
                    if (inventory.InInventory(item) == true)
                    {
                        goldKazoo.transform.position = new Vector3(goldKazoo.transform.position.x, goldKazoo.transform.position.y - 9f, goldKazoo.transform.position.z);
                        manager.setMenuInactive(chest);
                    }
                }
            }
        }
    }
}
