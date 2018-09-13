using System;

namespace DFS
{
    public enum MenuType
    {
        CoachList,
        Logout
    }
    public class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.CoachList;
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}

