using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject desc;
    public InputField column;
    public int qcolumn = 2;
    public InputField row;
    public int qrow = 2;
    public InputField mines;
    public int qmine = 1;
    public int maxmines = 1;
    public GameObject grid;
    public GameObject endGame;

    public void QOC(int a)
    {
        qcolumn = int.Parse(column.text);
        qcolumn += a;
        if (qcolumn < 2)
        {
            qcolumn = 2;
        }
        if (qcolumn > 20)
        {
            qcolumn = 20;
        }
        maxmines = qcolumn * qrow / 2;
        column.GetComponent<InputField>().text = qcolumn.ToString();
    }
    public void QOR(int b)
    {
        qrow = int.Parse(row.text);
        qrow += b;
        if (qrow < 2)
        {
            qrow = 2;
        }
        if (qrow > 20)
        {
            qrow = 20;
        }
        maxmines = qcolumn * qrow / 2;
        row.GetComponent<InputField>().text = qrow.ToString();
    }
    public void QOM(int c)
    {
        qmine = int.Parse(mines.text);
        qmine += c;
        if (qmine < 1)
        {
            qmine = 1;
        }
        if (qmine > maxmines)
        {
            qmine = maxmines;
        }
        mines.GetComponent<InputField>().text = qmine.ToString();
    }
    public void OK()
    {
        qcolumn = int.Parse(column.text);
        qrow = int.Parse(row.text);
        qmine = int.Parse(mines.text);
        if (qcolumn > 20)
        {
            qcolumn = 20;
        }
        if (qrow > 20)
        {
            qrow = 20;
        }
        maxmines = qcolumn * qrow / 2;
        if (qmine > maxmines)
        {
            qmine = maxmines;
        }
        grid.GetComponent<Grid>().Inform(qcolumn, qrow, qmine);
        gameObject.SetActive(false);
    }
}
