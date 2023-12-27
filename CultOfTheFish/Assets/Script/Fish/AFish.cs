using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public enum EFishState
{
    Free,
    Hooked,
    Caught
}

public abstract class AFish : MonoBehaviour
{
    public delegate void FishHooked();
    public FishHooked fishHookedEvent;


    [SerializeField] protected float _value;
    [SerializeField] protected float _speed;
    [SerializeField] protected Radar _radar;
    protected EFishState state = EFishState.Free;
    protected Vector3 _targetPos;


    public EFishState GetState() {return state;}
    public float GetValue() {return _value;}
 

    private void Start() {
        _targetPos = transform.position;
        _radar.hookInRadarEvent += hookInRadar;
    }

    private void Update() {
        Move();
    }

    public abstract void Caught();

    protected abstract void hookInRadar(Vector3 hookPos);
    protected abstract void hookLeftRadar();
    protected abstract void atTarget();
    protected abstract void Move();
} 
