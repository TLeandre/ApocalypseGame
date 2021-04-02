////////////////////////////////////////////////////////////////////////////////
//// Player == index 0
//// Player Gros == index 1
////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {



    private GameObject Manager;
    private Vector2 direction;

    protected int oil; // variable pour le nombre de oil


    public Animator transitionAnim; // recupere l'animation transition
    public Text TextGold; // recupere texte gold
    public Text TextOil; // recupere texte oil
    public GameObject FindujeuWin; // recuper le game objects qui permet d'afficher la victoire
    public Text TextGoldGagnerWin; // recupere la texte qui permet de voir combien de gold il a gagner
    public GameObject FindujeuDefaite; // recuper le game object qui permet d'afficher la defaite
    public Text TextdeMort; // recupere le text de mort pour modifier le nombre de km ( lvl ) parcouru
    public Text TextGoldGagnerDefaite; // recupere la texte qui permet de voir combien de gold il a gagner
    public Text TextMunition;
    public GameObject PanelAffichageObject;
    //// Pour target l'enemy ///
    private Transform target;
    public float range;
    public float rechargement;
    public GameObject cible;
    //// pour tiré ////
    private float NextAttack;
    public GameObject Balle;
    public float speedBalle = 2;
    public Transform firePoint;
    //// en ce qui comcerne el personnage ( caractéristique ) ////
    public int vieMax;
    public int vie;
    public int vieMaxDefault = 0;

    public int speedengrandnombre;// definit la vitesse du joueur
    public float speed;
    public int SpeedDefault = 0; // valeur du speed par Default pour le joueur
    //()//
    public int munitionDebutGame;
    public int munitionInGame;
    public int MunitionDebutGameDefault; // nb de munition par default pour le joueur
    //// HealthGestion ////
    private float vieMaxHealthBar;
    private float vieHealthBar;
    public Slider slider;
    //// PowerUp ///
    public GameObject PowerUpPanel;
    public Text NBExtraLife;
    public Text NBGoldX2;
    public Text NBBoostDegat;
    public Text NBBoostSpeed;
    public Text NBSkipLvl;
    //// multiplicateur ///
    public int multiplicateurGold = 1;

    //// Timer ///
    public float time;
    public Text Timer;


    private GameObject IndexSelector;
    private GameObject Weapon;
    private int index;





	  void Start ()
    {

        index = PlayerPrefs.GetInt("CharacterSelected");



        if ( index == 0 )
        {

          //// tout debut de la partie
          if (PlayerPrefs.HasKey("VieMaxPlayer"))
          {
              vieMax = PlayerPrefs.GetInt("VieMaxPlayer");
          }
          else
          {
              vieMax = vieMaxDefault;
              PlayerPrefs.SetInt("VieMaxPlayer", vieMax);
          }
          // recherche le speed du joueur dans les PlayerPrefs
          if (PlayerPrefs.HasKey("SpeedPlayer"))
          {
              speedengrandnombre = PlayerPrefs.GetInt("SpeedPlayer");
          }
          else
          {
              speedengrandnombre = SpeedDefault;
              PlayerPrefs.SetInt("SpeedPlayer", speedengrandnombre);
          }
          // recherche le nombre de munition au debut de partie du joueur dans les PlayerPrefs
          if (PlayerPrefs.HasKey("munitionDebutGamePlayer"))
          {
              munitionDebutGame = PlayerPrefs.GetInt("munitionDebutGamePlayer");
          }
          else
          {
              munitionDebutGame = MunitionDebutGameDefault;
              PlayerPrefs.SetInt("munitionDebutGamePlayer", munitionDebutGame);
          }



          ///////autre niveau durant la partie ///////


          // cherche si partie présendente la vie est descendu
          if (PlayerPrefs.HasKey("VieInGamePlayer"))
          {
              vie = PlayerPrefs.GetInt("VieInGamePlayer");
          }
          else
          {
              vie = vieMax;
          }
          // cherche si partie présendente le nb de munition a descendu
          if (PlayerPrefs.HasKey("munitionInGamePlayer"))
          {
              munitionInGame = PlayerPrefs.GetInt("munitionInGamePlayer");
          }
          else
          {
              munitionInGame = munitionDebutGame;
          }
        }



        if ( index == 1 )
        {

          //// tout debut de la partie
          if (PlayerPrefs.HasKey("VieMaxPlayerGros"))
          {
              vieMax = PlayerPrefs.GetInt("VieMaxPlayerGros");
          }
          else
          {
              vieMax = vieMaxDefault;
              PlayerPrefs.SetInt("VieMaxPlayerGros", vieMax);
          }
          // recherche le speed du joueur dans les PlayerPrefs
          if (PlayerPrefs.HasKey("SpeedPlayerGros"))
          {
              speedengrandnombre = PlayerPrefs.GetInt("SpeedPlayerGros");
          }
          else
          {
              speedengrandnombre = SpeedDefault;
              PlayerPrefs.SetInt("SpeedPlayerGros", speedengrandnombre);
          }
          // recherche le nombre de munition au debut de partie du joueur dans les PlayerPrefs
          if (PlayerPrefs.HasKey("munitionDebutGamePlayerGros"))
          {
              munitionDebutGame = PlayerPrefs.GetInt("munitionDebutGamePlayerGros");
          }
          else
          {
              munitionDebutGame = MunitionDebutGameDefault;
              PlayerPrefs.SetInt("munitionDebutGamePlayerGros", munitionDebutGame);
          }



          ///////autre niveau durant la partie ///////


          // cherche si partie présendente la vie est descendu
          if (PlayerPrefs.HasKey("VieInGamePlayerGros"))
          {
              vie = PlayerPrefs.GetInt("VieInGamePlayerGros");
          }
          else
          {
              vie = vieMax;
          }
          // cherche si partie présendente le nb de munition a descendu
          if (PlayerPrefs.HasKey("munitionInGamePlayerGros"))
          {
              munitionInGame = PlayerPrefs.GetInt("munitionInGamePlayerGros");
          }
          else
          {
              munitionInGame = munitionDebutGame;
          }


        }



        Manager = GameObject.Find("GameManager").gameObject;
        ///////////recupère les stats de l'arme
        Weapon = GameObject.FindWithTag("Weapons").gameObject;
        Invoke("RangeRechargementTarget", 1f); // pour retrouver le rang et celui du rechargement sinon tire bcp trop vite un peu plus tard car sinon pas le temsp est donc = 0







        speed = speedengrandnombre / 25;
        /// pour la barre de vie
        vieMaxHealthBar = vieMax;
        FindujeuDefaite.SetActive(false);
        FindujeuWin.SetActive(false);
        PanelAffichageObject.SetActive(true);
        oil = 0; // definit le nombre de oil à zero lors du lancement du jeu
        TextOil.text = oil + " / 6"; // definit l'affichage de oil
        TextGold.text = Manager.GetComponent<GameManager>().GoldInGame + " "; // definit l'affichage de Gold
        TextMunition.text = munitionInGame + " ";


        InvokeRepeating("UpdateTarget", 0f, 0.5f); // recupere de façon repeter la detection des enemy
        //regarde si c'est la premier game
        if ( Manager.GetComponent<GameManager>().FirstGame == 1 && Manager.GetComponent<GameManager>().Play == 1)
        {
            StartCoroutine(PowerUpPanelActive());
        }

        //// power up
        //verifier si c'est pas la premier game

        // verification des PowerUp
        if ( Manager.GetComponent<GameManager>().GoldX2Active == 1 )
        {
            multiplicateurGold = 2;
        }
        else
        {
            multiplicateurGold = 1;
        }

    }


