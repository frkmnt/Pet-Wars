using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTileManager : MonoBehaviour
{

    public GameObject HouseTileSpawnerPrefab;

    private int size = 8;
    public GameObject[,] grid;

    public List<HouseTile> DiningRoom;
    public List<HouseTile> Kitchen;
    public List<HouseTile> Bathroom;
    public List<HouseTile> BedroomA;
    public List<HouseTile> BedroomB;
    public List<HouseTile> Garden;
    public List<HouseTile> LivingRoom;

    public List<HouseTile> Unmoveable;

    public List<HouseTile> MoveableTiles;


    public List<GameObject> Pets;
    public List<GameObject> Party1, Party2;

    public Persister Persister;




    public HouseTile CurTile;





    void Awake()
    {
        MoveableTiles = new List<HouseTile>();
        DiningRoom = new List<HouseTile>();
        Kitchen = new List<HouseTile>();
        Bathroom = new List<HouseTile>();
        BedroomA = new List<HouseTile>();
        BedroomB = new List<HouseTile>();
        Garden = new List<HouseTile>();
        LivingRoom = new List<HouseTile>();
        Unmoveable = new List<HouseTile>();




        GameObject housemap = Instantiate(HouseTileSpawnerPrefab) as GameObject;
        HouseTileSpawner TileSpawner = housemap.GetComponent<HouseTileSpawner>();

        Persister = GameObject.Find("Overseer").GetComponent<Overseer>().Persister;
        grid = Persister.grid;
        Pets = Persister.HousePets;
        Party1 = Persister.Party1;
        Party2 = Persister.Party2;


        TileSpawner.GenerateMap(grid);
        //delete spawner





        //initialize lists
        DiningRoom = new List<HouseTile>();
        Kitchen = new List<HouseTile>();
        Bathroom = new List<HouseTile>();
        BedroomA = new List<HouseTile>();
        BedroomB = new List<HouseTile>();
        Garden = new List<HouseTile>();
        LivingRoom = new List<HouseTile>();
        Unmoveable = new List<HouseTile>();




        //generate moveable map
        GenerateMoveableMap();



    }

    public void GenerateMoveableMap()
    {
        int x, y;


        //walls
        for (x = 0; x <= 33; x++)
        {
            Unmoveable.Add(grid[x, 0].GetComponent<HouseTile>());
            Unmoveable.Add(grid[x, 33].GetComponent<HouseTile>());
        }

        for (y = 0; y <= 33; y++)
        {
            Unmoveable.Add(grid[0, y].GetComponent<HouseTile>());
            Unmoveable.Add(grid[33, y].GetComponent<HouseTile>());
        }


        for (x = 0; x <= 8; x++)
        {
            for (y = 0; y <= 10; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }

        for (y = 0; y <= 10; y++)
        {
            Unmoveable.Add(grid[9, y].GetComponent<HouseTile>());
            Unmoveable.Add(grid[23, y].GetComponent<HouseTile>());
        }

        for (x = 9; x <= 23; x++)
        {
            Unmoveable.Add(grid[x, 0].GetComponent<HouseTile>());
            Unmoveable.Add(grid[x, 10].GetComponent<HouseTile>());
        }

        for (x = 24; x <= 33; x++)
        {
            for (y = 0; y <= 10; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }


        for (x = 0; x <= 11; x++)
        {
            Unmoveable.Add(grid[x, 33].GetComponent<HouseTile>());
        }


        for (x = 8; x <= 9; x++)
        {
            for (y = 12; y <= 22; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }



        for (x = 1; x <= 7; x++)
        {
            for (y = 21; y <= 22; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }


        for (x = 10; x <= 22; x++)
        {
            for (y = 19; y <= 20; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }

        for (x = 15; x <= 16; x++)
        {
            for (y = 12; y <= 18; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }


        for (x = 21; x <= 22; x++)
        {
            for (y = 12; y <= 18; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }


        for (x = 26; x <= 27; x++)
        {
            for (y = 12; y <= 32; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }

        for (x = 28; x <= 32; x++)
        {
            for (y = 21; y <= 22; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }

        for (x = 17; x <= 22; x++)
        {
            for (y = 28; y <= 29; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }

        for (x = 1; x <= 32; x++)
        {
            Unmoveable.Add(grid[x, 11].GetComponent<HouseTile>());
        }




        //DiningRoom;


        //exceptions
        Unmoveable.Add(grid[7, 12].GetComponent<HouseTile>());
        Unmoveable.Add(grid[1, 13].GetComponent<HouseTile>());
        Unmoveable.Add(grid[1, 14].GetComponent<HouseTile>());
        Unmoveable.Add(grid[7, 20].GetComponent<HouseTile>());
        Unmoveable.Add(grid[1, 20].GetComponent<HouseTile>());

        for (x = 3; x <= 5; x++)
        {
            for (y = 15; y <= 18; y++)
            {
                Unmoveable.Add(grid[x, y].GetComponent<HouseTile>());
            }
        }

        for (x = 1; x <= 7; x++)
        {
            for (y = 12; y <= 20; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    DiningRoom.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }



        //Kitchen;


        //exceptions
        Unmoveable.Add(grid[13, 12].GetComponent<HouseTile>());
        Unmoveable.Add(grid[12, 13].GetComponent<HouseTile>());
        Unmoveable.Add(grid[12, 14].GetComponent<HouseTile>());
        Unmoveable.Add(grid[11, 17].GetComponent<HouseTile>());
        Unmoveable.Add(grid[13, 18].GetComponent<HouseTile>());
        Unmoveable.Add(grid[14, 18].GetComponent<HouseTile>());

        for (y = 12; y <= 15; y++)
        {
            Unmoveable.Add(grid[14, y].GetComponent<HouseTile>());
        }

        for (x = 10; x <= 14; x++)
        {
            for (y = 12; y <= 18; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    Kitchen.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }





        //Bathroom;

        //exceptions
        Unmoveable.Add(grid[17, 16].GetComponent<HouseTile>());
        Unmoveable.Add(grid[17, 17].GetComponent<HouseTile>());
        Unmoveable.Add(grid[20, 18].GetComponent<HouseTile>());

        for (x = 17; x <= 19; x++)
        {
            Unmoveable.Add(grid[x, 12].GetComponent<HouseTile>());
        }


        for (x = 17; x <= 20; x++)
        {
            for (y = 12; y <= 18; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    Bathroom.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }





        //BedroomA;

        //exceptions
        Unmoveable.Add(grid[31, 14].GetComponent<HouseTile>());
        Unmoveable.Add(grid[31, 15].GetComponent<HouseTile>());
        Unmoveable.Add(grid[32, 14].GetComponent<HouseTile>());
        Unmoveable.Add(grid[32, 15].GetComponent<HouseTile>());
        Unmoveable.Add(grid[32, 20].GetComponent<HouseTile>());

        for (y = 17; y <= 20; y++)
        {
            Unmoveable.Add(grid[28, y].GetComponent<HouseTile>());
        }

        for (x = 28; x <= 32; x++)
        {
            for (y = 12; y <= 20; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    BedroomA.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }





        //BedroomB;

        //exceptions
        Unmoveable.Add(grid[32, 31].GetComponent<HouseTile>());
        Unmoveable.Add(grid[32, 32].GetComponent<HouseTile>());
        Unmoveable.Add(grid[28, 31].GetComponent<HouseTile>());
        Unmoveable.Add(grid[28, 32].GetComponent<HouseTile>());

        for (x = 28; x <= 32; x++)
        {
            Unmoveable.Add(grid[x, 23].GetComponent<HouseTile>());
        }

        for (x = 30; x <= 32; x++)
        {
            Unmoveable.Add(grid[x, 24].GetComponent<HouseTile>());
        }

        for (x = 30; x <= 32; x++)
        {
            Unmoveable.Add(grid[x, 25].GetComponent<HouseTile>());
        }

        for (y = 27; y <= 29; y++)
        {
            Unmoveable.Add(grid[32, y].GetComponent<HouseTile>());
        }


        for (x = 28; x <= 32; x++)
        {
            for (y = 23; y <= 32; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    BedroomB.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }





        //Garden;

        //exceptions
        Unmoveable.Add(grid[32, 5].GetComponent<HouseTile>());
        Unmoveable.Add(grid[13, 9].GetComponent<HouseTile>());
        Unmoveable.Add(grid[15, 8].GetComponent<HouseTile>());
        Unmoveable.Add(grid[16, 8].GetComponent<HouseTile>());
        Unmoveable.Add(grid[15, 9].GetComponent<HouseTile>());
        Unmoveable.Add(grid[16, 9].GetComponent<HouseTile>());
        Unmoveable.Add(grid[19, 2].GetComponent<HouseTile>());
        Unmoveable.Add(grid[20, 2].GetComponent<HouseTile>());
        Unmoveable.Add(grid[19, 3].GetComponent<HouseTile>());
        Unmoveable.Add(grid[20, 3].GetComponent<HouseTile>());
        Unmoveable.Add(grid[18, 6].GetComponent<HouseTile>());
        Unmoveable.Add(grid[8, 6].GetComponent<HouseTile>());

        for (x = 13; x <= 16; x++)
        {
            Unmoveable.Add(grid[x, 2].GetComponent<HouseTile>());
        }

        for (x = 13; x <= 16; x++)
        {
            Unmoveable.Add(grid[x, 3].GetComponent<HouseTile>());
        }


        for (x = 10; x <= 22; x++)
        {
            for (y = 1; y <= 9; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    Garden.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }





        //Living Room (Hallway);

        //exceptions Hallway
        Unmoveable.Add(grid[17, 30].GetComponent<HouseTile>());
        Unmoveable.Add(grid[19, 30].GetComponent<HouseTile>());
        Unmoveable.Add(grid[20, 30].GetComponent<HouseTile>());
        Unmoveable.Add(grid[22, 32].GetComponent<HouseTile>());
        Unmoveable.Add(grid[23, 32].GetComponent<HouseTile>());
        Unmoveable.Add(grid[23, 16].GetComponent<HouseTile>());
        Unmoveable.Add(grid[25, 21].GetComponent<HouseTile>());
        Unmoveable.Add(grid[23, 12].GetComponent<HouseTile>());
        Unmoveable.Add(grid[24, 12].GetComponent<HouseTile>());

        //exceptions Living room
        Unmoveable.Add(grid[1, 23].GetComponent<HouseTile>());
        Unmoveable.Add(grid[2, 23].GetComponent<HouseTile>());
        Unmoveable.Add(grid[3, 23].GetComponent<HouseTile>());
        Unmoveable.Add(grid[7, 23].GetComponent<HouseTile>());
        Unmoveable.Add(grid[8, 23].GetComponent<HouseTile>());
        Unmoveable.Add(grid[13, 21].GetComponent<HouseTile>());
        Unmoveable.Add(grid[15, 21].GetComponent<HouseTile>());
        Unmoveable.Add(grid[16, 21].GetComponent<HouseTile>());
        Unmoveable.Add(grid[20, 21].GetComponent<HouseTile>());
        Unmoveable.Add(grid[21, 20].GetComponent<HouseTile>());
        Unmoveable.Add(grid[18, 27].GetComponent<HouseTile>());
        Unmoveable.Add(grid[20, 27].GetComponent<HouseTile>());
        Unmoveable.Add(grid[21, 27].GetComponent<HouseTile>());
        Unmoveable.Add(grid[1, 25].GetComponent<HouseTile>());
        Unmoveable.Add(grid[1, 26].GetComponent<HouseTile>());
        Unmoveable.Add(grid[2, 30].GetComponent<HouseTile>());
        Unmoveable.Add(grid[3, 30].GetComponent<HouseTile>());
        Unmoveable.Add(grid[2, 31].GetComponent<HouseTile>());
        Unmoveable.Add(grid[3, 31].GetComponent<HouseTile>());
        Unmoveable.Add(grid[7, 32].GetComponent<HouseTile>());
        Unmoveable.Add(grid[8, 32].GetComponent<HouseTile>());
        Unmoveable.Add(grid[6, 29].GetComponent<HouseTile>());
        Unmoveable.Add(grid[7, 29].GetComponent<HouseTile>());
        Unmoveable.Add(grid[6, 30].GetComponent<HouseTile>());
        Unmoveable.Add(grid[7, 30].GetComponent<HouseTile>());
        Unmoveable.Add(grid[11, 28].GetComponent<HouseTile>());
        Unmoveable.Add(grid[11, 29].GetComponent<HouseTile>());


        for (x = 5; x <= 9; x++)
        {
            Unmoveable.Add(grid[x, 27].GetComponent<HouseTile>());
        }

        for (x = 6; x <= 9; x++)
        {
            Unmoveable.Add(grid[x, 28].GetComponent<HouseTile>());
        }




        //Living room
        for (x = 17; x <= 25; x++)
        {
            for (y = 30; y <= 32; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    LivingRoom.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }

        for (x = 23; x <= 25; x++)
        {
            for (y = 12; y <= 29; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    LivingRoom.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }


        //LivingRoom;
        for (x = 1; x <= 9; x++)
        {
            for (y = 23; y <= 32; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    LivingRoom.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }

        for (x = 10; x <= 16; x++)
        {
            for (y = 21; y <= 32; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    LivingRoom.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }

        for (x = 17; x <= 22; x++)
        {
            for (y = 21; y <= 27; y++)
            {
                if (!Unmoveable.Contains(grid[x, y].GetComponent<HouseTile>()))
                {
                    LivingRoom.Add(grid[x, y].GetComponent<HouseTile>());
                }

            }
        }

        Unmoveable.Remove(grid[8, 14].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[9, 14].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[8, 15].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[9, 15].GetComponent<HouseTile>());

        Unmoveable.Remove(grid[11, 19].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[12, 19].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[11, 20].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[12, 20].GetComponent<HouseTile>());

        Unmoveable.Remove(grid[5, 21].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[6, 21].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[5, 22].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[6, 22].GetComponent<HouseTile>());

        Unmoveable.Remove(grid[18, 19].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[18, 20].GetComponent<HouseTile>());

        Unmoveable.Remove(grid[26, 26].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[27, 26].GetComponent<HouseTile>());

        Unmoveable.Remove(grid[26, 13].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[27, 13].GetComponent<HouseTile>());

        Unmoveable.Remove(grid[11, 10].GetComponent<HouseTile>());
        Unmoveable.Remove(grid[11, 11].GetComponent<HouseTile>());


        foreach (HouseTile g in Unmoveable)
        {
            //g.GetComponent<SpriteRenderer>().enabled = true;
            g.GetComponent<HouseTile>().SetUnmoveable();
            g.SetTileRed();
        }




    }
    public void SpawnPetsOnTiles()
    {
        //bool main1 = false, main2 = false;
        int r;
        HouseTile c;

        GameObject s = GameObject.Find("PetSelectionManager");
        PetSprites Sprites = s.GetComponent<PetSelectionManager>().Sprites;
        



        int m;
        m = Random.Range(0, 100);


        //spawn other pets
        r = Random.Range(0, DiningRoom.Count - 1);
        c = DiningRoom[r].GetComponent<HouseTile>();
        c.SetObj(SpawnStarters(c, Sprites.Main1));
        Party1.Add(c.Pet);
        CurTile = c;
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);
        c.Pet.GetComponent<Stats>().SetMainPet();
        GameObject.Find("Overseer").GetComponent<Overseer>().Persister.MainPet1 = c.Pet;

        r = Random.Range(0, DiningRoom.Count - 1);
        c = DiningRoom[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, DiningRoom.Count - 1);
                c = DiningRoom[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);




        //KITCHEN
        r = Random.Range(0, Kitchen.Count - 1);
        c = Kitchen[r].GetComponent<HouseTile>();
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, Kitchen.Count - 1);
        c = Kitchen[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Kitchen.Count - 1);
                c = Kitchen[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);




        //BATHROOM
        r = Random.Range(0, Bathroom.Count - 1);
        c = Bathroom[r].GetComponent<HouseTile>();
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, Bathroom.Count - 1);
        c = Bathroom[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Bathroom.Count - 1);
                c = Bathroom[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);





        //BEDROOM A
        r = Random.Range(0, BedroomA.Count - 1);
        c = BedroomA[r].GetComponent<HouseTile>();
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, BedroomA.Count - 1);
        c = BedroomA[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, BedroomA.Count - 1);
                c = BedroomA[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);





        //BEDROOM B
        r = Random.Range(0, BedroomB.Count - 1);
        c = BedroomB[r].GetComponent<HouseTile>();
        c.Pet = SpawnStarters(c, Sprites.Main2);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);
        Party2.Add(c.Pet);
        Persister.MainPet2 = c.Pet;
        c.Pet.GetComponent<Stats>().SetMainPet();

        r = Random.Range(0, BedroomB.Count - 1);
        c = BedroomB[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, BedroomB.Count - 1);
                c = BedroomB[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);







        //GARDEN
        r = Random.Range(0, Garden.Count - 1);
        c = Garden[r].GetComponent<HouseTile>();
        c.Pet = RandomOutsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, Garden.Count - 1);
        c = Garden[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Garden.Count - 1);
                c = Garden[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomOutsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, Garden.Count - 1);
        c = Garden[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Garden.Count - 1);
                c = Garden[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomOutsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, Garden.Count - 1);
        c = Garden[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Garden.Count - 1);
                c = Garden[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomOutsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, Garden.Count - 1);
        c = Garden[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Garden.Count - 1);
                c = Garden[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomOutsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);



        //LIVING ROOM
        r = Random.Range(0, LivingRoom.Count - 1);
        c = LivingRoom[r].GetComponent<HouseTile>();
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);

        r = Random.Range(0, LivingRoom.Count - 1);
        c = LivingRoom[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, LivingRoom.Count - 1);
                c = LivingRoom[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.Pet = RandomInsidePet(c, Sprites);
        Pets.Add(c.Pet);
        m = Random.Range(0, 100);


        Destroy(s);
    }
    private GameObject RandomInsidePet(HouseTile c, PetSprites s)
    {
        string ssut = AnimalSpawning.GetAnInsidePet();
        Debug.Log(ssut);
        GameObject g = Instantiate(Resources.Load("Pets/" + ssut + "Prefab"), c.transform.parent.transform.localScale, Quaternion.identity, c.transform) as GameObject;
        g.transform.parent = GameObject.Find("Overseer").transform;
        g.transform.localScale = new Vector3(g.GetComponent<Stats>().HouseScale / 6, g.GetComponent<Stats>().HouseScale / 6, 1);
        g.transform.position = new Vector3(c.transform.position.x, c.transform.position.y, -9);


        Persister.Coordinates.Add(new Coordinates(c.X, c.Y, g));

        return g;
    }

    private GameObject RandomOutsidePet(HouseTile c, PetSprites s)
    {
        string ssut = AnimalSpawning.GetAnOutsidePet();
        Debug.Log(ssut);
        GameObject g = Instantiate(Resources.Load("Pets/" + ssut + "Prefab"), c.transform.parent.transform.localScale, Quaternion.identity, c.transform) as GameObject;
        g.transform.parent = GameObject.Find("Overseer").transform;
        g.transform.localScale = new Vector3(g.GetComponent<Stats>().HouseScale / 6, g.GetComponent<Stats>().HouseScale / 6, 1);
        g.transform.position = new Vector3(c.transform.position.x, c.transform.position.y, -9);


        Persister.Coordinates.Add(new Coordinates(c.X, c.Y, g));

        return g;
    }


    private GameObject SpawnStarters(HouseTile c, string s)
    {

        GameObject g = Instantiate(Resources.Load(s), c.transform.parent.transform.localScale, Quaternion.identity, c.transform) as GameObject;
        g.transform.parent = GameObject.Find("Overseer").transform;
        g.transform.localScale = new Vector3(g.GetComponent<Stats>().HouseScale / 6, g.GetComponent<Stats>().HouseScale / 6, 1);
        g.transform.position = new Vector3(c.transform.position.x, c.transform.position.y, -9);

        Persister.Coordinates.Add(new Coordinates(c.X, c.Y, g));

        return g;
    }






    public void SpawnHealthNodes()
    {
        int r;
        HouseTile c;
        r = Random.Range(0, LivingRoom.Count - 1);
        c = LivingRoom[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, LivingRoom.Count - 1);
                c = LivingRoom[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.hasHealNode = true;
        c.SetTileHealthNode();
        c.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Persister.HealthNodes.Add(new Coordinates(c.X, c.Y, null));





        r = Random.Range(0, DiningRoom.Count - 1);
        c = DiningRoom[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, DiningRoom.Count - 1);
                c = DiningRoom[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.hasHealNode = true;
        c.SetTileHealthNode();
        c.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Persister.HealthNodes.Add(new Coordinates(c.X, c.Y, null));




        //KITCHEN
        r = Random.Range(0, Kitchen.Count - 1);
        c = Kitchen[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Kitchen.Count - 1);
                c = Kitchen[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.hasHealNode = true;
        c.SetTileHealthNode();
        c.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Persister.HealthNodes.Add(new Coordinates(c.X, c.Y, null));




        //BATHROOM
        r = Random.Range(0, Bathroom.Count - 1);
        c = Bathroom[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Bathroom.Count - 1);
                c = Bathroom[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.hasHealNode = true;
        c.SetTileHealthNode();
        c.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Persister.HealthNodes.Add(new Coordinates(c.X, c.Y, null));





        //BEDROOM A
        r = Random.Range(0, BedroomA.Count - 1);
        c = BedroomA[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, BedroomA.Count - 1);
                c = BedroomA[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.hasHealNode = true;
        c.SetTileHealthNode();
        c.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Persister.HealthNodes.Add(new Coordinates(c.X, c.Y, null));





        //BEDROOM B
        r = Random.Range(0, BedroomB.Count - 1);
        c = BedroomB[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, BedroomB.Count - 1);
                c = BedroomB[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.hasHealNode = true;
        c.SetTileHealthNode();
        c.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Persister.HealthNodes.Add(new Coordinates(c.X, c.Y, null));







        //GARDEN
        r = Random.Range(0, Garden.Count - 1);
        c = Garden[r].GetComponent<HouseTile>();
        if (c.IsOccupied())
        {
            bool b = true;
            while (b)
            {
                r = Random.Range(0, Garden.Count - 1);
                c = Garden[r].GetComponent<HouseTile>();
                b = c.IsOccupied();
            }
        }
        c.hasHealNode = true;
        c.SetTileHealthNode();
        c.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Persister.HealthNodes.Add(new Coordinates(c.X, c.Y, null));




    }




    public void SubsequentTurns()
    {
        if (Persister.IsTeam1)
        {
            Persister.IsTeam1 = false;
        }
        else
        {
            Persister.IsTeam1 = true;
        }


        foreach (Coordinates item in Persister.Coordinates)
        {
            if (item.IsUsed)
            {
                if (Party1.Contains(item.Pet) || Party2.Contains(item.Pet))
                {
                    if (item.Pet.GetComponent<Stats>().IsMainPet)
                    {
                        Debug.Log("subd");
                        HouseTile c = grid[item.X, item.Y].GetComponent<HouseTile>();
                        c.Pet = item.Pet;
                        PlacePetOnTile(c);
                        if (Persister.IsTeam1 && Party1.Contains(item.Pet))
                        {
                            CurTile = c;
                        }
                        else if (!Persister.IsTeam1 && Party2.Contains(item.Pet))
                        {
                            CurTile = c;
                        }

                    }
                    else
                    {
                        item.Pet.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }

                else if (Pets.Contains(item.Pet))
                {
                    HouseTile c = grid[item.X, item.Y].GetComponent<HouseTile>();
                    c.Pet = item.Pet;
                    PlacePetOnTile(c);
                }

            }
            else
            {
                item.Pet.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        foreach (Coordinates item in Persister.HealthNodes)
        {
            if (item.IsUsed)
            {
                HouseTile h = grid[item.X, item.Y].GetComponent<HouseTile>();
                h.SetTileHealthNode();
                h.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

        }


        GetMoveableTiles();
        foreach (HouseTile h in MoveableTiles)
        {
            h.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        //UPDATE CAMERA
        Vector3 v = GetTilePosition(CurTile.gameObject);
        GameObject.Find("Main Camera").GetComponent<Transform>().position = new Vector3(v.x, v.y, -10);

    }
    private void PlacePetOnTile(HouseTile c)
    {
        float f = c.Pet.GetComponent<Stats>().HouseScale;
        c.Pet.transform.localScale = new Vector3(f / 5, f / 5, 1);
        c.Pet.transform.position = new Vector3(c.transform.position.x, c.transform.position.y, -9);
    }
    public HouseTile FindPet(GameObject Pet)
    {
        Persister o = GameObject.Find("Overseer").GetComponent<Overseer>().Persister;
        foreach (Coordinates item in o.Coordinates)
        {
            if (item.Pet == Pet)
            {
                return grid[item.X, item.Y].GetComponent<HouseTile>();
            }
        }

        return null;
    }













    //METHODS//



    public void FirstTurn()
    {
        GetMoveableTiles();

        foreach (HouseTile h in MoveableTiles)
        {
            h.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        //UPDATE CAMERA
        Vector3 v = GetTilePosition(CurTile.gameObject);
        GameObject.Find("Main Camera").GetComponent<Transform>().position = new Vector3(v.x, v.y, -10);
    }

    public void NextTurn()
    {
        if (Persister.IsTeam1)
        {
            Persister.IsTeam1 = false;
        }
        else
        {
            Persister.IsTeam1 = true;
        }

        foreach (HouseTile h in MoveableTiles)
        {
            h.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        GetMoveableTiles();
        foreach (HouseTile h in MoveableTiles)
        {
            h.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        //UPDATE CAMERA
        Vector3 v = GetTilePosition(CurTile.gameObject);
        GameObject.Find("Main Camera").GetComponent<Transform>().position = new Vector3(v.x, v.y, -10);

    }





    public void MoveToTile(int x, int y)
    {
        HouseTile dest = grid[x, y].GetComponent<HouseTile>();
        if (MoveableTiles.Contains(dest))
        {
            if (Persister.IsTeam1)
            {
                dest.SetObj(Persister.MainPet1);

                dest.Pet.transform.position = GetTilePosition(dest.gameObject);
                CurTile.RemoveObj();

                CurTile = FindPet(Persister.MainPet2);
                MoveToTileUpdateCoordinates(Persister.MainPet1, dest);


            }
            else
            {
                dest.SetObj(Persister.MainPet2);

                dest.Pet.transform.position = GetTilePosition(dest.gameObject);
                CurTile.RemoveObj();

                CurTile = FindPet(Persister.MainPet1);
                MoveToTileUpdateCoordinates(Persister.MainPet2, dest);

            }

        }
        else
        {
            Debug.Log("Can't move to tile");
        }
    }

    private Vector3 GetTilePosition(GameObject g)
    {
        Vector3 v = new Vector3(g.transform.position.x, g.transform.position.y, -2);
        return v;
    }


    private void MoveToTileUpdateCoordinates(GameObject Pet, HouseTile c)
    {
        Persister o = GameObject.Find("Overseer").GetComponent<Overseer>().Persister;
        foreach (Coordinates item in o.Coordinates)
        {
            if (item.Pet == Pet)
            {
                item.X = c.X;
                item.Y = c.Y;
            }
        }
    }



























    //return a list of moveable tiles
    public void GetMoveableTiles()
    {
        List<HouseTile> ret = new List<HouseTile>();
        int[,] speedgrid = new int[34, 34]; //speedgrid
        //initialize speed grid
        for (int x = 0; x < 34; x++)
        {
            for (int y = 0; y < 34; y++)
            {
                speedgrid[x, y] = -1;
            }
        }

        ret = Moveable(ret, CurTile, 4, speedgrid);

        ret.Remove(CurTile);

        MoveableTiles.RemoveRange(0, MoveableTiles.Count);
        MoveableTiles = ret;


    }

    private List<HouseTile> Moveable(List<HouseTile> ret, HouseTile tile, int speed, int[,] speedgrid)
    {
        if (tile.isMoveable)
        {

            if (speed > speedgrid[tile.X, tile.Y])
            {

                if (!ret.Contains(tile))
                {
                    ret.Add(tile);
                }
                speedgrid[tile.X, tile.Y] = speed;

                if (speed < 1) return ret;
                else
                {
                    speed--;

                    if (tile.Y + 1 < 34)
                    {
                        HouseTile aux = grid[tile.X, tile.Y + 1].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                    if (tile.Y + 1 < 34 && tile.X + 1 < 34)
                    {
                        HouseTile aux = grid[tile.X + 1, tile.Y + 1].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                    if (tile.X + 1 < 34)
                    {
                        HouseTile aux = grid[tile.X + 1, tile.Y].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                    if (tile.Y - 1 > -1 && tile.X + 1 < 34)
                    {
                        HouseTile aux = grid[tile.X + 1, tile.Y - 1].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                    if (tile.Y - 1 > -1)
                    {
                        HouseTile aux = grid[tile.X, tile.Y - 1].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                    if (tile.Y - 1 > -1 && tile.X - 1 > -1)
                    {
                        HouseTile aux = grid[tile.X - 1, tile.Y - 1].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                    if (tile.X - 1 > -1)
                    {
                        HouseTile aux = grid[tile.X - 1, tile.Y].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                    if (tile.Y + 1 < 34 && tile.X - 1 > -1)
                    {
                        HouseTile aux = grid[tile.X - 1, tile.Y + 1].GetComponent<HouseTile>();
                        Moveable(ret, aux, speed, speedgrid);
                    }

                }
            }




        }

        return ret;
    }














}
