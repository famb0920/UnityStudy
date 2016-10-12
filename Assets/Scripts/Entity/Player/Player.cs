using UnityEngine;
using System.Collections;

public class Player : Entity {

    public Player_Controller player_controller;
    public Player_Info player_info;

    GameObject go_player;
    static Player _instance;
    public static Player instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        go_player = this.gameObject;
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            if (go_player == null)
            {
            //    player = new GameObject();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

	public override void Start()
	{
		player_controller = new Player_Controller(gameObject);
		player_info = new Player_Info(gameObject);
	}
	
	public override void Update()
    {
		player_controller.Update();
        player_info.Update();
    }

	public override void FixedUpdate()
	{
		player_controller.FixedUpdate ();
	}
}
