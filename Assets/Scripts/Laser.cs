using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform LaserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right * -1)) {
            RaycastHit2D _hit = Physics2D.Raycast(LaserFirePoint.position, transform.right * -1);
            Draw2DRay(LaserFirePoint.position, _hit.point);
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
}
