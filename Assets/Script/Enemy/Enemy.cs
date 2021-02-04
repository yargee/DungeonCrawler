using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _target;

    public float Speed => _speed;
    public int Damage => _damage;
    public Player Target => _target;

    private float _attackDelay = 0;
    private bool _cooldown;
    

    public event UnityAction TargetFound;
    public event UnityAction TargetLost;

    private void Start()
    {
        //var _movePoint = Random.insideUnitCircle * 4;
        //transform.position = Vector3.MoveTowards(transform.position, _movePoint, _speed * Time.deltaTime);
        _cooldown = _attackDelay > 0;
    }   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _target = player;
            TargetFound?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _target = null;
            TargetLost?.Invoke();
        }
    }
}
