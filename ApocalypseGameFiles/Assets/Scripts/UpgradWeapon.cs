using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradWeapon : MonoBehaviour {

		private GameObject WeaponSelection; // recuperer l'arme selectioné
		private int index;
		private GameObject Manager;

		/// en ce qui concerne les text de caractéristique
		public Text DegatText;
		public Text CadenceText;
		public Text RangeText;
		/// en ce qui concerne le prix
		public Text PriceDegat;
		public Text PriceCadence;
		public Text PriceRange;
		/// en ce qui concerne le lvl des armes
		public int lvlDegat;
		public int lvlCadence;
		public int lvlRange;
		/// pour pouvoir sauvegarder de facons simple
		public int Degat;
		public int Cadence;
		public int Range;
		/// affichage du nombea de gold
		public Text GoldText;

		void Start ()
		{
				WeaponSelection = GameObject.Find("WeaponsList").gameObject;
				Manager = GameObject.Find("GameManager").gameObject;
				InvokeRepeating("ChangementdeUpgrad", 0.1f, 0.5f);
				//InvokeRepeating("GoldUpdate", 0f, 0.5f);
		}

	/*	void GoldUpdate ()
		{
				GoldText.text = "" + Manager.GetComponent<GameManager>().Gold;
		}*/

		void ChangementdeUpgrad ()
		{
				index = WeaponSelection.GetComponent<WeaponSelection>().index;
				GoldText.text = "" + Manager.GetComponent<GameManager>().Gold;

				if ( index == 0 )
				{



						Degat = PlayerPrefs.GetInt("DegatsRevolver");
						Cadence = PlayerPrefs.GetInt("CadenceRevolver");
						Range = PlayerPrefs.GetInt("RangeRevolver");



						if ( PlayerPrefs.HasKey("lvlDegatRevolver") )
						{
								lvlDegat = PlayerPrefs.GetInt("lvlDegatRevolver");
						}
						else
						{
								lvlDegat = 1;
								PlayerPrefs.SetInt("lvlDegatRevolver", lvlDegat);
						}

						if ( PlayerPrefs.HasKey("lvlCadenceRevolver") )
						{
								lvlCadence = PlayerPrefs.GetInt("lvlCadenceRevolver");
						}
						else
						{
								lvlCadence = 1;
								PlayerPrefs.SetInt("lvlCadenceRevolver", lvlCadence);
						}

						if ( PlayerPrefs.HasKey("lvlRangeRevolver") )
						{
								lvlRange = PlayerPrefs.GetInt("lvlRangeRevolver");
						}
						else
						{
								lvlRange = 1;
								PlayerPrefs.SetInt("lvlRangeRevolver", lvlRange);
						}

						////// met à jour les text //////
						DegatText.text = "Degat : " + PlayerPrefs.GetInt("DegatsRevolver");
						CadenceText.text = "Cadence : " + PlayerPrefs.GetInt("CadenceRevolver");
						RangeText.text = "Range : " + PlayerPrefs.GetInt("RangeRevolver");

						PriceDegat.text = "Price :  " + lvlDegat * 50;
						PriceCadence.text = "Price :  " + lvlCadence * 50;
						PriceRange.text = "Price :  " + lvlRange * 50;




				}



				if ( index == 1 )
				{



						Degat = PlayerPrefs.GetInt("DegatsGunMoche");
						Cadence = PlayerPrefs.GetInt("CadenceGunMoche");
						Range = PlayerPrefs.GetInt("RangeGunMoche");



						if ( PlayerPrefs.HasKey("lvlDegatGunMoche") )
						{
								lvlDegat = PlayerPrefs.GetInt("lvlDegatGunMoche");
						}
						else
						{
								lvlDegat = 1;
								PlayerPrefs.SetInt("lvlDegatGunMoche", lvlDegat);
						}

						if ( PlayerPrefs.HasKey("lvlCadenceGunMoche") )
						{
								lvlCadence = PlayerPrefs.GetInt("lvlCadenceGunMoche");
						}
						else
						{
								lvlCadence = 1;
								PlayerPrefs.SetInt("lvlCadenceGunMoche", lvlCadence);
						}

						if ( PlayerPrefs.HasKey("lvlRangeGunMoche") )
						{
								lvlRange = PlayerPrefs.GetInt("lvlRangeGunMoche");
						}
						else
						{
								lvlRange = 1;
								PlayerPrefs.SetInt("lvlRangeGunMoche", lvlRange);
						}

						////// met à jour les text //////
						DegatText.text = "Degat : " + PlayerPrefs.GetInt("DegatsGunMoche");
						CadenceText.text = "Cadence : " + PlayerPrefs.GetInt("CadenceGunMoche");
						RangeText.text = "Range : " + PlayerPrefs.GetInt("RangeGunMoche");

						PriceDegat.text = "Price :  " + lvlDegat * 50;
						PriceCadence.text = "Price :  " + lvlCadence * 50;
						PriceRange.text = "Price :  " + lvlRange * 50;




				}
		}



		public void AdDegat ()
		{

				if ( Manager.GetComponent<GameManager>().Gold >= lvlDegat * 50)
				{
						Manager.GetComponent<GameManager>().Gold -= lvlDegat * 50;
						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
						lvlDegat += 1;
						PriceDegat.text = "Price :  " + lvlDegat * 50;
						Degat += 5;

						if ( index == 1 )
						{
								PlayerPrefs.SetInt("lvlDegatGunMoche", lvlDegat);
								PlayerPrefs.SetInt("DegatsGunMoche", Degat);
								DegatText.text = "Degat : " + PlayerPrefs.GetInt("DegatsGunMoche");
						}
						if ( index == 0 )
						{
								PlayerPrefs.SetInt("lvlDegatRevolver", lvlDegat);
								PlayerPrefs.SetInt("DegatsRevolver", Degat);
								DegatText.text = "Degat : " + PlayerPrefs.GetInt("DegatsRevolver");
						}
				}
				else
				{
						Debug.Log("Pas assez de tune");
				}

		}

		public void AdCadence ()
		{

				if ( Manager.GetComponent<GameManager>().Gold >= lvlCadence * 50)
				{
						Manager.GetComponent<GameManager>().Gold -= lvlCadence * 50;
						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
						lvlCadence += 1;
						PriceCadence.text = "Price :  " + lvlCadence * 50;
						Cadence -= 1;

						if ( index == 1 )
						{
								PlayerPrefs.SetInt("lvlCadenceGunMoche", lvlCadence);
								PlayerPrefs.SetInt("CadenceGunMoche", Cadence);
								CadenceText.text = "Cadence : " + PlayerPrefs.GetInt("CadenceGunMoche");
						}
						if ( index == 0 )
						{
								PlayerPrefs.SetInt("lvlCadenceRevolver", lvlCadence);
								PlayerPrefs.SetInt("CadenceRevolver", Cadence);
								CadenceText.text = "Cadence : " + PlayerPrefs.GetInt("CadenceRevolver");
						}
				}
				else
				{
						Debug.Log("Pas assez de tune");
				}

		}

		public void AdRange ()
		{

				if ( Manager.GetComponent<GameManager>().Gold >= lvlRange * 50)
				{
						Manager.GetComponent<GameManager>().Gold -= lvlRange * 50;
						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
						lvlRange += 1;
						PriceRange.text = "Price :  " + lvlRange * 50;
						Range += 1;

						if ( index == 1 )
						{
								PlayerPrefs.SetInt("lvlRangeGunMoche", lvlRange);
								PlayerPrefs.SetInt("RangeGunMoche", Range);
								RangeText.text = "Range : " + PlayerPrefs.GetInt("RangeGunMoche");
						}
						if ( index == 0 )
						{
								PlayerPrefs.SetInt("lvlRangeRevolver", lvlRange);
								PlayerPrefs.SetInt("RangeRevolver", Range);
								RangeText.text = "Range : " + PlayerPrefs.GetInt("RangeRevolver");
						}
				}
				else
				{
						Debug.Log("Pas assez de tune");
				}

		}

}
