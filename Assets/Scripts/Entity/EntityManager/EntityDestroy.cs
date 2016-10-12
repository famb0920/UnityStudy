using UnityEngine;
using System.Collections;

public class EntityDestroy : MonoBehaviour 
{
    enum E_TYPE
    {
        DESTROY,
        ACTIVE
    }
    [SerializeField]
    bool visible;
    [SerializeField]
    E_TYPE eraseType = E_TYPE.ACTIVE;





    void OnBecameVisible()
    {
        enabled = true;
    }
    void OnBecameInvisible()
    {
        enabled = false;
    }
}
