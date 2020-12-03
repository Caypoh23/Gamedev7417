using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//can't get the purpose of the script. should it destroy aother object not the current one?
public class DestroyEvent : MonoBehaviour
{
    //why name is event?
    [SerializeField] private GameObject _destroyEvent;
    
    //I didn't find where this method used. why to make it public?
    public void Destroy()
    {
        Destroy(_destroyEvent.gameObject);
    }
}
