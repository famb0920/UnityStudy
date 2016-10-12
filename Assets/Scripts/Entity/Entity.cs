using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {


	[HideInInspector]
    public Transform OwnerTransform;

    ~Entity() // this is finalize
    {
        Dispose(); //가비지컬렉터 해제
    }


    protected virtual void Dispose()
    {
        Debug.Log(gameObject.name + " Dispose !");
        return;
    }
	// Use this for initialization
    public virtual void Start()
    {
	
	}


    // Update -> Update2 cycle
    public virtual void Update2()
    {

    }

	// Update is called once per frame
	public virtual void Update () {
	    
	}

}
