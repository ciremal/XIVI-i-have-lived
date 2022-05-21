using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryMiniGameManager : MonoBehaviour
{
    public GameObject lighter;
    public GameObject lighterRhythm;

    public GameObject lockedBookKey;
    public GameObject lockedBookKeyRhythm;

    public GameObject kazooKey;
    public GameObject kazooKeyRhythm;

    public bool miniGameComplete(GameObject obj)
    {
        lighter = GameObject.Find("Lighter");
        lockedBookKey = GameObject.Find("Locked Book Key");
        kazooKey = GameObject.Find("Kazoo Book Key");

        if (obj == lighter)
        {
            if (BlockManager.lighterWin == true)
            {
                return true;
            }
            return false;
        }
        if (obj == lockedBookKey)
        {
            if (BlockManager.lockedBookKeyWin == true)
            {
                return true;
            }
            return false;
        }


        if (obj == kazooKey)
        {
            if (BlockManager.kazooKeyWin == true)
            {
                return true;
            }
            return false;
        }

        return true;
    }
    public void activateMiniGame(GameObject obj)
    {
        lighter = GameObject.Find("Lighter");
        lockedBookKey = GameObject.Find("Locked Book Key");
        kazooKey = GameObject.Find("Kazoo Book Key");
        if (obj == lighter)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            lighterRhythm.SetActive(true);

        }
        if (obj == lockedBookKey)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            lockedBookKeyRhythm.SetActive(true);

        }
        if (obj == kazooKey)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            kazooKeyRhythm.SetActive(true);

        }
    }
}
