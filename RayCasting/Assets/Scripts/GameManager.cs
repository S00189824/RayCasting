using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<WorldResources> possibleResources;

    Dictionary<ResourceType, int> registeredGenerators = new Dictionary<ResourceType, int>();
    Dictionary<ResourceType, int> GeneratedResources = new Dictionary<ResourceType, int>();

    public GameObject generatorPrefab;

	// Use this for initialization
	void Start ()
    {
        registeredGenerators.Add(ResourceType.Coal, 0);
        registeredGenerators.Add(ResourceType.Gold, 0);
        registeredGenerators.Add(ResourceType.Soil, 0);
        registeredGenerators.Add(ResourceType.Water, 0);

        GeneratedResources.Add(ResourceType.Coal, 0);
        GeneratedResources.Add(ResourceType.Gold, 0);
        GeneratedResources.Add(ResourceType.Soil, 0);
        GeneratedResources.Add(ResourceType.Water, 0);

        Invoke("GenerateResources", 2);
    }

    public void SpawnGenerator(Vector3 location,Vector3 normal,Color resourceColor)
    {
        //Any returns a bool

        if(possibleResources.Any(wr=> wr.resourceColorPixel == resourceColor))
        {
            ResourceType type = possibleResources.Find(wr => wr.resourceColorPixel == resourceColor).Resource;

            GameObject generator = Instantiate(generatorPrefab, location, Quaternion.identity);
            generator.transform.up = normal;

            ResourceGenerator res = generator.GetComponent<ResourceGenerator>();
            res.SetMaterialColor(resourceColor);

            registeredGenerators[type]++;
        }
    }

    private void GenerateResources()
    {
        GeneratedResources[ResourceType.Coal] += registeredGenerators[ResourceType.Coal];
        GeneratedResources[ResourceType.Water] += registeredGenerators[ResourceType.Water];
        GeneratedResources[ResourceType.Gold] += registeredGenerators[ResourceType.Gold];
        GeneratedResources[ResourceType.Soil] += registeredGenerators[ResourceType.Soil];

        Debug.Log(GeneratedResources[ResourceType.Coal]);
        Debug.Log(GeneratedResources[ResourceType.Water]);
        Debug.Log(GeneratedResources[ResourceType.Soil]);
        Debug.Log(GeneratedResources[ResourceType.Gold]);

        Invoke("GenerateResources", 2);
    }
}
