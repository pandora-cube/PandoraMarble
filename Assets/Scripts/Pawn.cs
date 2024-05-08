using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Pawn : MonoBehaviour
{
    public string teamName;
    private int point;
    private int run;

    void Awake()
    {
        run = 0;
    }

    public void MovePoint(int newPoint)
    {
        // 한바퀴 이상 돌았을 시
        if (GameSystem.Instance.cells.Count <= newPoint)
        {
            run++;
            MovePoint(newPoint - GameSystem.Instance.cells.Count);
            return;
        }
        
        // 새 위치 확인
        BoardCell newCell = GameSystem.Instance.cells[newPoint];

        // 새 위치로 이동
        Vector3 newPos = newCell.transform.position + new Vector3(0f, 0.2f, 0f);
        transform.Translate(newPos);

        // 위치 정보 갱신
        point = newPoint;
    }
}
