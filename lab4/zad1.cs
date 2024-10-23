using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    public int numberOfObjects = 10; // Specify the number of objects in the Inspector
    public float delay = 3.0f;
    private int objectCounter = 0;

    // Object to generate
    public GameObject block;

    // Materials to assign randomly
    public Material[] materials; // Drag and drop 5 materials in the Inspector

    private List<Vector3> positions = new List<Vector3>();
    private Bounds platformBounds;

    void Start()
    {
        // Get the bounds of the platform this script is attached to
        platformBounds = GetComponent<Renderer>().bounds;

        GenerateRandomPositions();

        // Start the coroutine to generate objects
        StartCoroutine(GenerateObject());
    }

    void GenerateRandomPositions()
    {
        // Generate random x and z positions based on the platform size
        List<float> posX = new List<float>(Enumerable.Range(0, 20)
            .Select(i => Random.Range(platformBounds.min.x, platformBounds.max.x))
            .Take(numberOfObjects));

        List<float> posZ = new List<float>(Enumerable.Range(0, 20)
            .Select(i => Random.Range(platformBounds.min.z, platformBounds.max.z))
            .Take(numberOfObjects));

        for (int i = 0; i < numberOfObjects; i++)
        {
            positions.Add(new Vector3(posX[i], platformBounds.max.y + 1, posZ[i])); // y starts 1 unit above the platform
        }
    }

    IEnumerator GenerateObject()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            // Assign a random material from the list
            Material randomMaterial = materials[Random.Range(0, materials.Length)];
            newBlock.GetComponent<Renderer>().material = randomMaterial;

            yield return new WaitForSeconds(delay);
        }
    }
}
