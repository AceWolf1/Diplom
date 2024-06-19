using Diplom.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.ClassHelper
{
    internal class PCClass
    {
        public static DataBase.Entities Context { get; } = new DataBase.Entities();
        public static List <PC> PCClassesList {  get; set; } = new List <PC> ();
    }
}
