using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;

    public int chestAbs;  // 胸腹筋
    public int legs;      // 足
    public int arms;      // 腕
    public int back;      // 背中

    void Start()
    {
        currentHP = maxHP;
    }

    public void IncreaseMuscle(string muscleType, int amount)
    {
        switch (muscleType)
        {
            case "chestAbs": chestAbs += amount; break;
            case "legs": legs += amount; break;
            case "arms": arms += amount; break;
            case "back": back += amount; break;
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;
    }

    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;
    }
}
