using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decks : MonoBehaviour
{   
    public static List<GameObject> P1Deck;
    public static List<GameObject> P2Deck;
    public static GameObject P1Leader;
    public static GameObject P2Leader;

    public GameObject P1Hand;
    public GameObject P2Hand;
    public static int P1CardsInHand = 0;
    public static void SaveDecks()
    {
        P1Deck = PlayerDeck.Deck2.GetRange(0, PlayerDeck.Deck2.Count);
        P2Deck = PlayerDeck.Deck1.GetRange(0, PlayerDeck.Deck1.Count);
        P1Leader = PlayerDeck.Leader1;
        P2Leader = PlayerDeck.Leader2;
    }

    public void P1ShuffleDeck()
    {
        for (int i = 0; i < P1Deck.Count; i++)
        {
            int a = Random.Range(i, P1Deck.Count - 1);
            GameObject temp = P1Deck[i];
            P1Deck[i] = P1Deck[a];
            P1Deck[a] = temp;
        }
    }

    public void P1Draw(int a)
    {
        for (int i = 0; i < a && P1CardsInHand < 10 && P1Deck.Count != 0; i++)
        {
            Vector3 scale = new Vector3(0.3f, 0.3f, 0.3f);
            GameObject P1Card = Instantiate(P1Deck[0], new Vector3(0, 0, 0), Quaternion.identity);
            P1Card.transform.SetParent(P1Hand.transform, false);
            P1Card.SetActive(true);
            P1Card.transform.localScale = scale;
            P1Deck.RemoveAt(0);
            P1CardsInHand++;
        }
    }

    void Start()
    {
    }

    
}