///////////////////////////////////// appartiton de la cible lorsque l'on trouve la target /////////////////////////////////////
    void Update ()
    {
        if ( target == null)
        {
            cible.SetActive(false);
            return;

        }

        cible.SetActive(true);
        Vector3 dir = target.position;
        cible.transform.position = Vector2.MoveTowards(target.position, transform.position, Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && target != null && Time.time > NextAttack && munitionInGame > 0)
        {
            Shoot();
            NextAttack = Time.time + rechargement;
            Debug.Log("Tiré");
        }



    }



/////////////////////////////////////Mouvement du joueur + verification de sa mort /////////////////////////////////////
	   void FixedUpdate ()
    {
        GetInput();
		    Move();

        if ( vie <= 0) //(Manager.GetComponent<GameManager>().lifeInGame <= 0 )
        {
            if ( Manager.GetComponent<GameManager>().ExtraLifeActive == 1 )
            {
                vie = vieMax;
                Manager.GetComponent<GameManager>().ExtraLifeActive = 0;
            }
            else
            {
                MortDuPlayer();
            }
        }

        /// permet de gerer la barre de vie ////
        vieHealthBar = vie ;
        float pourcentage = vieHealthBar / vieMaxHealthBar;
        slider.value = pourcentage;
        // timer
        time = (int)Time.time - Manager.GetComponent<GameManager>().TimeStart;
        Timer.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(time/60), time%60);
	  }



    public void Move ()
    {
        transform.Translate(direction*speed*Time.deltaTime);
    }



    private void GetInput ()
    {

        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            direction +=Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

    }



