using System;
using System.Collections.ObjectModel;

namespace DFS
{
    public class CoachList
    {
        public CoachList(){
            
        }
        
        public static ObservableCollection<Models.Coach> GetCoachList(){

            ObservableCollection<Models.Coach> items = new ObservableCollection<Models.Coach>();

            items.Add(new Models.Coach("Jose Inaki", "Cordova, Spain", "Swimming trainer, Aquatic threapy, pool therapy", "profile1.jpeg"));
            items.Add(new Models.Coach("David Spieldmen", "London, England", "Swimmimg trainer, specialist in terapy training, Spritual and Your Guru", "profile2.jpeg"));
            items.Add(new Models.Coach("Sushi", "Texas, USA", "Swimming trainer, Scuba diving", "profile3.jpeg"));
            items.Add(new Models.Coach("Isaias Roble", "Ohio, USA", "Coach. Life Saver", "profile4.jpeg"));
            items.Add(new Models.Coach("Ralph Johnson", "Guadalajara, Mexico", "Personal trainer for the famous. Rising fitness star", "profile5.jpeg"));

            return items;

        }
    }
}
