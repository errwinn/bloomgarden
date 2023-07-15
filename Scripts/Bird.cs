using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    AudioSource gagak;
    [SerializeField] Manager manager;
    private void Start()
    {
        gagak = GetComponent<AudioSource>();
    }
    void Update()
    {
        float posY = Random.Range(-4, 10);
        transform.Translate(new Vector2(2f * Time.deltaTime, 0));
        if(transform.position.x > 34f)
        {
            transform.Translate(-72f, posY - transform.position.y, transform.position.z);
        }
        
        if(Mathf.Abs(transform.position.x - manager.playerPositionFromBirdX) < 10 && Mathf.Abs(transform.position.y - manager.playerPositionFromBirdY) < 10)
        {
            gagak.Play();
        }
    }
}
