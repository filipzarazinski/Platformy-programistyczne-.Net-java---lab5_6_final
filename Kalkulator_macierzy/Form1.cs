using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalkulator_macierzy;

namespace Kalkulator_macierzy
{
    public partial class Form1 : Form
    {

        int x, y;
        int[,] Macierz1;
        int[,] Macierz2;
        int[,] Macierz3;
        int flag = 0;


        
            

        public Form1()
        {
            InitializeComponent();
        }



        public void Test_4_watki_Click(object sender, EventArgs e)
        {
            int n = 4;
            int wiersze = Macierz1.GetLength(0);
            
            int pomoc;
            



            if (wiersze%4 == 0 || wiersze < n)
            {  
                pomoc = wiersze/n;
            } else if (wiersze / n == 1 || wiersze / n == 2)
            {
                pomoc = (wiersze/n);
            } else
            { pomoc = (wiersze / n) + 1; }

      
            Thread[] threads = new Thread[n];
            
            
          

                
                
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            if (wiersze < 4)
            {
                textBox11.Text = String.Empty;
                textBox11.Text += "Dziala tylko dla: liczba wierszy Macierzy1 > 4";
            }
            else if (Macierz1.GetLength(1) != Macierz2.GetLength(0))
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Nieprawidłowe wymiary tablic!";


            }
            else
            {
                textBox11.Text = String.Empty;
                textBox11.Text += Environment.NewLine + "Licze...";
                for (int i = 0; i < n; i++)
                {
                    if (i == 0) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, 0, pomoc)); }
                    else if (i == 1) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc, pomoc * 2)); }
                    else if (i == 2) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc * 2, pomoc * 3)); }
                    else if (i == 3) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc * 3, wiersze)); }


                }

                for (int i = 0; i < n; i++)
                {
                    threads[i].Start();

                }

                for (int i = 0; i < n; i++)
                {
                    threads[i].Join();

                }
            
            watch2.Stop();

            textBox11.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox2.Text += watch2.ElapsedMilliseconds + "ms";
            }


        }

        public void generuj_tablice_Click(object sender, EventArgs e)
        {
           

            if (textBox7.Text == String.Empty || textBox8.Text == String.Empty || textBox9.Text == String.Empty || textBox10.Text == String.Empty)
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Musisz podac wszystkie wymiary!!!";
                
            } else if(textBox7.Text == "0" || textBox8.Text == "0" || textBox9.Text == "0" || textBox10.Text == "0")
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Rozmiar wierszu i kolumn musi byc > 0!!!";
            }
            else if(int.Parse(textBox7.Text) < 0 || int.Parse(textBox8.Text) < 0 || int.Parse(textBox9.Text) < 0 || int.Parse(textBox10.Text) < 0)
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Wymiary nie mogą być ujemne!!!";
            }
            else
            {
                textBox11.Text = String.Empty;
            x = int.Parse(textBox7.Text);
            y = int.Parse(textBox8.Text);
            Macierz1 = new int[x, y];
            x = int.Parse(textBox10.Text);
            y = int.Parse(textBox9.Text);
            Macierz2 = new int[x, y];
            Macierz3 = new int[Macierz1.GetLength(0), Macierz2.GetLength(1)];
            

                Generuj_macierz(Macierz1, 1);
                Generuj_macierz(Macierz2, 2);

                flag = 1;
            }

        }

        public void Test_bez_watkow_Click(object sender, EventArgs e)
        {

           

            if (Macierz1.GetLength(1) != Macierz2.GetLength(0))
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Nieprawidłowe wymiary tablic!";
            }
            else
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
               
                    textBox11.Text = String.Empty;
                    textBox11.Text += Environment.NewLine + "Licze...";
          
                 MnozenieMacierzy(Macierz1, Macierz2, Macierz3); 
               
              // MnozenieMacierzy_2(Macierz1,Macierz2,Macierz3,0,Macierz1.GetLength(0));
                watch.Stop();

                textBox3.Text = String.Empty;
                textBox3.Text += watch.ElapsedMilliseconds + "ms";
                
                    textBox11.Text = String.Empty;
                
            }
        }

        public void Test_8_watkow_Click(object sender, EventArgs e)
        {
            int n = 8;
            Thread[] threads = new Thread[n];

            int wiersze = Macierz1.GetLength(0);
            int pomoc;

           
               pomoc = wiersze / n;
            
            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            


            if (wiersze < 8)
            {
                textBox11.Text = String.Empty;
                textBox11.Text += "Dziala tylko dla: liczba wierszy Macierzy1 > 8";

            }
            else if (Macierz1.GetLength(1) != Macierz2.GetLength(0))
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Nieprawidłowe wymiary tablic!";


            }else
            {
                textBox11.Text = String.Empty;
                textBox11.Text += Environment.NewLine + "Licze...";
                for (int i = 0; i < n; i++)
                {

                    if (i == 0) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, 0, pomoc)); }
                    else if (i == 1) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc, pomoc*2)); }
                    else if (i == 2) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc*2, pomoc*3)); }
                    else if (i == 3) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc*3, pomoc*4)); }
                    else if (i == 4) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc * 4, pomoc*5)); }
                    else if (i == 5) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc * 5, pomoc * 6)); }
                    else if (i == 6) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc * 6, pomoc * 7)); }
                    else if (i == 7) { threads[i] = new Thread(() => MnozenieMacierzy_2(Macierz1, Macierz2, Macierz3, pomoc * 7, wiersze)); }


                }

            
            for (int i = 0; i < n; i++)
            {
                threads[i].Start();

            }

            for (int i = 0; i < n; i++)
            {
                threads[i].Join();

            }

            watch3.Stop();
            textBox11.Text = String.Empty;
                textBox1.Text = String.Empty;
                textBox1.Text += watch3.ElapsedMilliseconds + "ms";
            }


        }

        public void wypisz_macierz1_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                Wypisz_macierz(Macierz1, 1);
            }
            else textBox11.Text = "Najpierw wygeneruj macierze!";
        }

       
        private void button6_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                Wypisz_macierz(Macierz2, 2);
            }
            else textBox11.Text = "Najpierw wygeneruj macierze!";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                Wypisz_macierz(Macierz3, 3);
            }
            else textBox11.Text = "Najpierw wygeneruj macierze!";
        }


        public void Wypisz_macierz(int[,] tab,int n)
        {
            if (n == 1)
            {
                textBox6.Text = String.Empty;
            }
            else if (n == 2)
            {
                textBox5.Text = String.Empty;
            }
            else if (n == 3)
            {
                textBox4.Text = String.Empty;
            }
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (n == 1)
                    {
                        textBox6.Text += tab[i, j] + " ";
                    } else if (n == 2)
                    {
                        textBox5.Text += tab[i, j] + " ";
                    }
                    else if (n == 3)
                    {
                        textBox4.Text += tab[i, j] + " ";
                    }

                }
                if (n == 1)
                {
                    textBox6.Text += Environment.NewLine;
                }
                else if (n == 2)
                {
                    textBox5.Text += Environment.NewLine;
                }
                else if (n == 3)
                {
                    textBox4.Text += Environment.NewLine;
                }
            }
        }

        public void Generuj_macierz(int[,] tab, int seed)
        {
            Random generator = new Random(seed);
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    tab[i, j] = generator.Next(0, 10);

                }
            }
        }

        public void MnozenieMacierzy(int[,] tab1, int[,] tab2, int[,] tab3)
        {
            int sum = 0;


            if (tab1.GetLength(1) != tab2.GetLength(0))
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Nieprawidłowe wymiary tablic!";


            }
            else
            {
                for (int i = 0; i < tab1.GetLength(0); i++)
                    for (int j = 0; j < tab2.GetLength(1); j++)
                        tab3[i, j] = 0;
                for (int i = 0; i < tab1.GetLength(0); i++)
                {
                    for (int j = 0; j < tab2.GetLength(1); j++)
                    {
                        sum = 0;
                        for (int k = 0; k < tab1.GetLength(1); k++)
                            sum = sum + tab1[i, k] * tab2[k, j];
                        tab3[i, j] = sum;
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox6.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox4.Text = String.Empty;
        }

       

        public void MnozenieMacierzy_2(int[,] tab1, int[,] tab2, int[,] tab3, int wiersz_poczatek, int wiersz_koniec)
        {
            int sum;
            if (tab1.GetLength(1) != tab2.GetLength(0))
            {
                textBox11.Text = String.Empty;
                textBox11.Text = "Nieprawidłowe wymiary tablic!";


            }
            else
            {

                for (int i = wiersz_poczatek; i < wiersz_koniec; i++)
                    for (int j = 0; j < tab2.GetLength(1); j++)
                        tab3[i, j] = 0;
                for (int i = wiersz_poczatek; i < wiersz_koniec; i++)
                {
                    for (int j = 0; j < tab2.GetLength(1); j++)
                    {
                        sum = 0;
                        for (int k = 0; k < tab1.GetLength(1); k++)
                            sum = sum + tab1[i, k] * tab2[k, j];
                        tab3[i, j] = sum;
                    }
                }
            }
        }


    }

}
