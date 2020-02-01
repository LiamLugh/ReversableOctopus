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
    int winCount = 0;

    private void Awake()
    {
        collectedAnimals = new List<string>();
        inventoryPositions = new List<Transform>();

        for(int i = 0; i < Globals.levelPairCount+1; i++)
        {
            GameObject cell = Instantiate(inventoryPrefab, inventoryParent.transform);
            inventoryPositions.Add(cell.transform);
        }
    }

    private void Update()
    {
        winCount = 0;
        foreach(string animal in collectedAnimals)
        {
            if (animal.Equals("Complete"))
            {
                winCount++;
            }
        }
        if(winCount == Globals.levelPairCount)
        {
            Globals.win = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinLose");
        }
        //check for win state here
        //might have to look at changing the string in the collected animals to something else
        //so as a win state we could check if we have the  required amount of "colelcted" or something
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
                collectedAnimals[i] = "Complete";
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
        if(offset < 9)
        {
            collectedAnimals.Add(animalName);
        }
        else
        {
            Destroy(animal.GetComponent<DragHandeler>());
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
                //animate model being shot from cannon
                break;
            }
        }
    }
}
