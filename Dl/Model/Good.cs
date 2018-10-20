using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dl.Model
{
    [Table("tblGood")]
    public class Good
    {
        [Key]
        public int Id { get; set; }

        //[Required, StringLength(maximumLength: 50)]
        public string Group { get; set; }

        //[Required, StringLength(maximumLength: 50)]
        public string Firm { get; set; }


        //[Required, StringLength(maximumLength: 50)]
        public string Model { get; set; }

        //[Required, StringLength(maximumLength: 50)]
        public string TehnicalInfo { get; set; }

        //[Required, Range(0, 100000)]
        public int Price { get; set; }

        //[Required, Range(0, 100000)]
        public int Count { get; set; }

       // [Required, Range(0, 36)]
        public int Warranty { get; set; }

        //[Required, StringLength(maximumLength: 50)]
        public string Status { get; set; }

       // [DataType(DataType.Date)]
        public DateTime DateReception { get; set; }


    }
}
