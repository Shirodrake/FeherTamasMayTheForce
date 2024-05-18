
using UnityEngine;

public class MinMax : MonoBehaviour
{
    [SerializeField] float NumberA;
    [SerializeField] float NumberB;
    [SerializeField] float Min;
    [SerializeField] float Max;


    void Update()
    {
        if (NumberA > NumberB) { Max = NumberA; Min = NumberB; }
        if (NumberA < NumberB) { Max = NumberB; Min = NumberA; }
    }
}
