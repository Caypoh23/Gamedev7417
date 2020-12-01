using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEvent;

    public void Destroy()
    {
        Destroy(_destroyEvent.gameObject);
    }
}
