using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable] 
public class PoolData 
{ 
    public List<GameObject> prefabList = new List<GameObject>(); //this is pool prefab List
    public GameObject Prefab; // this is identity GameObject
    public string Name; // this is identity Key
}
public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public  static ObjectPool instance
    {
        get 
        { 
            if (_instance == null)
                _instance = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();

           return _instance;
        }
    }
    public List<PoolData> pList = new List<PoolData>();
    public void Create(GameObject Prefab, Vector3 pos, Quaternion quaternion)
    {
        GameObject temp_go = null;
        GameObject parent = transform.FindChild(Prefab.name + " Pool") ? transform.FindChild(Prefab.name + " Pool").gameObject : null;
        if (!transform.FindChild(Prefab.name + " Pool"))
        {
            GameObject temp_parent = new GameObject();
            temp_parent.name = Prefab.name + " Pool";
            temp_parent.transform.parent = gameObject.transform;
            parent = temp_parent;
        }

        foreach (PoolData p in pList)
        {
            //이 프리팹이 존재하는가?
            if (p.Prefab.Equals(Prefab))
            {
                bool findedNonActive = false;
                //오브젝트가 하나도 없을경우.
                if (p.prefabList.Count == 0)
                {
                    if (!findedNonActive)
                    {
                        temp_go = Instantiate(Prefab, pos, quaternion) as GameObject;
                        p.prefabList.Add(temp_go);
                    }
                    break;
                }
                //비활성 오브젝트 검사
                foreach (GameObject go in p.prefabList)
                {
                    if (!go.activeInHierarchy)
                    {
                        go.SetActive(true);
                        go.transform.position = pos;
                        go.transform.rotation = quaternion;
                        findedNonActive = true;
                        return;
                    }
                }
                //비활성 오브젝트가 없을시.
                if (!findedNonActive)
                {
                    temp_go = Instantiate(Prefab, pos, quaternion) as GameObject;
                    p.prefabList.Add(temp_go);
                }

                break;
            }
        }

        temp_go.transform.parent = parent.transform;
       
    }
  
}
