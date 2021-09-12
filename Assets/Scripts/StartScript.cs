using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        var player = Instantiate(playerPrefab, new Vector2(-1.58f, -0.578f), Quaternion.identity);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(2.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
