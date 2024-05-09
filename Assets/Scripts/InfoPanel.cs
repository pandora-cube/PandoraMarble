using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public TMP_InputField input;        // 타일 번호 입력받기

    public TMP_Text title;      // 내용 타이틀
    public TMP_Text contents;   // 내용 상세



    public void ShowInfo()
    {
        title.text = "";
        contents.text = "";
        
        // 이동할 장소값 파싱
        if (int.TryParse(input.text, out int newPos) == false)
        {
            Debug.Log($"정보를 확인할 위치를 숫자로 입력해주세요 : {input.text}");
            return;
        }

        if (newPos < 0 || newPos > GameSystem.Instance.MapLength)
        {
            Debug.Log($"위치 오류 : {newPos}");
            return;
        }

        BoardCell cell = GameSystem.Instance.GetCell(newPos);

        title.text = cell.title;
        contents.text = cell.contents;
    }
}
