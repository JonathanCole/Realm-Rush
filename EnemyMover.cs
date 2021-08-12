using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField][Range(0,5)] float speed = 1f;

    Enemy enemy;

    void Start(){
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath(){
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform){
            Tile point = child.GetComponent<Tile>();
            if(point != null){
                path.Add(point);
            }
        }
    }

    void ReturnToStart(){
        transform.position = path[0].transform.position;
    }

    void FinishPath(){
        enemy.stealGold();
        gameObject.SetActive(false); 
    }

    IEnumerator FollowPath(){
        foreach(Tile point in path){
            Vector3 startPos = transform.position;
            Vector3 endPos = point.transform.position; 
            float travelPercent = 0f;
            transform.LookAt(endPos);
            while(travelPercent < 1f){
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
        }
        FinishPath();
    }

}
