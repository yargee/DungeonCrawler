using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    /*[SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _topBorder;
    [SerializeField] private Transform _bottomBorder;*/
    [SerializeField] private Animator _animator;
    [SerializeField] private CircleCollider2D _wallChecker;
    private Vector2 _direction = new Vector2(1,0);
    private Vector2 _stay = new Vector2(0, 0);

    private int x = 0;
    private int y = 0;
    private float timeToChangeDirection = 0;
    private int[] directionArray = { -1, 1 };

    
    

    
    void Update()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);        
    }
}




