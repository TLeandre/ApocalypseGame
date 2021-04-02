using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerPlayerWeapon : MonoBehaviour {

	//// Bouton pour changer de Joueur ///
	public void ChangeJoueur ()
	{
			SceneManager.LoadScene ("Changement de Joueur");
	}
	//// Bouton pour changer d'arme ///
	public void ChangeArme ()
	{
			SceneManager.LoadScene ("Changement d'arme");
	}
}
