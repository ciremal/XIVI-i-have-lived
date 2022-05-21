using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacup : MonoBehaviour
{
    public DollhouseIsInInventory inventory;

    public ClickManager manager;
    public GameObject emptyCup;
    public GameObject fullCup;
    public GameObject coldKazoo;

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
                if (hit.collider.gameObject.name == "Empty Tea Cup")
                {
                    emptyCup = hit.collider.gameObject;
                    fullCup = GameObject.Find("Full Tea Cup");
                    coldKazoo = GameObject.Find("Cold Kazoo");
                    if (Teapot.isTeapotFull == true)
                    {
                        manager.setMenuInactive(emptyCup);
                        fullCup.transform.position = new Vector3(fullCup.transform.position.x, fullCup.transform.position.y - 9, fullCup.transform.position.z);
                        coldKazoo.transform.position = new Vector3(coldKazoo.transform.position.x, coldKazoo.transform.position.y - 9, coldKazoo.transform.position.z);

                    }
                }
            }
        }
    }
}
