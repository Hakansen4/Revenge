using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class charSoulController : MonoBehaviour
{
    public static charSoulController instance;

    private float soulSayisi;
    public TextMeshProUGUI soulText;
    private void Awake()
    {
        instance = this;
        soulSayisi = 0;
        soulText.text = soulSayisi.ToString();
    }
    public void addSoul(float sayi)
    {
        soulSayisi += sayi;
        soulText.text = soulSayisi.ToString();
    }
    public float getSoulCount()
    {
        return soulSayisi;
    }
    public void deleteSouls(int count)
    {
        soulSayisi -= count;
        soulText.text = soulSayisi.ToString();
    }
    public void resetSouls()
    {
        soulSayisi = 0;
        soulText.text = soulSayisi.ToString();
    }
}