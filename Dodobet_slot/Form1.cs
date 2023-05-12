using System;
using System.CodeDom;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Media;

namespace Dodobet_slot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int uret()//YÜZDELÝK DÝLÝMLERLE SEMBOL TÝPÝ ÜRETÝR
        {
            int[] symbols = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int chance_number = 1, symbol_type = 2; //default deðerlendirilmiþ deðiþkenler
            Random rnd = new Random();
            chance_number = rnd.Next(1, 101);// 1 ile 100 arasýnda rastgele bir sayý oluþturuyoruz.

            if (chance_number <= 20)
            {
                symbol_type = symbols[0];

            }
            else if (chance_number > 20 && chance_number <= 35)
            {
                symbol_type = symbols[1];

            }
            else if (chance_number > 35 && chance_number <= 46)
            {
                symbol_type = symbols[2];

            }
            else if (chance_number > 46 && chance_number <= 58)
            {
                symbol_type = symbols[3];

            }
            else if (chance_number > 58 && chance_number <= 69)
            {
                symbol_type = symbols[4];

            }
            else if (chance_number > 69 && chance_number <= 78)
            {
                symbol_type = symbols[5];

            }
            else if (chance_number > 78 && chance_number <= 85)
            {
                symbol_type = symbols[6];

            }
            else if (chance_number > 85 && chance_number <= 91)
            {
                symbol_type = symbols[7];

            }
            else if (chance_number > 91 && chance_number <= 96)
            {
                symbol_type = symbols[8];

            }
            else if (chance_number > 96 && chance_number <= 96)
            {
                symbol_type = symbols[9];

            }
            else if (chance_number > 96 && chance_number <= 100)
            {
                symbol_type = symbols[10];
            }

            return symbol_type;
        }


        public void cevir()
        {
            //Sembollerimizin gözükeceði pictureBox dizisi oluþturduk ve tanýmladýk
            PictureBox[] pb = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30 };
            //Semboller dizisini tanýmladýk(png resimlerin isimleri numaralandýrýldý)
            string[] symbol_names = { "Kiraz", "Hamburger", "Pizza", "Pasta", "Sushi", "Limon", "Dondurma", "Patates", "Çiçek", "Elmas", "Çarpan" };
            int[] table_content = new int[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //hangi sembollerden kaçtane geldiðini tutan dizi
            //carpan sembollerinin bulunduðu pictureboxlar
            int[] carpan_pb = new int[5] { -1, -1, -1, -1, -1 };
            int i = 0;
            int symbol_type;
            int control = 0;
            int o = 0;
            double takla_kazanci = 0.00;
            label6.Text = takla_kazanci.ToString("0.00") + " $";

            //sembolleri tabloya yerleþtirme 
            for (i = 0; i <= 29; i++)
            {
                symbol_type = uret();

                //tablodaki sembollerin toplam sayýsýný dizinin icerisine atadým
                switch (symbol_type)
                {
                    case 1:
                        table_content[0]++; break;
                    case 2:
                        table_content[1]++; break;
                    case 3:
                        table_content[2]++; break;
                    case 4:
                        table_content[3]++; break;
                    case 5:
                        table_content[4]++; break;
                    case 6:
                        table_content[5]++; break;
                    case 7:
                        table_content[6]++; break;
                    case 8:
                        table_content[7]++; break;
                    case 9:
                        table_content[8]++; break;
                    case 10:
                        table_content[9]++; break;
                    case 11:
                        table_content[10]++; break;
                }

                //dizi içine attým çarpanlarý

                if (symbol_type == 11)
                {
                    carpan_pb[o] = i;
                    //listBox3.Items.Add(carpan_pb[o].ToString());
                    o++;
                }
                pb[i].Image = Image.FromFile("C:\\Users\\smtdo\\source\\repos\\Dodobet_slot\\semboller\\" + symbol_type.ToString() + ".png");
                pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pb[i].Tag = symbol_type.ToString();

                //her satýrda 30 milisaniye bekliyor.
                if (i % 5 == 0)
                {
                    Thread.Sleep(20);
                }
            }
            for (int k = 0; k <= 10; k++)
            {
                if (table_content[k] >= 8)
                {
                    control = 1;
                }
            }





            //ilk çevirmede patlarsa döngüye girer
            while (control > 0)
            {
                control = 0;
                //hangi cisimden kaç tane var listeleme(göster)
                for (i = 0; i <= 10; i++)
                {
                    if (table_content[i] >= 8 && table_content[i] <= 9)
                    {
                        //patlayacak olan cisim
                        listBox1.Items.Add("8-9 adet :" + symbol_names[i]);
                    }
                    else if (table_content[i] >= 10 && table_content[i] <= 11)
                    {
                        //patlayacak olan cisim
                        listBox1.Items.Add("10-11 adet :" + symbol_names[i]);
                    }
                    else if (table_content[i] >= 12 && table_content[i] <= 30)
                    {
                        //patlayacak olan cisim
                        listBox1.Items.Add("12-30 adet :" + symbol_names[i]);
                    }
                    else
                    {
                        //cisim patlamayacak
                    }
                }


                //hangi cisimler 8 ve daha fazla var (bomb_symbols)
                int[] bomb_symbols = new int[11] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                int t = 0;
                int carpan_toplam;
                for (i = 0; i <= 10; i++)
                {
                    if (table_content[i] >= 8 && table_content[i] <= 9)
                    {
                        switch (i)
                        {
                            case 0:
                                takla_kazanci += bet * (0.25);
                                break;
                            case 1:
                                takla_kazanci += bet * (0.4);
                                break;
                            case 2:
                                takla_kazanci += bet * (0.5);
                                break;
                            case 3:
                                takla_kazanci += bet * (0.8);
                                break;
                            case 4:
                                takla_kazanci += bet * (1);
                                break;
                            case 5:
                                takla_kazanci += bet * (1.5);
                                break;
                            case 6:
                                takla_kazanci += bet * (2);
                                break;
                            case 7:
                                takla_kazanci += bet * (2.5);
                                break;
                            case 8:
                                takla_kazanci += bet * (10);
                                break;
                            case 9:
                                //iþlem yok (ayrý deðerlendirilecek)
                                break;
                            case 10:
                                //iþlem yok (ayrý deðerlendirilecek)
                                break;
                        }
                        Thread.Sleep(800);
                        if (table_content[10] > 0)
                        {
                            carpan_toplam = table_content[10] * 2;
                            takla_kazanci = takla_kazanci * carpan_toplam;
                            label6.Text = (takla_kazanci / carpan_toplam).ToString("0.00") + " x " + carpan_toplam.ToString() + " = " + takla_kazanci.ToString("0.00") + " $";
                        }
                        else
                        {
                            carpan_toplam = 1;
                            takla_kazanci = takla_kazanci * carpan_toplam;
                            label6.Text = takla_kazanci.ToString("0.00")+ " $";
                        }
                        credit_t += takla_kazanci;
                        ttk += takla_kazanci;
                        takla_kazanci = 0;
                        label2.Text = credit_t.ToString("0.00") + " $";
                        bomb_symbols[t] = i + 1;
                        t++;
                    }
                    else if (table_content[i] >= 10 && table_content[i] <= 11)
                    {
                        switch (i)
                        {
                            case 0:
                                takla_kazanci += bet * (0.75);
                                break;
                            case 1:
                                takla_kazanci += bet * (0.9);
                                break;
                            case 2:
                                takla_kazanci += bet * (0.1);
                                break;
                            case 3:
                                takla_kazanci += bet * (1.2);
                                break;
                            case 4:
                                takla_kazanci += bet * (1.5);
                                break;
                            case 5:
                                takla_kazanci += bet * (2);
                                break;
                            case 6:
                                takla_kazanci += bet * (5);
                                break;
                            case 7:
                                takla_kazanci += bet * (10);
                                break;
                            case 8:
                                takla_kazanci += bet * (25);
                                break;
                            case 9:
                                //iþlem yok (ayrý deðerlendirilecek)
                                break;
                            case 10:
                                //iþlem yok (ayrý deðerlendirilecek)
                                break;
                        }
                        Thread.Sleep(800);
                        if (table_content[10] > 0)
                        {
                            carpan_toplam = table_content[10] * 2;
                            takla_kazanci = takla_kazanci * carpan_toplam;
                            label6.Text = (takla_kazanci / carpan_toplam).ToString("0.00") + " x " + carpan_toplam.ToString() + " = " + takla_kazanci.ToString("0.00") + " $";
                        }
                        else
                        {
                            carpan_toplam = 1;
                            takla_kazanci = takla_kazanci * carpan_toplam;
                            label6.Text = takla_kazanci.ToString("0.00") + " $";
                        }
                        credit_t += takla_kazanci;
                        ttk += takla_kazanci;
                        takla_kazanci = 0;
                        label2.Text = credit_t.ToString("0.00") + " $";
                        bomb_symbols[t] = i + 1;
                        t++;
                    }
                    else if (table_content[i] >= 12 && table_content[i] <= 30)
                    {
                        switch (i)
                        {
                            case 0:
                                takla_kazanci += bet * (2);
                                break;
                            case 1:
                                takla_kazanci += bet * (4);
                                break;
                            case 2:
                                takla_kazanci += bet * (5);
                                break;
                            case 3:
                                takla_kazanci += bet * (8);
                                break;
                            case 4:
                                takla_kazanci += bet * (10);
                                break;
                            case 5:
                                takla_kazanci += bet * (12);
                                break;
                            case 6:
                                takla_kazanci += bet * (15);
                                break;
                            case 7:
                                takla_kazanci += bet * (25);
                                break;
                            case 8:
                                takla_kazanci += bet * (50);
                                break;
                            case 9:
                                //iþlem yok (ayrý deðerlendirilecek)
                                break;
                            case 10:
                                //iþlem yok (ayrý deðerlendirilecek)
                                break;
                        }
                        Thread.Sleep(800);
                        if (table_content[10] > 0)
                        {

                            carpan_toplam = table_content[10] * 2;
                            takla_kazanci = takla_kazanci * carpan_toplam;
                            label6.Text = (takla_kazanci / carpan_toplam).ToString("0.00") + " x " + carpan_toplam.ToString() + " = " + takla_kazanci.ToString("0.00") + " $";
                        }
                        else
                        {
                            carpan_toplam = 1;
                            takla_kazanci = takla_kazanci * carpan_toplam;
                            label6.Text = takla_kazanci.ToString("0.00") + " $";
                        }
                        credit_t += takla_kazanci;
                        ttk += takla_kazanci;
                        takla_kazanci = 0;
                        label2.Text = credit_t.ToString("0.00") + " $";
                        bomb_symbols[t] = i + 1;
                        t++;
                    }

                }

                Thread.Sleep(1600);
                //8 ve daha fazla olan cisimlerin olduðu pictureboxlara efekt ekleme
                int[] bomb_pb = new int[30] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                for (i = 0; i <= 29; i++)
                {
                    for (int j = 0; j <= 10; j++)
                    {



                        if (pb[i].Tag == bomb_symbols[j].ToString())
                        {

                            if (table_content[10] > 0)
                            {
                                // pb[15].Dispose(); 

                            }


                            pb[i].Image = Image.FromFile("C:\\Users\\smtdo\\source\\repos\\Dodobet_slot\\semboller\\bomb.gif");
                            pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            bomb_pb[i] = i;

                            //Thread.Sleep(1100);
                            //pb[i].Dispose();

                        }


                    }
                }
                Thread.Sleep(1800);

                //carpan sembollerini yýldýrým ile gösterme
                for (int r = 0; r <= 29; r++)
                {
                    for (int z = 0; z <= 4; z++)
                    {
                        if (r == carpan_pb[z])
                        {
                            pb[r].Image = Image.FromFile("C:\\Users\\smtdo\\source\\repos\\Dodobet_slot\\semboller\\carpan.gif");
                            pb[r].SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }

                }
                Thread.Sleep(1800);
                //carpan sembolleri yerine rastgele yenilerinin üretilmesi
                for (i = 0; i <= 29; i++)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        if (i == carpan_pb[j])
                        {
                            symbol_type = uret();
                            pb[i].Image = Image.FromFile("C:\\Users\\smtdo\\source\\repos\\Dodobet_slot\\semboller\\" + symbol_type + ".png");
                            pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            pb[i].Tag = symbol_type.ToString();

                        }
                    }

                }

                //carpan dizisini sýfýrlama
                for (int r = 0; r <= 4; r++)
                {
                    carpan_pb[r] = -1;
                }


                //patlayanlar yerin yeni sembollerin üretilmesi
                for (i = 0; i <= 29; i++)
                {
                    for (int j = 0; j <= 29; j++)
                    {
                        if (bomb_pb[i] == j)
                        {
                            symbol_type = uret();
                            pb[bomb_pb[i]].Image = Image.FromFile("C:\\Users\\smtdo\\source\\repos\\Dodobet_slot\\semboller\\" + symbol_type + ".png");
                            pb[bomb_pb[i]].SizeMode = PictureBoxSizeMode.StretchImage;
                            pb[bomb_pb[i]].Tag = symbol_type.ToString();

                        }
                    }

                }


                //table_content içini boþaltma
                for (i = 0; i <= 10; i++)
                {
                    table_content[i] = 0;
                }


                //son kontrol kýsmý
                int g = 0;
                for (int x = 0; x <= 29; x++)
                {
                    //listBox3.Items.Add(pb[x].Tag);
                    symbol_type = Convert.ToInt16(pb[x].Tag);
                    switch (symbol_type)
                    {
                        case 1:
                            table_content[0]++; break;
                        case 2:
                            table_content[1]++; break;
                        case 3:
                            table_content[2]++; break;
                        case 4:
                            table_content[3]++; break;
                        case 5:
                            table_content[4]++; break;
                        case 6:
                            table_content[5]++; break;
                        case 7:
                            table_content[6]++; break;
                        case 8:
                            table_content[7]++; break;
                        case 9:
                            table_content[8]++; break;
                        case 10:
                            table_content[9]++; break;
                        case 11:
                            table_content[10]++;
                            carpan_pb[g] = x;
                            g++;

                            break;
                    }

                }
                //listBox3.Items.Clear();
                for (i = 0; i <= 4; i++)
                {
                    //listBox3.Items.Add(carpan_pb[i].ToString());
                }


                for (int k = 0; k <= 10; k++)
                {
                    if (table_content[k] >= 8)
                    {
                        control++;
                    }

                }

                if (control > 0)
                {
                    control = 1;
                }
                else
                {
                    control = 0;
                }


            }

            label6.Text = ttk.ToString("0.00") + " $";
            button1.Enabled = true;
        }//SLOT MAKÝNESÝNÝ ÇEVÝRÝR

        public double credit_t = 0.00;//bakiye
        public double ttk = 0.00; //toplam müþteri tur kazanç
        public double bet = 0.00;
        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                button3.Text = "^";
                panel1.Visible = false;
            }
            else
            {
                button3.Text = "v";
                panel1.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //bahis arttýrma iþlemi
            if (textBox1.Text != "")
            {
                double artis_miktari = Convert.ToDouble(textBox1.Text);
                if (credit_t > 1)
                {
                    bet += artis_miktari;
                    if (bet > credit_t)
                    {
                        MessageBox.Show("Yeterli miktarda bakiyeniz bulunmamaktadýr. bahsinizi daha fazla arttýramazsýnýz !");
                    }
                    else
                    {
                        label4.Text = bet.ToString("0.00") + " $";
                    }
                }
                else
                {
                    MessageBox.Show("Bakiyeniz Bahis yatýrmak için yeterli deðildir lütfen yükleme yapýnýz");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Lütfen Artýþ miktarýný giriniz");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Bahis azaltma iþlemi
            double azalis_miktari = Convert.ToDouble(textBox1.Text);
            if (textBox1.Text != "")
            {
                if (bet <= 0)
                {
                    MessageBox.Show("Bahsinizi daha fazla azaltamazsýnýz");
                }
                else
                {
                    bet -= azalis_miktari;
                    label4.Text = bet.ToString("0.00") + " $";

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //bakiye yükleme iþlemi
            string credits;
            double credit = 0.00;
            int control = 0;
            while (control < 1)
            {

                credits = Interaction.InputBox("Yüklemek istediðiniz Bakiyeyi yazýnýz(min :10$) :", "Bakiye Yükleme Penceresi", "1000", 500, 300);

                if (credits != "")
                {
                    credit = Convert.ToDouble(credits);


                    if (credit >= 10)
                    {
                        credit_t += credit;
                        MessageBox.Show("Bakiye Yüklemesi Baþarýlý  Bol Kazançlar");
                        label2.Text = credit_t.ToString("0.00") + " $";
                        control = 1;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen 10 Dolar veya daha fazla bir tutar giriniz");
                    }

                }
                else
                {
                    MessageBox.Show("Bakiye yüklemesi yapmadýnýz tekrar deneyin");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //çevirme butonu
            ttk = 0;
            if (bet <= 0.00 || credit_t < bet)
            {

                MessageBox.Show("Lütfen bakiye veya bahis yüklemesi yapýnýz :)");
            }
            else
            {

                credit_t -= bet;
                label2.Text = credit_t.ToString("0.00") + " $";
                listBox1.Items.Clear();
                //listBox3.Items.Clear();
                Thread th = new Thread(cevir);
                th.Start();
                button1.Enabled = false;
            }

        }
    }
}