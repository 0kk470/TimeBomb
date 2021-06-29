using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player m_Player;

    private void Awake()
    {
        m_Player = GetComponent<Player>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameCore.CurrentLevel.SwapTime(m_Player);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameCore.CurrentLevel.TimeScale -= GameCore.TIMESCALE_STEP;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameCore.CurrentLevel.TimeScale += GameCore.TIMESCALE_STEP;
        }
    }
}