using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

		private GameObject[] characterObjectList;
		public int index;
		private GameObject Manager;

		//// si joueur bloquer
		public GameObject PanelUpgrad;
		public GameObject PanelDebloquer;
		public GameObject BoutonConfirm;
		public Text Health;
		public Text Speed;
		public Text Munition;

		private void Awake ()
		{

				Manager = GameObject.Find("GameManager").gameObject;
				PanelDebloquer.SetActive(false);

				index = PlayerPrefs.GetInt("CharacterSelected");

				characterObjectList = new GameObject[transform.childCount];

				for(int i = 0; i < transform.childCount; i++)
				{
						characterObjectList[i] = transform.GetChild(i).gameObject;
				}

				foreach (GameObject go in characterObjectList)
						go.SetActive(false);

						if(characterObjectList[index])
								characterObjectList[index].SetActive(true);
		}
    ///// Touche de Gauche /////
		public void ToucheLeft ()
		{
				// met celui d'avant en desactif
				characterObjectList[index].SetActive(false);

				// change celui qui est present
				index--;
				if (index < 0)
				{
						index = characterObjectList.Length - 1;
				}

				// on l'affiche
				characterObjectList[index].SetActive(true);

				/// verification de si le personnage est Bloque
				Verification();
		}

		///// Touche de Droite /////
		public void ToucheRight ()
		{
				// met celui d'avant en desactif
				characterObjectList[index].SetActive(false);

				// change celui qui est present
				index++;
				if (index == characterObjectList.Length)
				{
						index = 0;
				}

				// on l'affiche
				characterObjectList[index].SetActive(true);

				/// verification de si le personnage est Bloque
				Verification();
		}

		public void ToucheConfirm ()
		{
				PlayerPrefs.SetInt("CharacterSelected", index);
				SceneManager.LoadScene("Inventaire");
		}

		public void continuePlayer ()
		{
					SceneManager.LoadScene("Changement de Joueur");
		}

		public void continueWeapons ()
		{
					SceneManager.LoadScene("Changement d'arme");
		}

		public void Return ()
		{
					SceneManager.LoadScene("Menu");
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
						if ( Manager.GetComponent<GameManager>().BloquePersonnageGros == 0 )
						{
								// faire les texts
								Health.text = "Health : 450";
								Speed.text = "Speed : 45";
								Munition.text = "Munition : 15";
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
								Manager.GetComponent<GameManager>().BloquePersonnageGros = 1;
								PlayerPrefs.SetInt("BloquePersonnageGros", Manager.GetComponent<GameManager>().BloquePersonnageGros);
								Verification();
						}
				}

		}


}
