using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KingSnake : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    private List<Transform> segments;
    public Transform segmentPrefab;
    public float obstacleDetectionRadius = 1f;
    public int initialSegmentCount = 0; // Nombre de segments initiaux
    public int compteur=0;
    public int scoreAnnulation = 0;
    public TextMeshProUGUI text_scoreAnnulation;
    public AudioSource audioSource;

    public void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
        
        // Instancier des segments supplémentaires
        for (int i = 0; i < initialSegmentCount; i++)
        {
            Transform segment = Instantiate(segmentPrefab);
            segment.position = transform.position - new Vector3(i + 1, 0, 0);
            segments.Add(segment);
        }
        
        target = GameObject.FindGameObjectWithTag("Food").transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;

        // Move towards the food target
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            if (targetDirection.magnitude > 0.1f)
            {
                direction = targetDirection.normalized;
            }
        }

        // Avoid obstacles
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(transform.position, obstacleDetectionRadius);
        foreach (Collider2D obstacle in obstacles)
        {
            if (obstacle.gameObject.CompareTag("Obstacle"))
            {
                Vector3 avoidDirection = transform.position - obstacle.transform.position;
                direction += avoidDirection.normalized * speed;
            }
        }

        // Move the segments
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        // Move the head
        Vector3 newPosition = transform.position + direction * speed;
        transform.position = newPosition;
        text_scoreAnnulation.text = compteur + " / 3";

        
    }

    private void Grow()
    {
        compteur++;
        if(compteur==3){
            compteur=0;
            scoreAnnulation++;
            Transform segment = Instantiate(segmentPrefab);
            segment.position = segments[segments.Count - 1].position;
            segments.Add(segment);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Food"){
            Grow();
            audioSource.Play();
        }
    }
}