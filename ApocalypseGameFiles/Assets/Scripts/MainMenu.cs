using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private GameObject Manager;

    public Text TextGoldMenu;
    public Text TextCaisseMenu;

    //////////////////// Opening des Caisses ////////////////////////

    //// Bouton de retour
    public GameObject BPReturn;


    //// gameobject
    public GameObject PanelAnimation;

    public GameObject Caisse;
    public GameObject CaisseGold;

    public GameObject GoldCentral;
    public GameObject GoldX2Central;
    public GameObject ExtraLifeCentral;
    public GameObject BoostDegatCentral;
    public GameObject BoostSpeedCentral;

    public GameObject GoldLeft;
    public GameObject GoldX2Left;
    public GameObject ExtraLifeLeft;
    public GameObject BoostDegatLeft;
    public GameObject BoostSpeedLeft;

    public GameObject GoldRight;
    public GameObject GoldX2Right;
    public GameObject ExtraLifeRight;
    public GameObject BoostDegatRight;
    public GameObject BoostSpeedRight;

    //// animation

    public Animator AnimCaisse;
    public Animator AnimCaisseGold;

    public Animator AnimGoldCentral;
    public Animator AnimGoldX2Central;
    public Animator AnimExtraLifeCentral;
    public Animator AnimBoostDegatCentral;
    public Animator AnimBoostSpeedCentral;

    public Animator AnimGoldLeft;
    public Animator AnimGoldX2Left;
    public Animator AnimExtraLifeLeft;
    public Animator AnimBoostDegatLeft;
    public Animator AnimBoostSpeedLeft;

    public Animator AnimGoldRight;
    public Animator AnimGoldX2Right;
    public Animator AnimExtraLifeRight;
    public Animator AnimBoostDegatRight;
    public Animator AnimBoostSpeedRight;

    //// text

    public Text textCentral;
    public Text textLeft;
    public Text textRight;


    void Start ()
		{
				Manager = GameObject.Find("GameManager").gameObject;
				TextGoldMenu.text = Manager.GetComponent<GameManager>().Gold + " ";
        TextCaisseMenu.text = Manager.GetComponent<GameManager>().CaisseGeneral + " ";

        /// desactive tout
        PanelAnimation.SetActive(false);
        Caisse.SetActive(false);

        CaisseGold.SetActive(false);
        GoldCentral.SetActive(false);
        GoldX2Central.SetActive(false);
        ExtraLifeCentral.SetActive(false);
        BoostDegatCentral.SetActive(false);
        BoostSpeedCentral.SetActive(false);

        GoldLeft.SetActive(false);
        GoldX2Left.SetActive(false);
        ExtraLifeLeft.SetActive(false);
        BoostDegatLeft.SetActive(false);
        BoostSpeedLeft.SetActive(false);

        GoldRight.SetActive(false);
        GoldX2Right.SetActive(false);
        ExtraLifeRight.SetActive(false);
        BoostDegatRight.SetActive(false);
        BoostSpeedRight.SetActive(false);

        textCentral.gameObject.SetActive(false);
        textLeft.gameObject.SetActive(false);
        textRight.gameObject.SetActive(false);

        BPReturn.gameObject.SetActive(false);



		}

    /////////////////// boutons ///////////////////////
    public void PlayGame ()
    {
        SceneManager.LoadScene("MondeSelection");
    }

    public void Upgarde ()
    {
        SceneManager.LoadScene("Inventaire");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void ResetGame ()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Le jeu à bine été reset");
    }

    public void CaisseButton()
    {
        if (Manager.GetComponent<GameManager>().CaisseGeneral > 0)
        {
            StartCoroutine(AnimationCaisseOuverture());
        }
    }

    public void GoldButton ()
    {
        SceneManager.LoadScene("GoldShop");
    }

    public void ReturnMenuBouton ()
    {
        BPReturn.gameObject.SetActive(false);
        textLeft.gameObject.SetActive(false);
        textRight.gameObject.SetActive(false);
        textCentral.gameObject.SetActive(false);
        PanelAnimation.SetActive(false);
        TextGoldMenu.text = Manager.GetComponent<GameManager>().Gold + " ";
        Caisse.SetActive(false);
    }

