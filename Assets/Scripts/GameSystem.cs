using System.Collections.Generic;
using UnityEngine;

public class GameSystem : Singleton<GameSystem>
{
    public GameObject pawnPrefab;       // 폰 프리팹
    public RectTransform panel;        // 팀 패널 오브젝트
    
    public List<BoardArea> Areas = new();  // 맵 내 타일들
    
    private new void Awake()
    {
        base.Awake();
    }


    // 셀 값 반환
    public BoardCell GetCell(int area, int index)
    {
        return Areas[area].cells[index];
    }
}


public enum DataColumn
{
    Title,
    Contents,
    Action,
    Param1,
    Param2,
}
