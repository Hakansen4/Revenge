using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootCreater : MonoBehaviour
{
    [SerializeField] private Enemies enemyType;

    public GameObject loot;
    [HideInInspector]public float soulsSayisi;
    private GameObject lootObject;
    public void createLoot()
    {
        soulsSayisi = enemyType.enemySoulCount;
        lootObject = Instantiate(loot,this.transform.position,Quaternion.identity);
        lootObject.GetComponent<lootController>().soulsSayisi = soulsSayisi;
    }
}
