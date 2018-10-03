﻿using System;

namespace DFS
{
    public enum MenuType
    {
        CoachList,
        Logout,
        TraineeProfile
    }
    public class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.TraineeProfile;
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}

