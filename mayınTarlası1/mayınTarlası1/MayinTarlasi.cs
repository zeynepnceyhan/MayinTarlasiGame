using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mayınTarlası1
{
    class MayinTarlasi
    {
        Size buyukluk_;
        List<Mayin> mayinlar;
        int dolu_mayin_sayisi;
        Random rnd = new Random();
        public MayinTarlasi(Size buyukluk, int mayin_Sayisi)
        {
            mayinlar = new List<Mayin>();
            dolu_mayin_sayisi = mayin_Sayisi;
            buyukluk_ = buyukluk;
            for(int x = 0; x < buyukluk.Width; x = x + 20)
            {
                for(int y = 0; y < buyukluk.Height; y = y + 20)
                {
                    Mayin m = new Mayin(new Point(x, y));
                    Mayin_ekle(m);
                }
            }
            Mayinlari_doldur();
        }
        public void Mayin_ekle(Mayin m)
        {
            mayinlar.Add(m);
        }
        private void Mayinlari_doldur()
        {
            int sayi = 0;
            while(sayi < dolu_mayin_sayisi)
            {
                int i = rnd.Next(0,mayinlar.Count);
                Mayin item = mayinlar[i];
                if(item.mayin_var_mi == false)
                {
                    item.mayin_var_mi = true;
                    sayi++;
                }
            }
        }
        public Size buyuklugu
        {
            get { return buyukluk_; }
        }
        public Mayin mayin_al_loc(Point loc)
        {
            foreach(Mayin item in mayinlar)
            {
                if(item.konum_al == loc)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Mayin> GetAllMayin
        {
            get { return mayinlar; }
        }
    }
}
