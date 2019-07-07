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

namespace winform_070709
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void DoWork()
        {
            for (int i = 0; i < 1000; i++)
            {
                // this can be done outside the UI thread
                //if (i % 2 == 0)
                //{
                //    label1.ForeColor = Color.Blue;
                //}
                //else
                //{
                //    label1.ForeColor = Color.Red;
                //}

                // this can NOT done outside the UI thread!!!

                Action a = () => { label1.Text = i.ToString(); };
                //label1.BeginInvoke(a); // this calls the UI thread to perform this action
                this.BeginInvoke(a);


                Thread.Sleep(20);
                //await Task.Run(() => { Thread.Sleep(20); });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Task.Run(() => { Thread.Sleep(10 * 1000); });

            // solution 1:
            //for (int i = 0; i < 1000; i++)
            //{
            //    label1.Text = i.ToString();
            //    await Task.Run(() => { Thread.Sleep(20); });
            //}

            // solution 2:
            Task.Run(() => { DoWork(); });

        }
    }
}
