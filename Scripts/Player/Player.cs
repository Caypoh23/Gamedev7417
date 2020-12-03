using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

//too many resposibilities on a single script: movement,attack
//ideally, you should separate user input from movement and animation and link them via events
public class Player : MonoBehaviour, IFlippable
{
    #region Properties

    #region Serializable Fields
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private RipplePostProcessor _ripple;
    [SerializeField] private ParticleSystem _dashParticle;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _startDashTime;
    #endregion

    #region Private Constants
    private const float _speed = 12.0f;
    private const float _jumpForce = 20.0f;
    #endregion
    
    private bool _resetJump = false;
    private bool _isGrounded = false;
    private bool _faceRight;
    private float _dashDuration;
    private float _direction;
    private float _playerHorizontalMove;
    
    
    #endregion
    
    private void Start()
    {
        _dashDuration = _startDashTime;
    }

    private void Update()
    {
        Move();
        Jump();
        Dash();
    }

    private void Move()
    {
        //why to store in local variable?
        _playerHorizontalMove = Input.GetAxisRaw("Horizontal");
        
        _isGrounded = IsGrounded();

        if (_playerHorizontalMove > 0)
        {
            
            Flip();
            //are you sure that you should change this value after call of the function where it is used?
            //why not to pass it as argument?
            _faceRight = true;
        }
        else if (_playerHorizontalMove < 0)
        {
            Flip();
            _faceRight = false;
        }
        _rigid.velocity = new Vector2(_playerHorizontalMove * _speed, _rigid.velocity.y);
        _playerAnimation.Move(_playerHorizontalMove);
    }

    private void Jump()
    {        
        if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded()))
        {
            _rigid.velocity = new Vector2(_rigid.velocity.y, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnimation.Jump(true);
        }
    }

    private void Dash()
    {
        if(_direction == 0 )
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) && !IsGrounded())
            {
                if(_playerHorizontalMove < 0)
                {
                    Instantiate(_dashParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),Quaternion.identity);
                    _direction = 1;
                }else if (_playerHorizontalMove > 0)
                {
                    Instantiate(_dashParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    _direction = 2;
                }
                _playerAnimation.Dash();
                _ripple.RippleEffect();
            }
        }
        else
        {
            if(_dashDuration <= 0)
            {
                _direction = 0;
                _dashDuration = _startDashTime;
                _rigid.velocity = Vector2.zero;
            }else
            {
                Instantiate(_dashParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),Quaternion.identity);
                _dashDuration -= Time.deltaTime;

                if(_direction == 1)
                {
                    _rigid.velocity = Vector2.left * _dashSpeed;
                }
                else if (_direction == 2)
                {
                    _rigid.velocity = Vector2.right * _dashSpeed;
                }
            }
        }
    }
    
    public void Flip()
    {
        if (_faceRight)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    #region Coroutines
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    #endregion
}
