using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject word = GameObject.Find("Word Puzzle");
        if(word == null) {
            StartCoroutine(Magician());
            this.enabled = false;
        }
    }

    IEnumerator Magician()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        GameObject wand = GameObject.Find("Wand");
        wand.transform.position = new Vector2(-1.53f, -0.43f);
        GameObject image = GameObject.Find("Canvas");
        image.transform.GetChild(1).gameObject.SetActive(false);
        image.transform.GetChild(2).gameObject.SetActive(true);
    }
}
