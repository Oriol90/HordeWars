using System;

[Serializable]
public class TalentData
{
    public string name;
    public string description;
    public Boolean enabled { get; set; }
    public Boolean locked { get; set; }
    public String require1;
    public String require2;
}