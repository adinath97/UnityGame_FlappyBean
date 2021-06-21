using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GameObject columnPrefab;
    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;
    public static float moveSpeed = .1f;
    public bool rotateUpDown,closeGap,moveUp,startColumnProduction;
    GameObject columnInstance;
    GroundSpawner groundSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = .1f;
        rotateUpDown = true;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if(startColumnProduction) {
            int randX = Random.Range(0,2);
            int randY = Random.Range(0,2);
            if(randX == randY) {
                moveUp = true;
            }
            else {
                moveUp = false;
            }
            columnInstance = Instantiate(columnPrefab,this.transform.GetChild(2).transform.position,Quaternion.identity);
            float y  = Random.Range(-1f,.7f);
            columnInstance.transform.position += new Vector3(0f,y,0f);
            columnInstance.transform.parent = this.gameObject.transform; //make column a child of the parent ground tile
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-moveSpeed * Time.deltaTime * 8f,0,0); //make framerate independent
        if(startColumnProduction) {
            if(columnInstance.transform.position != endPosition.position) {
                columnInstance.transform.position = Vector3.MoveTowards(columnInstance.transform.position,endPosition.position,moveSpeed * Time.deltaTime);
            }
            if(columnInstance.transform.position == endPosition.position) {
                Transform temp = endPosition;
                endPosition = startPosition;
                startPosition = temp;
            }  
        }
        if(bean.playerDead) {
            CancelInvoke("DestroySelf");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !bean.playerDead) {
            groundSpawner.SpawnTile();
            Invoke("DestroySelf",10.0f);
        }
    }

    private void DestroySelf() {
        Destroy(this.gameObject);
    }
}
