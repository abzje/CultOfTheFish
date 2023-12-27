using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public delegate void HookInRadar(Vector3 hookPos);
    public delegate void HookLeftRadar();
    public event HookInRadar hookInRadarEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="Hook")
            hookInRadarEvent.Invoke(collision.transform.position);
    }
}
