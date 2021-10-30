using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Grid : MonoBehaviour
{
    public GameObject cell;
    public GameObject[] allTile;
    public GameObject[] unMined;
    public GameObject[] mined;
    public int numberofTiles;
    public int numberofColumn;
    public int numberofRow;
    public int distance;
    public float xO = 0.0f;
    public float yO = 0.0f;
    public int numberOfMines;
    public GameObject start;
    public GameObject endGame;
    public int flags;
    public int disTiles;
    public float x1, x2, y1;

    void Init()
    {
        numberofTiles = numberofColumn * numberofRow;
        unMined = new GameObject[numberofTiles];
        mined = new GameObject[numberOfMines];
        allTile = new GameObject[numberofTiles];
        x1 = 10.5f - numberofColumn * 1.0f / 2;
        y1 = 9.5f - numberofRow * 1.0f / 2;
        x2 = x1;
        CreateTiles();
    }

    public void Inform(int qcolumn, int qrow, int qmine)
    {
        numberofColumn = qcolumn;
        numberofRow = qrow;
        numberOfMines = qmine;
        Init();
    }

    // Update is called once per frame
    void CreateTiles()
    {
        for (int createdTiles = 0; createdTiles < numberofTiles; createdTiles++)
        {
            x1 += distance;
            if (createdTiles % numberofColumn == 0)
            {
                y1 += distance;
                x1 = x2;
            }
            unMined[createdTiles] = Instantiate(cell,new Vector3(transform.position.x + x1, transform.position.y + y1, transform.position.z), transform.rotation);
            unMined[createdTiles].GetComponent<Tile>().CreateID(createdTiles);
            //allTile[createdTiles] = unMined[createdTiles];
        }
        //allTile = unMined;
        Array.Copy(unMined, 0, allTile, 0, unMined.Length);
        AssignMines();
    }
    void AssignMines()
    {
        for (int minesAssigned = 0; minesAssigned < numberOfMines; minesAssigned++)
        {
            int rand = UnityEngine.Random.Range(0, unMined.Length);
            GameObject currentTile = unMined[rand];
            
            mined[minesAssigned] = currentTile;
            unMined[rand] = null;
            unMined = unMined.Where(x => x != null).ToArray();
            currentTile.GetComponent<Tile>().isMine = true;
            int ident = currentTile.GetComponent<Tile>().iD;
            NumOfMines(ident);
        }
    }
    void NumOfMines(int ident)
    {
        int checkID = 0;
        checkID = ident + numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
        checkID = ident + 1 + numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && ((ident + 1) % numberofColumn) != 0)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
        checkID = ident + 1;
        if (checkID >= 0 && checkID < numberofTiles && ((ident + 1) % numberofColumn) != 0)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
        checkID = ident + 1 - numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && ((ident + 1) % numberofColumn) != 0)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
        checkID = ident - numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
        checkID = ident - 1 - numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && (ident % numberofColumn) != 0)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
        checkID = ident - 1;
        if (checkID >= 0 && checkID < numberofTiles && (ident % numberofColumn) != 0)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
        checkID = ident - 1 + numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && (ident % numberofColumn) != 0)
        {
            allTile[checkID].GetComponent<Tile>().NumberOfMines();
        }
    }
    public void UncoverTile(int ident1)
    {
        int checkID = 0;  
        checkID = ident1 + numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
        checkID = ident1 + 1 + numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && ((ident1 + 1) % numberofColumn) != 0 && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
        checkID = ident1 + 1;
        if (checkID >= 0 && checkID < numberofTiles && ((ident1 + 1) % numberofColumn) != 0 && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
        checkID = ident1 + 1 - numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && ((ident1 + 1) % numberofColumn) != 0 && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
        checkID = ident1 - numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
        checkID = ident1 - 1 - numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && (ident1 % numberofColumn) != 0 && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
        checkID = ident1 - 1;
        if (checkID >= 0 && checkID < numberofTiles && (ident1 % numberofColumn) != 0 && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
        checkID = ident1 - 1 + numberofColumn;
        if (checkID >= 0 && checkID < numberofTiles && (ident1 % numberofColumn) != 0 && allTile[checkID].GetComponent<Tile>().active == true)
        {
            allTile[checkID].GetComponent<Tile>().OpenTile();
        }
    }
    public void CheckBut(int f)
    {
        if (f == 0)
        {
            start.GetComponent<StartGame>().QOC(1);
        }
        if (f == 1)
        {
            start.GetComponent<StartGame>().QOC(-1);
        }
        if (f == 2)
        {
            start.GetComponent<StartGame>().QOR(1);
        }
        if (f == 3)
        {
            start.GetComponent<StartGame>().QOR(-1);
        }
        if (f == 4)
        {
            start.GetComponent<StartGame>().QOM(1);
        }
        if (f == 5)
        {
            start.GetComponent<StartGame>().QOM(-1);
        }
        if (f == 6)
        {
            start.GetComponent<StartGame>().OK();
        }
        if (f == 7)
        {
            endGame.GetComponent<EndGame>().Restart();
        }
        if (f == 8)
        {
            endGame.GetComponent<EndGame>().Exit();
        }
    }
    public void Tr()
    {
        endGame.SetActive(true);
        endGame.GetComponent<EndGame>().Message("You lose");
        for (int i = 0; i < numberofTiles; i++)
        {
            allTile[i].GetComponent<Tile>().Active();
        }
    }
    public void Win(int a, int f)
    {
        if (a == 0 && f == 1)
        {
            flags++;
        }
        if (a == 0)
        {
            disTiles++;
        }
        if (a == 1 && f == 0)
        {
            disTiles--;
            flags--;
        }
        if (flags == numberOfMines && disTiles == numberofTiles)
        {
            endGame.SetActive(true);
            endGame.GetComponent<EndGame>().Message("You win");
        }
    }
}
