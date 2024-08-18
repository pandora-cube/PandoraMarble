using System;
using TMPro;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;

    public int currentArea;
    public int currentPos;

    
    // 이름 설정
    public void SetName(string text)
    {
        text1.text = text;
        text2.text = text;
    }


    public BoardCell GetCell()
    {
        return GameSystem.Instance.GetCell(currentArea, currentPos);
    }
    
    
    // 새 위치로 이동
    public void MovePoint(int Point, int Area = -99)
    {
        if (Area == -99) Area = currentArea;
        
        // 새 위치 확인
        BoardCell newCell = GameSystem.Instance.GetCell(Area, Point);
        currentArea = Area;
        currentPos = Point;

        // 새 위치로 이동
        Vector3 newPos = newCell.transform.position + new Vector3(0f, 5f, 0f);
        transform.position = newPos;
    }

    public void ShowInfo()
    {
        // 새 위치 이벤트 활성화
        if (!String.IsNullOrEmpty(GetCell().title))
        {
            InfoPanel.Instance.ShowInfo(this, GetCell());
        }
    }
}
