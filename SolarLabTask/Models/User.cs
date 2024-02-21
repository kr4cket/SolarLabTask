using Microsoft.EntityFrameworkCore;
using System;

namespace SolarLabTask.Models
{
    [Index(nameof(Login), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }

        public List<Person>? PersonList { get; set; }
    }
}
