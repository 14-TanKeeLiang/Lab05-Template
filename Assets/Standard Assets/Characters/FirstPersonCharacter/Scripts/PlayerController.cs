using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int coinCollected;

    private AudioSource audioSource;

    public AudioClip[] audioClips;
    public Text coinCollectedTxt;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(coinCollected == 12)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(audioClips[0]);
            coinCollected += 1;
            coinCollectedTxt.text = "CoinCollected: " + coinCollected;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Water"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
