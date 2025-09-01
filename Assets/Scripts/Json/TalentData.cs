using System;
using UnityEngine;

[Serializable]
public class TalentData : ScriptableObject
{
    public new string name;
    public string description;
    public Boolean enabled { get; set; }
    public Boolean locked { get; set; }
    public String require1;
    public String require2;
}