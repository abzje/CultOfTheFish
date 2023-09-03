using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public abstract class AFish : MonoBehaviour
{
    [SerializeField] protected int _value;
    [SerializeField] protected float _speed;
    protected Vector3 _targetPos;
    
    private void Start() {
        _targetPos = transform.position;
    }

    private void Update() {
        Move();
    }

    protected abstract void ChangeTarget();
    protected abstract void Move();
} 
