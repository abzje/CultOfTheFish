using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BigFish : AFish
{
    protected override void Move()
    {
        if (Vector2.Distance(transform.position, _targetPos) < .005)
            atTarget();

        transform.position = Vector2.MoveTowards(transform.position, _targetPos, Time.deltaTime*_speed);

        float angle = Mathf.Atan2(_targetPos.y - transform.position.y, _targetPos.x -transform.position.x ) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speed * Time.deltaTime * 250);
    }
    protected override void atTarget()
    {
        // Check if hooked
        if (state == EFishState.Hooked)
        {
            _radar.hookInRadarEvent -= hookInRadar;
            fishHookedEvent.Invoke();
        }

        // If not continue swimming
        float newX = Mathf.Clamp(transform.position.x + Random.Range(-2f, 2f),-3f, 3f);
        float newY = Mathf.Clamp(transform.position.y + Random.Range(-2f, 2f),-1.6f, 5f);
        _targetPos.x = newX;
        _targetPos.y = newY;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="Hook")
            state = EFishState.Hooked;
    }

    protected override void hookInRadar(Vector3 hookPos)
    {
        _targetPos = hookPos;
    }

    protected override void hookLeftRadar()
    {
        atTarget();
    }

    public override void Caught()
    {
        state = EFishState.Caught;
    }
}
