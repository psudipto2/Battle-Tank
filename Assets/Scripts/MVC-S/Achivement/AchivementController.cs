using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementController 
{
    public AchivementModel model { get; private set; }
    private int currentBulletFiredAchievement;
    public AchivementController(AchivementModel _model)
    {
        currentBulletFiredAchievement = PlayerPrefs.GetInt("currentBulletFiredAchievement", 0);
        model = _model;
    }
    public void CheckForBulletFiredAchievement()
    {
        for (int i = 0; i < model.BulletsFiredAchievement.achievements.Length; i++)
        {
            if (i != currentBulletFiredAchievement) continue;
            if (TankService.Instance.GetCurrentTankModel().bulletsFired == model.BulletsFiredAchievement.achievements[i].requirement)
            {
                UnlockAchievement(model.BulletsFiredAchievement.achievements[i].name, model.BulletsFiredAchievement.achievements[i].info);
                currentBulletFiredAchievement = i + 1;
                PlayerPrefs.SetInt("currentBulletFiredAchievement", currentBulletFiredAchievement);
            }
            break;
        }
    }
    private void UnlockAchievement(string achievementName, string achievementInfo)
    {
        UIService.Instance.ShowAchievementUnlocked(achievementName, achievementInfo, 3f);
    }
}
