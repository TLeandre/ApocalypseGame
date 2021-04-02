using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour {

		public int Depart;
		public GameObject[] objects;

		private GameObject Manager;


    void Start ()
    {
				Manager = GameObject.Find("GameManager").gameObject;
				/////// pour lancer la premier vague de zombie en fonction de si c'est la firste game ( 0 ou 2 secondes )
        if ( Manager.GetComponent<GameManager>().FirstGame == 1)
        {
            Depart = 2;
        }
        else
        {
            Depart = 0;
        }

				InvokeRepeating("SpawnEnemy", Depart, 3f); // comment dans 2 seconde and se repète tout les 3 secondes
    }

		void SpawnEnemy()
		{
				int randome = Random.Range(0, 6);
				if ( randome == 1 && Manager.GetComponent<GameManager>().MobSpawn <= 5)
				{
						int rand = Random.Range(0, objects.Length);
						Instantiate(objects[rand], transform.position, Quaternion.identity);
						Manager.GetComponent<GameManager>().MobSpawn += 1;
				}
		}

}
