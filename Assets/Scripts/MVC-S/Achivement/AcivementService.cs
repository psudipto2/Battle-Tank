using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcivementService : MonoSingletonGeneric<AcivementService>
{
    public AchivementHolder achivement;
    private AchivementController achivementController;
    private void Start()
    {
        CreateNewAchivement();
    }
    public void CreateNewAchivement()
    {
        AchivementModel model = new AchivementModel(achivement);
        AchivementController controller = new AchivementController(model);
        achivementController = controller;
    }
    public AchivementController GetAchievementController()
    {
        return achivementController;
    }
}
