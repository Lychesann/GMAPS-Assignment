// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat1;
    private HMatrix2D mat2;
    private HMatrix2D resultMat = new HMatrix2D();
    private HVector2D vec1;
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        Question2();
        
    }

    public void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f);
        HMatrix2D mat2 = new HMatrix2D(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f);
        HMatrix2D resultMat = mat1 * mat2;
        HMatrix2D vec1 = mat1 * mat2;
        resultMat.Print(); //To get the results of the matrices
    }
}