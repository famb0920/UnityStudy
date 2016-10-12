using UnityEngine;
using System.Collections;

public class JobcodeParser : MonoBehaviour {


    public static string GetJobName(int JobCode)
    {
        string result = string.Empty;
        switch (JobCode)
        {
            case 0:
            result = "초보자";
            break;


            case 100:
            result = "전사";
            break;


            case 910:
            result = "운영자";
            break;
        }

        return result;
    }

}
