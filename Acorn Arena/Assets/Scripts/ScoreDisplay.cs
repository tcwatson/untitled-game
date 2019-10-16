using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreLabel;
    void Update()
    {
        Vector2 scorePosition = Camera.main.WorldToScreenPoint(this.transform.position);
        scoreLabel.transform.position = scorePosition;
        scoreLabel.text = gameObject.GetComponentInParent<PlayerController>().numberOfAcorns.ToString();
    }
}
