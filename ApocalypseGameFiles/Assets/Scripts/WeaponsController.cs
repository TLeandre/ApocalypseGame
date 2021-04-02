using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour {

		//// permet de savoir quel gun est actif
		public int index;

		///// stats de Degats
		public int DegatsDefault = 0;
		public int Degats;
		///// stats Cadence
		public int CadenceDefault = 0;
		public int CadenceSave;
		public float Cadence;
		///// stats range
		public int RangeDefault = 0;
		public int RangeSave;
		public float Range;



		void Start ()
		{
				index = PlayerPrefs.GetInt("WeaponSelected");

				if ( index == 0 ) ///////////Revolver
				{
						/// inititalise les stats degats
						if (PlayerPrefs.HasKey("DegatsRevolver"))
	          {
	              Degats = PlayerPrefs.GetInt("DegatsRevolver");
	          }
	          else
	          {
	              Degats = DegatsDefault;
	              PlayerPrefs.SetInt("DegatsRevolver", Degats);
	          }
						// inititalise les stats Cadence
						if (PlayerPrefs.HasKey("CadenceRevolver"))
	          {
	              CadenceSave = PlayerPrefs.GetInt("CadenceRevolver");
	          }
	          else
	          {
	              CadenceSave = CadenceDefault;
	              PlayerPrefs.SetInt("CadenceRevolver", CadenceSave);
	          }
						// inititalise les stats Range
						if (PlayerPrefs.HasKey("RangeRevolver"))
	          {
	              RangeSave = PlayerPrefs.GetInt("RangeRevolver");
	          }
	          else
	          {
	              RangeSave = RangeDefault;
	              PlayerPrefs.SetInt("RangeRevolver", RangeSave);
	          }
				}
				if ( index == 1 ) ///////////GunMoche
				{
						/// inititalise les stats degats
						if (PlayerPrefs.HasKey("DegatsGunMoche"))
	          {
	              Degats = PlayerPrefs.GetInt("DegatsGunMoche");
	          }
	          else
	          {
	              Degats = DegatsDefault;
	              PlayerPrefs.SetInt("DegatsGunMoche", Degats);
	          }
						// inititalise les stats Cadence
						if (PlayerPrefs.HasKey("CadenceGunMoche"))
	          {
	              CadenceSave = PlayerPrefs.GetInt("CadenceGunMoche");
	          }
	          else
	          {
	              CadenceSave = CadenceDefault;
	              PlayerPrefs.SetInt("CadenceGunMoche", CadenceSave);
	          }
						// inititalise les stats Range
						if (PlayerPrefs.HasKey("RangeGunMoche"))
	          {
	              RangeSave = PlayerPrefs.GetInt("RangeGunMoche");
	          }
	          else
	          {
	              RangeSave = RangeDefault;
	              PlayerPrefs.SetInt("RangeGunMoche", RangeSave);
	          }
				}

				Range = RangeSave / 25;
				Cadence = CadenceSave / 25;
				Debug.Log("Degats : " + Degats);
				Debug.Log("Range : " + Range);
				Debug.Log("Cadence : " + Cadence);




		}
}
