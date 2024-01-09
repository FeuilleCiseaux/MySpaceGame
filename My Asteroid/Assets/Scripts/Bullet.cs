
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;

    private GameObject scoreText;

    public Vector3 targetVector;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
        scoreText = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * targetVector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            IncreaseScore();
        }

    }

    private void IncreaseScore()
    {
        PlayerController.SCORE++;
        //Debug.Log(message"My score is :" + PlayerController.SCORE++);
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + PlayerController.SCORE;
    }
}
