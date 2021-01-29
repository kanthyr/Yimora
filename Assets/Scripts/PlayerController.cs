using System;
using System.Collections.Generic;
using Bolt;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public string lightPunchInputName;
    public string mediumPunchInputName;
    public string heavyPunchInputName;

    private const int maxlife = 1000;
    //private const int Maxsuper = 100;

    [SerializeField] private int currentlife;
    //[SerializeField] private int currentsuper;
    //[SerializeField] private int winMatches;

    [SerializeField] private bool isAttacking;
    private Animator _animator;
    private GameObject _hitbox;
    private GameObject _hurtbox;
    public string enemyHurtboxLayer;
    public string enemyHitboxLayer;

    private Collider2D _colHitbox;
    private Collider2D _colHurtbox;

    #region Referencias

    public int GetCurrentLife => currentlife;

    public int GetMaxLife => maxlife;
    
    public int ResetCurrentLife
    {
        set => currentlife = value;
    }

    public string GetPlayerName => gameObject.name;

    #endregion

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _hitbox = GameObject.FindWithTag("");
        _hurtbox = GameObject.FindWithTag("");
        
        _colHitbox = _hitbox.GetComponent<Collider2D>();
        _colHurtbox = _hurtbox.GetComponent<Collider2D>();
        isAttacking = false;
        
        currentlife = maxlife;
        //currentsuper = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown(lightPunchInputName))
            LightAttackCheck();
        
        if (Input.GetButtonDown(mediumPunchInputName))
            MediumAttackCheck();
        
        if (Input.GetButtonDown(heavyPunchInputName))
            HeavyAttackCheck();
        
        HurtboxCollisionCheck(_colHurtbox);
    }

    private void LightAttackCheck()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            _animator.SetBool("LA", true);
        }
    }

    private void MediumAttackCheck()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            _animator.SetBool("MA", true);
        }
    }
    
    private void HeavyAttackCheck()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            _animator.SetBool("HA", true);
        }
    }

    public void ActivateHitbox()
    {
        _hitbox.SetActive(true);
    }

    public void DoHit()
    {
        HitboxCollisionCheck(_colHitbox);
    }
    
    public void DeActivateHitbox()
    {
        _hitbox.SetActive(false);
    }
    
    public void EndAttack()
    {
        _animator.SetBool("LA", false);
        _animator.SetBool("MA", false);
        _animator.SetBool("HA", false);
        isAttacking = false;
    }

    private void HitboxCollisionCheck(Collider2D collider2D)
    {
        var bounds = collider2D.bounds;
        Collider2D[] cols =
        {
            Physics2D.OverlapBox(bounds.center, bounds.extents, collider2D.transform.rotation.z)
        };
        foreach (Collider2D c in cols)
        {
            if (c == null)
            {
                Debug.Log("No hit");
            }
            else
            {
                Debug.Log("Hit: "+ c.name);
            }
        }
    }

    private void HurtboxCollisionCheck(Collider2D collider2D)
    {
        var bounds = collider2D.bounds;
        Collider2D[] cols =
            {
                Physics2D.OverlapBox(bounds.center, bounds.extents, collider2D.transform.rotation.z)
            };
        foreach (Collider2D c in cols)
        {
            if (!c)
            {
                //Debug.Log("No hit");
            }
            else
            {
                //Debug.Log("Hit: "+ c.name);
                currentlife -= 5;
            }
        }
    }
    
}
