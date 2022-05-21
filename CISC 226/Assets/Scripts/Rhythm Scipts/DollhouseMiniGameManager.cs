using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollhouseMiniGameManager : MonoBehaviour
{
    public GameObject brain;
    public GameObject brainRhythm;

    public GameObject heart;
    public GameObject heartRhythm;

    public GameObject dollEye;
    public GameObject dollEyeRhythm;

    public bool miniGameComplete(GameObject obj)
    {
        brain = GameObject.Find("Brain");
        heart = GameObject.Find("Heart");
        dollEye = GameObject.Find("Doll Eye");

        if (obj == brain)
        {
            if (BlockManager.brainWin == true)
            {
                return true;
            }
            return false;
        }
        if (obj == heart)
        {
            if (BlockManager.heartWin == true)
            {
                return true;
            }
            return false;
        }

        if (obj == dollEye)
        {
            if (BlockManager.dollEyeWin == true)
            {
                return true;
            }
            return false;
        }

        return true;
    }
    public void activateMiniGame(GameObject obj)
    {
        brain = GameObject.Find("Brain");
        heart = GameObject.Find("Heart");
        dollEye = GameObject.Find("Doll Eye");
        if (obj == brain)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            brainRhythm.SetActive(true);

        }
        if (obj == heart)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            heartRhythm.SetActive(true);

        }
        if (obj == dollEye)
        {
            //redBlockRhythm = GameObject.Find("Red Block Rhythm");
            dollEyeRhythm.SetActive(true);

        }
    }
}
