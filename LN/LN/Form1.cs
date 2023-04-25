using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 1;
          double  x, x0, x1, fx0, fx1, fx, ea, xant;
        int ban = 0, ban2 = 0;

        private void txtLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                while ((ban + ban2) < 2)
                {
                    if (i == 1)
                    {
                        x = Convert.ToDouble(txtLN.Text);
                        x0 = Convert.ToDouble(txtx0.Text);
                        x1 = Convert.ToDouble(txtx00.Text);

                        i++;

                    }
                    else
                    {
                        
                        fx0 = Math.Log(x0);
                        fx1 = Math.Log(x1);
                        xant = fx; 
                        fx = fx0 + ((fx1 - fx0) / (x1 - x0)) * (x - x0);

                        ea = Math.Abs(((fx - xant) / fx) * 100);
                        txtvalor.Text = Convert.ToString(fx);
                        datapapapa.Rows.Add(i - 1, x, x0, x1, fx0, fx1, fx, ea);
                        i++;
                        x1 --;
                        x0++;


                        if (x0 == x)
                        {
                            ban = 1;
                            x0--;
                        }

                        if (x1 == x)
                        {
                            ban2 = 1;
                            x1++;
                        }
                    }

                }
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Limpiar()
        {
            txtLN.Text = "";
            txtvalor.Text = "";
            txtx0.Text = "";
            txtx00.Text = "";
            datapapapa.Rows.Clear();
            i = 1;
            x = 0;
            x0 = 0;
            x1 = 0;
            fx = 0;
            fx0 = 0;
            fx1 = 0;
            xant = 0;

        }
    }

}
