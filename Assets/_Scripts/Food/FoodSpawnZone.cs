using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FoodSpawnZone : MonoBehaviour
{
    private Bounds objectBounds;

    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private int amountToSpawn;
    [SerializeField] private int spawnCount;
    [SerializeField] private FoodScriptable[] foodToSpawn;

    SpriteRenderer renderer;

    private void Awake()
    {
        // Get the Renderer component attached to the game object
        renderer = GetComponent<SpriteRenderer>();

        // Calculate the bounds of the game object
        objectBounds = renderer.bounds;
    }

    void Start()
    {
        StartCoroutine(SpawnThings());
        renderer.enabled = false;
    }

    void SpawnObjectWithinBounds()
    {
        // Generate a random position within the spawner's bounds
        Vector3 randomPosition = new Vector2(
            Random.Range(objectBounds.min.x, objectBounds.max.x),
            Random.Range(objectBounds.min.y, objectBounds.max.y)
        );
        FoodScriptable foodScriptable = foodToSpawn[Random.Range(0, foodToSpawn.Length)];
        // Spawn a food at the random position
        GameObject item = Instantiate(foodPrefab, randomPosition, transform.rotation);
        item.transform.parent = transform;
        if (item.TryGetComponent<FoodItem>(out FoodItem food))
        {
            food.CreateFood(foodScriptable);
        }
        if (foodScriptable.isWandering)
        {
            WanderingAnimal wanderingAnimal = item.AddComponent<WanderingAnimal>();
            wanderingAnimal.range = foodScriptable.range;
            wanderingAnimal.speed = foodScriptable.speed;
            wanderingAnimal.waitTime = foodScriptable.waitTime;
        }
    }

    IEnumerator SpawnThings()
    {
        spawnCount = amountToSpawn;
        while (spawnCount > 0)
        {
            SpawnObjectWithinBounds();
            spawnCount--;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
