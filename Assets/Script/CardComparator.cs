using System;
using UnityEngine;

public class CardComparator : MonoBehaviour
{
    public static CardComparator instance;
    
    private CardSelector card1 = null;
    private CardSelector card2 = null;

    private void Awake()
    {
        instance = this;
    }

    public void SetCard(CardSelector card)
    {
        if (!card1)
        {
            card1 = card;
        }
        else if (!card2)
        {
            card2 = card;
        }

        if (card1 && card2) CompareCards();
    }

    private void CompareCards()
    {
        if (card1.name.Contains(card2.name))
        {
            card1.gameObject.SetActive(false);
            card2.gameObject.SetActive(false);

            card1 = null;
            card2 = null;
        }
        else
        {
            card1.RotateCard();
            card2.RotateCard();

            card1 = null;
            card2 = null;
        }
    }
}
