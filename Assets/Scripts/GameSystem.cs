using System.Collections.Generic;
using UnityEngine;

public class GameSystem : Singleton<GameSystem>
{
    public GameObject pawnPrefab;       // 폰 프리팹
    
    public List<Pawn> teams = new();    // 팀 목록
    
    
    public string mapPath;      // 맵 정보
    public Transform boardSpace;    // 맵 내 타일 오브젝트
    public List<BoardCell> cells = new();  // 맵 내 타일들
    
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
            string cellType = dataList[i][(int)DataColumn.Type];
            cells[i].SetType(cellType);
        }
        
        Debug.Log("데이터 호출 완료");
    }


    /// <summary>
    /// 새 팀 만들기
    /// </summary>
    /// <param name="teamName">팀 이름</param>
    public void CreateTeam(string teamName)
    {
        // 새 폰 생성
        GameObject newPawn = Instantiate(pawnPrefab, transform.GetChild(0));
        Pawn pawn = newPawn.GetComponent<Pawn>();
        
        // 폰 초기화
        pawn.name = teamName;
        pawn.MovePoint(0);
        
        teams.Add(pawn);
    }
}


public enum DataColumn
{
    Type,
}
