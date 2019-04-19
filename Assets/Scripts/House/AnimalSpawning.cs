using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawning
{

    public static string GetAPet()
    {

        List<string> pets = new List<string>();
        pets.Add("CatFat");
        pets.Add("CatSmall");
        pets.Add("DogSmall");
        pets.Add("DogMedium");
        pets.Add("DogLarge");
        pets.Add("Fly");
        pets.Add("Bird");
        pets.Add("Spider");
        pets.Add("Rat");



        int r = Random.Range(0, pets.Count);
        return pets[r];






        /*
        //large cat 20, small cat 20, medium dog 20, large dog 20, small dog 20, fly 70, bird 50
        if (r < 15)
        {
            return "CatFat";
        }

        if (r >= 15 && r < 30)
        {
            return "CatSmall";
        }

        if (r >= 30 && r < 45)
        {
            return "DogSmall";
        }

        if (r >= 45 && r < 60)
        {
            return "DogMedium";
        }

        if (r >= 60 && r < 75)
        {
            return "DogLarge";
        }

        if (r >= 75 && r < 92)
        {
            return "Fly";
        }

        if (r >= 92)
        {
            return "Bird";
        }
        return "";
        */


    }


    public static string GetAnInsidePet()
    {

        List<string> pets = new List<string>();

        pets.Add("Lizard");
        pets.Add("Iguana");
        pets.Add("Turtle");
        pets.Add("Tarantula");

        int r = Random.Range(0, 100);

        if (r < 50)
        {
            int rr = Random.Range(0, pets.Count);
            return pets[rr];
        }


        pets.Add("CatFat");
        pets.Add("CatSmall");
        pets.Add("DogSmall");
        pets.Add("DogMedium");
        pets.Add("DogLarge");
        pets.Add("Fly");
        pets.Add("Bird");
        pets.Add("Spider");
        pets.Add("Rat");


        r = Random.Range(0, pets.Count);
        return pets[r];



        /* 
        //lizard 25, iguana 20, turtle 30
        if (r < 50)
        {
            if (r < 8)
            {
                return "Lizard";
            }

            if (r >= 8 && r < 25)
            {
                return "Iguana";
            }

            if (r >= 25 && r < 50)
            {
                return "Turtle";
            }
        }
        */
    }


    public static string GetAnOutsidePet()
    {

        List<string> pets = new List<string>();

        pets.Add("Tiger");
        pets.Add("Bear");
        pets.Add("Racoon");
        pets.Add("Possum");
        pets.Add("Ant");

        int r = Random.Range(0, 100);

        if (r < 50)
        {
            int rr = Random.Range(0, pets.Count);
            return pets[rr];
        }


        pets.Add("CatFat");
        pets.Add("CatSmall");
        pets.Add("DogSmall");
        pets.Add("DogMedium");
        pets.Add("DogLarge");
        pets.Add("Fly");
        pets.Add("Bird");
        pets.Add("Spider");
        pets.Add("Rat");

        r = Random.Range(0, pets.Count);
        return pets[r];





        /* 
        //tiger 5, bear 5, raccoon 20, possum 20
        if (r < 50)
        {

            if (r < 5)
            {
                return "Tiger";
            }

            if (r >= 5 && r < 10)
            {
                return "Bear";
            }

            if (r >= 10 && r < 30)
            {
                return "Racoon";
            }

            if (r >= 30 && r < 50)
            {
                return "Possum";
            }

        }
        */
    }



}
