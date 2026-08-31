using System;

[Serializable]
public class PlayerInstance
{
    public string id;
    public string playerName;
    public string position;
    public int attack;
    public int defense;
    public int stamina;
    public int level = 1;

    public PlayerInstance() { }

    public PlayerInstance(string id, string playerName, string position, int attack, int defense, int stamina)
    {
        this.id = id;
        this.playerName = playerName;
        this.position = position;
        this.attack = attack;
        this.defense = defense;
        this.stamina = stamina;
        this.level = 1;
    }
}
