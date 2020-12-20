using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lab5.Controllers;

namespace Lab5.Models
{
    public class ProjectModel
    {
        [Key]
        public string name { get; set; }
        public string description { get; set; }
        public string worker { get; set; }

        public ProjectModel()
        {

        }
        public ProjectModel(string name, string description, string worker)
        {
            this.name = name;
            this.description = description;
            this.worker = worker;
        }
        public string ToString(List<ProjectModel> list)
        {
            string message = "";
            for(int i = 0; i < list.Count(); i++)
            {
                message += "";
            }
            return message;
        }
        public void GenerateProjects()
        {
            var projects = new List<ProjectModel>
            {
                new ProjectModel { name = "Boxing Day Sale", description = "Get sale items ready for Boxing day", worker = "Kyle James"},
                new ProjectModel { name = "Different Project", description = "Do Something", worker = "Trevor Lahey"},
                new ProjectModel { name = "Another Different Project", description = "Do Something else that wasn't the previous thing.", worker = "Corey Lahey"}
            };
            HomeController.projectList.AddRange(projects);
        }
    }
}
