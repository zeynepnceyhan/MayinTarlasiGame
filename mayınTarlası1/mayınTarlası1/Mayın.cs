using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace mayınTarlası1
{
    public class Mayin
    {
        Point loc;
        bool dolu;
        bool bakildi;
        public Mayin(Point loca)
        {
            dolu = false;
            loc = loca;
        }
        public Point konum_al
        {
            get { return loc; }
        }
        public bool mayin_var_mi
        {
            get { return dolu; }
            set { dolu = value; }
        }
        public bool bakildi_
        {
            get { return bakildi; }
            set { bakildi = value; }
        }
    }
}
