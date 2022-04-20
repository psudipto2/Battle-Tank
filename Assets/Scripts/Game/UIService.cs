using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIService : MonoSingletonGeneric<UIService>
{
    public TextMeshProUGUI AchivementNameText;
    public TextMeshProUGUI AchievementInfoText;
    public async void ShowAchievementUnlocked(string name, string achievementInfo, float timeForPopUp)
    {
        AchivementNameText.text = "Achievement Unlocked!\n";
        AchievementInfoText.text = achievementInfo;
        AchivementNameText.text = AchivementNameText.text + name;
    }
}
