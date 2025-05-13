using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerControls ControlPlayer1, ControlPlayer2;
    public GameObject Player1Object, Player2Object;
    public float Speed;
    public float yLimit;
    public static GameManager Instance;
    [SerializeField] GameObject BallObject;
   
    

    private void Awake()
    {
        Instance = this;
        ControlPlayer1 = new PlayerControls(KeyCode.W, KeyCode.S,Player1Object,yLimit);
        ControlPlayer2 = new PlayerControls(KeyCode.UpArrow, KeyCode.DownArrow,Player2Object,yLimit);
        RespawnBall();
    }

    private void Update()
    {
        ControlPlayer1.UpdateMovement(Speed);
        ControlPlayer2.UpdateMovement(Speed);

    }

    public void RespawnBall()
    {
        Instantiate(BallObject, Vector3.zero, Quaternion.identity);
    }



    

}
