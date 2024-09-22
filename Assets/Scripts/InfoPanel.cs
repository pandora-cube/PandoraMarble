using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : Singleton<InfoPanel>
{
    public GameObject Panel;
    public TMP_Text title;      // 내용 타이틀
    public TMP_Text contents;   // 내용 상세
    public Button Accept;



    public void ShowInfo(Pawn pawn, BoardCell cell)
    {
        title.text = cell.title;
        contents.text = cell.contents;
        Accept.gameObject.SetActive(false);
        Panel.SetActive(true);

        if (!string.IsNullOrEmpty(cell.action))
        {
            CellAction newAction = CellAction.GetAction(cell.action);
            newAction.pawn = pawn;
            newAction.param1 = cell.param1;
            newAction.param2 = cell.param2;
            
            Accept.gameObject.SetActive(true);
            Accept.onClick.RemoveAllListeners();
            Accept.onClick.AddListener(newAction.Invoke);
        }
    }
}
