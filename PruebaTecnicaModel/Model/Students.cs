using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaModel.Model
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public int PersonId { get; set; }
        public string Matricula { get; set; } = string.Empty;
        public bool Act {  get; set; }
        public DateTime DateCreate  { get; set; }

    }
}
