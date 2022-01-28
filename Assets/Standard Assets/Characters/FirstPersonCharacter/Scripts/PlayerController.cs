using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int coinCollected;
    private float timer;

    private AudioSource audioSource;

    public AudioClip[] audioClips;
    public Text coinCollectedTxt;
    public Text timerTxt;

    private int buildIn;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buildIn = SceneManager.GetActiveScene().buildIndex;

        if(buildIn == 2)
        {
            timer = 40;
        }
        if (buildIn == 3)
        {
            timer = 60;
        }
        if (buildIn == 4)
        {
            timer = 80;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCollected == 6 && buildIn == 2 || coinCollected == 10 && buildIn == 3 || coinCollected == 14 && buildIn == 4)
        {
            SceneManager.LoadScene("GameWin");
        }
        if(timer <= 0)
        {
            SceneManager.LoadScene("GameLose");
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        DisplayTime(timer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin") && buildIn == 2)
        {
            audioSource.PlayOneShot(audioClips[0]);
            coinCollected += 1;
            coinCollectedTxt.text = "Coin Collected: " + coinCollected + "/6";
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin") && buildIn == 3)
        {
            audioSource.PlayOneShot(audioClips[0]);
            coinCollected += 1;
            coinCollectedTxt.text = "Coin Collected: " + coinCollected + "/10";
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin") && buildIn == 4)
        {
            audioSource.PlayOneShot(audioClips[0]);
            coinCollected += 1;
            coinCollectedTxt.text = "Coin Collected: " + coinCollected + "/14";
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Water"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerTxt.text = "Time Left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
