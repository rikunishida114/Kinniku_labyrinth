using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string muscleType;
    public int gainPerSecond = 1;
    private bool isPressed = false;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if (isPressed)
        {
            playerStats.IncreaseMuscle(muscleType, Mathf.RoundToInt(gainPerSecond * Time.deltaTime));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
