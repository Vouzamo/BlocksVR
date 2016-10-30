using UnityEngine;

public class ScoreCounter : MonoBehaviour {

    public int Score = 0;
    
    void OnCollisionEnter(Collision hit)
    {
        var target = hit.gameObject;

        var points = target.GetComponent<BlockScore>();

        if(points != null)
        {
            Score += points.Score;
            Destroy(points);

            Debug.Log(Score);
        }
    }
}
