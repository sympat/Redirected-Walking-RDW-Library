using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SimulationSetting
{
    public bool useVisualization;
    public bool useDebugMode;
    public bool useContinousSimulation;
    public PrefabSetting prefabSetting;
    public SpaceSetting realSpaceSetting;
    public SpaceSetting virtualSpaceSetting;
    public UnitSetting[] unitSettings;
}