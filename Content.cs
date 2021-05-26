using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoooon22_Program
{
    class Content
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Source { get; set; }
        public string Remarks { get; set; }
    }
}
