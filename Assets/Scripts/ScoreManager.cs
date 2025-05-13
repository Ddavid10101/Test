using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private float Player1Score;
    private float Player2Score;
    private int ScoreLimit = 5;
    public static ScoreManager Instance;
    [SerializeField] private TextMeshProUGUI Player1ScoreText, Player2ScoreText;
    private GameManager gameManager;

    private void Awake()
    {
        Instance = this; 
    }

    private void Update()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        Player1ScoreText.text = Player1Score.ToString();
        Player2ScoreText.text = Player2Score.ToString();
    }
    public void PointScore(int Player)
    {
        if (Player == 1)
            ++Player1Score;
        if (Player == 2)
            ++Player2Score;
        GameManager.Instance.RespawnBall();
    }

    private void VerifyGameEnd()
    {
        if (Player1Score > ScoreLimit || Player2Score > ScoreLimit)
            EndGame();
    }

    private void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
