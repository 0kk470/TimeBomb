
using System.Collections;
using UnityEngine;

public enum LevelState
{
    Now,
    Future,
}

public class LevelItem:MonoBehaviour
{

    private LevelState m_CurState;

    [SerializeField]
    private float m_OffsetY;

    [SerializeField]
    [Range(0, 2)]
    private float m_TimeScale = 1f;

    public float TimeScale
    {
        get
        {
            return m_TimeScale;
        }
        set
        {
            m_TimeScale = Mathf.Clamp(value,0, 2);
            Time.timeScale = m_TimeScale;
        }
    }

    [SerializeField]
    private Transform NowLevelRoot;

    [SerializeField]
    private Transform FutureLevelRoot;


    public void SwapTime(Player player)
    {
        var cam = GameCore.CinemachineCam;
        if (cam != null)
        {
            cam.Follow = null;
            cam.PreviousStateIsValid = false;
        }
        if(m_CurState == LevelState.Future)
        {
            player.transform.position += Vector3.down * m_OffsetY;
            m_CurState = m_CurState - 1;
        }
        else
        {
            player.transform.position += Vector3.up * m_OffsetY;
            m_CurState = m_CurState + 1;
        }
        if (cam != null)
        {
            cam.Follow = player.transform;
            StartCoroutine(DelaySetCamPos());
        }
    }

    private IEnumerator DelaySetCamPos()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        var cam = GameCore.CinemachineCam;
        if (cam != null)
        {
            cam.PreviousStateIsValid = true;
        }
    }


    public void LevelComplete(Player player)
    {
        if(player == null)
        {
            Debug.LogError("No Player");
            return;
        }
        player.StopMove();
    }

}