///////////////////////////////////// detection des objects /////////////////////////////////////
    void OnTriggerEnter2D(Collider2D others)
    {
        //// Oil
        if (others.gameObject.CompareTag ("PickUp")) // detecttion des PickUp soit Oil pour les recuperer
        {
            others.gameObject.SetActive (false);
            oil = oil + 1;
            TextOil.text = oil + " / 6"; // changer l'affichage de oil
            Debug.Log(oil);
            Manager.GetComponent<GameManager>().GoldInGame += (1 * multiplicateurGold);
            TextGold.text = Manager.GetComponent<GameManager>().GoldInGame + " ";

        }
        /////Gold
        if (others.gameObject.CompareTag ("PickUpGold")) // detection d'un gold tombé d'un Enemy
        {
            others.gameObject.SetActive (false);
            Manager.GetComponent<GameManager>().GoldInGame += ( 1 * multiplicateurGold);
            TextGold.text = Manager.GetComponent<GameManager>().GoldInGame + " ";
        }
        ////Munition
        if (others.gameObject.CompareTag ("PickUpMunition")) // detection d'une munition tombé d'un Enemy
        {
            others.gameObject.SetActive (false);
            munitionInGame += 1;
            TextMunition.text = munitionInGame + " ";
        }
        ///// Caisse
        if (others.gameObject.CompareTag ("PickUpCaisse")) // detection d'une caisse
        {
            others.gameObject.SetActive (false);
            Manager.GetComponent<GameManager>().CaisseGeneral += 1;
            PlayerPrefs.SetInt("CaisseGeneral", Manager.GetComponent<GameManager>().CaisseGeneral);
            Debug.Log(Manager.GetComponent<GameManager>().CaisseGeneral);
        }
        ////PowerUp
        // gold * 2
        if (others.gameObject.CompareTag ("PickUpGoldX2")) // detection du power up gold * 2
        {
            others.gameObject.SetActive(false);
            Manager.GetComponent<GameManager>().NombreGoldX2 += 1;
            PlayerPrefs.SetInt("GoldX2", Manager.GetComponent<GameManager>().NombreGoldX2);
            Debug.Log("+1 gold * 2 ");
            Debug.Log(Manager.GetComponent<GameManager>().NombreGoldX2);
        }
        // extra life
        if (others.gameObject.CompareTag ("PickUpExtralife")) // detection du power up extra life
        {
            others.gameObject.SetActive(false);
            Manager.GetComponent<GameManager>().NombreExtraLife += 1;
            PlayerPrefs.SetInt("ExtraLife", Manager.GetComponent<GameManager>().NombreExtraLife);
            Debug.Log("+1 extra life  ");
            Debug.Log(Manager.GetComponent<GameManager>().NombreExtraLife);
        }
        // BoostDegat
        if (others.gameObject.CompareTag ("PickUpBoostDegat")) // detection du power BoostDegat
        {
            others.gameObject.SetActive(false);
            Manager.GetComponent<GameManager>().NombreBoostDegat += 1;
            PlayerPrefs.SetInt("BoostDegat", Manager.GetComponent<GameManager>().NombreBoostDegat);
            Debug.Log("+1 BoostDegat ");
            Debug.Log(Manager.GetComponent<GameManager>().NombreBoostDegat);
        }
        // BoostSpeed
        if (others.gameObject.CompareTag ("PickUpBoostSpeed")) // detection du power BoostSpeed
        {
            others.gameObject.SetActive(false);
            Manager.GetComponent<GameManager>().NombreBoostSpeed += 1;
            PlayerPrefs.SetInt("BoostSpeed", Manager.GetComponent<GameManager>().NombreBoostSpeed);
            Debug.Log("+1 BoostSpeed ");
            Debug.Log(Manager.GetComponent<GameManager>().NombreBoostSpeed);
        }



        /// plus de life
        if (others.gameObject.CompareTag ("PickUpLife")) // detection du power up gold * 2
        {
            others.gameObject.SetActive(false);
            if ( ( vie + 45 ) >= vieMax)
            {
                vie = vieMax;
            }
            else
            {
                vie += 45;
            }

        }


        ///Spawn
        if (others.gameObject.CompareTag ("SpawnPlayer"))  // detection du spawn pour savoir si il a tout recup ( pickup ) et s'il peut changer de lvl
        {
           if ( oil >= 6)
           {
               if ( Manager.GetComponent<GameManager>().levelInGame == 20 ) // il a reussi a passer les 20 lvl
               {
                   WinDuPlayer();
               }
                else
                {
                Debug.Log("Bravo vous avez trouver toute l'essence"); // il a trouvé les 6 oil amsi n'est pas au lvl 20
                StartCoroutine(Transition());
                Manager.GetComponent<GameManager>().levelInGame += 1;
               }
           }
            else // n'a pas trouvé assez de oil
            {
                Debug.Log("Il vous manque de l'essence");
            }
        }
    }


