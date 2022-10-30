using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    [SerializeField] BadApple theBA;

    public bool startPlaying;

    public static GameManager instance; // bruh this is painful

    public float bpm = 120;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMultiplier;

    public TextMeshProUGUI scoreText;

    public float totalNotes;
    public float successfulHits;

    public GameObject resultsScreen;
    public TextMeshProUGUI totalNotesText, notesHitText, accText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        instance = this;

        totalNotes = theBA.spawnTime.Length;
        Debug.Log(totalNotes);
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBA.hasStarted = true;

                theMusic.Play();
                GameObject.Find("Bad Apple Background").GetComponent<VideoPlayer>().Play();
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                totalNotesText.text = "" + totalNotes;
                notesHitText.text = "" + successfulHits;
                accText.text = (successfulHits / totalNotes * 100).ToString("F1") + "%";
                finalScoreText.text = "" + currentScore;
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit On Time");
        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
        successfulHits++;
    }

    public void NoteMissed()
    {
        //Debug.Log("Missed Note");
    }
}
