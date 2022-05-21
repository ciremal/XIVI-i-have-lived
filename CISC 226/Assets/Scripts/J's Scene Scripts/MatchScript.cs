using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchScript : MonoBehaviour
{
    public GameObject[] card;
    public int counter;
    public AudioSource audioSource;
    public AudioClip roar;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        card = new GameObject[6];
        card[0] = GameObject.Find("Bear");
        card[1] = GameObject.Find("Lion 2");
        card[2] = GameObject.Find("Seal");
        card[3] = GameObject.Find("Ring 2");
        card[4] = GameObject.Find("Tricycle");
        card[5] = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x == 0) {
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
                    foreach (GameObject i in card)
                    {
                        if (item == i)
                        {
                            i.GetComponent<SpriteRenderer>().enabled = true;
                            i.transform.GetChild(0).gameObject.SetActive(true);
                            i.GetComponent<BoxCollider2D>().enabled = false;
                            counter = counter + 1;
                            break;
                        }
                    }
                    if (counter == 2)
                    {
                        StartCoroutine(Check());
                    }
                }
            }
        }
    }

    IEnumerator Check() 
    {
        foreach (GameObject i in card)
        {
            i.GetComponent<BoxCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(0.5f);
        if (card[1].GetComponent<SpriteRenderer>().enabled && card[3].GetComponent<SpriteRenderer>().enabled)
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.GetChild(7).gameObject.SetActive(false);
                gameObject.transform.GetChild(8).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.GetChild(8).gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
            gameObject.transform.GetChild(8).gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            gameObject.transform.position = new Vector2(-20f, 0f);
            StartCoroutine(Fire());
        } else {
            yield return new WaitForSeconds(1f);
            foreach (GameObject i in card)
            {
                i.GetComponent<SpriteRenderer>().enabled = false;
                i.transform.GetChild(0).gameObject.SetActive(false);
                i.GetComponent<BoxCollider2D>().enabled = true;
            }
            counter = 0;
        }
    }

    IEnumerator Fire() 
    {
        GameObject lion = GameObject.Find("Lion");
        lion.GetComponent<AudioSource>().PlayOneShot(roar, 1f);
        lion.transform.GetChild(4).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        lion.transform.GetChild(4).gameObject.SetActive(false);
        lion.transform.GetChild(5).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        lion.transform.GetChild(4).transform.localScale = new Vector2(-lion.transform.GetChild(4).transform.localScale.x, lion.transform.GetChild(4).transform.localScale.y);
        lion.transform.GetChild(4).gameObject.SetActive(true);
        lion.transform.GetChild(5).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        lion.transform.GetChild(4).gameObject.SetActive(false);
        lion.transform.GetChild(5).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        lion.transform.GetChild(4).transform.localScale = new Vector2(-lion.transform.GetChild(4).transform.localScale.x, lion.transform.GetChild(4).transform.localScale.y);
        lion.transform.GetChild(4).gameObject.SetActive(true);
        lion.transform.GetChild(5).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        lion.transform.GetChild(4).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            lion.transform.GetChild(0).gameObject.SetActive(false);
            lion.transform.GetChild(1).gameObject.SetActive(true);
            lion.transform.GetChild(2).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            lion.transform.GetChild(0).gameObject.SetActive(true);
            lion.transform.GetChild(1).gameObject.SetActive(false);
            lion.transform.GetChild(2).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(0.25f);
        lion.transform.GetChild(0).gameObject.SetActive(false);
        lion.transform.GetChild(1).gameObject.SetActive(true);
        lion.transform.GetChild(2).gameObject.SetActive(false);
        GameObject pumpkin = GameObject.Find("W Pumpkin");
        pumpkin.GetComponent<CircleCollider2D>().enabled = true;
        Destroy(lion.GetComponent<BoxCollider2D>());
        gameObject.SetActive(false);
    }
}
