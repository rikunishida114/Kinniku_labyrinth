using UnityEngine;
using TMPro;

public class DebugMuscleUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = $"胸腹: {playerStats.chestAbs}  足: {playerStats.legs}  腕: {playerStats.arms}  背中: {playerStats.back}";
    }
}
