using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardCell : MonoBehaviour
{
    public int index;
    public bool nameSort = true;
    [CanBeNull] public CellAction action;
    
    // 타일 이벤트
    public string title;
    public string contents;
    
    private void Awake()
    {
        index = transform.GetSiblingIndex();
        if (nameSort == true) gameObject.name = index.ToString();
    }
}
