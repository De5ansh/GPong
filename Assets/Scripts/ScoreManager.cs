using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int max;
    private int player1Score = 0;
    private int player2Score = 0;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public BallMovement move;
    // Start is called before the first frame update
    public void Player1Goal() {
        
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        check();
    }

    public void Player2Goal() {
        
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        check();
    }

    public void check() {
        if (player1Score == max || player2Score == max) {
            StartCoroutine(WaitAndLoad());
        } else {
            StartCoroutine(move.Launch());
        }
    }

    public IEnumerator WaitAndLoad() {
    yield return new WaitForSeconds(1); 
    SceneManager.LoadScene(2);
}
}
