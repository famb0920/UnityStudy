using UnityEngine;
using System.Collections;

public class Player_Statement
{

    public enum Player_State
    {
        MOVEMENT,
		JUMP,
        ATTACK,
		HIT
    }

	static public Player_State CheckingPlayerState (Transform player_trans)
	{
		RaycastHit hit;

		if (Physics.Raycast (player_trans.position, Vector3.down, out hit, 0.5f)) 
		{
			if (hit.transform.tag == "Ground")
			{
				return Player_State.MOVEMENT;
			}
		}

		return Player_State.JUMP;
	}

}
