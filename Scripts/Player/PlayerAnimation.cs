using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }
    //method not readable
    //bad idea to have it like jump true false
    //better to split to separate functions like Jump and Land
    public void Jump(bool jump)
    {
        _animator.SetBool("Jump", jump);
    }

    public void Dash()
    {
        _animator.SetTrigger("Dash");
    }
    
}
