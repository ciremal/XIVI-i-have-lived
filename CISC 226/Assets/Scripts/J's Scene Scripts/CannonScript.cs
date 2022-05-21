using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fizz;
    public AudioClip boom;
    public AudioClip thud;
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
                GameObject torch = GameObject.Find("Torch");
                other = gameObject.GetComponent<JIsInInventory>();
                if (item == gameObject && other.InInventory(torch)) {
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    StartCoroutine(Wait());
                    this.enabled = false;
                }
            }
        }
    }

    IEnumerator Wait()
    {
        audioSource.PlayOneShot(fizz, 1f);
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(boom, 1f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GameObject aPumpkin = GameObject.Find("Ghost 1");
        GameObject dPumpkin = GameObject.Find("Ghost 2");
        GameObject nPumpkin = GameObject.Find("Ghost 3");
        aPumpkin.transform.position = new Vector2(-4.91f, -0.66f);
        dPumpkin.transform.position = new Vector2(-4.58f, -1.1f);
        nPumpkin.transform.position = new Vector2(-4.51f, -1.93f);
        yield return new WaitForSeconds(0.5f);
        aPumpkin.transform.position = new Vector2(-4.73f, -0.47f);
        dPumpkin.transform.position = new Vector2(-4.3f, -1f);
        nPumpkin.transform.position = new Vector2(-4.297f, -1.958f);
        yield return new WaitForSeconds(0.1f);
        aPumpkin.transform.position = new Vector2(-4.37f, -0.24f);
        dPumpkin.transform.position = new Vector2(-4f, -0.99f);
        nPumpkin.transform.position = new Vector2(-3.945f, -2.143f);
        yield return new WaitForSeconds(0.1f);
        aPumpkin.transform.position = new Vector2(-3.5f, -0.04f);
        aPumpkin.transform.Rotate(0f, 0f, -60f, Space.Self);
        dPumpkin.transform.position = new Vector2(-3.8f, -0.87f);
        nPumpkin.transform.position = new Vector2(-3.5f, -2.4f);
        yield return new WaitForSeconds(0.1f);
        aPumpkin.transform.position = new Vector2(-2f, -0.04f);
        dPumpkin.transform.position = new Vector2(-2f, -1f);
        dPumpkin.transform.Rotate(0f, 0f, -45f, Space.Self);
        nPumpkin.transform.position = new Vector2(-2f, -2f);
        StartCoroutine(Pumpkin(nPumpkin));
        yield return new WaitForSeconds(0.1f);
        aPumpkin.transform.position = new Vector2(-0.28f, -0.73f);
        dPumpkin.transform.position = new Vector2(-0.45f, -2.07f);
        yield return new WaitForSeconds(0.1f);
        aPumpkin.transform.position = new Vector2(1.8f, -1.64f);
        dPumpkin.transform.position = new Vector2(0.17f, -2.38f);
        StartCoroutine(Pumpkin(dPumpkin));
        yield return new WaitForSeconds(0.1f);
        aPumpkin.transform.position = new Vector2(4.19f, -2.98f);
        StartCoroutine(Pumpkin(aPumpkin));
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.position = new Vector2(-10f, 0f);
        GameObject end = GameObject.Find("End Cannon");
        end.transform.position = new Vector2(-6.48f, -2.09f);
    }

    IEnumerator Pumpkin(GameObject pumpkin)
    {
        yield return new WaitForSeconds(0.5f);
        pumpkin.SetActive(false);
        if (pumpkin.name == "Ghost 3")
        {
            pumpkin = GameObject.Find("N Pumpkin");
            audioSource.PlayOneShot(thud, 1f);
            pumpkin.transform.position = new Vector2(1f, -3.6f);
        } else if (pumpkin.name == "Ghost 1")
        {
            pumpkin = GameObject.Find("A Pumpkin");
            audioSource.PlayOneShot(thud, 1f);
            pumpkin.transform.position = new Vector2(7f, -3.5f);
        } else if (pumpkin.name == "Ghost 2")
        {
            pumpkin = GameObject.Find("D Pumpkin");
            audioSource.PlayOneShot(thud, 1f);
            pumpkin.transform.position = new Vector2(-0.7f, -2.7f);
        }
    }
}
