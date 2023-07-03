using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int initialHealth;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private float speed;


    public Transform[] movementPoints;
    private int currentPointIndex = 0;

    private GM gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GM>();
        speed = 2;
        initialHealth = 50;
        currentHealth = initialHealth;
        GameObject wp = GameObject.Find("Waypoints");
        movementPoints = wp.GetComponentsInChildren<Transform>(true);
        movementPoints = movementPoints.Where(t => t.gameObject != wp).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
        if (transform.position == movementPoints[currentPointIndex].position)
        {
            currentPointIndex = (currentPointIndex + 1) % movementPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, movementPoints[currentPointIndex].position, speed * Time.deltaTime);

        if (currentPointIndex == movementPoints.Length-1)
        {
            Destroy(gameObject, 10f);
            //Debug.Log("destruir");
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            // El enemigo ha sido destruido
            Destroy(gameObject);
            gameManager.AddCoins(10);
        }
    }
    public void IncreaseStats(float speed, int health){
        this.currentHealth += health;
        this.speed += speed;
    }
}
