using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public double baks;
    public Text bakst;
    public BoxCollider colider;
    public GameObject panelsettings;
    public GameObject panelshop;
    public GameObject buttonshadow;
    public GameObject buttonshop;
    public int language;
    public RectTransform content;
    public AudioSource Tap1;
    public ManegerScript1 ms1;
    public Dropdown ddown;
    public Animator settingsanim, shopanim;
    public bool stb, shb;
    void Start( )
    {        
        ms1 = GetComponent<ManegerScript1>();
        for (int i = 0; i < ms1.panels.Count; i++)
        {
            ms1.panels[i].value = PlayerPrefs.GetInt(i.ToString());
        }
        baks = double.Parse(PlayerPrefs.GetString("baks"));
        language = PlayerPrefs.GetInt("language");
        ddown.value = PlayerPrefs.GetInt("language");
        StartCoroutine(AutoClick());
        System.DateTime datenew = System.DateTime.Now;
        System.DateTime dateold = System.DateTime.Parse(PlayerPrefs.GetString("Date"));
        int cur_time = (int)(datenew - dateold).TotalSeconds;
        for (int i = 0; i < ms1.panels.Count; i++)
        {
            if (ms1.panels[i].autoclick == true)
            {
                baks = baks + ms1.panels[i].value * ms1.panels[i].taps * cur_time;
            }
            }
}
    public void ShopButton() {
        StartCoroutine(ZERO());
        if (shb)
        {
            shopanim.Play("SettingsClosePanel");
        }
        if (!shb)
        {
            shopanim.Play("SettingsOpenPanel");
        }
        shb = !shb;
    }
    public void SettingsButton()
    {
        if (stb)
        {
            settingsanim.Play("SettingsClosePanel");
        }
        if (!stb)
        {
            settingsanim.Play("SettingsOpenPanel");
        }
        stb = !stb;
    }
    public void sadowbutton()
    {
        if (stb)
        {
            settingsanim.Play("SettingsClosePanel");
            stb = !stb;
        }
        if (shb)
        {
            shopanim.Play("SettingsClosePanel");
            shb = !shb;
        }
    }
    void Update()
    {
        if ((stb) || (shb))
        {
            buttonshadow.active = true;
        }
        else { buttonshadow.active = false; }
        bakst.text = "Баксы  =  " + baks;
            if (language == 1)
        {
            if (baks < 999)
            bakst.text = "Баксы: " + baks.ToString("F2");
            if (baks > 999)
            {
                bakst.text = "Баксы: " + (baks / 1000).ToString("F2") + " k";
            }
            if (baks > 999999)
            {
                bakst.text = "Баксы: " + (baks / 1000000).ToString("F2") + " m";
            }
            if (baks > 999999999)
            {
                bakst.text = "Баксы: " + (baks / 1000000000).ToString("F2") + " b";
            }
            if (baks > 999999999999)
            {
                bakst.text = "Баксы: " + (baks / 1000000000000).ToString("F2") + " bk";
            }
        }
            if (language == 0)
        {
            if (baks < 999)
            bakst.text = "Money: " + baks.ToString("F2");
            bakst.text = "Money: " + baks;
            if (baks > 999)
            {
                bakst.text = "Money: " + (baks / 1000).ToString("F1") + " k";
            }
            if (baks > 999999)
            {
                bakst.text = "Money: " + (baks / 1000000).ToString("F1") + " m";
            }
            if (baks > 999999999)
            {
                bakst.text = "Money: " + (baks / 1000000000).ToString("F1") + " b";
            }
            if (baks > 999999999999)
            {
                bakst.text = "Money: " + (baks / 1000000000000).ToString("F1") + " bk";
            }
        }
    }
    public void OnApplicationQuit()
    {
        for (int i = 0; i < ms1.panels.Count; i++)
        {
            PlayerPrefs.SetInt(i.ToString(),ms1.panels[i].value);
        }
        PlayerPrefs.SetInt("language", language);
        PlayerPrefs.SetString("baks", baks.ToString());
        PlayerPrefs.SetString("Date", System.DateTime.Now.ToString());
    }
    public void OnMouseDown()
    {
        baks += 1;
        for (int i = 0; i < ms1.panels.Count; i++)
        {
            if (ms1.panels[i].autoclick == false)
            {
                baks += ms1.panels[i].taps * ms1.panels[i].value;
            }
        }
        Tap1.Play();
    }
    public void OnLanguageChanged(Dropdown dropdown)
    {
        language = dropdown.value;
        Tap1.Play();
    }
    IEnumerator AutoClick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            for (int i = 0; i < ms1.panels.Count; i++)
            {
               if (ms1.panels[i].autoclick == true)
                {
                    baks += ms1.panels[i].taps * ms1.panels[i].value;
                }
            }
        }
    }
    public void ChangeVolume(Slider slider)
    {
       AudioSource[] sounds = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].volume = slider.value;
        }
    }

    public void Exit()
    {
        Application.Quit();
        Tap1.Play();
    }
    IEnumerator ZERO()
    {
        yield return new WaitForSeconds(0.16f);
        content.transform.localPosition = Vector2.zero;
        content.localPosition = Vector2.zero;
    }
}

