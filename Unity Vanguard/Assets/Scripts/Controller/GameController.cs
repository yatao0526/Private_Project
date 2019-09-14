using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //各フェーズ管理のフラグ
    private bool standupPhase, drowPhase, standbyPhase, battlePhase, turnEndPhase = false;
    
    private Sprite backCard;

    [SerializeField] private GameObject firstVanGuard;

    void Start()
    {
        firstVanGuard.GetComponent<SpriteRenderer>().sprite = backCard;
    }

    void Update()
    {
        StandUp();
    }

    //ゲーム開始時のスタンドアップ
    private void StandUp()
    {
        //ヴァンガードサークルをクリックでスタンドアップさせる
        if (standupPhase && Input.GetMouseButtonDown(0))
        {
            standbyPhase = true;
        }
    }
    //
    public void DrowButton()
    {
        if (drowPhase) return;
        {
            Debug.Log("ドローボタンclear");
            drowPhase = true;
            standupPhase = true;
        }
    }
    //
    public void StandbyButton()
    {
        if (standbyPhase) return;
        {
            Debug.Log("スタンバイボタンclear");
            standbyPhase = true;
        }
    }
    //
    public void BattleButton()
    {
        if (battlePhase) return;
        {
            Debug.Log("バトルボタンclear");
            battlePhase = true;
            standbyPhase = true;
        }
    }
    //
    public void TurnEndButton()
    {
        if (turnEndPhase) return;
        {
            Debug.Log("ターンエンドボタンclear");
            turnEndPhase = true;
            battlePhase = true;
            standbyPhase = true;
        }
    }
}
