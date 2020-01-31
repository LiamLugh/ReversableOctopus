﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<string> collectedAnimals;
    public List<Transform> inventoryPositions;

    public GameObject inventoryPrefab;
    public GameObject inventoryParent;
    public GameObject animalPrefab;

    private void Awake()
    {
        collectedAnimals = new List<string>();
        inventoryPositions = new List<Transform>();

        for(int i = 0; i < Globals.levelPairCount; i++)
        {
            GameObject cell = Instantiate(inventoryPrefab, inventoryParent.transform);
            inventoryPositions.Add(cell.transform);
        }
    }

    //this is the funciton the ship script will call when it collides with a animal
    //this script will then instantiate a prefab into the next available spot
    //this will also need to check if the animals have found their pairs - put them side by side
    public void collectAnimal(string animalName)
    {
        bool spawned = false;
        for (int i = 0; i < collectedAnimals.Count; i++)
        {
            if (animalName.Equals(collectedAnimals[i]))
            {
                spawnAnimals(i, 10, animalName);
                spawned = true;
                break;
            }
        }

        if (spawned == false)
        {
            //check positions
            int position = collectedAnimals.Count;
            spawnAnimals(position, 0, animalName);
        }
    }

    void spawnAnimals(int position, int offset, string animalName)
    {
        GameObject animal = Instantiate(animalPrefab, inventoryPositions[position]);
        animal.transform.position = new Vector3(animal.transform.position.x + offset, animal.transform.position.y, animal.transform.position.z);
        animal.name = animalName;
        Image animalSprite = animal.GetComponent<Image>();
        animalSprite.sprite = Resources.Load<Sprite>(animalName);
        Destroy(animal.GetComponent<DragHandeler>());
        if(offset < 9)
        {
            collectedAnimals.Add(animalName);
        }
    }

    //this script is called when a animal needs to be removed fromt the list and then shot out of the cannon
    //this string will get send on the collision of the dropped item
    public void removeAnimal(string animalName)
    {
        foreach(string animal in collectedAnimals)
        {
            if (animalName.Equals(animal))
            {
                collectedAnimals.Remove(animalName);
                break;
            }
        }
    }
}
