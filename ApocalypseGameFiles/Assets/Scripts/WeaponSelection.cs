using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour {

		private GameObject[] weaponObjectList;
		public int index;

		private GameObject Manager;

		//// si weapon bloquer
		public GameObject PanelUpgrad;
		public GameObject PanelDebloquer;
		public GameObject BoutonConfirm;
		public Text Degat;
		public Text Cadence;
		public Text Range;

		private void Awake ()
		{

				Manager = GameObject.Find("GameManager").gameObject;
				PanelDebloquer.SetActive(false);

				index = PlayerPrefs.GetInt("WeaponSelected");

				weaponObjectList = new GameObject[transform.childCount];

				for(int i = 0; i < transform.childCount; i++)
				{
						weaponObjectList[i] = transform.GetChild(i).gameObject;
				}

				foreach (GameObject go in weaponObjectList)
						go.SetActive(false);

						if(weaponObjectList[index])
								weaponObjectList[index].SetActive(true);
		}
    ///// Touche de Gauche /////
		public void ToucheLeft ()
		{
				// met celui d'avant en desactif
				weaponObjectList[index].SetActive(false);

				// change celui qui est present
				index--;
				if (index < 0)
				{
						index = weaponObjectList.Length - 1;
				}

				// on l'affiche
				weaponObjectList[index].SetActive(true);
				Verification();
		}

		///// Touche de Droite /////
		public void ToucheRight ()
		{
				// met celui d'avant en desactif
				weaponObjectList[index].SetActive(false);

				// change celui qui est present
				index++;
				if (index == weaponObjectList.Length)
				{
						index = 0;
				}

				// on l'affiche
				weaponObjectList[index].SetActive(true);
				Verification();
		}

		public void ToucheConfirm ()
		{
				PlayerPrefs.SetInt("WeaponSelected", index);
				SceneManager.LoadScene("Inventaire");
		}


		void Verification()
		{
				if ( index == 0 )
				{
						PanelUpgrad.SetActive(true);
						PanelDebloquer.SetActive(false);
						BoutonConfirm.SetActive(true);
				}
				if ( index == 1)
				{
						if ( Manager.GetComponent<GameManager>().BloqueWeaponGunMoche == 0 )
						{
								// faire les texts
								Degat.text = "Degat : 450";
								Cadence.text = "Cadence : 45";
								Range.text = "Range : 15";
								PanelUpgrad.SetActive(false);
								PanelDebloquer.SetActive(true);
								BoutonConfirm.SetActive(false);
						}
						else
						{
								PanelUpgrad.SetActive(true);
								PanelDebloquer.SetActive(false);
								BoutonConfirm.SetActive(true);
						}
				}
		}


		public void Achat ()
		{
				if ( index == 1)
				{
						if ( Manager.GetComponent<GameManager>().Gold >= 1000)
						{
								Manager.GetComponent<GameManager>().Gold -= 1000;
								PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
								Manager.GetComponent<GameManager>().BloqueWeaponGunMoche = 1;
								PlayerPrefs.SetInt("BloquePersonnageGros", Manager.GetComponent<GameManager>().BloqueWeaponGunMoche);
								Verification();
						}
				}

		}
}
