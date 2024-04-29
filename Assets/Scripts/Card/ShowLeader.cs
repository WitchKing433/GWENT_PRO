using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowLeader : MonoBehaviour
{
    public Card card;
    
    public TMP_Text tCardName;
    public TMP_Text tCardDescription;
    public TMP_Text tCardCardAtkType;
    public Vector2 vOriginalPosition;
    public Vector2 vCanvasCenter;



    // Start is called before the first frame update
    void Start()
    {
        tCardName.text = card.sCardName;
        tCardDescription.text = card.sCardDescription;
        tCardCardAtkType.text = card.sCardAtkType;
        vCanvasCenter = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2f, (Screen.height / 2f) + 150f));
    }
    public void Center(bool bCenter)
    {
        if (bCenter)
        {
            vOriginalPosition = transform.position;
            transform.position = vCanvasCenter;
        }
        else
        {
            transform.position = vOriginalPosition;
        }
    }        
}
