using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    private void Start()
    {
        score = 0;
        scoreText.text = "Coins : " + score;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            score++;
            scoreText.text = "Coins : " + score;
            Destroy(collision.gameObject);
        }
    }
}
