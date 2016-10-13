using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


[System.Serializable]
public class SceneChanger
{
    public string SceneName;

    public void SceneChange()
    {
        Application.LoadLevel(SceneName);
    }
}

public class GUIFunc
{
    public static void Func1()
    {

    }

    public static void UIUpdate()
    {
        Player.instance.player_info.OnUpdateUI();
    }
    public static void Create()
    {
        ObjectPool.instance.Create(ObjectPool.instance.pList[0].Prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public static void Create2()
    {
        ObjectPool.instance.Create(ObjectPool.instance.pList[1].Prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public static void Create3()
    {
        ObjectPool.instance.Create(ObjectPool.instance.pList[2].Prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
    public class GuiDebugger : MonoBehaviour
    {

        public SceneChanger changer = new SceneChanger();
        public bool DrawGUI = false;
        private int guiCall = 1;
        public float gameSpeed = 1;


        void OnGUI()
        {
            if (DrawGUI == false) return;


            CreateButton(GUIFunc.UIUpdate, 80, "UI_Update");
            CreateButton(GUIFunc.Create, 80, "박스");
            CreateButton(GUIFunc.Create2, 80, "캡슐");
            CreateButton(GUIFunc.Create3, 80, "동그라미");
            CreateButton(GUIFunc.Func1, 80, "Method");
            CreateButton(GUIFunc.Func1, 80, "Method");
            CreateButton(GUIFunc.Func1, 80, "Method");
            CreateButton(GUIFunc.Func1, 80, "Method");


            guiCall = 1;
        }


        void CreateButton(Action method, int width, string text)
        {
            int widthPosition = 0 + guiCall * width;
            int tempHeight = guiCall;
            int height = 0;
            while (true)
            {
                tempHeight -= 5;
                if (tempHeight > 0)
                {
                    height++;
                }
                else
                {
                    widthPosition = 0 + (tempHeight + 5) * width;
                    break;
                };
            }
            if (GUI.Button(new Rect(widthPosition, 80 * height, width, 80), text))
            {
                method();
                Debug.Log(method.Method.Name + "Running");
            }
            guiCall++;
        }
        void CreateButton(Action<int> method, int width, string text)
        {
            int widthPosition = 0 + guiCall * width;
            int tempHeight = guiCall;
            int height = 0;
            while (true)
            {
                tempHeight -= 5;
                if (tempHeight > 0)
                {
                    height++;
                }
                else
                {
                    widthPosition = 0 + (tempHeight + 5) * width;
                    break;
                };
            }
            if (GUI.Button(new Rect(widthPosition, 80 * height, width, 80), text))
            {
                method(15);
                Debug.Log(method.Method.Name + "Running");
            }
            guiCall++;
        }



    }

