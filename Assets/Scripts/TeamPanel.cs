using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamPanel : MonoBehaviour
{
    public string teamName = "";    // 팀명
    private int currentPoint = 0;      // 현재 위치
    public int star = 0;

    private Pawn pawn = null;       // 말 오브젝트

    [Header("UI")] 
    public TMP_Text starCount;       // 현재 위치 카운트
    public TMP_Text nameUI;         // 이름 UI

    
    // 위치 정보 갱신
    private void Update()
    {
        starCount.text = star.ToString();
    }

    
    // 팀 새로 초기화
    public void init()
    {
        Debug.Log($"New Pawn Init : {teamName}");
        // 이름 미작성 시 스킵
        if (teamName == "" || teamName == null)
        {
            Destroy(pawn.gameObject);
            pawn = null;
            return;
        }

        // 폰 존재 시 초기화
        if (pawn != null)
        {
            Destroy(pawn.gameObject);
            pawn = null;
        }
        
        //새로운 폰 생성
        var newPawn = Resources.Load("GamePawn") as GameObject;
        pawn = Instantiate(newPawn ).GetComponent<Pawn>();
        
        // 새로운 폰 초기화
        pawn.MovePoint(0, 0);
        pawn.SetName(teamName);
    }

    
    // 이름 설정
    public void SetName()
    {
        teamName = nameUI.text;
    }
    
    
    // 스타 개수 설정
    public void SetStar(int count = 1)
    {
        star += count;
    }
}
