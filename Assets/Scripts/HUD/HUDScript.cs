using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public static GameObject actualChar;
    public bool activateAllChar;
    public float PanelCloseTime;

    //public AudioSource choiseSound;

    public GameObject[] charList;
    private GameObject _fireButton, _frozenButton, _stormButton, fireParticles, frozenParticles, stormParticles, _enemyBar;
    
    private void Start()
    {
        _fireButton = FindInPanel("Fire");
        _frozenButton = FindInPanel("Frozen");
        _stormButton = FindInPanel("Storm");
        fireParticles = FindInPanel("Fire/Particles");
        frozenParticles = FindInPanel("Frozen/Particles");
        stormParticles = FindInPanel("Storm/Particles");
        _enemyBar = GameObject.Find("Canvas/HUD/EnemyBar");
        _enemyBar.SetActive(false);
        ActivateChar(false, false, false, true);
        if (activateAllChar)
        {
            ActivateChar(true, true, true, true);
            ActivateChar(true, false, false, false);
            actualChar = charList[0];
        }
    }
    private static GameObject FindInPanel(string name)
    {
        return GameObject.Find("Canvas/HUD/Panel/" + name);
    }
    private void ActivateChar(bool fire, bool frozen, bool storm, bool activateButtons)
    {
        if (activateButtons)
        {
            _fireButton.SetActive(fire);
            _frozenButton.SetActive(frozen);
            _stormButton.SetActive(storm);
        }
        fireParticles.SetActive(fire);
        frozenParticles.SetActive(frozen);
        stormParticles.SetActive(storm);
    }
    public void ActiveFire()
    {
        actualChar = charList[0];
        ActivateChar(true, false, false, false);
        //choiseSound.Play();
    }
    public void ActiveFrozen()
    {
        actualChar = charList[1];
        ActivateChar(false, true, false, false);
        //choiseSound.Play();
    }
    public void ActiveStorm()
    {
        actualChar = charList[2];
        ActivateChar(false, false, true, false);
        //choiseSound.Play();
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("OldmanQuest1") == 3)
        {
            ActivateChar(true, false, false, true);
            actualChar = charList[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            ActiveFire();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveFrozen();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveStorm();
            
        }
        if (_enemyBar.activeSelf)
            PanelCloseTime -= Time.deltaTime;
        if (PanelCloseTime < 0 || !_enemyBar.activeSelf)
        {
            _enemyBar.SetActive(false);
            PanelCloseTime = 10;
        }
        
    }
}
