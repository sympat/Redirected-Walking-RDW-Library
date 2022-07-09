using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// 사용하지 않음
public class TrainSetting
{
    public int n_agent;
    public TrainSpaceSetting realSpaceSetting;
    public TrainSpaceSetting virtualSpaceSetting;
    public UnitSetting unitSetting;
}
