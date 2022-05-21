using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour

{
    public DollhouseIsInInventory inventory;
    public GameObject item;
    public ClickManager manager;
    public GameObject heart;
    public GameObject teddyBear;
    public GameObject teddyBearCut;

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

                if (hit.collider.gameObject.name == "Teddy Bear")
                {
                    teddyBear = hit.collider.gameObject;
                    item = GameObject.Find("Butter Knife");
                    heart = GameObject.Find("Heart");
                    teddyBearCut = GameObject.Find("Teddy Bear Cut");
                    if (inventory.InInventory(item) == true )
                    {
                        heart.transform.position = new Vector3(heart.transform.position.x, heart.transform.position.y - 12f, heart.transform.position.z);
                        teddyBearCut.transform.position = new Vector3(teddyBearCut.transform.position.x, teddyBearCut.transform.position.y - 12f, teddyBearCut.transform.position.z);
                        manager.setMenuInactive(teddyBear);
                    }
                }
            }
        }
    }
}