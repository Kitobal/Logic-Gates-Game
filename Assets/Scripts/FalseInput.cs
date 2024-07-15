using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseInput : MonoBehaviour
{
    Output myOutput;
    void Start()
    {
        myOutput = GetComponent<Output>();
        myOutput.output = false;
    }
}
