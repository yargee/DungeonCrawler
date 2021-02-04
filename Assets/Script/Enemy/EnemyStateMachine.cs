using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachineBehaviour
{
    [SerializeField] private Enemy _npc;
    [SerializeField] private Player _target;    
    [SerializeField] private float _distance;

    private Animator _animator;
    private float _attackDelay = 1.5f;
    private Health _targetHealth;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
        _npc = _animator.gameObject.GetComponent<Enemy>();
        _npc.TargetFound += OnTargetFound;
        _npc.TargetLost += OnTargetLost;
    }    

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckDistance();
    }

    protected void OnTargetLost()
    {
        _target = null;
    }

    protected void OnTargetFound()
    {
        _target = _npc.Target;
        _targetHealth = _target.GetComponent<Health>();
    }

    protected void CheckDistance()
    {
        
        if (_target != null)
        {
            Debug.Log("Checking Distance");
            _distance = Vector2.Distance(_npc.transform.position, _target.transform.position);
            _animator.SetFloat("distance", _distance);
        }
        else return;
    }

    protected void Attack()
    {
        _attackDelay += Time.deltaTime;

        if (_targetHealth != null && _attackDelay >= 1.0f)
        {
            _targetHealth.SetDamage(_npc.Damage);
            _attackDelay = 0;
        }
        else return;
    }

    protected void Chase()
    {
        if (_target != null)
        {           
            var direction = (_target.transform.position - _npc.transform.position);
            _npc.transform.Translate(direction * Time.deltaTime * _npc.Speed);
        }
        else return;
    }
}
