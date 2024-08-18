using System.Collections.Generic;
using UnityEngine;


public class BoardArea : MonoBehaviour
{
    public int index;
    public string mapPath;
    public List<BoardCell> cells;

    public int length => cells.Count;
    

    void Awake()
    {
        // Cells 불러오기
        for (int i = 0; i < transform.childCount; i++)
        {
            cells.Add(transform.GetChild(i).GetComponent<BoardCell>());
        }
        
        // 맵 데이터 로드
        var dataList = FileReader.ReadCSV(mapPath);
        if (dataList == null) return;
        
        for (int i = 0; i < (cells.Count < dataList.Count ? cells.Count : dataList.Count); i++) 
        {
            cells[i].title = dataList[i][(int)DataColumn.Title];
            cells[i].contents = dataList[i][(int)DataColumn.Contents];
            cells[i].action = CellAction.GetAction(dataList[i][(int)DataColumn.Action]);
            if (cells[i].action != null)
            {
                cells[i].action.param1 = dataList[i][(int)DataColumn.Param1];
                cells[i].action.param2 = dataList[i][(int)DataColumn.Param2];
            }
        }
    }
}