///////////////////////////////////// Lorsque le joueur Gagne /////////////////////////////////////
    public void WinDuPlayer()
    {
        PanelAffichageObject.SetActive(false);
        // remet la vie au max et les balles aussi lors de la fin du jeu en fonction du joueur
        if ( index == 0 )
        {
          vie = vieMax;
          PlayerPrefs.SetInt("VieInGamePlayer", vie);
          munitionInGame = munitionDebutGame;
          PlayerPrefs.SetInt("munitionInGamePlayer", munitionInGame);
        }
        if ( index == 1 )
        {
          vie = vieMax;
          PlayerPrefs.SetInt("VieInGamePlayerGros", vie);
          munitionInGame = munitionDebutGame;
          PlayerPrefs.SetInt("munitionInGamePlayerGros", munitionInGame);
        }

        Manager.GetComponent<GameManager>().MobSpawn = 0;

        //////////// nouveau monde debloqué
        if ( Manager.GetComponent<GameManager>().Monde == 0 )
        {
            Manager.GetComponent<GameManager>().BloqueMonde2 = 1;
            PlayerPrefs.SetInt("BloqueMonde2", Manager.GetComponent<GameManager>().BloqueMonde2);
        }

        TextGoldGagnerWin.text = Manager.GetComponent<GameManager>().GoldInGame + " ";
        Debug.Log("Find du game");
        FindujeuWin.SetActive(true);

        /// power up desactiver
        Manager.GetComponent<GameManager>().GoldX2Active = 0;




        //// Mise à niveau des records
        if ( Manager.GetComponent<GameManager>().Monde == 0 )
        {
            if ( Manager.GetComponent<GameManager>().BestLvlMonde1 < Manager.GetComponent<GameManager>().levelInGame)
            {
                Manager.GetComponent<GameManager>().BestLvlMonde1 = Manager.GetComponent<GameManager>().levelInGame;
                Manager.GetComponent<GameManager>().BestTimeMonde1 = (int)time;
                PlayerPrefs.SetInt("BestLvlMonde1", Manager.GetComponent<GameManager>().BestLvlMonde1);
                PlayerPrefs.SetInt("BestTimeMonde1", Manager.GetComponent<GameManager>().BestTimeMonde1);
            }
            if ( Manager.GetComponent<GameManager>().BestLvlMonde1 == Manager.GetComponent<GameManager>().levelInGame && Manager.GetComponent<GameManager>().BestTimeMonde1 > time)
            {
                Manager.GetComponent<GameManager>().BestTimeMonde1 = (int)time;
                PlayerPrefs.SetInt("BestTimeMonde1", Manager.GetComponent<GameManager>().BestTimeMonde1);
            }


        }


    }

