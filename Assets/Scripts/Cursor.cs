using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public LayerMask tileLayer;
    private Tile tile;
    public GameObject currentTile;
    public GameObject previousTile;

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
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, tileLayer);
            if (hit)
            {
                

                if (hit.collider.gameObject != currentTile)
                {
                    if (currentTile != null)
                    {
                        previousTile = currentTile;
                    }
                    else
                    {
                        currentTile = hit.collider.gameObject;
                        GettingNeighbours();
                    }
                }

                currentTile = hit.collider.gameObject;

                //if (currentTile == null)
                //{
                //    currentTile = hit.collider.gameObject;
                //}

                //if(previousTile != null)
                //{
                //    if (currentTile == previousTile.GetComponent<Tile>().neighbourTile1 || currentTile == previousTile.GetComponent<Tile>().neighbourTile2 || currentTile == previousTile.GetComponent<Tile>().neighbourTile3 || currentTile == previousTile.GetComponent<Tile>().neighbourTile4)
                //    {
                //        currentTile = hit.collider.gameObject;
                //    }
                //}
                
                
                
                if (previousTile != null && currentTile != null)
                {
                    if (currentTile.transform.position.x > previousTile.transform.position.x && currentTile == previousTile.GetComponent<Tile>().neighbourTile2)
                    {
                        
                        if(!previousTile.GetComponent<Tile>().used)
                        {
                            GettingNeighbours();
                            previousTile.GetComponent<Tile>().right.SetActive(true);
                            previousTile.GetComponent<Tile>().used = true;
                            previousTile.GetComponent<Tile>().nextTile = currentTile;
                            currentTile.GetComponent<Tile>().previousTile = previousTile;
                        }
                        if(currentTile.GetComponent<Tile>().used)
                        {
                            //currentTile.GetComponent<Tile>().used = false;
                            currentTile.GetComponent<Tile>().left.SetActive(false);
                        }
                    }
                    else if (currentTile.transform.position.x < previousTile.transform.position.x && currentTile == previousTile.GetComponent<Tile>().neighbourTile4)
                    {
                        
                        if (!previousTile.GetComponent<Tile>().used)
                        {
                            GettingNeighbours();
                            previousTile.GetComponent<Tile>().left.SetActive(true);
                            previousTile.GetComponent<Tile>().used = true;
                            previousTile.GetComponent<Tile>().nextTile = currentTile;
                            currentTile.GetComponent<Tile>().previousTile = previousTile;
                        }

                        if (currentTile.GetComponent<Tile>().used)
                        {
                            //currentTile.GetComponent<Tile>().used = false;
                            currentTile.GetComponent<Tile>().right.SetActive(false);
                        }
                    }
                    else if (currentTile.transform.position.y > previousTile.transform.position.y && currentTile == previousTile.GetComponent<Tile>().neighbourTile1)
                    {
                       
                        if (!previousTile.GetComponent<Tile>().used)
                        {
                            GettingNeighbours();
                            previousTile.GetComponent<Tile>().up.SetActive(true);
                            previousTile.GetComponent<Tile>().used = true;
                            previousTile.GetComponent<Tile>().nextTile = currentTile;
                            currentTile.GetComponent<Tile>().previousTile = previousTile;
                        }

                        if (currentTile.GetComponent<Tile>().used)
                        {
                            //currentTile.GetComponent<Tile>().used = false;
                            currentTile.GetComponent<Tile>().down.SetActive(false);
                        }
                    }
                    else if (currentTile.transform.position.y < previousTile.transform.position.y && currentTile == previousTile.GetComponent<Tile>().neighbourTile3)
                    {
                        if (!previousTile.GetComponent<Tile>().used)
                        {
                            GettingNeighbours();
                            previousTile.GetComponent<Tile>().down.SetActive(true);
                            previousTile.GetComponent<Tile>().used = true;
                            previousTile.GetComponent<Tile>().nextTile = currentTile;
                            currentTile.GetComponent<Tile>().previousTile = previousTile;
                        }

                        if (currentTile.GetComponent<Tile>().used)
                        {
                            //currentTile.GetComponent<Tile>().used = false;
                            currentTile.GetComponent<Tile>().up.SetActive(false);
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

    private void GettingNeighbours()
    {
        RaycastHit2D hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 50f, 0f)), Vector2.zero, 100, tileLayer);
        if (hit2)
        {
            neighbourTile1 = hit2.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile1 = neighbourTile1;
        }
        RaycastHit2D hit3 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(50f, 0f, 0f)), Vector2.zero, 100, tileLayer);
        if (hit3)
        {
            neighbourTile2 = hit3.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile2 = neighbourTile2;
        }
        RaycastHit2D hit4 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, -50f, 0f)), Vector2.zero, 100, tileLayer);
        if (hit4)
        {
            neighbourTile3 = hit4.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile3 = neighbourTile3;
        }
        RaycastHit2D hit5 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(-50f, 0f, 0f)), Vector2.zero, 100, tileLayer);
        if (hit5)
        {
            neighbourTile4 = hit5.collider.gameObject;
            currentTile.GetComponent<Tile>().neighbourTile4 = neighbourTile4;
        }
    }
}
