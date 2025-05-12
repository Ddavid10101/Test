using UnityEngine;

public class PlayerControls
{
    private KeyCode Upkey;
    private KeyCode Downkey;
    private int MoveAxis;
    private GameObject Object;
    private float Limit;


    public PlayerControls(KeyCode upkey, KeyCode downkey,GameObject Object,float Limit)
    {
        this.Upkey = upkey;
        this.Downkey = downkey;
        this.Object = Object;
        this.Limit = Limit;
    }
    
    public void UpdateMovement(float Speed)
    {  
        MoveAxis = UpdateAxis(); 
        if(CheckForValidMove(Object.transform.position.y,MoveAxis))
        Object.transform.Translate(Vector3.up * Speed * Time.deltaTime * MoveAxis);
    }

    private int UpdateAxis()
    {
        if (Input.GetKey(Upkey))
            return 1;
        if (Input.GetKey(Downkey))
            return -1;
        return 0;
    }

    private bool CheckForValidMove(float yPosition,int CurrentMove)
    {
        if (Mathf.Abs(yPosition)< Limit)
            return true;
        if (Mathf.Abs(yPosition) >= Limit && Mathf.Sign(yPosition) != CurrentMove)
            return true;
        return false;
    }
}