///////////////////////////////////// Lorsque le joueur Meurt /////////////////////////////////////
    public void MortDuPlayer()
    {
        PanelAffichageObject.SetActive(false);
        // remet la vie au max et les balles aussi lors de la fin du jeu en fonction du joueur
        if ( index == 0 )
        {
          vie = vieMax;
          PlayerPrefs.SetInt("VieInGamePlayer", vie);
          munitionInGame = munitionDebutGame;
          PlayerPrefs.SetInt("munitionInGamePlayer", munitionInGame);
        }
        if ( index == 1 )
        {
          vie = vieMax;
          PlayerPrefs.SetInt("VieInGamePlayerGros", vie);
          munitionInGame = munitionDebutGame;
          PlayerPrefs.SetInt("munitionInGamePlayerGros", munitionInGame);
        }

        //// Mise à niveau des records
        if ( Manager.GetComponent<GameManager>().Monde == 0 )
        {
            if ( Manager.GetComponent<GameManager>().BestLvlMonde1 < Manager.GetComponent<GameManager>().levelInGame)
            {
                Manager.GetComponent<GameManager>().BestLvlMonde1 = Manager.GetComponent<GameManager>().levelInGame - 1;
                Manager.GetComponent<GameManager>().BestTimeMonde1 = (int)time;
                PlayerPrefs.SetInt("BestLvlMonde1", Manager.GetComponent<GameManager>().BestLvlMonde1);
                PlayerPrefs.SetInt("BestTimeMonde1", Manager.GetComponent<GameManager>().BestTimeMonde1);
            }
            if ( Manager.GetComponent<GameManager>().BestLvlMonde1 == Manager.GetComponent<GameManager>().levelInGame && Manager.GetComponent<GameManager>().BestTimeMonde1 > time)
            {
                Manager.GetComponent<GameManager>().BestTimeMonde1 = (int)time;
                PlayerPrefs.SetInt("BestTimeMonde1", Manager.GetComponent<GameManager>().BestTimeMonde1);
            }


        }

        // panel de mort
        Manager.GetComponent<GameManager>().MobSpawn = 0;
        TextdeMort.text = "Bravo vous avez parcouru " + Manager.GetComponent<GameManager>().levelInGame + " kilomètres. Mais malheureusement vous êtes mort";
        TextGoldGagnerDefaite.text = Manager.GetComponent<GameManager>().GoldInGame + " ";
        FindujeuDefaite.SetActive(true);

        /// power up desactiver
        Manager.GetComponent<GameManager>().GoldX2Active = 0;





    }


///////////////////////////////////// Lorsque le Joueur a recuperer les 6 oils et change de scene /////////////////////////////////////
    IEnumerator Transition()
    {
      /////permet de stocker la vie et le nombre de balle pdt une game entre les scènes en fonction du joueur
      if ( index == 0 )
      {
        PlayerPrefs.SetInt("VieInGamePlayer", vie);
        PlayerPrefs.SetInt("munitionInGamePlayer", munitionInGame);
      }
      if ( index == 1 )
      {
        PlayerPrefs.SetInt("VieInGamePlayerGros", vie);
        PlayerPrefs.SetInt("munitionInGamePlayerGros", munitionInGame);
      }

        Manager.GetComponent<GameManager>().MobSpawn = 0;
        transitionAnim.SetTrigger("EndRond");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }


///////////////////////////////////// zone de detection /////////////////////////////////////
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }


///////////////////////////////////// Calcul de l'enemy le plus proche  /////////////////////////////////////


    /// d'abord reprend le rang + le rechargementstocker dans l'arme
    void RangeRechargementTarget()
    {
        range = Weapon.GetComponent<WeaponsController>().Range;
        rechargement = Weapon.GetComponent<WeaponsController>().Cadence;
    }

    //// puis on calcul l'enemy le plus proche en fonction de range
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombie");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance )
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if ( nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


///////////////////////////////////// tirer  /////////////////////////////////////

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(Balle, firePoint.position, firePoint.rotation);
        Balle balle = bulletGO.GetComponent<Balle>();

        if( balle != null)
        {
            munitionInGame -= 1;
            TextMunition.text = munitionInGame + " ";
            balle.Seek(target);
        }
    }


