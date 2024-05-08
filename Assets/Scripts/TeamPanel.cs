using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamPanel : MonoBehaviour
{
    public string teamName = "";    // 팀명
    private int currentPoint = 0;      // 현재 위치

    private Pawn pawn = null;       // 말 오브젝트

    [Header("UI")] 
    public TMP_Text runCount;       // 현재 위치 카운트
    public TMP_InputField newPoint;       // 이동할 새 위치
    public TMP_Text nameUI;         // 이름 UI

    
    // 위치 정보 갱신
    private void Update()
    {
        runCount.text = currentPoint.ToString();
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
        pawn.MovePoint(0);
        pawn.SetName(teamName);
    }

    
    // 장소 이동
    public void MovePosition()
    {
        // 폰 미생성시 이동 안함
        if (pawn == null)
            return;
        
        // 이동할 장소값 파싱
        if (int.TryParse(newPoint.text, out int newPos) == false)
        {
            Debug.Log($"이동할 위치를 숫자로 입력해주세요 : {newPoint.text}");
            return;
        }

        // 여러바퀴 값 무시
        while (GameSystem.Instance.MapLength <= newPos)
        {
            newPos -= GameSystem.Instance.MapLength;
        }
        
        pawn.MovePoint(newPos);
        currentPoint = newPos;
    }

    
    // 이름 설정
    public void SetName()
    {
        teamName = nameUI.text;
    }
}
