using DG.Tweening;
using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_Rb2D;

    [SerializeField]
    [Range(0,100)]
    private float m_FlySpeed = 5f;

    private Tween m_RotateTwn;

    // Use this for initialization
    void Start()
    {
        m_RotateTwn = transform.DOLocalRotate(Vector3.back * 359.9f, 2,RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        m_RotateTwn?.Kill();
    }

    // Update is called once per frame
    void Update()
    {
        m_Rb2D.MovePosition(transform.position + Time.deltaTime * m_FlySpeed * Vector3.right);
    }
}