using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bake : MonoBehaviour
{
    public GameObject SpawnObjekt;
    List<string> recipe = new List<string>();
    public int count = 0;
    public TextMeshProUGUI text;
    // Start is called before the first frame update

    void Start()
    {
        recipe.Add("Du skal nu bage boller, start med at tilsæt Vand");
        recipe.Add("Tilsæt Mælk");
        recipe.Add("Tilsæt Gær");
        recipe.Add("Tilsæt Olie");
        recipe.Add("Tilsæt Sukker");
        recipe.Add("Tilsæt Mel");
        recipe.Add("Tilsæt Salt");
        recipe.Add("");
        recipe.Add("Put boller i oven" + "\n" + "Når dine boller er færdige" + "\n" + "er det tid til at lave pynte en kage");



    }

    // Update is called once per frame
    void Update()
    {

        SpawnObject();
        text.text = recipe[count];

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NameOfObject>() != null)
        {

            if (collision.gameObject.GetComponent<NameOfObject>().objectName == recipe[count])
            {

                Destroy(collision.gameObject);
                count++;
                Debug.Log(collision.gameObject.GetComponent<NameOfObject>().objectName);
            }
        }

        //Recipe 
        // Water and milk
        //Yeast
        //Oil and sugar
        //Flour and salt
        //Put in oven done!!!

    }

    public void SpawnObject()
    {
        if (count == 7)
        {

            Instantiate(SpawnObjekt, new Vector3(-1.457f, 0.812f, 7.747f), Quaternion.identity);
            count++;
        }



    }
}
