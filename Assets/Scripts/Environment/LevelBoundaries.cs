using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;

    public static float internalLeft;
    public static float internalRight;

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
