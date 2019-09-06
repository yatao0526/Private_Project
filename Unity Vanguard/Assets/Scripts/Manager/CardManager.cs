using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    //カード保存するリスト
    private List<Card> cardList;
    
    #region 各グレードでの枚数指定
    private const int cardGrade_0 = 15;     //0からなのでint値+1(16枚)
    private const int cardGrade_1 = 14;     //0からなのでint値+1(15枚)
    private const int cardGrade_2 = 10;     //0からなのでint値+1(11枚)
    private const int cardGrade_3 = 6;      //0からなのでint値+1(7枚)
    #endregion

    #region 各グレードのID
    private const int grade_0 = 0;
    private const int grade_1 = 1;
    private const int grade_2 = 2;
    private const int grade_3 = 3;
    private List<int> grade = new List<int>() { grade_0, grade_1, grade_2, grade_3 };
    #endregion

    private void Start()
    {
        //初期化
        InitializeCardList();
        //シャッフル
        DeckShuffle();
        //手札に配る
        
        //コンソールにデバッグとして表示
        ShowCardName();
    }
    //山札初期化
    private void InitializeCardList()
    {
        cardList = new List<Card>();
        Card card;
        //card = new Card(grade_0, 0, true);
        //cardList.Add(card);
        for (int i = 1; i <= cardGrade_0; i++)
        {
            card = new Card(grade_0, i, false);
            cardList.Add(card);
        }
        for (int i = 0; i <= cardGrade_1; i++)
        {
            card = new Card(grade_1, i, false);
            cardList.Add(card);
        }
        for (int i = 0; i <= cardGrade_2; i++)
        {
            card = new Card(grade_2, i, false);
            cardList.Add(card);
        }
        for (int i = 0; i <= cardGrade_3; i++)
        {
            card = new Card(grade_3, i, false);
            cardList.Add(card);
        }
        Debug.Log(cardList.Count);
    }
    //山札をシャッフル
    private void DeckShuffle()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            Card deck = cardList[i];
            int randomIndex = Random.Range(0, cardList.Count);
            cardList[i] = cardList[randomIndex];
            cardList[randomIndex] = deck;
        }
    }
    #region コンソールにdebugとして出すよう
    //出力文字列の生成(debug)
    private void ShowCardName()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (Card card in cardList)
        {
            sb.Append(GetGrade(card.card_Grade)).Append("の").Append(card.card_Trigger).Append("番目,");
        }
        string cardText = sb.ToString();
        cardText = cardText.Remove(cardText.LastIndexOf(","));
        Debug.Log(cardText);
    }
    //debugに出す用のGrade表示
    private string GetGrade(int grade)
    {
        string gradeNum;
        switch (grade)
        {
            case grade_0:
                gradeNum = "Grade_0";
                break;
            case grade_1:
                gradeNum = "Grade_1";
                break;
            case grade_2:
                gradeNum = "Grade_2";
                break;
            case grade_3:
                gradeNum = "Grade_3";
                break;
            default:
                gradeNum = "null";
                break;
        }
        return gradeNum;
    }
    #endregion
}
