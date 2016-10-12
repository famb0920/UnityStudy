using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player_Controller {
    [SerializeField]
	Player_Statement.Player_State PlayerState;

    GameObject go_player;

	public Vector3 moveDirect = Vector3.zero;
	public bool isMoveFix = false;

	public KeyCode inputKey = KeyCode.None;

	public float moveSpeed = 4.0f;
	public float jumpPower = 4.0f;

    public Player_Controller(GameObject mine)
    {
        go_player = mine;
    }

	public void Update()
	{
		if (PlayerState == Player_Statement.Player_State.MOVEMENT || 
		    PlayerState == Player_Statement.Player_State.JUMP)
		{
			PlayerState = Player_Statement.CheckingPlayerState (go_player.transform);
			CheckingInput();
		}
	}

    public void FixedUpdate()
    {
		Movement ();

		switch (inputKey) 
		{
		case KeyCode.C:
			Jump();
			break;
		case KeyCode.X:
			Attack();
			break;
		}
    }

	void CheckingInput()
	{
		if (Input.anyKeyDown) 
		{
			if (Input.GetKeyDown (KeyCode.RightArrow))
			{
				isMoveFix = false;
				moveDirect = Vector3.right;
			}
			else if (Input.GetKeyDown (KeyCode.LeftArrow))
			{
				isMoveFix = false;
				moveDirect = Vector3.left;
			}

			if (Input.GetKeyDown (KeyCode.C))
			{
				inputKey = KeyCode.C;
			}
			else if (Input.GetKeyDown (KeyCode.X))
			{
				inputKey = KeyCode.X;
			}
		}
		else
		{
			if (Input.GetKeyUp (KeyCode.RightArrow) && moveDirect == Vector3.right)
			{
				if (PlayerState == Player_Statement.Player_State.JUMP)
					isMoveFix = true;
				else
					moveDirect = Vector3.zero;
			}
			else if (Input.GetKeyUp (KeyCode.LeftArrow) && moveDirect == Vector3.left)
			{
				if (PlayerState == Player_Statement.Player_State.JUMP)
					isMoveFix = true;
				else
					moveDirect = Vector3.zero;
			}
			
			if (Input.GetKeyUp (KeyCode.C) && inputKey == KeyCode.C)
			{
				inputKey = KeyCode.None;		
			}
			else if (Input.GetKeyUp (KeyCode.X) && inputKey == KeyCode.X)
			{
				inputKey = KeyCode.None;
			}
		}
	}

	void Movement()
	{
		if (PlayerState == Player_Statement.Player_State.MOVEMENT && isMoveFix)
		{
			isMoveFix = false;
			moveDirect = Vector3.zero;
		}

		if (moveDirect != Vector3.zero)
		{
			Vector3 move = moveDirect * moveSpeed * Time.deltaTime;
			go_player.rigidbody.MovePosition (go_player.transform.position + move);
		}
	}

	void Jump()
	{
		if (PlayerState == Player_Statement.Player_State.MOVEMENT) 
		{
			Vector3 jump = Vector3.up * jumpPower;
			go_player.rigidbody.AddForce(jump, ForceMode.Impulse);
		}
	}

	void Attack()
	{
		if (PlayerState == Player_Statement.Player_State.MOVEMENT || 
		    PlayerState == Player_Statement.Player_State.JUMP)
		{
			// Play animation
			// Other func~
			Debug.Log ("Attack!");

			//PlayerState = Player_Statement.Player_State.ATTACK;
			// ~End animation 
			//PlayerState = Player_Statement.CheckingPlayerState (go_player.transform);
		}
	}
}
