using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CardComparator : MonoBehaviour
{
    public static CardComparator Instance;

    [SerializeField] private int totalCrads;
    [SerializeField] private int cardsAmountToCompare = 2;
    private List<CardSelector> cards = new List<CardSelector>();

    private void Awake()
    {
        Instance = this;

        totalCrads = FindObjectsOfType<CardSelector>().Length;
    }

    public void SetCard(CardSelector card)
    {
        cards.Add(card);

        if (cards.Count == cardsAmountToCompare) CompareCards();
    }

    private async void CompareCards()
    {
        for (int i = 1; i < cards.Count; i++)
        {
            if (!cards[0].name.Contains(cards[i].name))
            {
                var tasks = new List<Task>();

                for (int j = 0; j < cards.Count; j++)
                {
                    tasks.Add(cards[j].RotateCard());
                }

                await Task.WhenAll(tasks);
            
                cards.Clear();
                
                return;
            }
        }

        foreach (CardSelector card in cards)
        {
            card.gameObject.SetActive(false);
            card.transform.SetParent(this.transform);
        }
        
        cards.Clear();

        if (transform.childCount >= totalCrads)
        {
            Debug.Log("ENCONTRASTE TODAS LAS CARTAS!!!");
        }
    }
}