using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player_UserInterface
{
    //나중에 UILabel로 변경할 아이들.
    public string HP;
    public string MP;
    public string EXP;
    public string JOB;
    public string MONEY;


    public void Initstallize()
    {
        //여기서 UILabel의 컴퍼넌트를 초기화시켜준다.
    }
}
[System.Serializable]
public class Player_Info {
    public Player_UserInterface player_ui;
    GameObject player_object;
    private int hp = 100;
    private int max_hp = 100;

    private int mp = 20;
    private int max_mp = 20;

    private int exp = 0;
    private int max_exp = 50;

    private int job_code = 0;

    private int money = 0;

    public int HP
    {
        get
        {
            OnUpdateUI();
            return hp;
        }
        set
        {
            hp = value;
            OnUpdateUI();
        }
    }

    public int MP
    {
        get
        {
            OnUpdateUI();
            return mp;
        }
        set
        {
            mp = value;
            OnUpdateUI();
        }
    }


    public int EXP
    {
        get
        {
            OnUpdateUI();
            return exp;
        }
        set
        {
            exp = value;
            OnUpdateUI();
        }
    }

    public int MONEY
    {
        get
        {
            OnUpdateUI();
            return money;
        }
        set
        {
            money = value;
            OnUpdateUI();
        }
    }


    public int JOB_CODE
    {
        get
        {
            OnUpdateUI();
            return job_code;
        }
        set
        {
            job_code = value;
            OnUpdateUI();
        }
    }


    

    public Player_Info(GameObject go)
    {
        player_object = go;
        Initstallize();
    }
    public void OnUpdateUI()
    {
        player_ui.EXP = exp.ToString();
        player_ui.HP = hp.ToString();
        player_ui.MP = mp.ToString();
        player_ui.MONEY = money.ToString();
        player_ui.JOB = JobcodeParser.GetJobName(job_code);
    }

    public void Initstallize()
    {
        player_ui = new Player_UserInterface();
    }

    public void Update()
    {

    }
}
