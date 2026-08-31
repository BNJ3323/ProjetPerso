using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MatchResult
{
    public int homeGoals;
    public int awayGoals;
    public List<string> events = new List<string>();
}

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Very simple simulation based on sum of attack/defense
    public MatchResult SimulateMatch(TeamData home, TeamData away, int seed = -1)
    {
        System.Random rng = seed >= 0 ? new System.Random(seed) : new System.Random();
        MatchResult result = new MatchResult();

        int homeAttack = 0;
        int homeDefense = 0;
        int awayAttack = 0;
        int awayDefense = 0;

        foreach (var p in home.players)
        {
            homeAttack += p.attack;
            homeDefense += p.defense;
        }
        foreach (var p in away.players)
        {
            awayAttack += p.attack;
            awayDefense += p.defense;
        }

        // compute offensive power vs defensive power and derive probable goals
        float homePower = (homeAttack * 0.6f + homeDefense * 0.4f) / Math.Max(1, home.players.Count);
        float awayPower = (awayAttack * 0.6f + awayDefense * 0.4f) / Math.Max(1, away.players.Count);

        // baseline scoring chance
        float homeScoreChance = Mathf.Clamp(0.5f + (homePower - awayPower) / 200f, 0.05f, 0.95f);
        float awayScoreChance = Mathf.Clamp(0.5f + (awayPower - homePower) / 200f, 0.05f, 0.95f);

        // simulate 90 minutes in discrete chunks
        for (int minute = 1; minute <= 90; minute += 5)
        {
            if (rng.NextDouble() < homeScoreChance * 0.08)
            {
                result.homeGoals++;
                result.events.Add($"{minute}' - But pour {home.teamName} (simulation)");
            }
            if (rng.NextDouble() < awayScoreChance * 0.06)
            {
                result.awayGoals++;
                result.events.Add($"{minute}' - But pour {away.teamName} (simulation)");
            }

            // small chance of other events
            if (rng.NextDouble() < 0.02)
            {
                result.events.Add($"{minute}' - Carton jaune (simulation)");
            }
        }

        // if no events, add a few flavor texts
        if (result.events.Count == 0)
        {
            result.events.Add("Match calme, aucune action majeure (simulation)");
        }

        result.events.Add($"Score final: {home.teamName} {result.homeGoals} - {result.awayGoals} {away.teamName}");

        return result;
    }
}
