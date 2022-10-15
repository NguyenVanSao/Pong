using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int scoreToReach;
    [SerializeField] int player1Score;
    [SerializeField] int player2Score;

    public Text player1ScoreText;
    public Text player2ScoreText;

    public void player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        checkScore();
    }

    public void player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        checkScore();
    }

    public void checkScore()
    {
        if(player1Score == scoreToReach || player2Score == scoreToReach)
        {
            SceneManager.LoadScene(2);
        }
    }


}
