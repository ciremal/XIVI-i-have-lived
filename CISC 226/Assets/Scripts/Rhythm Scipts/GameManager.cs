using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int winScore;
    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public bool noScoreLoss = false;

    public float totalNotes;

    public GameObject resultsScreen;
    public Text finalScoreText, resultText;
    public SceneSwitcher sceneManager;

    public static bool circusCompleted = false;
    public static bool theatreCompleted = false;
    public static bool dollHouseCompleted = false;
    public static bool libraryCompleted = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        } else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                string resultVal = "You Lose";
                if(currentScore >= winScore)
                {
                    resultVal = "You Win!";
                }

                resultText.text = resultVal;
                finalScoreText.text = currentScore.ToString();

            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        if (!noScoreLoss)
        {
            Debug.Log("Hit Missed");

            currentMultiplier = 1;
            multiplierTracker = 0;
            multiText.text = "Multiplier: x" + currentMultiplier;
        }
    }

    public void BadNoteHit()
    {
        if (!noScoreLoss)
        {
            Debug.Log("Bad Note Hit");

            currentMultiplier = 1;
            multiplierTracker = 0;
            multiText.text = "Multiplier: x" + currentMultiplier;

            if (currentScore >= 0)
            {
                currentScore += -scorePerNote * 3;
            }
            scoreText.text = "Score: " + currentScore;
        }
    }

    public void BadNoteMissed()
    {
        Debug.Log("Bad Hit Missed");

    }

    public void ExtraScoreNoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier * 2;
        scoreText.text = "Score: " + currentScore;
    }

    public void ExtraScoreNoteMissed()
    {
        Debug.Log("High Score Note Missed");

    }

    public void PassingScoreNoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += 1500;
        scoreText.text = "Score: " + currentScore;
    }

    public void PassingScoreNoteMissed()
    {
        Debug.Log("High Score Note Missed");

    }

    public void exitScene()
    {
        if (currentScore >= 6500 && SceneManager.GetActiveScene().name == "Dollhouse Rhythm") {
            SceneManager.LoadScene("Levels Scene");
            dollHouseCompleted = true;
        } 
        else if (currentScore >= 9000 && SceneManager.GetActiveScene().name == "Library Level Rhythm") {
            SceneManager.LoadScene("Levels Scene");
            libraryCompleted = true;
        }
        else if (currentScore >= 3000 && SceneManager.GetActiveScene().name == "Circus Rhythm") {
            SceneManager.LoadScene("Circus Scene");
            circusCompleted = true;
        } 
        else if (currentScore >= 2000 && SceneManager.GetActiveScene().name == "RhythmDemo") {
            SceneManager.LoadScene("Levels Scene");
            theatreCompleted = true;
        //}
        //else if (currentScore >= 2000)
        //{
        //    sceneManager.goToRhythm();
        } else
        {
            sceneManager.back();
        }

    }
    /*
    public IEnumerator PowerUpNoteHit()
    {
        Debug.Log("Hit Power Up ");
        noScoreLoss = true;
        yield return new WaitForSeconds(2f);
        noScoreLoss = false;
        Debug.Log("Hit Power Time's Up ");
        Destroy(gameObject);

    }
    */



}
