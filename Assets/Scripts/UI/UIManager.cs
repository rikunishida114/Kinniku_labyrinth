using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainActionPanel;
    public GameObject cardPanel;
    public GameObject trainingPanel;
    public GameObject backButton;

    public void ShowMainActions()
    {
        mainActionPanel.SetActive(true);
        cardPanel.SetActive(false);
        trainingPanel.SetActive(false);
        backButton.SetActive(false);
    }

    public void ShowCards()
    {
        mainActionPanel.SetActive(false);
        cardPanel.SetActive(true);
        trainingPanel.SetActive(false);
        backButton.SetActive(true);
    }

    public void ShowTraining()
    {
        mainActionPanel.SetActive(false);
        cardPanel.SetActive(false);
        trainingPanel.SetActive(true);
        backButton.SetActive(true);
    }
}
