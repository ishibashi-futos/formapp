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
        private NumericUpDown spin2;
        private MenuStrip ms;
        private DataGridView dataGrid;

        public Form1()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {

            // TODO: Columnのサイズを最大化する
            this.dataGrid = new DataGridView{
                Name = "DataGridView",
                Location = new Point(10, 50),
                Size = new Size(780, 300),
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ColumnCount = 3
            };

            this.dataGrid.Columns[0].Name = "No";
            this.dataGrid.Columns[0].Width = 50;
            this.dataGrid.Columns[1].Name = "Time";
            this.dataGrid.Columns[1].Width = 150;
            this.dataGrid.Columns[2].Name = "Result";
            this.dataGrid.Columns[2].Width = 560;

            spin2 = new NumericUpDown{
                Location = new Point(10, 355),
                Size = new Size(300, 100),
                Value = 5,
                Maximum = 100,
                Minimum = 1,
                Increment = 1.0M
            };

            spin = new NumericUpDown{
                Location = new Point(10, 375),
                Size = new Size(300, 100),
                Value = 5,
                Maximum = 10,
                Minimum = 1,
                Increment = 1.0M
            };

            button = new Button{
                Location = new Point(650, 375),
                Size = new Size(100, 22),
                Text = "button",
                BackColor = Color.Crimson,
            };
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

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dataGrid,
                this.spin,
                this.button,
                this.ms,
                this.spin2,
            });
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            uint count = (uint)this.spin.Value;
            // TODO: Dropdownから取得するように変更する.
            uint max = (uint)this.spin2.Value;
            uint[] resultList = new uint[count];
            var r = new System.Random();

            for (var i = 0; i < count; i++)
            {
                resultList[i] = (uint)r.Next(1, (int)max);
            }
            this.AddRow(now, string.Join(", ", resultList));
        }

        private void AddRow(string now, string result)
        {
            string[] s = {(this.dataGrid.Rows.Count).ToString(), now, result};
            this.dataGrid.Rows.Add(s);
            this.dataGrid.FirstDisplayedScrollingRowIndex = this.dataGrid.Rows.Count - 1;
        }

        private void windowNewMenu_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Text = "Form - " + this.spin.Value.ToString();
            f.Show();
        }

    }
}
