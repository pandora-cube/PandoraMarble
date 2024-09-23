using System;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : Singleton<StarManager>
{
    public List<BoardCell> starPoint;
    public List<GameObject> starObject;
    public int currentIndex = 0;

    private void Awake()
    {
        SetStar(0);
    }

    public void SetStar(int index = -1)
    {
        if (index == -1)
        {
            index = currentIndex + 1;
            if (index >= starPoint.Count)
                index -= starPoint.Count;
        }
        
        for (int i = 0; i < starPoint.Count; i++)
        {
            if (i == index)
            {
                starObject[i].SetActive(true);
                currentIndex = index;
                continue;
            }
            starObject[i].SetActive(false);
        }
    }
}
