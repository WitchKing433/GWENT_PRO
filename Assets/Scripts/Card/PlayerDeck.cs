using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    
    public  static int unitCards = 0;
    public static int totalCards = 0;
    public static int specialCards = 0;
    public TMP_Text tUnitCards;
    public TMP_Text tSpecialCards;
    public TMP_Text tTotalCards;
    public static List<GameObject> Deck1 = new List<GameObject>();
    public static List<GameObject> Deck2 = new List<GameObject>();
    public static GameObject Leader1;
    public static GameObject Leader2;
    private static bool leaderEnd = false;


    
    public static void LeaderEnd() { leaderEnd = true; }
    public static void ChangeLeader(GameObject leader)
    {
        if (leaderEnd == false) 
        {
            Leader1 = leader;
        }
        else
        {
            Leader2 = leader;
        }
        
    }
    public void AddGoldCard(GameObject card)
    {
        if (IsCardInDeck(card) == 0 && unitCards < 30)
        {
            Deck1.Add(card);
            unitCards++;
        }
    }
    public void AddSilverCard(GameObject card)
    {
        if (IsCardInDeck(card) < 3 && unitCards < 30)
        {
            Deck1.Add(card);
            unitCards++;
        }
    }
    public void AddSpecialCard(GameObject card)
    {
        if (IsCardInDeck(card) < 3 && specialCards < 10)
        {
            Deck1.Add(card);
            specialCards++;
        }
    }

    public void EliminateSpecialCard(GameObject card)
    {
        if (IsCardInDeck(card) != 0)
        {
            for (int i = 0; i < Deck1.Count; i++)
            {
                if (Deck1[i] == card)
                {
                    Deck1.RemoveAt(i);
                    specialCards--;
                    break;
                }
            }
        }
    }
    public void EliminateCard(GameObject card)
    {
        if (IsCardInDeck(card) != 0)
        {
            for (int i = 0; i < Deck1.Count; i++)
            {
                if (Deck1[i] == card)
                {
                    Deck1.RemoveAt(i);
                    unitCards--;
                    break;
                }
            }
        }
    }

    public

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        tUnitCards.text = $"{unitCards.ToString()}/30";
        tSpecialCards.text = $"{specialCards.ToString()}/10";
        totalCards = unitCards + specialCards;
        tTotalCards.text = $"{totalCards.ToString()}/40";
    }

    private static int IsCardInDeck(GameObject card)
    {
        int total = 0;
        for (int i = 0;i < Deck1.Count;i++)
        {            
            if(Deck1[i] == card)
            {
                total++;
            }
        }
        return total;
    }
    public static void ResetValues()
    {
        Deck2 = Deck1.GetRange(0, Deck1.Count);
        Deck1.Clear();
        unitCards = 0;
        totalCards = 0;
        specialCards = 0;
    }
    
}
