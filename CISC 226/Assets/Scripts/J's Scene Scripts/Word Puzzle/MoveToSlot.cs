using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSlot : MonoBehaviour
{
    public int slot;
    public IsInSlot other;
    public GameObject[] pumpkin;
    public Vector2[] pumpkinSlot;
    public Vector2[] pumpkinLocation;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        pumpkin = new GameObject[4];
        pumpkin[0] = GameObject.Find("W");
        pumpkin[1] = GameObject.Find("A");
        pumpkin[2] = GameObject.Find("N");
        pumpkin[3] = GameObject.Find("D");

        pumpkinLocation = new Vector2[4];
        pumpkinLocation[0] = pumpkin[0].transform.position;
        pumpkinLocation[1] = pumpkin[1].transform.position;
        pumpkinLocation[2] = pumpkin[2].transform.position;
        pumpkinLocation[3] = pumpkin[3].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get Mouse position in 2D
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickPos.x, clickPos.y);
        
            // Used to detect what is clicked
            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);
            pumpkinSlot = new Vector2[4];
            pumpkinSlot[0] = GameObject.Find("Pumpkin Slot 1").transform.position;
            pumpkinSlot[1] = GameObject.Find("Pumpkin Slot 2").transform.position;
            pumpkinSlot[2] = GameObject.Find("Pumpkin Slot 3").transform.position;
            pumpkinSlot[3] = GameObject.Find("Pumpkin Slot 4").transform.position;
        
            // A collider is clicked
            if (hit.collider != null)
            {
                item = GameObject.Find(hit.collider.gameObject.name);

                bool isPumpkin = false;
                foreach (GameObject i in pumpkin){
                    if (i == item){
                        isPumpkin = true;
                    }
                }
                if (isPumpkin) {
                    other = gameObject.GetComponent<IsInSlot>();
                    if (!(other.InSlot(item))) {
                        slot = 0;
                        foreach (GameObject i in pumpkin){
                            if (other.InSlot(i)) {
                                slot++;
                            }
                        }
                        item.transform.position = pumpkinSlot[slot];
                        if (slot == 3) {
                            bool inOrder = true;
                            for (int i = 0; i < pumpkin.Length; i++) {
                                if ((Vector2) pumpkin[i].transform.position != pumpkinSlot[i]) {
                                    inOrder = false;
                                }
                            }
                            if (!(inOrder)) {
                                StartCoroutine(Incorrect());
                            } else {
                                StartCoroutine(Correct());
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator Incorrect() 
    {
        gameObject.transform.GetChild(9).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.transform.GetChild(9).gameObject.SetActive(false);
        for (int i = 0; i < pumpkin.Length; i++) {
            pumpkin[i].transform.position = new Vector2(pumpkinLocation[i].x, pumpkinLocation[i].y + 10.7f);
        }
        slot = 0;
    }

    IEnumerator Correct()
    {
        gameObject.transform.GetChild(10).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
