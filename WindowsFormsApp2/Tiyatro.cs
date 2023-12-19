using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Tiyatro
    {
        int id;
        string ad;
        string sahne;
        int sure;
        double fiyat;
        bool muzikal;
        DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Sahne { get => sahne; set => sahne = value; }
        public int Sure { get => sure; set => sure = value; }
        public double Fiyat { get => fiyat; set => fiyat = value; }
        public bool Muzikal { get => muzikal; set => muzikal = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public Tiyatro(int id, string ad, string sahne, int sure, double fiyat, bool muzikal, DateTime tarih)
        {
            this.id = id;
            this.ad = ad;
            this.sahne = sahne;
            this.sure = sure;
            this.fiyat = fiyat;
            this.muzikal = muzikal;
            this.tarih = tarih;
        }
    }
}
