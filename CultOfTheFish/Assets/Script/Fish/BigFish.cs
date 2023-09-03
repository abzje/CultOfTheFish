using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BigFish : AFish
{
    protected override void Move()
    {
        if (Vector2.Distance(transform.position, _targetPos) < .05)
            ChangeTarget();

        transform.position = Vector2.MoveTowards(transform.position, _targetPos, Time.deltaTime*_speed);

        float angle = Mathf.Atan2(_targetPos.y - transform.position.y, _targetPos.x -transform.position.x ) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speed * Time.deltaTime * 250);
    }
    protected override void ChangeTarget()
    {
        float newX = Mathf.Clamp(transform.position.x + Random.Range(-2f, 2f),-3f, 3f);
        float newY = Mathf.Clamp(transform.position.y + Random.Range(-2f, 2f),-5f, 2f);
        _targetPos.x = newX;
        _targetPos.y = newY;
    }
}
