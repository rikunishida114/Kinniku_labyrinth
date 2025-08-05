using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CardUIManager : MonoBehaviour
{
    public GameObject cardButtonPrefab;
    public Transform handArea;
    public PlayerController playerController;
    public TurnManager turnManager;

    public void ShowHand(List<Card> hand)
    {
        // 古いカードUI削除
        foreach (Transform child in handArea)
        {
            Destroy(child.gameObject);
        }

        // 新しいカードUI生成
        foreach (Card card in hand)
        {
            GameObject buttonObj = Instantiate(cardButtonPrefab, handArea);
            TextMeshProUGUI textUI = buttonObj.GetComponentInChildren<TextMeshProUGUI>();

            if (card.type == CardType.Move)
            {
                textUI.text = $"move {card.moveValue}";
                buttonObj.GetComponent<Image>().color = new Color(0.4f, 0.7f, 1f); // 青
            }
            else
            {
                textUI.text = "other";
                buttonObj.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f); // 灰
            }

            // クリック時の動作
            buttonObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (card.type == CardType.Move && turnManager.CanMove())
                {
                    playerController.MoveByCard(card.moveValue, Vector2Int.up);
                    turnManager.RegisterMove(card.moveValue);
                }
            });
        }
    }
}
