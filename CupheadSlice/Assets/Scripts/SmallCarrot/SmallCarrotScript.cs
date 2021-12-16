using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCarrotScript : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int health = 1;
    public PlayerHealthScript playerHealthScript;
    public Transform lookPoint;

    private void Start()
    {
        playerHealthScript = GameObject.Find("TestPlayer").GetComponent<PlayerHealthScript>();
    }
    void Update()
    {
        //if de state is true doe dan dit:
        //Vector2 testLocation = target.transform.position;
        //testLocation.y = 0;

        Vector3 lookPos = target.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.forward);
        float eulerZ = lookRot.eulerAngles.z;
        Quaternion rotation = Quaternion.Euler(0, 0, eulerZ);
        transform.rotation = rotation;

        //Vector3 targetPosition = new Vector3(this.transform.position.x, this.transform.position.y, target.position.z);
        //this.transform.LookAt(targetPosition);
        //lookPoint.transform.LookAt(target);
        //lookPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //float angle = Mathf.Atan2(testLocation.y, testLocation.x) * Mathf.Rad2Deg;
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealthScript.playerHealth -= 1;
            //Moet de animatie van carrot kapot gaan afspelen.
            Destroy(gameObject);
        }
    }
}
