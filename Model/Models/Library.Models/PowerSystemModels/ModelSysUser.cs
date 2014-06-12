using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.PowerSystemModels
{
    public class ModelSysUser
    {
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "输入错误！")]
        public Int32 Id { get; set; }

        public String Userid { get; set; }

        public String Uname { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "输入错误！")]
        public Int32 OrderAsc { get; set; }

        public String Upassword { get; set; }

        public String Fullname { get; set; }

        public Boolean Ismanage { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "输入错误！")]
        public Int32 Ustate { get; set; }

        public String Email { get; set; }

    }

}
