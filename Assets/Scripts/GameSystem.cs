using System.Collections.Generic;
using UnityEngine;

public class GameSystem : Singleton<GameSystem>
{
    public GameObject pawnPrefab;       // 폰 프리팹
    public RectTransform panel;        // 팀 패널 오브젝트
    
    public string mapPath;      // 맵 정보
    public Transform boardSpace;    // 맵 내 타일 오브젝트
    private List<BoardCell> cells = new();  // 맵 내 타일들
    
    public int MapLength    // 전체 맵 길이
    {
        get { return cells.Count; }
    }
    
    private new void Awake()
    {
        base.Awake();
        
        // 맵 타일 불러오기
        for (int i = 0; i < boardSpace.childCount; i++)
        {
            cells.Add(boardSpace.GetChild(i).GetComponent<BoardCell>());
        }
        
        // 맵 데이터 불러오기
        var dataList = FileReader.ReadCSV(mapPath);
        if (dataList == null) return;
        
        for (int i = 0; i < (cells.Count < dataList.Count ? cells.Count : dataList.Count); i++) 
        {
            cells[i].title = dataList[i][(int)DataColumn.Title];
            cells[i].contents = dataList[i][(int)DataColumn.Contents];
        }
        
        Debug.Log("데이터 호출 완료");
    }


    // 셀 값 반환
    public BoardCell GetCell(int index)
    {
        return cells[index];
    }
}


public enum DataColumn
{
    Title,
    Contents,
}
