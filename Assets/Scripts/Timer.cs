using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer = 0f;
    Text timerText;
    public Text loseText;
    public AudioSource LoseMusic;
    public AudioClip LoseSound;
    public GameObject backgroundMusic;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
        loseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Timer: " + Mathf.Round(timer);

        if (timer >= 10)
        {
            Destroy(player.gameObject);
            Destroy(backgroundMusic.gameObject);
            loseText.text = "You Lose!!!";
            LoseMusic.PlayOneShot(LoseSound);
        }
    }
}
