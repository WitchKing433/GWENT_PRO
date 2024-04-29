using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string sCardName;
    public int iCardPower;
    public string sCardType;
    public string sCardDescription;
    public int iCardSkill;
    public string sCardAtkType;

}
