using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowCard : MonoBehaviour
{
    public Card card;

    public bool bCount = false;
    private static int unitCards;
    private static int specialCards;
    private int cardCount = 0;
    public TMP_Text tCardCount;
    public TMP_Text tCardName;
    public TMP_Text tCardDescription;
    public TMP_Text tCardCardAtkType;
    public TMP_Text tCardPower;
    public Vector2 vOriginalPosition;
    public Vector2 vCanvasCenter;
    public Vector3 vScale;
    private Vector2 startPosition;
    private bool isDragging = false;
    private bool isCentered = false;



    // Start is called before the first frame update
    void Start()
    {
        tCardName.text = card.sCardName;
        tCardDescription.text = card.sCardDescription;
        tCardCardAtkType.text = card.sCardAtkType;
        tCardPower.text = card.iCardPower.ToString();
        vCanvasCenter = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2f, (Screen.height / 2f) + 150f));
    }
    private void Update()
    {
        if (bCount)
        {
            tCardCount.text = cardCount.ToString();
        }
        if(isDragging)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
        
    }
    
    public void StartDrag()
    {
        if (isCentered == false)
        {
            startPosition = transform.position;
            isDragging = true;
        }
    }
    public void EndDragg()
    {
        if (isCentered == false)
        {
            isDragging = false;
        }
    }

    public void Center(bool bCenter)
    {
        if (bCenter)
        {
            vScale = transform.localScale;
            vOriginalPosition = transform.position;
            transform.position = vCanvasCenter;
            transform.localScale = Vector3.one;
            isCentered = true;
        }
        else
        {
            transform.position = vOriginalPosition;
            transform.localScale = vScale;
            isCentered = false;
        }
    }
    public void ResetValue()
    {
        unitCards = 0;
        specialCards = 0;
    }

    public void Add()
    {
        bCount = true;
        if(card.sCardType == "Gold" && cardCount == 0 && unitCards < 30)
        {
            cardCount++;
            unitCards++;
        }
        if (card.sCardType == "Silver" && cardCount <= 2 && unitCards < 30)
        {
            cardCount++;
            unitCards++;
        }
        else if (card.sCardType != "Silver" && card.sCardType != "Gold" && cardCount <= 2 && specialCards < 10)
             {
                    cardCount++;
                    specialCards++;
             }
    }
    public void Eliminate()
    {
        if(cardCount > 0)
        {
            cardCount--;
            unitCards--;
        }
    }
    public void EliminateSpecial()
    {
        if (cardCount > 0)
        {
            cardCount--;
            specialCards--;
        }
    }
    public void ResetCount()
    {
        cardCount = 0;
    }
}
