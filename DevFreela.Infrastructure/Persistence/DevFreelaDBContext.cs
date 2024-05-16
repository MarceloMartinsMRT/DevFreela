using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDBContext
    {
        public DevFreelaDBContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu Projeto ASPNET CORE 1", "Minha descricao 1", 1, 1, 10000),
                new Project("Meu Projeto ASPNET CORE 2", "Minha descricao 2", 1, 1, 23333),
                new Project("Meu Projeto ASPNET CORE 3", "Minha descricao 3", 1, 1, 32300),
            };

            Users = new List<User>
            {
                new User("Marcelo Martins", "marcelomartinsmrt@gmail.com", new DateTime(1989, 8, 6)),
                new User("José Mirosmar", "josemirosmar@decamargoeluciano.com", new DateTime(1995, 1, 1)),
                new User("Roberval Jacinto", "robjac@hotmail.com", new DateTime(1975, 4, 7))
            };

            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
