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

    public int directX_Prioty_Key = -1;
    public Player_Controller(GameObject mine)
    {
        go_player = mine;
    }

    public void Movement()
    {
        
        if (Input.GetKeyDown(KeyCode.A)) directX_Prioty_Key = (int)KeyCode.A;
        if (Input.GetKeyDown(KeyCode.D)) directX_Prioty_Key = (int)KeyCode.D;
        if (Input.GetKeyUp(KeyCode.A) && directX_Prioty_Key == (int)KeyCode.A) { directX_Prioty_Key = -1; }
        if (Input.GetKeyUp(KeyCode.D) && directX_Prioty_Key == (int)KeyCode.D) { directX_Prioty_Key = -1; }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            switch (directX_Prioty_Key)
            {
                case (int)KeyCode.A:
                    go_player.transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
                    break;
                case (int)KeyCode.D:
                    go_player.transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
                    break;
            }
        }
    }


    public void Update()
    {
        Movement();
    }
}
