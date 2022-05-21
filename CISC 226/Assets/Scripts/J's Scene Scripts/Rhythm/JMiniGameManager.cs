using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMiniGameManager : MonoBehaviour
{
    public GameObject torch;
    public GameObject torchRhythm;

    public GameObject fireRing;
    public GameObject fireRingRhythm;

    public GameObject wand;
    public GameObject wandRhythm;

    public GameObject banana;
    public GameObject bananaRhythm;
    public static bool mini = false;

    public bool miniGameComplete(GameObject obj)
    {
        torch = GameObject.Find("Torch");
        fireRing = GameObject.Find("Fire Ring");
        wand = GameObject.Find("Wand");
        banana = GameObject.Find("Bananas");

        if (obj == torch){
            if (BlockManager.torchWin == true)
            {
                return true;
            }
            return false;
        }
        if (obj == fireRing)
        {
            if (BlockManager.fireRingWin == true)
            {
                return true;
            }
            return false;
        }

        if (obj == wand)
        {
            if (BlockManager.wandWin == true)
            {
                return true;
            }
            return false;
        }

        if (obj == banana)
        {
            if (BlockManager.bananaWin == true)
            {
                return true;
            }
            return false;
        }

        return true;
    }
    public void activateMiniGame(GameObject obj)
    {
        torch = GameObject.Find("Torch");
        fireRing = GameObject.Find("Fire Ring");
        wand = GameObject.Find("Wand");
        banana = GameObject.Find("Bananas");
        if (obj == torch)
        {
            //torchRhythm = GameObject.Find("Torch Rhythm");
            torchRhythm.SetActive(true);
            mini = true;

        }
        if (obj == fireRing)
        {
            //torchRhythm = GameObject.Find("Torch Rhythm");
            fireRingRhythm.SetActive(true);
            mini = true;

        }
        if (obj == wand)
        {
            //torchRhythm = GameObject.Find("Torch Rhythm");
            wandRhythm.SetActive(true);
            mini = true;

        }
        if (obj == banana)
        {
            //torchRhythm = GameObject.Find("Torch Rhythm");
            bananaRhythm.SetActive(true);
            mini = true;

        }
    }
}
