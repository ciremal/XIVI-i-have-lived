using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMoveToInventory : MonoBehaviour
{
  public Vector2[] inventorySlot;
  public GameObject[] itemNumber;
  public JIsInInventory other;
  public Transform player;
  public PlayerMovement p;
  [SerializeField] public float dist;
  [SerializeField] public float speed;
  [SerializeField] public float pickUpDelay;
  float moveAccuracy = 0.15f;

  public JMiniGameManager minigame;

  // Start is called before the first frame update
  void Start()
  {
        itemNumber = new GameObject[4];
        itemNumber[0] = GameObject.Find("Torch");
        itemNumber[1] = GameObject.Find("Fire Ring");
        itemNumber[2] = GameObject.Find("Wand");
        itemNumber[3] = GameObject.Find("Bananas");
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

        inventorySlot = new Vector2[4];
        inventorySlot[0] = new Vector2(8f, 3f);
        inventorySlot[1] = new Vector2(8f, 2f);
        inventorySlot[2] = new Vector2(8f, 1f);
        inventorySlot[3] = new Vector2(8f, 0f);

        // Array of "inventory" items (MUST have collider component)
        itemNumber = new GameObject[4];
        itemNumber[0] = GameObject.Find("Torch");
        itemNumber[1] = GameObject.Find("Fire Ring");
        itemNumber[2] = GameObject.Find("Wand");
        itemNumber[3] = GameObject.Find("Bananas");


        // Get item that is clicked on
        GameObject item = GameObject.Find(hit.collider.gameObject.name);
        Debug.Log(item.name);

        //Checks distance between player and item
        //If distance is in range, perform the following actions
        if (Mathf.Abs(player.position.x - item.transform.position.x) < dist){

          //Check if the item is an inventory-item
          bool isItem = false;
          foreach (GameObject i in itemNumber){
            if (i == item){
              isItem = true;
            }
          }

          //Move player towards item if it is an inventory-item
          if (isItem && item.name != "Wand"){
            //Calls IENumerator to move player
            //StartCoroutine(MoveToPoint(item.transform.position));
          }
          //Calls IEnumerator to call inventory stuff
          StartCoroutine(Minigame(item));
        }
      }
    }
    foreach (GameObject i in itemNumber){
      StartCoroutine(MinigameComplete(i));
    }
  }

  public IEnumerator MoveToPoint(Vector2 point){
    Vector2 positionDifference = point - (Vector2)player.position;
    while(positionDifference.magnitude > moveAccuracy){
        player.Translate(speed * positionDifference.normalized * Time.deltaTime);
        p.anim.SetBool("run", true);
        positionDifference = point - (Vector2)player.position;
        yield return null;
      }
    player.position = point;
    yield return null;
  }

  public IEnumerator Minigame(GameObject item){
    // Call IsInInventory script
    yield return new WaitForSeconds(pickUpDelay);

    foreach (GameObject i in itemNumber){

      // Clicked item is an inventory item
      if (i == item){

        if (minigame.miniGameComplete(i) == false){
            Debug.Log("False");
            minigame.activateMiniGame(i);
        }
      }
    }
  }

  public IEnumerator MinigameComplete(GameObject item){
    // Call IsInInventory script
    yield return new WaitForSeconds(pickUpDelay);
    other = gameObject.GetComponent<JIsInInventory>();

    foreach (GameObject i in itemNumber){

      // Clicked item is an inventory item
      if (i == item){
        // Item is not already in inventory
        if (!(other.InInventory(item)) && minigame.miniGameComplete(i)){

          // Rescale
          //SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
          //float width = sr.bounds.size.x;
          //float height = sr.bounds.size.y;
          if (item.name == "Torch"){
            item.transform.localScale = new Vector2(0.8f, 0.8f);
          } else if (item.name == "Wand"){
            item.transform.localScale = new Vector2(1f, 1f);
          } else if (item.name == "Fire Ring"){
            item.transform.localScale = new Vector2(0.07f, 0.07f);
          } else if (item.name == "Bananas"){
            item.transform.localScale = new Vector2(-0.4f, 0.4f);
          }

          //item.transform.localScale = new Vector2(0.85f *width, 0.85f*height);

          // Start at first slot
          int slot = 0;

          foreach (GameObject j in itemNumber){
            // Another inventory item is in the inventory

            if (other.InInventory(j)){
              // Move to the next slot
              slot++;
            }
          }

          // Move item into the first empty slot
          Debug.Log(slot);
          item.transform.position = inventorySlot[slot];
          break;
        }
      }
    }
  }
}
