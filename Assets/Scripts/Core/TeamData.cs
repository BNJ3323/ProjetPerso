using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TeamData
{
    public string teamName;
    public List<PlayerInstance> players = new List<PlayerInstance>();
    public int formation = 442; // simple numeric formation id
    public int tactic = 0; // placeholder for tactics

    public TeamData() { }

    public TeamData(string name)
    {
        teamName = name;
    }
}
