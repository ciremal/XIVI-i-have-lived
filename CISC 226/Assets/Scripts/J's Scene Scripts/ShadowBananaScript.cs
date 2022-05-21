using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBananaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Maze") == null) {
            StartCoroutine(Shadow());
            this.enabled = false;
        }
    }
    IEnumerator Shadow()
    {
        GameObject monkeys = GameObject.Find("Monkeys");
         yield return new WaitForSeconds(1f);
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.25f);
            monkeys.transform.GetChild(1).gameObject.SetActive(false);
            monkeys.transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            monkeys.transform.GetChild(1).gameObject.SetActive(true);
            monkeys.transform.GetChild(2).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.25f);
        monkeys.transform.GetChild(1).gameObject.SetActive(false);
        monkeys.transform.GetChild(2).gameObject.SetActive(true);
        GameObject cymbals = GameObject.Find("Cymbals");
        if (cymbals != null)
        {
            cymbals.transform.position = new Vector2(5.78f, -1.91f);
        }
    }
}
