using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EFishType
{
    BIG
}
public class FishSpawner : MonoBehaviour
{
    private int _fishSpawned;
    public GameObject _BigFishPrefab;

    public int GetFishSpawned(){return _fishSpawned;}
    public AFish SpawnFish(EFishType spawnType, UnityEngine.Vector2 pos)
    {
        switch (spawnType)
        {
            case EFishType.BIG:
                _fishSpawned++;
                return Instantiate(_BigFishPrefab, pos, _BigFishPrefab.transform.rotation).GetComponent<BigFish>();
            default : return null;
        }

    }    
}
