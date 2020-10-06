using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawn : MonoBehaviour
{
    public static BossSpawn instance2;

    public GameObject boss;
    public Transform[] spawnPositions;  //spawn할 지점은 몇 군데?

    public GameObject bossHpBar;
    public GameObject bossImage;

    void Awake()
    {
        if (!instance2) instance2 = this;

        bossHpBar.SetActive(false);
        bossImage.SetActive(false);
    }

    public void SpawnMonster()
    {
        //몬스터가 나오는 장소를 랜덤으로 설정
        int spawnIndex = Random.Range(0, spawnPositions.Length);

        //Instantiate 함수를 사용하여 Prefabs폴더에 있는 Rabbit를 생성하여 Scene에 배치
        Instantiate(boss, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);

        bossHpBar.SetActive(true);
        bossImage.SetActive(true);
    }
}
