using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    //カードの
    [SerializeField] private Sprite[] cardFases;
    [SerializeField] private Sprite cardBack;

    private int cardNum;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CardFase(false);
    }

    public void CardFase(bool cardFaseCheck)
    {
        switch(cardFaseCheck)
        {
            case true:
                spriteRenderer.sprite = cardFases[cardNum];
                break;
            case false:
                spriteRenderer.sprite = cardBack;
                break;
        }
    }
}
public struct Card
{
    //カードのグレード
    public int card_Grade;
    //カードの数字(枚数)/*ファーストヴァンガード(0)/ヒール(1~4)/ドロー(5~8)/クリティカル(9~16)*/
    public int card_Trigger;
    //トリガーがついてるかのチェック
    public bool isTrigger;

    public Card(int card_Grade, int card_Trigger, bool isTrigger)
    {
        this.card_Grade = card_Grade;
        this.card_Trigger = card_Trigger;
        this.isTrigger = isTrigger;
    }
}