using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Music
    public AudioClip MusicClip;

    public AudioSource MusicSource;

    /// Gold ///
    public int Gold;  // Gold que a le joueur pour utiliser dans le shop ect
    public int GoldInGame; // nombre de gold que gagne le joueur lors q'une game
    /// Level ///
    public int levelInGame; // Nombre de lvl que le joueur passe durant une game
    public int MobSpawn; // gerer le nombre de mob qui spawn dans un monde
    /// caisse ////
    public int CaisseGeneral;
    //// premier game
    public int FirstGame;
    ///// lancement d'une game?
    public int Play;
    public int Monde;
    ///// power Up
    public int NombreExtraLife;
    public int NombreGoldX2;
    public int NombreBoostSpeed;
    public int NombreBoostDegat;
    public int NombreSkiplvl;

    public int ExtraLifeActive;
    public int GoldX2Active;
    public int BoostSpeedActive;
    public int BoostDegatActive;
 //////////////////////////////////////////////////////////////////////
 //////////////// EN CE QUI CONCERNE LE ACTIVE 0 REVOIR EN FONCTION DES BOUTONS
 //////////////////////////////////////////////////////////////////////



 ///////////////// BLOQUAGE ///////////////
    // monde
    public int BloqueMonde2;
    // personnage
    public int BloquePersonnageGros;
    // armes
    public int BloqueWeaponGunMoche;


//////////////// TEMPS //////////////
    public float TimeStart;

///// records ///
// lvl
    public int BestLvlMonde1;
    public int BestLvlMonde2;
// time
    public int BestTimeMonde1;
    public int BestTimeMonde2;


////////// En ce qui concerne l''experience du joueur  /////////
    public int ExpGame;
    public int LevelDuJoueur;
    public int Experience;
    public int PricelvlUp;





	void Start ()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        
        ///reprend toute les données des games précedente soit le gold et le nombre de caisse
        Gold = PlayerPrefs.GetInt("Gold");
        CaisseGeneral = PlayerPrefs.GetInt("CaisseGeneral");
        ///// reprend le nombre de power up que le personnage à gagner
        NombreExtraLife = PlayerPrefs.GetInt("ExtraLife");
        NombreGoldX2 = PlayerPrefs.GetInt("GoldX2");
        NombreBoostSpeed = PlayerPrefs.GetInt("BoostSpeed");
        NombreBoostDegat = PlayerPrefs.GetInt("BoostDegat");
        NombreSkiplvl = PlayerPrefs.GetInt("Skiplvl");
        ///// reprend les mondes/personnage/arme débloquer
        BloqueMonde2 = PlayerPrefs.GetInt("BloqueMonde2");
        BloquePersonnageGros = PlayerPrefs.GetInt("BloquePersonnageGros");
        BloqueWeaponGunMoche = PlayerPrefs.GetInt("BloqueWeaponGunMoche");


        //// reprend touts les records

        // lvl
        BestLvlMonde1 = PlayerPrefs.GetInt("BestLvlMonde1");
        BestLvlMonde2 = PlayerPrefs.GetInt("BestLvlMonde2");
        //time
        BestTimeMonde1 = PlayerPrefs.GetInt("BestTimeMonde1");
        BestTimeMonde2 = PlayerPrefs.GetInt("BestTimeMonde2");


        //// reprend la progression en ce qui concerne les lvl du joueur
        LevelDuJoueur = PlayerPrefs.GetInt("LevelDuJoueur");
        Experience = PlayerPrefs.GetInt("Experience");
        PricelvlUp = PlayerPrefs.GetInt("PricelvlUp");







        Play = 0;
        FirstGame = 1;
        GoldInGame = 0;
        levelInGame = 1;
        Monde = 0;
        MobSpawn = 0;
        ExpGame = 0;
		    DontDestroyOnLoad(gameObject);

	  }



}
