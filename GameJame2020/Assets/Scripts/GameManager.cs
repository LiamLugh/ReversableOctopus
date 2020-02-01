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

    public ImageData[] imageData;

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
        //so as a win state we could check if we have the required amount of "colelcted" or something
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

        switch(animalName)
        {
            case "Elephant":
                animalSprite.rectTransform.sizeDelta = new Vector2(imageData[0].data[0], imageData[0].data[1]);
                animalSprite.rectTransform.localPosition = new Vector2(imageData[0].data[2], imageData[0].data[3]);
                animalSprite.rectTransform.localScale = Vector3.one * imageData[0].data[4];
                break;
            case "Giraffe":
                animalSprite.rectTransform.sizeDelta = new Vector2(imageData[1].data[0], imageData[1].data[1]);
                animalSprite.rectTransform.localPosition = new Vector2(imageData[1].data[2], imageData[1].data[3]);
                animalSprite.rectTransform.localScale = Vector3.one * imageData[1].data[4];
                break;
            case "Penguin":
                animalSprite.rectTransform.sizeDelta = new Vector2(imageData[2].data[0], imageData[2].data[1]);
                animalSprite.rectTransform.localPosition = new Vector2(imageData[2].data[2], imageData[2].data[3]);
                animalSprite.rectTransform.localScale = Vector3.one * imageData[2].data[4];
                break;
            case "Pig":
                animalSprite.rectTransform.sizeDelta = new Vector2(imageData[3].data[0], imageData[3].data[1]);
                animalSprite.rectTransform.localPosition = new Vector2(imageData[3].data[2], imageData[3].data[3]);
                animalSprite.rectTransform.localScale = Vector3.one * imageData[3].data[4];
                break;
            case "Unicorn":
                animalSprite.rectTransform.sizeDelta = new Vector2(imageData[4].data[0], imageData[4].data[1]);
                animalSprite.rectTransform.localPosition = new Vector2(imageData[4].data[2], imageData[4].data[3]);
                animalSprite.rectTransform.localScale = Vector3.one * imageData[4].data[4];
                break;
        }

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
        //foreach(string animal in collectedAnimals)
        for(int i = 0; i < collectedAnimals.Count; i++)
        {
            if (animalName.Equals(collectedAnimals[i]))
            {
                collectedAnimals.Remove(animalName);
                //animate model being shot from cannon

                //move all other animals further on from that number to the previous spot
                if(i + 1 < inventoryPositions.Count)
                {
                    for (int j = i + 1; j < inventoryPositions.Count; j++)
                    {
                        if(inventoryPositions[j].childCount > 0)
                        {
                            for (int k = 0; k < inventoryPositions[j].childCount; k++)
                            {
                                Transform child = inventoryPositions[j].GetChild(k);
                                child.SetParent(inventoryPositions[j - 1]);
                                child.localPosition = Vector3.zero;
                                string childName = child.name;

                                switch (childName)
                                {
                                    case "Elephant":
                                        child.GetComponent<RectTransform>().localPosition = new Vector2(imageData[0].data[2], imageData[0].data[3]);
                                        break;
                                    case "Giraffe":
                                        child.GetComponent<RectTransform>().localPosition = new Vector2(imageData[1].data[2], imageData[1].data[3]);
                                        break;
                                    case "Penguin":
                                        child.GetComponent<RectTransform>().localPosition = new Vector2(imageData[2].data[2], imageData[2].data[3]);
                                        break;
                                    case "Pig":
                                        child.GetComponent<RectTransform>().localPosition = new Vector2(imageData[3].data[2], imageData[3].data[3]);
                                        break;
                                    case "Unicorn":
                                        child.GetComponent<RectTransform>().localPosition = new Vector2(imageData[4].data[2], imageData[4].data[3]);
                                        break;
                                }

                                if(k > 0)
                                {
                                    child.localPosition = new Vector3(child.localPosition.x + 10, child.localPosition.y);
                                }
                            }
                        }
                    }
                }
                
                break;
            }
        }
    }
}

[System.Serializable]
public struct ImageData
{
    public string name;
    public float[] data;
}
