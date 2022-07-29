using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public LayerMask tileLayer;
    private Tile tile;
    public GameObject currentTile;
    public GameObject previousTile;

    //Public variables to get neigbouring tiles for every current tile
    public GameObject neighbourTile1;
    public GameObject neighbourTile2;
    public GameObject neighbourTile3;
    public GameObject neighbourTile4;

    private GameObject getColorCode;
    public LayerMask dotLayer;
    private bool tileChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //Touch touch = Input.GetTouch(0);
            //Touch touch = Input.touches[0];
            //Raycast used to hit the dots
            RaycastHit2D colorHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, dotLayer);
            if (colorHit)
            {
                getColorCode = colorHit.collider.gameObject;
            }

            //Raycast used to hit the tiles
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, tileLayer);
            if (hit)
            {

                if (hit.collider.gameObject != currentTile)
                {
                    if (currentTile != null)
                    {
                        if (currentTile != previousTile)
                        {
                            previousTile = currentTile;
                            tileChanged = true;
                        }
                    }
                    else
                    {
                        currentTile = hit.collider.gameObject;
                        GettingNeighbours();
                    }
                }

                currentTile = hit.collider.gameObject;

                

                if (previousTile != null && currentTile != null)
                {
                    if(tileChanged)
                    {
                        tileChanged = false;
                        //GettingNeighbours();
                        Debug.Log("Inside new condition");
                        if (currentTile.transform.position.x > previousTile.transform.position.x && currentTile == previousTile.GetComponent<Tile>().neighbourTile2)
                        {
                            GettingNeighbours();
                            if (currentTile.GetComponent<Tile>().used)
                            {
                                RemovingTiles(currentTile);
                                //previousTile.GetComponent<Tile>().used = false;
                                previousTile.GetComponent<Tile>().right.SetActive(false);
                                currentTile.GetComponent<Tile>().left.SetActive(false);
                            }
                            if (!currentTile.GetComponent<Tile>().used)
                            {
                                previousTile.GetComponent<Tile>().right.SetActive(true);
                                previousTile.GetComponent<Tile>().right.GetComponent<SpriteRenderer>().color = getColorCode.GetComponent<SpriteRenderer>().color;
                                previousTile.GetComponent<Tile>().used = true;
                                previousTile.GetComponent<Tile>().nextTile = currentTile;
                                currentTile.GetComponent<Tile>().previousTile = previousTile;
                            }

                        }
                        else if (currentTile.transform.position.x < previousTile.transform.position.x && currentTile == previousTile.GetComponent<Tile>().neighbourTile4)
                        {
                            GettingNeighbours();
                            if (currentTile.GetComponent<Tile>().used)
                            {
                                RemovingTiles(currentTile);
                                //previousTile.GetComponent<Tile>().used = false;
                                previousTile.GetComponent<Tile>().left.SetActive(false);
                                currentTile.GetComponent<Tile>().right.SetActive(false);
                            }
                            if (!currentTile.GetComponent<Tile>().used)
                            {
                                previousTile.GetComponent<Tile>().left.SetActive(true);
                                previousTile.GetComponent<Tile>().left.GetComponent<SpriteRenderer>().color = getColorCode.GetComponent<SpriteRenderer>().color;
                                previousTile.GetComponent<Tile>().used = true;
                                previousTile.GetComponent<Tile>().nextTile = currentTile;
                                currentTile.GetComponent<Tile>().previousTile = previousTile;
                            }


                        }
                        else if (currentTile.transform.position.y > previousTile.transform.position.y && currentTile == previousTile.GetComponent<Tile>().neighbourTile1)
                        {
                            GettingNeighbours();
                            if (currentTile.GetComponent<Tile>().used)
                            {
                                RemovingTiles(currentTile);
                                //previousTile.GetComponent<Tile>().used = false;
                                previousTile.GetComponent<Tile>().up.SetActive(false);
                                currentTile.GetComponent<Tile>().down.SetActive(false);
                            }
                            if (!currentTile.GetComponent<Tile>().used)
                            {
                                previousTile.GetComponent<Tile>().up.SetActive(true);
                                previousTile.GetComponent<Tile>().up.GetComponent<SpriteRenderer>().color = getColorCode.GetComponent<SpriteRenderer>().color;
                                previousTile.GetComponent<Tile>().used = true;
                                previousTile.GetComponent<Tile>().nextTile = currentTile;
                                currentTile.GetComponent<Tile>().previousTile = previousTile;
                            }


                        }
                        else if (currentTile.transform.position.y < previousTile.transform.position.y && currentTile == previousTile.GetComponent<Tile>().neighbourTile3)
                        {
                            GettingNeighbours();
                            if (currentTile.GetComponent<Tile>().used)
                            {
                                RemovingTiles(currentTile);
                                //previousTile.GetComponent<Tile>().used = false;
                                previousTile.GetComponent<Tile>().down.SetActive(false);
                                currentTile.GetComponent<Tile>().up.SetActive(false);
                            }
                            if (!currentTile.GetComponent<Tile>().used)
                            {
                                previousTile.GetComponent<Tile>().down.SetActive(true);
                                previousTile.GetComponent<Tile>().down.GetComponent<SpriteRenderer>().color = getColorCode.GetComponent<SpriteRenderer>().color;
                                previousTile.GetComponent<Tile>().used = true;
                                previousTile.GetComponent<Tile>().nextTile = currentTile;
                                currentTile.GetComponent<Tile>().previousTile = previousTile;
                            }


                        }
                        else
                        {
                            Debug.Log("Inside but not working");
                        }
                    }
                    
                }
            }
            }

            
    }

    private void RemovingTiles(GameObject prevTile)
    {
        previousTile = null;
        if(prevTile.GetComponent<Tile>().nextTile != null)
        {
            prevTile.GetComponent<Tile>().used = false;
            prevTile.GetComponent<Tile>().right.SetActive(false);
            prevTile.GetComponent<Tile>().left.SetActive(false);
            prevTile.GetComponent<Tile>().up.SetActive(false);
            prevTile.GetComponent<Tile>().down.SetActive(false);
            RemovingTiles(prevTile.GetComponent<Tile>().nextTile);
        }
        else
        {
            return;
        }
    }

    private void GettingNeighbours()
    {
        //All the raycast used to find the neighbouring tiles of the current tile
        RaycastHit2D hit2 = Physics2D.Raycast(currentTile.transform.position + new Vector3(0f, 1f, 0f), Vector2.zero, 100, tileLayer);
        if (hit2)
        {
            neighbourTile1 = hit2.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile1 = neighbourTile1;
        }
        RaycastHit2D hit3 = Physics2D.Raycast(currentTile.transform.position + new Vector3(1f, 0f, 0f), Vector2.zero, 100, tileLayer);
        if (hit3)
        {
            neighbourTile2 = hit3.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile2 = neighbourTile2;
        }
        RaycastHit2D hit4 = Physics2D.Raycast((currentTile.transform.position + new Vector3(0f, -1f, 0f)), Vector2.zero, 100, tileLayer);
        if (hit4)
        {
            neighbourTile3 = hit4.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile3 = neighbourTile3;
        }
        RaycastHit2D hit5 = Physics2D.Raycast((currentTile.transform.position + new Vector3(-1f, 0f, 0f)), Vector2.zero, 100, tileLayer);
        if (hit5)
        {
            neighbourTile4 = hit5.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile4 = neighbourTile4;
        }
    }
}
