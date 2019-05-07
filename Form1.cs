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
        private MenuStrip ms;
        private TextBox text;
        private DataGridView dataGrid;

        public Form1()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {

            this.Controls.Add(text = new TextBox{
                Location = new Point(10, 50),
                Size = new Size(780, 100),
                AcceptsTab = true,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
            });

            // TODO: Columnのサイズを最大化する
            this.dataGrid = new DataGridView{
                Name = "DataGridView",
                Location = new Point(10, 160),
                Size = new Size(780, 100),
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ColumnCount = 2
            };

            this.dataGrid.Columns[0].Name = "Time";
            this.dataGrid.Columns[1].Name = "Result";

            for (var i = 1; i <= 10; i++)
            {
                string[] s = {i.ToString(), string.Format("result{0}",i)};
                this.dataGrid.Rows.Add(s);
            }

            this.Controls.Add(this.dataGrid);

            for (var i = 0; i < this.dataGrid.Columns.Count; i++)
            {
                this.dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }


            this.Controls.Add(spin = new NumericUpDown{
                Location = new Point(10, 300),
                Size = new Size(300, 100),
                Value = 5,
                Maximum = 10,
                Minimum = 1,
                Increment = 1.0M
            });

            this.Controls.Add(button = new Button{
                Location = new Point(650, 300),
                Size = new Size(100, 22),
                Text = "button",
                BackColor = Color.Crimson,
            });
            button.Click += Button_Click;

            this.ms = new MenuStrip();
            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Window");
            ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("New", null, new EventHandler(windowNewMenu_Click));
            windowMenu.DropDownItems.Add(windowNewMenu);
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowCheckMargin = true;
            
            ms.MdiWindowListItem = windowMenu;

            ms.Items.Add(windowMenu);

            ms.Dock = DockStyle.Top;

            this.MainMenuStrip = ms;

            this.Controls.Add(ms);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0}", (uint)spin.Value));
        }

        private void windowNewMenu_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Text = "Form - " + this.spin.Value.ToString();
            f.Show();
        }

    }
}
