using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookStack : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float dist;
    public LibraryIsInInventory inventory;
    public GameObject lighter;
    public GameObject water;
    public ClickManager manager;
    public GameObject bookStack;
    public Sprite stackOnFire;
    public Sprite stackBurnt;
    public static int bookState = 0;

    public GameObject test;

    // Update is called once per frame
    void Update()
    {
        //test = GameObject.Find("Book Stack");
        //Debug.Log((test.transform.position.x - player.position.x) < dist);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);

            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

            // A collider is clicked
            if (hit.collider != null)
            {   
                //Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Book Stack")
                {
                    bookStack = hit.collider.gameObject;
                    lighter = GameObject.Find("Lighter");
                    water = GameObject.Find("Cup Of Water");
                    if (inventory.InInventory(lighter) && bookState == 0 && (Mathf.Abs(bookStack.transform.position.x - player.position.x)) < dist)
                    {
                        bookStack.GetComponent<SpriteRenderer>().sprite = stackOnFire;
                        bookState = 1;
                    }
                    else if (inventory.InInventory(water) && bookState == 1){
                        bookStack.GetComponent<SpriteRenderer>().sprite = stackBurnt;
                        bookState = 2;
                    }
                }
            }
        }
    }
}
