using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public DeckManager deckManager;
    public PlayerController playerController;
    public CardUIManager cardUIManager;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI moveText;

    public float turnTime = 30f; // 30秒
    private float timer;
    private int moveLimit; // 移動可能マス
    private int movedThisTurn; // このターンで動いたマス

    void Start()
    {
        StartTurn();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            EndTurn();
            StartTurn();
        }

        UpdateUI();
    }

    void StartTurn()
    {
        timer = turnTime;
        movedThisTurn = 0;

        List<Card> hand = deckManager.DrawCards(5);
        Debug.Log($"引いたカード数: {hand.Count}");

        // 移動可能マス計算
        moveLimit = 0;
        foreach (var card in hand)
        {
            if (card.type == CardType.Move)
                moveLimit += card.moveValue;
        }

        // UI更新
        cardUIManager.ShowHand(hand);
        Debug.Log($"新しいターン開始: 移動上限 {moveLimit} マス");
    }

    void EndTurn()
    {
        deckManager.DiscardHand();
        Debug.Log("ターン終了");
    }

    public bool CanMove()
    {
        return movedThisTurn < moveLimit;
    }

    public void RegisterMove(int distance)
    {
        movedThisTurn += distance;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (timerText != null)
            timerText.text = $"time: {Mathf.CeilToInt(timer)}";

        if (moveText != null)
            moveText.text = $"move: {moveLimit - movedThisTurn}";
    }
}
