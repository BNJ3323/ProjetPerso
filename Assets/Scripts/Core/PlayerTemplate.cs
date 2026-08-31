using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTemplate", menuName = "Game/PlayerTemplate")]
public class PlayerTemplate : ScriptableObject
{
    public string playerName;
    public string position;
    public int baseAttack = 50;
    public int baseDefense = 50;
    public int baseStamina = 50;
    public Sprite portrait;
}
