using NUnit.Framework;
using UnityEngine;

public class dice : MonoBehaviour
{
    public int[] num = new int[6];
    public float ranMin;
    public float ranMax;
    public Vector3 rollPos;

    public void Roll()
    {
        Quaternion newRotate = new Quaternion(Random.Range(ranMin, ranMax), Random.Range(ranMin, ranMax), Random.Range(ranMin, ranMax), 1);
        Debug.Log($"Random : {newRotate.ToString()}");

        transform.SetPositionAndRotation(rollPos, newRotate);
    }
}
