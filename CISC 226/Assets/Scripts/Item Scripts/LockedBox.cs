using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBox : MonoBehaviour   

{
    public IsInInventory inventory;
    public GameObject item;
    public ClickManager manager;
    public GameObject greenBlock;
    public GameObject lockedCase;
    public GameObject curtain;

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
    
                if (hit.collider.gameObject.name == "Locked Case" )
                {
                    lockedCase = hit.collider.gameObject;
                    item = GameObject.Find("Small Key");
                    greenBlock = GameObject.Find("Green Block");
                    curtain = GameObject.Find("Curtain");
                    Debug.Log(curtain);
                    if (inventory.InInventory(item) == true && curtain == null){
                        greenBlock.transform.position = new Vector3(greenBlock.transform.position.x, greenBlock.transform.position.y - 9, greenBlock.transform.position.z);
                        manager.setMenuInactive(lockedCase);
                    }
                }
            }
        }
    }
}
