using System.Collections.Generic;
using UnityEngine;

public enum CardType { Move, Other }

[System.Serializable]
public class Card
{
    public CardType type;
    public int moveValue;
}

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<Card> discardPile = new List<Card>();

    void Start()
    {
        InitializeDeck();
        Debug.Log("デッキ内容:");
        foreach (var c in deck)
        {
            Debug.Log($"{c.type} - {c.moveValue}");
        }
    }

    // デッキ初期化
    void InitializeDeck()
    {
        deck.Clear();

        // 例: 移動カード 1〜3マスを10枚ずつ + その他カード10枚 = 計40枚
        for (int i = 0; i < 10; i++) deck.Add(new Card { type = CardType.Move, moveValue = 1 });
        for (int i = 0; i < 10; i++) deck.Add(new Card { type = CardType.Move, moveValue = 2 });
        for (int i = 0; i < 10; i++) deck.Add(new Card { type = CardType.Move, moveValue = 3 });
        for (int i = 0; i < 10; i++) deck.Add(new Card { type = CardType.Other, moveValue = 0 });

        Shuffle(deck);
    }

    // シャッフル
    void Shuffle(List<Card> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Card temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    // カードをn枚引く
    public List<Card> DrawCards(int count)
    {
        hand.Clear();

        for (int i = 0; i < count; i++)
        {
            if (deck.Count == 0)
            {
                // 捨て札を戻してシャッフル
                deck.AddRange(discardPile);
                discardPile.Clear();
                Shuffle(deck);
            }

            if (deck.Count > 0)
            {
                Card drawn = deck[0];
                deck.RemoveAt(0);
                hand.Add(drawn);
            }
        }
        return hand;
    }

    // 捨て札へ
    public void DiscardHand()
    {
        discardPile.AddRange(hand);
        hand.Clear();
    }
}
