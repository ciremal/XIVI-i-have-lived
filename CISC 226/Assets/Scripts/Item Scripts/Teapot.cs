using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teapot : MonoBehaviour
{
    public DollhouseIsInInventory inventory;
    public GameObject heart;
    public GameObject brain;
    public GameObject dollEye;
    public ClickManager manager;
    public GameObject emptyPot;
    public GameObject fullPot;
    public static bool isTeapotFull = false;

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
                if (hit.collider.gameObject.name == "Empty Tea Pot")
                {
                    emptyPot = hit.collider.gameObject;
                    heart = GameObject.Find("Heart");
                    brain = GameObject.Find("Brain");
                    dollEye = GameObject.Find("Doll Eye");
                    fullPot = GameObject.Find("Full Tea Pot");
                    if (inventory.InInventory(heart) && inventory.InInventory(brain) && inventory.InInventory(dollEye))
                    {
                        fullPot.transform.position = new Vector3(fullPot.transform.position.x, fullPot.transform.position.y - 8.6f, fullPot.transform.position.z);
                        manager.setMenuInactive(emptyPot);
                        manager.setMenuInactive(heart);
                        manager.setMenuInactive(brain);
                        manager.setMenuInactive(dollEye);
                        isTeapotFull = true;
                    }
                }
            }
        }
    }
}

