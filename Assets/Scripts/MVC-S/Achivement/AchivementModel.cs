using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementModel 
{
    public BulletsFiredAchievement BulletsFiredAchievement { get; private set; }
    public AchivementModel(AchivementHolder achievements)
    {
        BulletsFiredAchievement = achievements.bulletsFiredAchievementSO;

    }
}
