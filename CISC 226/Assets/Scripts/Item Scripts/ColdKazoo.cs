using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdKazoo : MonoBehaviour

{
    public ClickManager manager;
    public GameObject coldKazoo;
    public static bool haveColdKazoo = false;

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
                if (hit.collider.gameObject.name == "Cold Kazoo")
                {

                    coldKazoo = GameObject.Find("Cold Kazoo");
                    manager.setMenuInactive(coldKazoo);
                    haveColdKazoo = true;
                }
            }
        }
    }
}