using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Album
    {
        private string name;
        private DateTime dateRelease;
        private string style;
        private string fileFormat;
        private Artist artist;

        public string Name { get => name; set => name = value; }
        public DateTime DateRelease { get => dateRelease; set => dateRelease = value; }
        public string Style { get => style; set => style = value; }
        public string FileFormat { get => fileFormat; set => fileFormat = value; }

        public Album(string name, DateTime date, string style, string format) {
            this.name = name;
            dateRelease = date;
            this.style = style;
            fileFormat = format;
        }
    }
}
