using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollhouseInventory : MonoBehaviour
{
    public Vector2[] inventorySlot;
    public GameObject[] itemNumber;
    public DollhouseIsInInventory other;
    public Transform player;
    public PlayerMovement p;
    [SerializeField] public float dist;
    [SerializeField] public float speed;
    [SerializeField] public float pickUpDelay;
    float moveAccuracy = 0.15f;

    public DollhouseMiniGameManager minigame;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Left Mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get Mouse position in 2D
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);

            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

            // A collider is clicked
            if (hit.collider != null)
            {

                // Array of inventory slot positions
                /*
                inventorySlot = new Vector2[5];
                inventorySlot[0] = new Vector2(-1.5f, -0.5f);
                inventorySlot[1] = new Vector2(-0.5f, -0.5f);
                inventorySlot[2] = new Vector2(0.5f, -0.5f);
                inventorySlot[3] = new Vector2(1.5f, -0.5f);
                inventorySlot[4] = new Vector2(2.5f, -0.5f);
                */

                inventorySlot = new Vector2[4];
                inventorySlot[0] = new Vector2(9f, 2f);
                inventorySlot[1] = new Vector2(9f, 1f);
                inventorySlot[2] = new Vector2(9f, 0f);
                inventorySlot[3] = new Vector2(9f, -1f);

                // Array of "inventory" items (MUST have collider component)
                itemNumber = new GameObject[4];
                itemNumber[0] = GameObject.Find("Butter Knife");
                itemNumber[1] = GameObject.Find("Brain");
                itemNumber[2] = GameObject.Find("Heart");
                itemNumber[3] = GameObject.Find("Doll Eye");



                // Get item that is clicked on
                GameObject item = GameObject.Find(hit.collider.gameObject.name);

                //Checks distance between player and item
                //If distance is in range, perform the following actions
                if (Mathf.Abs(player.position.x - item.transform.position.x) < dist)
                {

                    //Check if the item is an inventory-item
                    bool isItem = false;
                    foreach (GameObject i in itemNumber)
                    {
                        if (i == item)
                        {
                            isItem = true;
                        }
                    }


                    //Calls IEnumerator to call inventory stuff
                    StartCoroutine(CallIsInventory(item));
                }
            }
        }
    }



    public IEnumerator CallIsInventory(GameObject item)
    {
        // Call IsInInventory script
        yield return new WaitForSeconds(pickUpDelay);
        other = gameObject.GetComponent<DollhouseIsInInventory>();

        foreach (GameObject i in itemNumber)
        {

            // Clicked item is an inventory item
            if (i == item)
            {

                if (minigame.miniGameComplete(i) == false)
                {
                    Debug.Log("False");
                    minigame.activateMiniGame(i);
                }
                // Item is not already in inventory
                if (!(other.InInventory(item)) && minigame.miniGameComplete(i))
                {

                    // Rescale
                    //SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
                    //float width = sr.bounds.size.x;
                    //float height = sr.bounds.size.y;
                    item.transform.localScale = new Vector2(0.85f * item.transform.localScale.x, 0.85f * item.transform.localScale.y);

                    //item.transform.localScale = new Vector2(0.85f *width, 0.85f*height);

                    // Start at first slot
                    int slot = 0;

                    foreach (GameObject j in itemNumber)
                    {
                        // Another inventory item is in the inventory

                        if (other.InInventory(j))
                        {
                            // Move to the next slot
                            slot++;
                        }
                    }

                    // Move item into the first empty slot
                    item.transform.position = inventorySlot[slot];
                    break;
                }
            }
        }
    }
}