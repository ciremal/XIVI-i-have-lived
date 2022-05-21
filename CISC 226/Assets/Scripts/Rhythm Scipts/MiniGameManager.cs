using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public GameObject redBlock;
    public GameObject redBlockRhythm;

    public GameObject blueBlock;
    public GameObject blueBlockRhythm;

    public GameObject needle;
    public GameObject needleRhythm;

    public bool miniGameComplete(GameObject obj)
    {
        redBlock = GameObject.Find("Red Block");
        blueBlock = GameObject.Find("Blue Block");
        needle = GameObject.Find("Needle");

        if (obj == redBlock){
            if (BlockManager.redBlockWin == true)
            {
                return true;
            }
            return false;
        }
        if (obj == blueBlock)
        {
            if (BlockManager.blueBlockWin == true)
            {
                return true;
            }
            return false;
        }

        if (obj == needle)
        {
            if (BlockManager.needleWin == true)
            {
                return true;
            }
            return false;
        }

        return true;
    }
    public void activateMiniGame(GameObject obj)
    {
        redBlock = GameObject.Find("Red Block");
        blueBlock = GameObject.Find("Blue Block");
        needle = GameObject.Find("Needle");
        if (obj == redBlock)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            redBlockRhythm.SetActive(true);

        }
        if (obj == blueBlock)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            blueBlockRhythm.SetActive(true);

        }
        if (obj == needle)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            needleRhythm.SetActive(true);

        }
    }
}
