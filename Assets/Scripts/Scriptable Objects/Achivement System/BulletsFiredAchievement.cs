using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletsFiredAchievement", menuName = "ScriptableObject/Achievement/NewBulletsFiredAchievementSO")]
public class BulletsFiredAchievement : ScriptableObject
{
    // To create number of achievements.
    public AchievementType[] achievements;

    [Serializable]
    public class AchievementType
    {

        public string name;
        public string info;
        public BulletAchievements selectAchievement;
        public int requirement;
    }
}
