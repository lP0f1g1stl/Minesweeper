using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{
    public bool isMine = false;
    public bool flag = false;
    public bool unflag = false;
    public bool active = true;
    public TextMesh text;
    public int iD;
    public Sprite[] sprites= new Sprite[4];
    public int numofmines;
    public GameObject grid;
    public float lct = 0.5f;

    public void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid");
    }

    public void CreateID(int createdTiles)
    {
        iD = createdTiles;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && active == true)
        {
            if (unflag == false)
            {
                if (isMine == true)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                    active = false;
                    grid.GetComponent<Grid>().Tr();
                }
                if (isMine == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                    active = false;
                    grid.GetComponent<Grid>().Win(0, 0);
                    if (numofmines < 1)
                    {
                        grid.GetComponent<Grid>().UncoverTile(iD);
                    }
                }
            }
            unflag = false;
        }
        if (active == true || flag == true)
        {
            if (Input.GetMouseButtonUp(1))
            {
                if (flag == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                    active = false;
                    flag = true;
                    grid.GetComponent<Grid>().Win(0, 1);
                    return;
                }
                if (flag == true)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                    active = true;
                    flag = false;
                    grid.GetComponent<Grid>().Win(1, 0);
                    return;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                lct = 0.5f;
            }
            if (Input.GetMouseButton(0))
            {
                if (lct < 0)
                {
                    if (flag == false)
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                        active = false;
                        flag = true;
                        grid.GetComponent<Grid>().Win(0, 1);
                        lct = 0.5f;
                        return;
                    }
                    if (flag == true)
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                        active = true;
                        flag = false;
                        unflag = true;
                        grid.GetComponent<Grid>().Win(1, 0);
                        lct = 0.5f;
                        return;
                    }
                }
                lct -= Time.deltaTime;
            }
        }
    }
    public void NumberOfMines()
    {
        numofmines++;
        text.text = numofmines.ToString();
    }
    public void OpenTile()
    {
        if (numofmines == 0 && isMine == false)
        { 
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            active = false;
            grid.GetComponent<Grid>().UncoverTile(iD);
            grid.GetComponent<Grid>().Win(0, 0);
        }
        if (numofmines!= 0 && isMine == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            active = false;
            grid.GetComponent<Grid>().Win(0, 0);
        }
    }
     public void Active()
    {
        active = false;
    }
}
