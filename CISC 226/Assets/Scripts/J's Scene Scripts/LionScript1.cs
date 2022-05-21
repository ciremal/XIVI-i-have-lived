using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript1 : MonoBehaviour
{
    public JIsInInventory other;

    // Start is called before the first frame update
    void Start()
    {
        
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

            if (hit.collider != null) {
                // Get item that is clicked on
                GameObject item = GameObject.Find(hit.collider.gameObject.name);
                GameObject ring = GameObject.Find("Fire Ring");
                other = gameObject.GetComponent<JIsInInventory>();
                if (item == gameObject && other.InInventory(ring)) {
                    StartCoroutine(Fire());
                    this.enabled = false;
                }
            }
        }
    }
    IEnumerator Fire() 
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.transform.GetChild(3).transform.localScale = new Vector2(-gameObject.transform.GetChild(3).transform.localScale.x, gameObject.transform.GetChild(3).transform.localScale.y);
        }
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        GameObject pumpkin = GameObject.Find("W Pumpkin");
        pumpkin.transform.position = new Vector2(2.7f, -2.1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
