using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject car;
    public float timer = 5f;
    public int maxCars = 6;
    private int currentCars = 0;

    void Start()
    {
        // Spawn a car every timer seconds
        InvokeRepeating("SpawnCar", timer, timer);
    }

    void SpawnCar() {
        // Spawn the car prefab at the spawner object position
        Instantiate(car, transform.position, Quaternion.identity);
        currentCars++;
        if(currentCars == maxCars) {
            CancelInvoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
