using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject backgroundMusic;
    public AudioSource WinMusic;
    public AudioClip WinSound;

    public Text coincountText;
    private int coincount;
    public Text winText;
    public AudioSource CoinMusic;
    public AudioClip CoinSound;
    public GameObject Timer;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        coincount = 0;
        SetCoinCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        var movement2 = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, movement2, 0) * Time.deltaTime * speed;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            coincount = coincount + 1;
            SetCoinCountText();
            CoinMusic.PlayOneShot(CoinSound);
        }
    }

    void SetCoinCountText()
    {
        coincountText.text = "Coins: " + coincount.ToString();
        if(coincount == 3)
        {
            Destroy(Timer.gameObject);
            Destroy(backgroundMusic.gameObject);
            winText.text = "You Win!!!";
            WinMusic.PlayOneShot(WinSound);
        }
    }
}
