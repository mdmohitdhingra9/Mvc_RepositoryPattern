using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Architect.Models.Models
{
   public class LogException : Exception
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string UserId { get; set; }

        public string Message { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }

        //[Column(TypeName = "NVarchar(max)")]
        //[DataType(DataType.Text)]
        public string Source { get; set; }
    }
}
