// TestMatchStarter.cs (mettre sur un GameObject en scène pour test rapide)
using UnityEngine;
using System;
using System.Collections.Generic;
public class TestMatchStarter : MonoBehaviour
{
    public MatchView matchView;

    void Start()
    {
        // créer un adversaire simple si besoin
        var home = GameManager.Instance.CurrentClub.team;
        var away = new TeamData("Adversaire");
        // remplir l'adversaire (ex : copie de quelques joueurs)
        away.players.AddRange(home.players.Count > 0 ? home.players : new List<PlayerInstance>{
            new PlayerInstance(Guid.NewGuid().ToString(), "Joueur A", "ATT", 40,30,50),
            new PlayerInstance(Guid.NewGuid().ToString(), "Joueur B", "DEF", 30,40,50)
        });

        matchView.PlayMatch(home, away);
    }
}