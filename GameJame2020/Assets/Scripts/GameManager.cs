using System.Collections;
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


    void Update()
    {
        
    }

    //this is the funciton the ship script will call when it collides with a animal
    //this script will then instantiate a prefab into the next available spot
    //this will also need to check if the animals have found their pairs - put them side by side
    public void collectAnimal(string animalName)
    {
        GameObject animal = Instantiate(animalPrefab, inventoryPositions[0]);
        animal.name = animalName;
        Image animalSprite= animal.GetComponent<Image>();
        animalSprite.sprite = Resources.Load<Sprite>(animalName);
        collectedAnimals.Add(animalName);
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
