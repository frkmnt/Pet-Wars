using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTileManager : MonoBehaviour {

    public GameObject CombatTileSpawnerPrefab;

    private int size=8;
    private GameObject[,] grid;
    private GameObject[,] navGrid;


    void Awake ()
    {
        GameObject hexmap = Instantiate(CombatTileSpawnerPrefab) as GameObject;
        CombatTileSpawner TileSpawner = hexmap.GetComponent<CombatTileSpawner>();

        grid = TileSpawner.GenerateMap();
        navGrid = TileSpawner.GenerateMoveGrid(grid);

    }





    //METHODS//




   public GameObject GetTile(int x,int y)
    {
        return grid[x, y];
    }

    public GameObject GetPetFromTile(int x, int y)
    {
        return GetTile(x, y).GetComponent<CombatTile>().Pet;       
    }


    public Vector3 GetTilePosition(int x, int y)
    {
        Vector3 v = new Vector3(grid[x, y].transform.position.x, grid[x, y].transform.position.y, -2);
        return v;
    }



    public bool IsOccupied (int x,int y)
    {
        CombatTile t = grid[x,y].GetComponent<CombatTile>();

        if (!t.IsOccupied())
        {
            return false;
        }
        return true;
    }

    public void SetPetOnTile (GameObject p, int x, int y)
    {
        CombatTile t = grid[x, y].GetComponent<CombatTile>();
        t.Pet = p;
    }

    public CombatTile FindPet(GameObject pet)
    {
        GameObject o;
        CombatTile t;

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (IsOccupied(x, y))
                {
                    o = grid[x, y];
                    t = o.GetComponent<CombatTile>();
                    
                    if (pet.name == t.Pet.name)
                    {
                        return t;
                    }
                }
                
            }
        }

        return null;
    }




    public CombatTile FindPetMoveGrid(GameObject pet)
    {
        GameObject o;
        CombatTile t;

        for (int x = 0; x < 11; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if(navGrid[x,y] != null)
                {
                    if (IsOccupied(x, y))
                    {
                        o = grid[x, y];
                        t = o.GetComponent<CombatTile>();

                        if (pet.name == t.Pet.name)
                        {
                            return t;
                        }
                    }
                }             
            }
        }

        return null;
    }


    public void MovePet (GameObject p, int x, int y)
    {
        if (!IsOccupied(x,y))
        {
            CombatTile c = FindPet(p);
            c.RemovePet();

            p.transform.position = GetTilePosition(x, y);
            SetPetOnTile(p, x, y);
            c.SetTileWhite();
        }

        
    }



    




    public List<CombatTile> AttackableTiles(GameObject pet)
    {

        List<CombatTile> lst = new List<CombatTile>();
        CombatTile c = FindPet(pet), aux;

        int x = c.MoveX, y = c.Y;

        if (x - 1 >= 0 && x - 1 <= 10)
        {
            if (navGrid[x - 1, y])
            {
                aux = navGrid[x - 1, y].GetComponent<CombatTile>();
                if (aux.IsOccupied())
                {
                    if (!aux.IsSameTeam(pet))
                    {
                        lst.Add(aux);
                    }
                }
            }



            if (x + 1 >= 0 && x + 1 <= 10)
            {
                if (navGrid[x + 1, y])
                {
                    aux = navGrid[x + 1, y].GetComponent<CombatTile>();
                    if (aux.IsOccupied())
                    {
                        if (!aux.IsSameTeam(pet))
                        {
                            lst.Add(aux);
                        }
                    }
                }
            }



            if (y+ 1 >= 0 && y + 1 <= 7)
            {
                if (navGrid[x, y + 1])
                {
                    aux = navGrid[x, y + 1].GetComponent<CombatTile>();
                    if (aux.IsOccupied())
                    {
                        if (!aux.IsSameTeam(pet))
                        {
                            lst.Add(aux);
                        }
                    }
                }
            }



            if (y - 1 >= 0 && y - 1 <= 7)
            {
                if (navGrid[x, y - 1])
                {
                    aux = navGrid[x, y - 1].GetComponent<CombatTile>();
                    if (aux.IsOccupied())
                    {
                        if (!aux.IsSameTeam(pet))
                        {
                            lst.Add(aux);
                        }
                    }
                }
            }


            if (x - 1 >= 0 && x - 1 <= 10 && y + 1 >= 0 && y + 1 <= 7)
            {
                if (navGrid[x - 1, y + 1])
                {
                    aux = navGrid[x - 1, y + 1].GetComponent<CombatTile>();
                    if (aux.IsOccupied())
                    {
                        if (!aux.IsSameTeam(pet))
                        {
                            lst.Add(aux);
                        }
                    }
                }
            }




            if (x + 1 >= 0 && x + 1 <= 10 && y - 1 >= 0 && y - 1 <= 7)
            {
                if (navGrid[x + 1, y - 1])
                {
                    aux = navGrid[x + 1, y - 1].GetComponent<CombatTile>();
                    if (aux.IsOccupied())
                    {
                        if (!aux.IsSameTeam(pet))
                        {
                            lst.Add(aux);
                        }
                    }
                }
            }

        }

        return lst;
    }






    //return a list of moveable tiles
    public List<CombatTile> MoveableTiles(GameObject pet, int speed)
    {      
        List<CombatTile> ret = new List<CombatTile>();

        CombatTile c = FindPet(pet);
        //Debug.Log(c.MoveX + " " + c.Y);
        
        ret = Moveable(ret, c, speed, pet.name);
        return ret;
    }

    private List<CombatTile> Moveable(List<CombatTile> ret, CombatTile tile, int speed, string name)
    {
        
        if (speed == 0)
        {
            if (!ret.Contains(tile) && !tile.Pet) ret.Add(tile);
            return ret;
        }

        else
        {
            speed--;

            if (tile.Pet)
            {
                if (tile.Pet.name == name)
                {
                    if (!ret.Contains(tile))
                    {
                        ret.Add(tile);

                        if (tile.MoveX - 1 >= 0 && tile.MoveX - 1 <= 10)
                        {
                            if (navGrid[tile.MoveX - 1, tile.Y])
                            {
                                CombatTile cc = navGrid[tile.MoveX - 1, tile.Y].GetComponent<CombatTile>();
                                Moveable(ret, cc, speed, name);
                            }

                        }



                        if (tile.MoveX + 1 >= 0 && tile.MoveX + 1 <= 10)
                        {
                            if (navGrid[tile.MoveX + 1, tile.Y])
                            {
                                CombatTile cc = navGrid[tile.MoveX + 1, tile.Y].GetComponent<CombatTile>();
                                Moveable(ret, cc, speed, name);
                            }

                        }



                        if (tile.Y + 1 >= 0 && tile.Y + 1 <= 7)
                        {
                            if (navGrid[tile.MoveX, tile.Y + 1])
                            {
                                CombatTile cc = navGrid[tile.MoveX, tile.Y + 1].GetComponent<CombatTile>();
                                Moveable(ret, cc, speed, name);
                            }
                        }



                        if (tile.Y - 1 >= 0 && tile.Y - 1 <= 7)
                        {
                            if (navGrid[tile.MoveX, tile.Y - 1])
                            {
                                CombatTile cc = navGrid[tile.MoveX, tile.Y - 1].GetComponent<CombatTile>();
                                Moveable(ret, cc, speed, name);
                            }
                        }



                        if (tile.MoveX - 1 >= 0 && tile.MoveX - 1 <= 10 && tile.Y + 1 >= 0 && tile.Y + 1 <= 7)
                        {
                            if (navGrid[tile.MoveX - 1, tile.Y + 1])
                            {
                                CombatTile cc = navGrid[tile.MoveX - 1, tile.Y + 1].GetComponent<CombatTile>();
                                Moveable(ret, cc, speed, name);
                            }
                        }



                        if (tile.MoveX + 1 >= 0 && tile.MoveX + 1 <= 10 && tile.Y - 1 >= 0 && tile.Y - 1 <= 7)
                        {
                            if (navGrid[tile.MoveX + 1, tile.Y - 1])
                            {
                                CombatTile cc = navGrid[tile.MoveX + 1, tile.Y - 1].GetComponent<CombatTile>();
                                Moveable(ret, cc, speed, name);
                            }
                        }
                    }
                }
            }

            else
            {
                ret.Add(tile);

                if (tile.MoveX - 1 >= 0 && tile.MoveX - 1 <= 10)
                {
                    if (navGrid[tile.MoveX - 1, tile.Y])
                    {
                        CombatTile cc = navGrid[tile.MoveX - 1, tile.Y].GetComponent<CombatTile>();
                        Moveable(ret, cc, speed, name);
                    }

                }



                if (tile.MoveX + 1 >= 0 && tile.MoveX + 1 <= 10)
                {
                    if (navGrid[tile.MoveX + 1, tile.Y])
                    {
                        CombatTile cc = navGrid[tile.MoveX + 1, tile.Y].GetComponent<CombatTile>();
                        Moveable(ret, cc, speed, name);
                    }

                }



                if (tile.Y + 1 >= 0 && tile.Y + 1 <= 7)
                {
                    if (navGrid[tile.MoveX, tile.Y + 1])
                    {
                        CombatTile cc = navGrid[tile.MoveX, tile.Y + 1].GetComponent<CombatTile>();
                        Moveable(ret, cc, speed, name);
                    }
                }



                if (tile.Y - 1 >= 0 && tile.Y - 1 <= 7)
                {
                    if (navGrid[tile.MoveX, tile.Y - 1])
                    {
                        CombatTile cc = navGrid[tile.MoveX, tile.Y - 1].GetComponent<CombatTile>();
                        Moveable(ret, cc, speed, name);
                    }
                }



                if (tile.MoveX - 1 >= 0 && tile.MoveX - 1 <= 10 && tile.Y + 1 >= 0 && tile.Y + 1 <= 7)
                {
                    if (navGrid[tile.MoveX - 1, tile.Y + 1])
                    {
                        CombatTile cc = navGrid[tile.MoveX - 1, tile.Y + 1].GetComponent<CombatTile>();
                        Moveable(ret, cc, speed, name);
                    }
                }



                if (tile.MoveX + 1 >= 0 && tile.MoveX + 1 <= 10 && tile.Y - 1 >= 0 && tile.Y - 1 <= 7)
                {
                    if (navGrid[tile.MoveX + 1, tile.Y - 1])
                    {
                        CombatTile cc = navGrid[tile.MoveX + 1, tile.Y - 1].GetComponent<CombatTile>();
                        Moveable(ret, cc, speed, name);
                    }
                }
            }


            



            




            

            

        }

       
        return ret;
        

    }





}
