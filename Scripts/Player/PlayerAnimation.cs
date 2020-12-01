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
    public void Jump(bool jump)
    {
        _animator.SetBool("Jump", jump);
    }

    public void Dash()
    {
        _animator.SetTrigger("Dash");
    }
    
}
