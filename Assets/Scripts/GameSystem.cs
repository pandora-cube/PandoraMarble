using System.Collections.Generic;
using UnityEngine;

public class GameSystem : Singleton<GameSystem>
{
    public GameObject pawnPrefab;       // 폰 프리팹
    
    public List<BoardArea> Areas = new();  // 맵 내 타일들
    
    private new void Awake()
    {
        base.Awake();
    }


    // 셀 값 반환
    public BoardCell GetCell(int area, int index)
    {
        while (index >= Areas[area].cells.Count)
        {
            index -= Areas[area].cells.Count;
        }

        if (index < 0)
        {
            index += Areas[area].cells.Count;
        }
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
