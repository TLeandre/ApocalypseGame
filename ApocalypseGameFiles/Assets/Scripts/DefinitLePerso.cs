using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinitLePerso : MonoBehaviour {

		private GameObject[] NombreEmpty;

		void Awake () {

				NombreEmpty = new GameObject[transform.childCount];

				Debug.Log("j'ai trouver " + NombreEmpty.Length + " de empty");
		}
}
