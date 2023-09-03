using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public FishSpawner _spawner;
    private RectTransform _transform;

    private void Awake() {
        _transform = GetComponent<RectTransform>();
    }

    private void Start() {
        StartCoroutine("SpawnFishes");
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnFishes()
    {
        while (_spawner._fishSpawned<5)
        {
        Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(-3f,3f), UnityEngine.Random.Range(-5f,3f));
        _spawner.SpawnFish(EFishType.BIG, spawnPos);
        yield return new WaitForSeconds(1);
        }
    }
}
