using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingCam : MonoBehaviour
{
    int[] jamie = new int[10];
    public int temp1;
    public int temp2;
    public int temp3;
    public int temp4;
    public int temp5;
    public int temp6;
    public int temp7;
    public int temp8;
    public int temp9;
    public int temp0;
    
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            jamie[0] = temp1;
            jamie[1] = temp2;
            jamie[2] = temp3;
            jamie[3] = temp4;
            jamie[4] = temp5;
            jamie[5] = temp6;
            jamie[6] = temp7;
            jamie[7] = temp8;
            jamie[8] = temp9;
            jamie[9] = temp0;
        }

        if(Input.GetKeyDown("w"))
        {
            FindMax();
        }
    }

    public void FindMax()
    {
        int max = -100000;
        for(int i = 0; i < jamie.Length; i++)
        {
            if(max < jamie[i])
            {
                max = jamie[i];
            }
        }
        Debug.Log(max);
    }
}
