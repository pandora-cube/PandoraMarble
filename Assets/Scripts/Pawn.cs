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
    
    
    // 새 위치로 이동
    public void MovePoint(int Point, int Area = -1)
    {
        if (Area == -1) Area = currentArea;
        
        // 새 위치 확인
        BoardCell newCell = GameSystem.Instance.GetCell(Area, Point);

        // 새 위치로 이동
        Vector3 newPos = newCell.transform.position + new Vector3(0f, 5f, 0f);
        transform.position = newPos;
        
        // 새 위치 이벤트 활성화
        if (newCell.title != null && newCell.title != "")
        {
            InfoPanel.Instance.ShowInfo(newCell);
            InfoPanel.Instance.gameObject.SetActive(true);
        }
    }
}
