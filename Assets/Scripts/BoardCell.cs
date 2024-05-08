using UnityEngine;
using UnityEngine.Serialization;

public class BoardCell : MonoBehaviour
{
    public int index;
    
    // 타일 이벤트
    [FormerlySerializedAs("type")] public string title;
    public string contents;
    
    private void Awake()
    {
        index = transform.GetSiblingIndex();
    }
}
