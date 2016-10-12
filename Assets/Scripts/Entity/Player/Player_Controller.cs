using UnityEngine;
using System.Collections;
[System.Serializable]
public class Player_Controller {
    [SerializeField]
    Player_Statment.Player_Stats PlayerStatus;
    
    GameObject go_player;
    public bool isRight;
    public bool isXInput;

    public float directX = 0;
    public float directX_speed = 0;
    public float directX_smooth = .95f;
    public float directX_maxSpeed = 1.0f;

    public Player_Controller(GameObject mine)
    {
        go_player = mine;
    }

    public void Movement()
    {
 
    }
    
    public void Update()
    {
        Movement();
    }
}
