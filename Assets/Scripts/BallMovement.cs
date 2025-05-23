using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D Body;
    [SerializeField] float StartSpeed;
    [SerializeField] float SpeedMultiplier;
    [SerializeField] Vector2 NormalSpeed;
    private bool CollidedWithPlayer;
    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        Body.linearVelocity = Vector2.one * StartSpeed*GetOrientation(Random.Range(0,101));
        CollidedWithPlayer = false;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vertical"))
        {
            Body.linearVelocityX *= -1;
            if (!CollidedWithPlayer)
                SetNormalSpeed();
            Body.linearVelocityX += SpeedMultiplier * Mathf.Sign(Body.linearVelocityX);
        }
        if (collision.gameObject.CompareTag("Horizontal"))
            Body.linearVelocityY *= -1;

        if(collision.gameObject.CompareTag("ScoreBorder"))
        {
            SendPointScore(transform.position.x);
            Destroy(gameObject);
        }
    }

    

    private void SetNormalSpeed()
    {
        Body.linearVelocityX *= NormalSpeed.x;
        Body.linearVelocityY *= NormalSpeed.y;
        CollidedWithPlayer = true;
    }

    private void SendPointScore(float Position)
    {
        if (Position < 0)
            ScoreManager.Instance.PointScore(1);
        if (Position > 0)
            ScoreManager.Instance.PointScore(2);
        
    }

    private int GetOrientation(int Number)
    {
        if (Number <= 50)
            return -1;
        else
            return 1;
    }
}
//make the ball faster after first touch