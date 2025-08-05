using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;
    public PlayerStats playerStats;

    void Update()
    {
        slider.value = playerStats.currentHP / playerStats.maxHP;
    }
}
