using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    public int index;
    private string type;

    public void SetType(string Type)
    {
        type = Type;
    }

    private void Awake()
    {
        index = transform.GetSiblingIndex();
    }
}
