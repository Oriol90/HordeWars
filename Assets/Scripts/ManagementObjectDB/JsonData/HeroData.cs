using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeroData
{
    public string heroeName;
    public int heroeLevel;
    public List<int> heroeSkills;
    public Vector3Int heroPos;
}