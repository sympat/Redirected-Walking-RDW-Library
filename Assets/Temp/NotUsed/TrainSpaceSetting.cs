using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// 사용하지 않음
public class TrainSpaceSetting
{
    public string name;
    public GameObject predefinedSpace;
    public Vector2 position;
    public float rotation;

    public Space2D GetSpace()
    {
        return new Space2DBuilder().SetName(name).SetPrefab(predefinedSpace).SetLocalPosition(position).SetLocalRotation(rotation).Build();
    }
}
