using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ClubData", menuName = "Game/ClubData")]
public class ClubDataSO : ScriptableObject
{
    public string clubName = "Mon Club";
    public Sprite clubLogo;
    public int money = 1000;
    public string rank = "Débutant";
    public TeamData team = new TeamData("Equipe Principale");
}
