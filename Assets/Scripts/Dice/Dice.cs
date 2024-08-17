using System;using UnityEngine;

namespace Dice
{
    [CreateAssetMenu(menuName = "Dices")]
    public class Dice : ScriptableObject
    {
        public string diceName;

        public Face[] faces = new Face[6];
    }

    public class Face
    {
        public FaceType type;
        public int num;
    }

    public enum FaceType
    {
        Move,
        Coin,
        Count
    }
}

