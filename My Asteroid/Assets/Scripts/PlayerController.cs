using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float thrustSpeed = 5f;

    public GameObject gun = null;
    public GameObject bulletPrefab = null;

    public static int SCORE = 0;
    public Text userName;

    public Vector2 thrustDirection;

    private Rigidbody _rigidbody;

    public GameObject pauseCanvas;
    public GameObject userNameCanvas;

    public List<int> highScoresList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Rotate") * Time.deltaTime * rotationSpeed;
        float thrust = Input.GetAxis("Thrust");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
        }

        thrustDirection = transform.right;

        //this.gameObject.transform
        transform.Rotate(Vector3.forward, -rotation);
        _rigidbody.AddForce(thrustDirection * thrust * thrustSpeed);


        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseCanvas.gameObject.SetActive(true);
            }
            else
            {
                pauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            userNameCanvas.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                highScoresList.Add(SCORE);
                highScoresList.Sort((a, b) => b.CompareTo(a));

                if (highScoresList.Count > 5)
                {
                    highScoresList.RemoveAt(5);
                }

                for (int i = 0; i < highScoresList.Count; i++)
                {
                    PlayerPrefs.SetInt("ScoreEntry" + i, highScoresList[i]);
                }
                PlayerPrefs.Save();
            }

            SCORE = 0;
            userNameCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene("ScoresScene", LoadSceneMode.Single);
        }
    }
}
