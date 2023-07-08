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
    public Animator animator;
    private bool isDie = false;

    public int enemyIndex;

    private int currentPointIndex = 0;

    private GM gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if (isDie)
        {
            // Detener el movimiento del enemigo si est� muerto
            speed = 0;
            return;
        }
        //Debug.Log(currentHealth);
        if (transform.position == movementPoints[currentPointIndex].position)
        {
            currentPointIndex = (currentPointIndex + 1) % movementPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, movementPoints[currentPointIndex].position, speed * Time.deltaTime);

        /*if (currentPointIndex == movementPoints.Length-1)
        {
            Destroy(gameObject, 10f);
            //Debug.Log("destruir");
        }*/
    }
    public void TakeDamage(int damageAmount)
    {
        if (isDie) return;
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
        
        /*if (currentHealth <= 0)
        {
            // El enemigo ha sido destruido

            Destroy(gameObject);
            gameManager.AddCoins(10);
        }*/
    }

    void Die()
    {
        isDie = true;
        animator.SetBool("isDie", true);

        // Desactivar colisiones y movimiento al morir
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        // Realizar acciones adicionales al morir
        switch (enemyIndex)
        {
            case 1: gameManager.AddCoins(10);
            break;
            case 2: gameManager.AddCoins(15);
            break;
            case 3: gameManager.AddCoins(20);
            break;
            case 4: gameManager.AddCoins(25);
            break;
            case 5: gameManager.AddCoins(30);
            break;
            default: gameManager.AddCoins(35);;
            break;
        }
        //gameManager.AddCoins(10);

        // Destruir el objeto despu�s de un tiempo (opcional)
        Destroy(gameObject, 1.3f);
    }

    public void IncreaseStats(float speed, int health){
        this.currentHealth += health;
        this.speed += speed;
    }
}
