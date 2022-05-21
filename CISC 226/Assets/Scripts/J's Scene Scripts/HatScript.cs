using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{
    public JIsInInventory other;
    public AudioSource audioSource;
    public AudioClip magic;
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
                GameObject wand = GameObject.Find("Wand");
                other = gameObject.GetComponent<JIsInInventory>();
                if (item == gameObject && other.InInventory(wand)) {
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                    gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                    StartCoroutine(Monkey());
                    this.enabled = false;
                }
            }
        }        
    }

    IEnumerator Monkey()
    {
        audioSource.PlayOneShot(magic, 1f);
        yield return new WaitForSeconds(0.5f);
        GameObject monkeys = GameObject.Find("Monkeys");
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            monkeys.transform.GetChild(0).gameObject.SetActive(false);
            monkeys.transform.GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            monkeys.transform.GetChild(0).gameObject.SetActive(true);
            monkeys.transform.GetChild(3).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.25f);
        monkeys.transform.GetChild(0).gameObject.SetActive(false);
        monkeys.transform.GetChild(1).gameObject.SetActive(true);
    }
}
