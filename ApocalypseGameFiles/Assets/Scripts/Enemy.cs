using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speedEnemy; // vitesse de l'enemy
    public int DegatsSurP = 0; // degats subit par la cible
    ////Bar de vie de l'enemy
    public Slider HealthBar;
    public float HealthMax;
    public float Health;
    ////Loot
    public GameObject Coin;
    public GameObject Munition;
    public GameObject Caisse;
    public GameObject GoldX2;
    public GameObject Extralife;
    public GameObject Life;
    public GameObject BoostDegat;
    public GameObject BoostSpeed;

    private Transform target; // variable pour stocker la position du player
    private GameObject Player;
    private float NextAttack; // temps entre chaque attack

    /////////// savoir le nombre de degat que le joueur fais
    private GameObject Weapon;
    public int DegatsWeapon;




	void Start ()
    {
        /////////// retoruve le game object avec l'arme pour le nombre de degat
        Weapon = GameObject.FindWithTag("Weapons").gameObject;
        DegatsWeapon = Weapon.GetComponent<WeaponsController>().Degats; // initialisation des degats

        HealthBar.gameObject.SetActive(false);
        Health = HealthMax;
        Player = GameObject.FindWithTag("Player").gameObject;
		    target = GameObject.FindWithTag("Player").GetComponent<Transform>(); // variable = à la position du player


	}


///////////////////////////////////// deplacement du zombie ( vers player ) /////////////////////////////////////
	void Update ()
    {

        if(Vector2.Distance(transform.position, target.position) >= 1 )
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedEnemy * Time.deltaTime);
        }
        else
        {
            ZombieHit();
        }

	}

  void OnTriggerEnter2D(Collider2D others)
  {
      if (others.gameObject.CompareTag ("Balles")) // detecttion desballes quand le zombie est touché
      {
          HealthBar.gameObject.SetActive(true);
          Health -= DegatsWeapon;
          Debug.Log("Le Zombie à été touché");
          float pourcentage = Health / HealthMax;
          HealthBar.value = pourcentage;

          if ( Health <= 0 )
          {
              /// loot en général
              int rand = Random.Range(0, 100);
              Debug.Log("rand  : " + rand);


              /// loot gold
              if ( rand >= 15 && rand < 85)
              {
                  int randomeCoin = Random.Range(0, 4);
                  Debug.Log("Coin : " + randomeCoin);
                  for ( int i = 0; i <= randomeCoin; i ++)
                  {
                      Instantiate(Coin, transform.position, Quaternion.identity);
                  }
              }

              //// loot munition
              if ( rand <= 40)
              {
                  int randomeMunition = Random.Range(0, 2);
                  Debug.Log("munition : " + randomeMunition);
                  for ( int i = 0; i <= randomeMunition; i ++)
                  {
                      Instantiate(Munition, transform.position, Quaternion.identity);
                  }
              }

              /// loot caisse
              if ( rand <= 50)
              {
                  Debug.Log("Caisse");
                  Instantiate(Caisse, transform.position, Quaternion.identity);
              }

              /// loot Power Up
              if ( rand >= 85 && rand < 95 )
              {
                  int randomePowerUp = Random.Range(1, 5);
                  Debug.Log("PowerUp");
                  if ( randomePowerUp == 1)
                  {
                      Instantiate(Extralife, transform.position, Quaternion.identity);
                  }
                  if ( randomePowerUp == 2)
                  {
                      Instantiate(GoldX2, transform.position, Quaternion.identity);
                  }
                  if ( randomePowerUp == 3)
                  {
                      Instantiate(BoostDegat, transform.position, Quaternion.identity);
                  }
                  if ( randomePowerUp == 4)
                  {
                      Instantiate(BoostSpeed, transform.position, Quaternion.identity);
                  }
                  if ( randomePowerUp == 5)
                  {
                      Instantiate(Extralife, transform.position, Quaternion.identity);
                  }

              }

              /// loot life
              if ( rand >= 65 && rand < 85 )
              {
                  Debug.Log("Life");
                  Instantiate(Life, transform.position, Quaternion.identity);
              }

              Destroy(gameObject);
          }
      }
  }
///////////////////////////////////// Attack du zombie lorsque il est assez proche /////////////////////////////////////
  public void  ZombieHit()
  {
      if (Time.time > NextAttack )
      {
          NextAttack = Time.time + 2;
          Player.GetComponent<PlayerController>().vie -= DegatsSurP;
      }
  }



}
