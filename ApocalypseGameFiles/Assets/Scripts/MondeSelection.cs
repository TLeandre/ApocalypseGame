using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MondeSelection : MonoBehaviour {

	private GameObject Manager;
	private GameObject[] characterObjectList;
	public int index;
	/// boutons play
	public GameObject ButtonPlay;
	/// panel pour bloqué
	public GameObject PanelBloque;
	/// panel records
	public GameObject PanelRecord;
	public Text MondeRecord;
	public Text TimeRecord;

	private void Awake ()
	{

			Manager = GameObject.Find("GameManager").gameObject;


			Debug.Log(Manager.GetComponent<GameManager>().BestTimeMonde1);
			Debug.Log(Manager.GetComponent<GameManager>().BestLvlMonde1);

			index = PlayerPrefs.GetInt("MondeSelected");

			ButtonPlay.SetActive(true);
			PanelBloque.SetActive(false);

			characterObjectList = new GameObject[transform.childCount];

			for(int i = 0; i < transform.childCount; i++)
			{
					characterObjectList[i] = transform.GetChild(i).gameObject;
			}

			foreach (GameObject go in characterObjectList)
					go.SetActive(false);

					if(characterObjectList[index])
							characterObjectList[index].SetActive(true);


			MAJRecord();

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

			Verification();
			MAJRecord();
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

			Verification();
			MAJRecord();
	}

	public void TouchePlay ()
	{
			PlayerPrefs.SetInt("MondeSelected", index);

			if ( index == 0)
			{
					SceneManager.LoadScene("Monde_1");
					Manager.GetComponent<GameManager>().Play = 1;
					Manager.GetComponent<GameManager>().Monde = 0;
			}
			if (index == 1)
			{
					SceneManager.LoadScene("Monde_2");
					Manager.GetComponent<GameManager>().Play = 1;
					Manager.GetComponent<GameManager>().Monde = 1;
			}
			if (index == 2)
			{
				SceneManager.LoadScene("Monde_3");
				Manager.GetComponent<GameManager>().Play = 1;
				Manager.GetComponent<GameManager>().Monde = 2;
			}

			Manager.GetComponent<GameManager>().TimeStart = Time.time;
	}

	void Verification ()
	{
			if (index == 0)
			{
							ButtonPlay.SetActive(true);
							PanelBloque.SetActive(false);
			}
			if (index == 1)
			{
					if ( Manager.GetComponent<GameManager>().BloqueMonde2 == 0)
					{
							ButtonPlay.SetActive(false);
							PanelBloque.SetActive(true);
					}
			}
	}

	void MAJRecord ()
	{
			if (index == 0)
			{
						PanelRecord.SetActive(true);
						MondeRecord.text = "Monde : " + Manager.GetComponent<GameManager>().BestLvlMonde1 +" / 20";
						TimeRecord.text = "Time : " + string.Format ("{0:0}:{1:00}", Mathf.Floor(Manager.GetComponent<GameManager>().BestTimeMonde1/60), Manager.GetComponent<GameManager>().BestTimeMonde1%60);
			}
			if (index == 1)
			{
					if ( Manager.GetComponent<GameManager>().BloqueMonde2 == 0)
					{
							PanelRecord.SetActive(false);
					}

					MondeRecord.text = "Monde : " + Manager.GetComponent<GameManager>().BestLvlMonde2 +" / 20";
					TimeRecord.text = "Time : " + string.Format ("{0:0}:{1:00}", Mathf.Floor(Manager.GetComponent<GameManager>().BestTimeMonde2/60), Manager.GetComponent<GameManager>().BestTimeMonde2%60);
			}
		}

		public void RetournerAuMenu ()
		{
				SceneManager.LoadScene("Menu");
		}


}
