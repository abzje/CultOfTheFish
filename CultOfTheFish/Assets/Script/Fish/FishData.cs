using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FishData", menuName = "Fish/FishData", order = 0)]
public class FishData : ScriptableObject
{
    public int _value;
    public Sprite _sprite;
    public Vector3 _scale;
    public Color _color;

    public int GetValue() {return _value;}
}
