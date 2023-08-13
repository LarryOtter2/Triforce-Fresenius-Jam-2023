using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSpawnerScript : MonoBehaviour
{
    public GameObject burger;
    public float spawneRate = 2;
    private float timer = 0;

    [SerializeField] EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        spawnBurger();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawneRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnBurger();
            timer = 0;
        }

        
    }

    void spawnBurger()
    {
        GameObject currentBurger = Instantiate(burger, transform.position, transform.rotation);
        currentBurger.GetComponent<FastFoodScript>().Instantiated(enemyMovement);
    }
}
