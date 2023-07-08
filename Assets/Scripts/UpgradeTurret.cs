using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTurret : MonoBehaviour
{

    public GameObject turretPrefab;//se coloca la nueva torre
    public GameObject turretDestroy;//se borra la anterior torre
    private GM gameManager;
    private CreateTurret ct;
    private int turretUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = FindObjectOfType<GM>();
        turretUpgrade = 150;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameManager.getCoins() >= turretUpgrade)
        {
            BuildTurret();
            gameManager.DecreaseCoins(turretUpgrade);
            gameManager.AddPuntaje(30);//se añade puntaje
        }
        else
        {
            Debug.Log("No tienes recursos suficientes");
        }
    }
    private void BuildTurret()
    {
        
        //nueva torreta
        Vector3 pos = transform.position;
        pos.y = pos.y + 0.35f;
        Instantiate(turretPrefab, pos, Quaternion.identity);
        //se reemplaza la anterior torreta, se destruye la anterior torreta y el boton de mejora
        Destroy(gameObject);
        Destroy(turretDestroy);
    }

}

