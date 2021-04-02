using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradPlayer : MonoBehaviour {

		private GameObject PlayerSelection; // recuperer l'arme selectioné
		private int index;
		private GameObject Manager;

		/// en ce qui concerne les text de caractéristique
		public Text HealthText;
		public Text SpeedText;
		public Text MunitionText;
		/// en ce qui concerne le prix
		public Text PriceHealth;
		public Text PriceSpeed;
		public Text PriceMunition;
		/// en ce qui concerne le lvl des armes
		public int lvlHealth;
		public int lvlSpeed;
		public int lvlMunition;
		/// pour pouvoir sauvegarder de facons simple
		public int Health;
		public int Speed;
		public int Munition;
		//// gold text en temps réel
		public Text GoldText;

		void Start ()
		{
				PlayerSelection = GameObject.Find("CharacterList").gameObject;
				Manager = GameObject.Find("GameManager").gameObject;
				InvokeRepeating("ChangementdeUpgrad", 0.1f, 0.5f);
		}

		void ChangementdeUpgrad ()
		{
				index = PlayerSelection.GetComponent<CharacterSelection>().index;
				GoldText.text = "" + Manager.GetComponent<GameManager>().Gold;

				if ( index == 0 )
				{



						Health = PlayerPrefs.GetInt("VieMaxPlayer");
						Speed = PlayerPrefs.GetInt("SpeedPlayer");
						Munition = PlayerPrefs.GetInt("munitionDebutGamePlayer");



						if ( PlayerPrefs.HasKey("lvlVieMaxPlayer") )
						{
								lvlHealth = PlayerPrefs.GetInt("lvlVieMaxPlayer");
						}
						else
						{
								lvlHealth = 1;
								PlayerPrefs.SetInt("lvlVieMaxPlayer", lvlHealth);
						}

						if ( PlayerPrefs.HasKey("lvlSpeedPlayer") )
						{
								lvlSpeed = PlayerPrefs.GetInt("lvlSpeedPlayer");
						}
						else
						{
								lvlSpeed = 1;
								PlayerPrefs.SetInt("lvlSpeedPlayer", lvlSpeed);
						}

						if ( PlayerPrefs.HasKey("lvlmunitionDebutGamePlayer") )
						{
								lvlMunition = PlayerPrefs.GetInt("lvlmunitionDebutGamePlayer");
						}
						else
						{
								lvlMunition = 1;
								PlayerPrefs.SetInt("lvlmunitionDebutGamePlayer", lvlMunition);
						}

						////// met à jour les text //////
						HealthText.text = "Health : " + PlayerPrefs.GetInt("VieMaxPlayer");
						SpeedText.text = "Speed : " + PlayerPrefs.GetInt("SpeedPlayer");
						MunitionText.text = "Munition : " + PlayerPrefs.GetInt("munitionDebutGamePlayer");

						PriceHealth.text = "Price :  " + lvlHealth * 50;
						PriceSpeed.text = "Price :  " + lvlSpeed * 50;
						PriceMunition.text = "Price :  " + lvlMunition * 50;




				}



				if ( index == 1 )
				{



						Health = PlayerPrefs.GetInt("VieMaxPlayerGros");
						Speed = PlayerPrefs.GetInt("SpeedPlayerGros");
						Munition = PlayerPrefs.GetInt("munitionDebutGamePlayerGros");



						if ( PlayerPrefs.HasKey("lvlVieMaxPlayerGros") )
						{
								lvlHealth = PlayerPrefs.GetInt("lvlVieMaxPlayerGros");
						}
						else
						{
								lvlHealth = 1;
								PlayerPrefs.SetInt("lvlVieMaxPlayerGros", lvlHealth);
						}

						if ( PlayerPrefs.HasKey("lvlSpeedPlayerGros") )
						{
								lvlSpeed = PlayerPrefs.GetInt("lvlSpeedPlayerGros");
						}
						else
						{
								lvlSpeed = 1;
								PlayerPrefs.SetInt("lvlSpeedPlayerGros", lvlSpeed);
						}

						if ( PlayerPrefs.HasKey("lvlmunitionDebutGamePlayerGros") )
						{
								lvlMunition = PlayerPrefs.GetInt("lvlmunitionDebutGamePlayerGros");
						}
						else
						{
								lvlMunition = 1;
								PlayerPrefs.SetInt("lvlmunitionDebutGamePlayerGros", lvlMunition);
						}

						////// met à jour les text //////
						HealthText.text = "Health : " + PlayerPrefs.GetInt("VieMaxPlayerGros");
						SpeedText.text = "Speed : " + PlayerPrefs.GetInt("SpeedPlayerGros");
						MunitionText.text = "Munition : " + PlayerPrefs.GetInt("munitionDebutGamePlayerGros");

						PriceHealth.text = "Price :  " + lvlHealth * 50;
						PriceSpeed.text = "Price :  " + lvlSpeed * 50;
						PriceMunition.text = "Price :  " + lvlMunition * 50;




				}
		}



		public void AdHealth ()
		{

				if ( Manager.GetComponent<GameManager>().Gold >= lvlHealth * 50)
				{
						Manager.GetComponent<GameManager>().Gold -= lvlHealth * 50;
						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
						lvlHealth += 1;
						PriceHealth.text = "Price :  " + lvlHealth * 50;
						Health += 10;

						if ( index == 1 )
						{
								PlayerPrefs.SetInt("lvlVieMaxPlayerGros", lvlHealth);
								PlayerPrefs.SetInt("VieMaxPlayerGros", Health);
								HealthText.text = "Health : " + PlayerPrefs.GetInt("VieMaxPlayerGros");
								/// pour que ca fonctionne dès la premier game
								PlayerPrefs.SetInt("VieInGamePlayerGros", Health);
						}
						if ( index == 0 )
						{
								PlayerPrefs.SetInt("lvlVieMaxPlayer", lvlHealth);
								PlayerPrefs.SetInt("VieMaxPlayer", Health);
								HealthText.text = "Health : " + PlayerPrefs.GetInt("VieMaxPlayer");
								/// pour que ca fonctionne dès la premier game
								PlayerPrefs.SetInt("VieInGamePlayer", Health);
						}
				}
				else
				{
						Debug.Log("Pas assez de tune");
				}

		}

		public void AdSpeed ()
		{

				if ( Manager.GetComponent<GameManager>().Gold >= lvlSpeed * 50)
				{
						Manager.GetComponent<GameManager>().Gold -= lvlSpeed * 50;
						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
						lvlSpeed += 1;
						PriceSpeed.text = "Price :  " + lvlSpeed * 50;
						Speed += 2;

						if ( index == 1 )
						{
								PlayerPrefs.SetInt("lvlSpeedPlayerGros", lvlSpeed);
								PlayerPrefs.SetInt("SpeedPlayerGros", Speed);
								SpeedText.text = "Speed : " + PlayerPrefs.GetInt("SpeedPlayerGros");
						}
						if ( index == 0 )
						{
								PlayerPrefs.SetInt("lvlSpeedPlayer", lvlSpeed);
								PlayerPrefs.SetInt("SpeedPlayer", Speed);
								SpeedText.text = "Speed : " + PlayerPrefs.GetInt("SpeedPlayer");
						}
				}
				else
				{
						Debug.Log("Pas assez de tune");
				}

		}

		public void AdMunition ()
		{

				if ( Manager.GetComponent<GameManager>().Gold >= lvlMunition * 50)
				{
						Manager.GetComponent<GameManager>().Gold -= lvlMunition * 50;
						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
						lvlMunition += 1;
						PriceMunition.text = "Price :  " + lvlMunition * 50;
						Munition += 2;

						if ( index == 1 )
						{
								PlayerPrefs.SetInt("lvlmunitionDebutGamePlayerGros", lvlMunition);
								PlayerPrefs.SetInt("munitionDebutGamePlayerGros", Munition);
								MunitionText.text = "Munition : " + PlayerPrefs.GetInt("munitionDebutGamePlayerGros");
								/// pour que ca fonctionne dès la premier game
								PlayerPrefs.SetInt("munitionInGamePlayerGros", Munition);
						}
						if ( index == 0 )
						{
								PlayerPrefs.SetInt("lvlmunitionDebutGamePlayer", lvlMunition);
								PlayerPrefs.SetInt("munitionDebutGamePlayer", Munition);
								MunitionText.text = "Munition : " + PlayerPrefs.GetInt("munitionDebutGamePlayer");
								/// pour que ca fonctionne dès la premier game
								PlayerPrefs.SetInt("munitionInGamePlayer", Munition);
						}
				}
				else
				{
						Debug.Log("Pas assez de tune");
				}

		}

}
