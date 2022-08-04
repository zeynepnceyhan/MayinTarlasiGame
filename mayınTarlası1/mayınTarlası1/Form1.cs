namespace mayınTarlası1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MayinTarlasi mayin_tarlamiz;
        Image mayin_Resmi = Image.FromFile(@"pngwing.png");
        List<Mayin> mayinlarimiz;

        private void panel1_Paint(object sender, EventArgs e)
        {
            
            
        }
        public void Mayin_ekle()
        {
            for (int x = 0; x < panel1.Width; x = x + 20)
            {
                for (int y = 0; y < panel1.Height; y = y + 20)
                {
                    Button_ekle(new Point(x, y));
                }
            }
        }
        public void Button_ekle(Point loc)
        {
            Button btn = new Button();
            btn.Name =  loc.X + ""+ loc.Y;
            btn.Size = new Size(20, 20);
            btn.Location = loc;
            btn.Click += new EventHandler(btn_Click);
            panel1.Controls.Add(btn);
        }
        public void btn_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            Mayin myn = mayin_tarlamiz.mayin_al_loc(btn.Location);
            mayinlarimiz = new List<Mayin>();
            if (myn.mayin_var_mi)
            {
                MessageBox.Show("Kaybettin!");
                Mayinlari_goster();
            }
            else
            {
                int s = etrafta_kac_mayin_var(myn);
                if (s == 0)
                {
                    mayinlarimiz.Add(myn);
                    for(int i = 0; i < mayinlarimiz.Count; i++)
                    {
                        Mayin item = mayinlarimiz[i];
                        if (item != null) {
                            if (item.bakildi_== false&&item.mayin_var_mi==false) { 
                                Button btnx = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0];
                                if (etrafta_kac_mayin_var(mayinlarimiz[i]) == 0)
                                {
                                
                                    btnx.Enabled = false;
                                    item.bakildi_ = true;
                                    cevresindekileri_ekle(item);
                                }
                                else
                                {
                                    btnx.Text = etrafta_kac_mayin_var(item).ToString();
                                
                                }
                                item.bakildi_ = false;
                            }
                        }
                    }
                }
                else
                {
                    btn.Text = s.ToString();
                }
            }
        }
        public int etrafta_kac_mayin_var(Mayin m)
        {
            int sayi = 0;
            if(m.konum_al.X > 0) 
            { 
                if(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X-20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if(m.konum_al.Y < panel1.Height-20&& m.konum_al.X <panel1.Width-20) 
            { 
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y+20)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if (m.konum_al.X < panel1.Width-20) 
            { 
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if (m.konum_al.X > 0 && m.konum_al.Y>0 ) 
            { 
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X-20, m.konum_al.Y-20)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if (m.konum_al.Y > 0) 
            { 
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X , m.konum_al.Y-20)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if (m.konum_al.X > 0 && m.konum_al.Y < panel1.Height-20) 
            { 
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y+20)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if (m.konum_al.Y < panel1.Height-20) 
            { 
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X , m.konum_al.Y+20)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if (m.konum_al.X > panel1.Width-20&& m.konum_al.Y > 0) 
            { 
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y-20)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            return sayi;
        }
        public void cevresindekileri_ekle(Mayin m)
        {
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            if(m.konum_al.X > 0)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y)));
                b1 = true;
            }
            if (m.konum_al.Y > 0)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y-20)));
                b2 = true;
            }
            if (m.konum_al.X < panel1.Width)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X+20, m.konum_al.Y)));
                b3 = true;
            }
            if (m.konum_al.Y < panel1.Height)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y+20)));
                b4 = true;
            }
            if(b1 && b2)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y - 20)));
            }
            if (b1 && b4)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y + 20)));
            }
            if (b2 && b3)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y - 20)));
            }
            if (b2 && b4)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y + 20)));
            }
        }
        public void Mayinlari_goster()
        {
            foreach(Mayin item in mayin_tarlamiz.GetAllMayin)
            {
                if (item.mayin_var_mi)
                {
                    Button btn = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0];
                    btn.BackgroundImage = mayin_Resmi;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mayin_tarlamiz = new MayinTarlasi(new Size(400, 400), 60);
            panel1.Size = mayin_tarlamiz.buyuklugu;
            Mayin_ekle();
        }
    }
}