using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monster;
    public float timeGap = 3f;
    public Transform[] spawnPositions;  //spawn할 지점은 몇 군데?

    void Start()
    {
        //timeGap(3초)만큼 시간이 지난 후 최초로 SpawnMonster 함수를 호출하고
        //시간이 timeGap만큼 지날 떄마다 반복 호출

        InvokeRepeating("SpawnMonster", timeGap, timeGap);
    }

    void SpawnMonster()

    {
        //몬스터가 나오는 장소를 랜덤으로 설정
        int spawnIndex = Random.Range(0, spawnPositions.Length);

        //Instantiate 함수를 사용하여 Prefabs폴더에 있는 Rabbit를 생성하여 Scene에 배치
        Instantiate(monster, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
    }
}
