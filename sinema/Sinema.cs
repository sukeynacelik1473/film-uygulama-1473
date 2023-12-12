using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinema
{
    internal class Sinema
    {

        public int Id { get; set; }
        public string FilmAdi { get; set; }
        public int Sure { get; set; }
        public string Turu{ get; set; }
        public bool Begendi { get; set; }

        public DateTime KayitTarih { get; set; }

        public Sinema(int id, string filmAdi, int sure, string turu, bool begendi, DateTime tarih)
        {
            Id = id;
            FilmAdi = filmAdi;
            Sure = sure;
            Turu = turu;
            Begendi = begendi;

            KayitTarih = tarih;
        }
    }
}