//////////////////////////////// PowerUpPanel ///////////////////
    IEnumerator PowerUpPanelActive ()
    {
        NBExtraLife.text = Manager.GetComponent<GameManager>().NombreExtraLife + "";
        NBGoldX2.text = Manager.GetComponent<GameManager>().NombreGoldX2 + "";
        NBBoostDegat.text = Manager.GetComponent<GameManager>().NombreBoostDegat + "";
        NBBoostSpeed.text = Manager.GetComponent<GameManager>().NombreBoostSpeed + "";
        NBSkipLvl.text = Manager.GetComponent<GameManager>().NombreSkiplvl + "";


        PowerUpPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        PowerUpPanel.SetActive(false);
        Manager.GetComponent<GameManager>().FirstGame = 0;

    }


    ///////////// en ce qui concert ls boutons du panel PowerUpPanel
    public void TouchExtraLife ()
    {
        if ( Manager.GetComponent<GameManager>().NombreExtraLife > 0 )
        {
            Manager.GetComponent<GameManager>().ExtraLifeActive = 1;
            Manager.GetComponent<GameManager>().NombreExtraLife -= 1;
            PlayerPrefs.SetInt("ExtraLife", Manager.GetComponent<GameManager>().NombreExtraLife);
            Debug.Log("vous serez regen");
            PowerUpPanel.SetActive(false);
        }
        else
        {
            Debug.Log("dsl mais vous n'en n'avais pas ");
        }
    }
    public void TouchGoldX2 ()
    {
        if ( Manager.GetComponent<GameManager>().NombreGoldX2 < 0 )
        {
            Manager.GetComponent<GameManager>().NombreGoldX2 -= 1;
            Manager.GetComponent<GameManager>().GoldX2Active = 1;
            PlayerPrefs.SetInt("GoldX2", Manager.GetComponent<GameManager>().NombreGoldX2);
            Debug.Log("Gobelin");
            PowerUpPanel.SetActive(false);

            multiplicateurGold = 2;
        }
        else
        {
            Debug.Log("dsl mais vous n'en n'avais pas ");
        }
    }
    public void TouchBoostDegat ()
    {
        if ( Manager.GetComponent<GameManager>().NombreBoostDegat > 0 )
        {
            Manager.GetComponent<GameManager>().NombreBoostDegat -= 1;
            PlayerPrefs.SetInt("BoostDegat", Manager.GetComponent<GameManager>().NombreBoostDegat);
            Debug.Log("Golemmmmme");
            PowerUpPanel.SetActive(false);
        }
        else
        {
            Debug.Log("dsl mais vous n'en n'avais pas ");
        }
    }
    public void TouchBoostSpeed ()
    {
        if ( Manager.GetComponent<GameManager>().NombreBoostSpeed > 0 )
        {
            Manager.GetComponent<GameManager>().NombreBoostSpeed -= 1;
            PlayerPrefs.SetInt("BoostSpeed", Manager.GetComponent<GameManager>().NombreBoostSpeed);
            Debug.Log("faster Faster Faster");
            PowerUpPanel.SetActive(false);
        }
        else
        {
            Debug.Log("dsl mais vous n'en n'avais pas ");
        }
    }
    public void TouchSkiplvl ()
    {
        if ( Manager.GetComponent<GameManager>().NombreSkiplvl > 0 )
        {
            Manager.GetComponent<GameManager>().NombreSkiplvl -= 1;
            PlayerPrefs.SetInt("Skiplvl", Manager.GetComponent<GameManager>().NombreSkiplvl);
            Debug.Log("Skip level Now");
            PowerUpPanel.SetActive(false);
        }
        else
        {
            Debug.Log("dsl mais vous n'en n'avais pas ");
        }
    }

    /// retour au menu après la mort ou la gagne
    public void returnMenu()
		{

				SceneManager.LoadScene("Menu");
				Manager.GetComponent<GameManager>().levelInGame = 1;
        Manager.GetComponent<GameManager>().Gold += Manager.GetComponent<GameManager>().GoldInGame;
				PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
				Manager.GetComponent<GameManager>().GoldInGame = 0;
				Manager.GetComponent<GameManager>().FirstGame = 1; // remettre que la prochaine partie est la premier
				Manager.GetComponent<GameManager>().Play = 0;
		}
}
