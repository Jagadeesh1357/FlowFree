using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //Variables for the 4 direction sprites of the tile
    public GameObject up;
    public GameObject down;
    public GameObject right;
    public GameObject left;

    public bool used = false; //To check whether the tile is used or not

    //Previous and next tile variables
    public GameObject nextTile;
    public GameObject previousTile;
    //Neigbouring tiles variables
    public GameObject neighbourTile1;
    public GameObject neighbourTile2;
    public GameObject neighbourTile3;
    public GameObject neighbourTile4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
