using System;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private int m_CurrentLevel;
    [SerializeField] private int m_MaxLevel;

    [SerializeField] private int m_CurrentExpereince;
    [SerializeField] private int m_ExperienceCap;

    [SerializeField] private GameObject m_LevelDisplay;

    public Action gunUpgrade;

    public void CollectXP()
    {
        m_CurrentExpereince++;

        if(m_CurrentExpereince >= m_ExperienceCap)
        {
            if(m_CurrentLevel < m_MaxLevel)
            {
                LevelUp();
            }
        }
    }

    private void LevelUp() // pause th game and allow the player to choose their upgrade
    {
        m_LevelDisplay.SetActive(true);
        Time.timeScale = 0;
        m_CurrentExpereince = 0;
        m_ExperienceCap *= 2;
        m_CurrentLevel++;
    }

    public void GunUpgrade()
    {
        Time.timeScale = 1;
        gunUpgrade?.Invoke();
        m_LevelDisplay.SetActive(false);
    }
}
