using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Artist
    {
        private string name;
        private DateTime birthday;

        public string Name { get => name; set => name = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }

        public Artist(string name, DateTime birthday) {
            this.name = name;
            this.birthday = birthday;
        }
    }
}
