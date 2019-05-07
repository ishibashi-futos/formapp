using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formapp
{
    public partial class Form1 : Form
    {

        private Button button;
        private NumericUpDown spin;

        public Form1()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {

            this.Controls.Add(spin = new NumericUpDown{
                Location = new Point(10, 10),
                Size = new Size(300, 100),
                Value = 5,
                Maximum = 10,
                Minimum = 1,
                Increment = 1.0M
            });

            this.Controls.Add(button = new Button{
                Location = new Point(5, 230),
                Size = new Size(200, 22),
                Text = "button",
                BackColor = Color.Crimson,
            });
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0}", (uint)spin.Value));
        }
    }
}
