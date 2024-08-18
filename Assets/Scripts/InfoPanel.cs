using TMPro;
using UnityEngine;

public class InfoPanel : Singleton<InfoPanel>
{
    public TMP_InputField input;        // 타일 번호 입력받기

    public TMP_Text title;      // 내용 타이틀
    public TMP_Text contents;   // 내용 상세



    public void ShowInfo(BoardCell cell)
    {
        title.text = cell.title;
        contents.text = cell.contents;
    }
}
