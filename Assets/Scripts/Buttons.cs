using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public int but;
    public GameObject grid;

    public void Start()
    {
        //start = GameObject.FindGameObjectWithTag("Start");
    }
    public void OnClick()
    {
        grid.GetComponent<Grid>().CheckBut(but);
    }
}
