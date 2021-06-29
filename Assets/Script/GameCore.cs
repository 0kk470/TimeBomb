using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameCore
{
    public static float OffSetY = 5f;

    public const float MIN_TIMESCALE = 0;

    public const float MAX_TIMESCALE = 2;

    public const float TIMESCALE_STEP = 0.5f;

    private static LevelItem m_CurLevel;

    public static LevelItem CurrentLevel
    {
        get
        {
            if (m_CurLevel == null)
                m_CurLevel = GameObject.FindObjectOfType<LevelItem>();
            return m_CurLevel;
        }
    }

    private static CinemachineVirtualCamera  m_CinemaChineCam;

    public static CinemachineVirtualCamera CinemachineCam
    {
        get
        {
            if (m_CinemaChineCam == null)
                m_CinemaChineCam = GameObject.FindGameObjectWithTag("CinemachineCam")?.GetComponent<CinemachineVirtualCamera>();
            return m_CinemaChineCam;
        }
    }

    public static bool IsLevelUnlock(uint level)
    {
        return PlayerPrefs.GetInt("level" + level, 0) == 1;
    }

    public static void UnLockLevel(uint level)
    {
        PlayerPrefs.SetInt("level" + level, 1);
        PlayerPrefs.Save();
    }
}
