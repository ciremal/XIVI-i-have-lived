using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CymbalScript : MonoBehaviour
{
    public ClickManager manager;
    public static bool hasCymbal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                if (hit.collider.gameObject.name == "Cymbals") {
                    GameObject cymbals = GameObject.Find("Cymbals");
                    manager.setMenuInactive(cymbals);
                    hasCymbal = true;
                }
            }
        }
    }
}
