using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour

{
    public IsInInventory inventory;
    public GameObject item;
    public ClickManager manager;
    public GameObject smallKey;
    public GameObject balloon;

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
                if (hit.collider.gameObject.name == "Balloon")
                {
                    balloon = hit.collider.gameObject;
                    item = GameObject.Find("Needle");
                    smallKey = GameObject.Find("Small Key");
                    if (inventory.InInventory(item) == true )
                    {
                        smallKey.transform.position = new Vector3(smallKey.transform.position.x + 0.5f, smallKey.transform.position.y - 9.5f, smallKey.transform.position.z);
                        manager.setMenuInactive(balloon);
                    }
                }
            }
        }
    }
}