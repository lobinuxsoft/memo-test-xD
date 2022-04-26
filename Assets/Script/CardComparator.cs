using UnityEngine;

public class CardComparator : MonoBehaviour
{
    public static CardComparator instance;

    [SerializeField] private int totalCrads = 0;
    private CardSelector card1 = null;
    private CardSelector card2 = null;

    private void Awake()
    {
        instance = this;

        totalCrads = FindObjectsOfType<CardSelector>().Length;
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
            
            card1.transform.SetParent(this.transform);
            card2.transform.SetParent(this.transform);

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

        if (transform.childCount >= totalCrads)
        {
            Debug.Log("ENCONTRASTE TODAS LAS CARTAS!!!");
        }
    }
}
