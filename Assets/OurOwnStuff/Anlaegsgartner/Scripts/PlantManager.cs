using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlantManager : MonoBehaviour
{

    public int TreeCount = 0;
    public int TreesToPlant = 6;

    public int BushCount = 0;
    public int BushToPlant = 8;


    public int TileCount = 0;
    public int TileToPlant = 14;

    public static PlantManager instance = null;
    public TextMeshProUGUI text;

    public int TotalCount;

    private void Awake()
    {
        if (instance == null)

            //if not, set gamemanager to this
            instance = this;

        //If gamemanager already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {   
        Victory();
    }

    public void Victory()
    {
        if (TreeCount < TreesToPlant)
        {
            text.text = $"Plant træer {TreeCount} / {TreesToPlant}";
        }
        else if (BushCount < BushToPlant)
        {
            text.text = $"Plant Buske {BushCount} / {BushToPlant}";
        }
        else if (TileCount <= TileToPlant)
        {

            text.text = $"Plant Fliser {TileCount} / {TileToPlant}";
        }
    }
    public void SpawnObject(GameObject other, GameObject prefab, Vector3 offset)
    {
        Destroy(other.gameObject);
        Instantiate(prefab, offset, Quaternion.identity);
        Victory();
    }

    public void AddToCount(string countName)
    {
        TotalCount++;
        switch (countName)
        {
            case "Tree":
                TreeCount++;
                break;
            case "Bush":
                BushCount++;
                break;
            case "Tile":
                TileCount++;
                break;
        }
    }

    public int GetTotalCount()
    {
        return TotalCount;
    }

    public int GetTotalToPlant()
    {
        return (TreesToPlant + BushToPlant + TileToPlant);
    }
    
}
