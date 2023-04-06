using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Snake : MonoBehaviour
{
    public KingSnake kingSnake;
    public Vector2 direction = Vector2.right;
    private List<Transform> segments;
    public Transform segmentPrefab;
    public string lastKey ="";
    public float speed = 1f;
    public int score = 0;
    public AudioSource audioSource;

    public void Start(){
        segments = new List<Transform>();
        segments.Add(this.transform);
    
    }

    private void Update(){
        if((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))  && lastKey!="down"){
            direction = Vector2.up;
            lastKey = "up";
        }
        else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && lastKey!="up"){
            direction = Vector2.down;
            lastKey= "down";
        }
        else if((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow)) && lastKey!="right"){
            direction = Vector2.left;
            lastKey= "left";
        }
        else if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && lastKey!="left"){
            direction = Vector2.right;
            lastKey = "right";
        }
    }


    private void FixedUpdate(){

        for (int i = segments.Count - 1; i > 0; i--) {
            segments[i].position = segments[i - 1].position;
        }

        Vector3 newPosition = transform.position + new Vector3(
            direction.x * speed,
            direction.y * speed,
            0.0f
        );
        transform.position = newPosition;
    }

    private void Grow()
    {
        score++;
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void ResetState()
    {
        transform.position = Vector3.zero;
        score=0;
        kingSnake.scoreAnnulation=0;
        kingSnake.compteur=0;

        for (int i = 1; i < segments.Count; i++) {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Food"){
            Grow();
            audioSource.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
            ResetState();
    }
}