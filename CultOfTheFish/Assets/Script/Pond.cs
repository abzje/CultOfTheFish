using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    [SerializeField] private UnityEngine.Vector2 _horizontalBorder;
    [SerializeField] private UnityEngine.Vector2 _verticalBorder;
     [SerializeField] GameObject _hook;
    public UnityEngine.Vector2 HorizontalBorder { get => _horizontalBorder; set => _horizontalBorder = value; }
    public UnityEngine.Vector2 VerticalBorder { get => _verticalBorder; set => _verticalBorder = value; }

    private List<AFish> _fishes = new List<AFish>();
    public FishSpawner _spawner;
    private RectTransform _transform;

    private void Awake() {
        _transform = GetComponent<RectTransform>();
        _hook.SetActive(false);
    }

    private void Start() {
        StartCoroutine("SpawnFishes");
    }

    IEnumerator SpawnFishes()
    {
        while (_spawner.GetFishSpawned() < 5)
        {
        Vector2 spawnPos = new Vector2(
                UnityEngine.Random.Range(HorizontalBorder.x,HorizontalBorder.y), 
                UnityEngine.Random.Range(VerticalBorder.x,VerticalBorder.y));

        AFish fish = _spawner.SpawnFish(EFishType.BIG, spawnPos);
        _fishes.Add(fish);
        fish.fishHookedEvent = FishHooked;
        
        yield return new WaitForSeconds(1);
        }
    }

    public void ThrowHook(Vector3 pos)
    {
        pos.z = -1;
        _hook.transform.position = pos;
        _hook.SetActive(true);
    }

    public void FishHooked()
    {
        foreach (AFish f in _fishes)
        {
            if (f.GetState() == EFishState.Hooked)
            {
                _hook.SetActive(false); // remove the hook
                f.Caught(); // Put the fish in the caught category
                
                f.gameObject.SetActive(false); // remove fish's gameobject
            }
        }
    }
}
