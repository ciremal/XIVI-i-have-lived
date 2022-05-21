using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript2 : MonoBehaviour
{
    public JIsInInventory other;
    public AudioSource audioSource;
    public AudioClip roar;

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
                if (item == gameObject) {
                    StartCoroutine(Lion(item));
                }
            }
        }
    }

    IEnumerator Lion(GameObject item) 
    {
        GameObject ring = GameObject.Find("Fire Ring");
        other = gameObject.GetComponent<JIsInInventory>();
        if (other.InInventory(ring)) {
            StartCoroutine(Match());
            this.enabled = false;
        } else {
            audioSource.PlayOneShot(roar, 1f);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(4).transform.localScale = new Vector2(-gameObject.transform.GetChild(4).transform.localScale.x, gameObject.transform.GetChild(4).transform.localScale.y);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(4).transform.localScale = new Vector2(-gameObject.transform.GetChild(4).transform.localScale.x, gameObject.transform.GetChild(4).transform.localScale.y);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            DialogueTrigger dialogue = gameObject.GetComponent<DialogueTrigger>();
            dialogue.TriggerDialogue();
        }
    }

    IEnumerator Match()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject match = GameObject.Find("Matching Game");
        match.transform.position = new Vector2(0f, 0f);
    }

    IEnumerator Fire() 
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        GameObject pumpkin = GameObject.Find("W Pumpkin");
        pumpkin.GetComponent<CircleCollider2D>().enabled = true;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
}
