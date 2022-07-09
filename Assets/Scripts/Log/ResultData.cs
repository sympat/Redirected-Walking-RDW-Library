﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResultData
{
    private Dictionary<string, float> data;

    public ResultData() {
        data = new Dictionary<string, float>
        {
            {"unitID", 0},
            {"episodeID", 0},
            {"totalTime", 0},
            {"totalReset", 0},
            {"wallReset", 0},
            {"userReset", 0},
        };
    }

    public void setData(Dictionary<string, float> dict, bool useAddition = false)
    {
        foreach(KeyValuePair<string, float> pair in dict)
        {
            if(useAddition)
                AddData(pair.Key, pair.Value);
            else
                setData(pair.Key, pair.Value);
        }
    }

    public void setData(string key, float value)
    {
        if (!data.ContainsKey(key))
            data.Add(key, value);
        else
            data[key] = value;
    }

    public void AddData(string key, float value)
    {
        if (!data.ContainsKey(key))
            data.Add(key, 0);

        data[key] += value;
    }

    public void setEpisodeID(int episodeID)
    {
        data["episodeID"] = episodeID;
    }

    public void setUnitID(int unitID)
    {
        data["unitID"] = unitID;
    }

    public void setGains(GainType gaintype, float appliedGain)
    {
        switch (gaintype)
        {
            case GainType.Translation:
                AddData("sumOfAppliedTranslationGain", appliedGain);
                break;
            case GainType.Rotation:
                AddData("sumOfAppliedRotationGain", appliedGain);
                break;
            case GainType.Curvature:
                AddData("sumOfAppliedCurvatureGain", appliedGain);
                break;
            default:
                break;
        }
    }

    public void AddElapsedTime(float deltaTime)
    {
        data["totalTime"] += deltaTime;
    }

    public void AddWallReset()
    {
        data["wallReset"] += 1;
        data["totalReset"] += 1;
    }

    public void AddUserReset()
    {
        data["wallReset"] += 1;
        data["totalReset"] += 1;
    }

    public override string ToString()
    {
        string result = "";

        foreach(KeyValuePair<string, float> element in data)
        {
            result += element.Key + ": " + element.Value + "\n";
        }

        return result;
    }
}
