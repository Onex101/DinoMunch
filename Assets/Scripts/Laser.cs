using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform LaserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    public Text text;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right * -1)) {
            RaycastHit2D _hit = Physics2D.Raycast(LaserFirePoint.position, transform.right * -1);
            Draw2DRay(LaserFirePoint.position, _hit.point);
            Debug.Log(_hit.collider.gameObject.tag);
            Debug.Log(m_lineRenderer.material.name);

            if (_hit.collider.gameObject.tag == "Untagged"){
                text.text = "You were saved, don't question it";
            }   
            else if (_hit.collider.gameObject.tag != "Blue Dino" && m_lineRenderer.material.name == "BlueLaser (Instance)") {
                Debug.Log("Hit!");
                Debug.Log(_hit.collider.gameObject.tag);
                Debug.Log(m_lineRenderer.material.name);
                GameOver();
            } else if (_hit.collider.gameObject.tag != "Green Dino" && m_lineRenderer.material.name == "GreenLaser (Instance)") {
                Debug.Log("Hit!");
                Debug.Log(_hit.collider.gameObject.tag);
                Debug.Log(m_lineRenderer.material.name);
                GameOver();
            }  else if (_hit.collider.gameObject.tag != "Red Dino" && m_lineRenderer.material.name == "RedLaser (Instance)") {
                Debug.Log("Hit!");
                Debug.Log(_hit.collider.gameObject.tag);
                Debug.Log(m_lineRenderer.material.name);
                GameOver();
            }  else if (_hit.collider.gameObject.tag != "Yellow Dino" && m_lineRenderer.material.name == "YellowLaser (Instance)") {
                Debug.Log("Hit!");
                Debug.Log(_hit.collider.gameObject.tag);
                Debug.Log(m_lineRenderer.material.name);
                GameOver();
            }
        } else {
            Draw2DRay(LaserFirePoint.position, (LaserFirePoint.transform.right * -1) * defDistanceRay);
        }

    }

    void Draw2DRay(Vector3 startPos, Vector3 endPos) 
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void GameOver() 
    {
        SceneManager.LoadScene("GameOver");
    }
}
