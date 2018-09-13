using System;
namespace DFS.Models
{
    public class Coach
    {
        public String Name { get; set; }
        public String Rating { get; set; }
        public String Description { get; set; }
        public String ImageName { get; set; }

        public Coach(String _name, String _rating, String _description, String _imageName)
        {
            Name = _name;
            Rating = _rating;
            Description = _description;
            ImageName = _imageName;
        }
    }
}
