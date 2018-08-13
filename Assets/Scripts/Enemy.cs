using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private float life = 100f;
    private float dmg = 1.0f;
    public int currentIndexPath = 0;
    public int maxIndexPath = 6;
    public float speed = 10.0f;
    private GameLogic refGL;
	// Use this for initialization
	void Start () {
        refGL = GameObject.Find("Canvas").GetComponent<GameLogic>();

    }
	
	// Update is called once per frame
	void Update () {
        if (currentIndexPath == maxIndexPath)
        {
            if (refGL.hp-1>0)
            {
                refGL.hp--;
                Destroy(gameObject);
            }
            else
            {
                //game over
            }
            return;
        }
            

        var pathNodes = GameObject.Find("PathNodes");
        var targetPoint = pathNodes.transform.GetChild(currentIndexPath).transform.position ;
        targetPoint.y = 0;

        var rot = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5.0f);
        //transform.Translate(new Vector3(1.0, 0.0, 0.0) * Time.deltaTime);
        transform.Translate(new Vector3(0,0,Time.deltaTime * speed));

        if (Vector3.Distance(transform.position, targetPoint) < 0.5)
        {
            currentIndexPath++;
        }
    }
}