/////////////////////ANIMATION ///////////////////////
    IEnumerator AnimationCaisseOuverture()
    {
        Manager.GetComponent<GameManager>().CaisseGeneral -= 1;
        PlayerPrefs.SetInt("CaisseGeneral", Manager.GetComponent<GameManager>().CaisseGeneral);
        TextCaisseMenu.text = Manager.GetComponent<GameManager>().CaisseGeneral + " ";

        PanelAnimation.SetActive(true);
        Caisse.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        AnimCaisse.SetTrigger("Go");
        yield return new WaitForSeconds(5.0f);


        //// OPEN LEFT ////
        int randleft = Random.Range(0, 100);

        //GOLD//
        if ( randleft <= 50 )
        {
            //CHOIX NOMBRE GOLD//
            Debug.Log(Manager.GetComponent<GameManager>().Gold);
            int rand2 = Random.Range(50,100);
						Manager.GetComponent<GameManager>().Gold += rand2;
						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
            Debug.Log(Manager.GetComponent<GameManager>().Gold);

            // ANIMATION //
            GoldLeft.SetActive(true);
            AnimGoldLeft.SetTrigger("Go");
            yield return new WaitForSeconds(1.5f);
            textLeft.gameObject.SetActive(true);
            textLeft.text = "+ " + rand2;

        }

        //POWERUP//
        if ( randleft > 50 )
        {
            //CHOX DU POWER UP¨//
            int rand2 = Random.Range(1,4);

            //EXTRALIFE//
            if ( rand2 == 1 )
            {
                //AJOUT DU NOMBRE DE POWERUP//
                Debug.Log(Manager.GetComponent<GameManager>().NombreExtraLife);
                Manager.GetComponent<GameManager>().NombreExtraLife += 1;
                PlayerPrefs.SetInt("ExtraLife", Manager.GetComponent<GameManager>().NombreExtraLife);
                Debug.Log(Manager.GetComponent<GameManager>().NombreExtraLife);

                //ANIMATION//
                ExtraLifeLeft.SetActive(true);
                AnimExtraLifeLeft.SetTrigger("Go");
                yield return new WaitForSeconds(1.5f);
                textLeft.gameObject.SetActive(true);
                textLeft.text = "+ 1";

            }

            //GOLDX2//
            if ( rand2 == 2 )
            {
                //AJOUT DU NOMBRE DE POWERUP//
                Debug.Log(Manager.GetComponent<GameManager>().NombreGoldX2);
                Manager.GetComponent<GameManager>().NombreGoldX2 += 1;
                PlayerPrefs.SetInt("GoldX2", Manager.GetComponent<GameManager>().NombreGoldX2);
                Debug.Log(Manager.GetComponent<GameManager>().NombreGoldX2);

                //ANIMATION//
                GoldX2Left.SetActive(true);
                AnimGoldX2Left.SetTrigger("Go");
                yield return new WaitForSeconds(1.5f);
                textLeft.gameObject.SetActive(true);
                textLeft.text = "+ 1";

            }

            //BOOSTDEGAT//
            if ( rand2 == 3 )
            {
                //AJOUT DU NOMBRE DE POWERUP//
                Debug.Log(Manager.GetComponent<GameManager>().NombreBoostDegat);
                Manager.GetComponent<GameManager>().NombreBoostDegat += 1;
                PlayerPrefs.SetInt("BoostDegat", Manager.GetComponent<GameManager>().NombreBoostDegat);
                Debug.Log(Manager.GetComponent<GameManager>().NombreBoostDegat);

                //ANIMATION//
                BoostDegatLeft.SetActive(true);
                AnimBoostDegatLeft.SetTrigger("Go");
                yield return new WaitForSeconds(1.5f);
                textLeft.gameObject.SetActive(true);
                textLeft.text = "+ 1";

            }

            //BOOSTSPEED//
            if ( rand2 == 4 )
            {
                //AJOUT DU NOMBRE DE POWERUP//
                Debug.Log(Manager.GetComponent<GameManager>().NombreBoostSpeed);
                Manager.GetComponent<GameManager>().NombreBoostSpeed += 1;
                PlayerPrefs.SetInt("BoostSpeed", Manager.GetComponent<GameManager>().NombreBoostSpeed);
                Debug.Log(Manager.GetComponent<GameManager>().NombreBoostSpeed);

                //ANIMATION//
                BoostSpeedLeft.SetActive(true);
                AnimBoostSpeedLeft.SetTrigger("Go");
                yield return new WaitForSeconds(1.5f);
                textLeft.gameObject.SetActive(true);
                textLeft.text = "+ 1";

            }
          }




            yield return new WaitForSeconds(1.2f);
            //// OPEN CENTRAL ////
            int randCentral = Random.Range(0, 100);

            //GOLD//
            if ( randCentral <= 50 )
            {
                //CHOIX NOMBRE GOLD//
                Debug.Log(Manager.GetComponent<GameManager>().Gold);
                int rand3 = Random.Range(50,100);
    						Manager.GetComponent<GameManager>().Gold += rand3;
    						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
                Debug.Log(Manager.GetComponent<GameManager>().Gold);

                // ANIMATION //
                GoldCentral.SetActive(true);
                AnimGoldCentral.SetTrigger("Go");
                yield return new WaitForSeconds(1.5f);
                textCentral.gameObject.SetActive(true);
                textCentral.text = "+ " + rand3;

            }

            //POWERUP//
            if ( randCentral > 50 )
            {
                //CHOX DU POWER UP¨//
                int rand3 = Random.Range(1,4);

                //EXTRALIFE//
                if ( rand3 == 1 )
                {
                    //AJOUT DU NOMBRE DE POWERUP//
                    Debug.Log(Manager.GetComponent<GameManager>().NombreExtraLife);
                    Manager.GetComponent<GameManager>().NombreExtraLife += 1;
                    PlayerPrefs.SetInt("ExtraLife", Manager.GetComponent<GameManager>().NombreExtraLife);
                    Debug.Log(Manager.GetComponent<GameManager>().NombreExtraLife);

                    //ANIMATION//
                    ExtraLifeCentral.SetActive(true);
                    AnimExtraLifeCentral.SetTrigger("Go");
                    yield return new WaitForSeconds(1.5f);
                    textCentral.gameObject.SetActive(true);
                    textCentral.text = "+ 1";

                }

                //GOLDX2//
                if ( rand3 == 2 )
                {
                    //AJOUT DU NOMBRE DE POWERUP//
                    Debug.Log(Manager.GetComponent<GameManager>().NombreGoldX2);
                    Manager.GetComponent<GameManager>().NombreGoldX2 += 1;
                    PlayerPrefs.SetInt("GoldX2", Manager.GetComponent<GameManager>().NombreGoldX2);
                    Debug.Log(Manager.GetComponent<GameManager>().NombreGoldX2);

                    //ANIMATION//
                    GoldX2Central.SetActive(true);
                    AnimGoldX2Central.SetTrigger("Go");
                    yield return new WaitForSeconds(1.5f);
                    textCentral.gameObject.SetActive(true);
                    textCentral.text = "+ 1";

                }

                //BOOSTDEGAT//
                if ( rand3 == 3 )
                {
                    //AJOUT DU NOMBRE DE POWERUP//
                    Debug.Log(Manager.GetComponent<GameManager>().NombreBoostDegat);
                    Manager.GetComponent<GameManager>().NombreBoostDegat += 1;
                    PlayerPrefs.SetInt("BoostDegat", Manager.GetComponent<GameManager>().NombreBoostDegat);
                    Debug.Log(Manager.GetComponent<GameManager>().NombreBoostDegat);

                    //ANIMATION//
                    BoostDegatCentral.SetActive(true);
                    AnimBoostDegatCentral.SetTrigger("Go");
                    yield return new WaitForSeconds(1.5f);
                    textCentral.gameObject.SetActive(true);
                    textCentral.text = "+ 1";

                }

                //BOOSTSPEED//
                if ( rand3 == 4 )
                {
                    //AJOUT DU NOMBRE DE POWERUP//
                    Debug.Log(Manager.GetComponent<GameManager>().NombreBoostSpeed);
                    Manager.GetComponent<GameManager>().NombreBoostSpeed += 1;
                    PlayerPrefs.SetInt("BoostSpeed", Manager.GetComponent<GameManager>().NombreBoostSpeed);
                    Debug.Log(Manager.GetComponent<GameManager>().NombreBoostSpeed);

                    //ANIMATION//
                    BoostSpeedCentral.SetActive(true);
                    AnimBoostSpeedCentral.SetTrigger("Go");
                    yield return new WaitForSeconds(1.5f);
                    textCentral.gameObject.SetActive(true);
                    textCentral.text = "+ 1";

                }
              }





                yield return new WaitForSeconds(1.2f);
                //// OPEN RIGHT ////
                int randRight = Random.Range(0, 100);

                //GOLD//
                if ( randRight <= 50 )
                {
                    //CHOIX NOMBRE GOLD//
                    Debug.Log(Manager.GetComponent<GameManager>().Gold);
                    int rand4 = Random.Range(50,100);
        						Manager.GetComponent<GameManager>().Gold += rand4;
        						PlayerPrefs.SetInt("Gold", Manager.GetComponent<GameManager>().Gold);
                    Debug.Log(Manager.GetComponent<GameManager>().Gold);

                    // ANIMATION //
                    GoldRight.SetActive(true);
                    AnimGoldRight.SetTrigger("Go");
                    yield return new WaitForSeconds(1.5f);
                    textRight.gameObject.SetActive(true);
                    textRight.text = "+ " + rand4;

                }

                //POWERUP//
                if ( randRight > 50 )
                {
                    //CHOX DU POWER UP¨//
                    int rand4 = Random.Range(1,4);

                    //EXTRALIFE//
                    if ( rand4 == 1 )
                    {
                        //AJOUT DU NOMBRE DE POWERUP//
                        Debug.Log(Manager.GetComponent<GameManager>().NombreExtraLife);
                        Manager.GetComponent<GameManager>().NombreExtraLife += 1;
                        PlayerPrefs.SetInt("=ExtraLife", Manager.GetComponent<GameManager>().NombreExtraLife);
                        Debug.Log(Manager.GetComponent<GameManager>().NombreExtraLife);

                        //ANIMATION//
                        ExtraLifeRight.SetActive(true);
                        AnimExtraLifeRight.SetTrigger("Go");
                        yield return new WaitForSeconds(1.5f);
                        textRight.gameObject.SetActive(true);
                        textRight.text = "+ 1";

                    }

                    //GOLDX2//
                    if ( rand4 == 2 )
                    {
                        //AJOUT DU NOMBRE DE POWERUP//
                        Debug.Log(Manager.GetComponent<GameManager>().NombreGoldX2);
                        Manager.GetComponent<GameManager>().NombreGoldX2 += 1;
                        PlayerPrefs.SetInt("GoldX2", Manager.GetComponent<GameManager>().NombreGoldX2);
                        Debug.Log(Manager.GetComponent<GameManager>().NombreGoldX2);

                        //ANIMATION//
                        GoldX2Right.SetActive(true);
                        AnimGoldX2Right.SetTrigger("Go");
                        yield return new WaitForSeconds(1.5f);
                        textRight.gameObject.SetActive(true);
                        textRight.text = "+ 1";

                    }

                    //BOOSTDEGAT//
                    if ( rand4 == 3 )
                    {
                        //AJOUT DU NOMBRE DE POWERUP//
                        Debug.Log(Manager.GetComponent<GameManager>().NombreBoostDegat);
                        Manager.GetComponent<GameManager>().NombreBoostDegat += 1;
                        PlayerPrefs.SetInt("BoostDegat", Manager.GetComponent<GameManager>().NombreBoostDegat);
                        Debug.Log(Manager.GetComponent<GameManager>().NombreBoostDegat);

                        //ANIMATION//
                        BoostDegatRight.SetActive(true);
                        AnimBoostDegatRight.SetTrigger("Go");
                        yield return new WaitForSeconds(1.5f);
                        textRight.gameObject.SetActive(true);
                        textRight.text = "+ 1";

                    }

                    //BOOSTSPEED//
                    if ( rand4 == 4 )
                    {
                        //AJOUT DU NOMBRE DE POWERUP//
                        Debug.Log(Manager.GetComponent<GameManager>().NombreBoostSpeed);
                        Manager.GetComponent<GameManager>().NombreBoostSpeed += 1;
                        PlayerPrefs.SetInt("BoostSpeed", Manager.GetComponent<GameManager>().NombreBoostSpeed);
                        Debug.Log(Manager.GetComponent<GameManager>().NombreBoostSpeed);

                        //ANIMATION//
                        BoostSpeedRight.SetActive(true);
                        AnimBoostSpeedRight.SetTrigger("Go");
                        yield return new WaitForSeconds(1.5f);
                        textRight.gameObject.SetActive(true);
                        textRight.text = "+ 1";

                    }
                  }

        yield return new WaitForSeconds(1.0f);
        BPReturn.gameObject.SetActive(true);



    }

}
