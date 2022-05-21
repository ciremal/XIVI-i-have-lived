using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPuzzle : MonoBehaviour
{
    public IsInInventory inventory;
    public GameObject blueBlock;
    public GameObject greenBlock;
    public GameObject redBlock;
    public ClickManager manager;
    public GameObject tower;
    public Sprite newImage;
    public GameObject key;

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
                if (hit.collider.gameObject.name == "Tower Puzzle")
                {
                    tower = hit.collider.gameObject;
                    blueBlock = GameObject.Find("Blue Block");
                    redBlock = GameObject.Find("Red Block");
                    greenBlock = GameObject.Find("Green Block");
                    if (inventory.InInventory(blueBlock) && inventory.InInventory(redBlock) && inventory.InInventory(greenBlock))
                    {
                        tower.GetComponent<SpriteRenderer>().sprite = newImage;
                        key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y - 9, key.transform.position.z);

                    }
                }
            }
        }
    }
}
