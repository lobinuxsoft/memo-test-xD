using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CardComparator : MonoBehaviour
{
    public static CardComparator Instance;

    [SerializeField] private int totalCrads;
    private CardSelector[] cards = new CardSelector[2];

    private void Awake()
    {
        Instance = this;

        totalCrads = FindObjectsOfType<CardSelector>().Length;
    }

    public void SetCard(CardSelector card)
    {
        if (!cards[0])
        {
            cards[0] = card;
        }
        else if (!cards[1])
        {
            cards[1] = card;
        }

        if (cards[0] && cards[1]) CompareCards();
    }

    private async void CompareCards()
    {
        if (cards[0].name.Contains(cards[1].name))
        {
            cards[0].gameObject.SetActive(false);
            cards[1].gameObject.SetActive(false);
            
            cards[0].transform.SetParent(this.transform);
            cards[1].transform.SetParent(this.transform);

            cards[0] = null;
            cards[1] = null;
        }
        else
        {

            var tasks = new List<Task>();

            for (int i = 0; i < 2; i++)
            {
                tasks.Add(cards[i].RotateCard());
            }

            await Task.WhenAll(tasks);
            
            cards[0] = null;
            cards[1] = null;
        }

        if (transform.childCount >= totalCrads)
        {
            Debug.Log("ENCONTRASTE TODAS LAS CARTAS!!!");
        }
    }
}