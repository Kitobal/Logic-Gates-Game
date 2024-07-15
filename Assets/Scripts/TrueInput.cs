using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueInput : MonoBehaviour
{
    Output myOutput;
    void Start()
    {
        myOutput = GetComponent<Output>();
        myOutput.output = true;
    }
}
