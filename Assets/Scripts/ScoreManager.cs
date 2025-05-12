using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float PlayerOneScore;
    private float PlayerTwoScore;
    public static ScoreManager Instance;


    private void Awake()
    {
        Instance = this; 
    }
    public void PointScore(int Player)
    {
        if (Player == 1)
            ++PlayerOneScore;
        if (Player == 2)
            ++PlayerTwoScore;
    }
}
