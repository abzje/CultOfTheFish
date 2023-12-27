using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Pond _pond;

    private float _score;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Vector3 inGameMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _pond.ThrowHook(inGameMousePos);
        }
    }

    void AddScore(AFish f)
    {
        _score+=f.GetValue();
    }
}
