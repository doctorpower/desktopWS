using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWS
{
    public partial class MainForm : Form
    {

        public Image[] images = new Image[4];

        public void refreshImages()
        {
            pictureBox1.BackgroundImage = images[0];
            pictureBox2.BackgroundImage = images[1];
            pictureBox3.BackgroundImage = images[2];
        }

        public void init()
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = Image.FromFile(@"material\image" + (i + 1).ToString() + ".jpg");
            }
            refreshImages();
        }

        public void transport(string side)
        {
            Image[] imagesLocal = new Image[4];

            switch(side)
            {
                case "left":
                    for (int i = 0; i < images.Length; i++)
                    {
                        if (i == 0)
                            imagesLocal[0] = images[images.Length - 1];
                        else
                            imagesLocal[i] = images[i - 1];
                    }
                    break;
                case "right":
                    for (int i = 0; i < images.Length; i++)
                    {
                        if (i == images.Length - 1)
                            imagesLocal[images.Length - 1] = images[0];
                        else
                            imagesLocal[i] = images[i + 1];
                    }
                    break;
                default:
                    break;
            }
            images = imagesLocal;
            refreshImages();
        }

        public Panel createNewPanel(int width, int count)
        {
            Panel panel = new Panel();
            panel.Width = width - 50;
            panel.Height = 100;
            panel.BackColor = Color.Purple;
            //panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, (count * 110));

            TextBox textbox = new TextBox();
            textbox.Text = count.ToString();

            panel.Controls.Add(textbox);

            return panel;
        }

        public void createList()
        {
            //tableLayoutPanel1.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                panel2.Controls.Add(createNewPanel(panel2.Width, i));
            }
        }

        public MainForm(bool check)
        {
            InitializeComponent();
            init();

            createList();

            chart1.Series["Series1"].Points.AddXY(20, 10);
            chart1.Series["Series1"].Points.AddXY(25, 15);
            chart1.Series["Series1"].Points.AddXY(28, 20);

            progressBar1.Value += 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A_TAB_CONTROL.SelectedTab = A_TAB_CONTROL.TabPages[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            A_TAB_CONTROL.SelectedTab = A_TAB_CONTROL.TabPages[0];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            for (int i = 0; i < 20; i++)
            {
                ListViewItem list = new ListViewItem(new string[] { i.ToString(), i.ToString() + " qweasdzxc" });
                listView1.Items.Add(list);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices[0] != -1)
            {
                A_TAB_CONTROL.SelectedTab = A_TAB_CONTROL.TabPages[2];

                textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listView1.SelectedIndices[0] != -1)
            {
                A_TAB_CONTROL.SelectedTab = A_TAB_CONTROL.TabPages[2];

                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    textBox1.Text += listView1.SelectedItems[i].SubItems[0].Text;
                    textBox2.Text += listView1.SelectedItems[i].SubItems[1].Text;
                }
            }
        }

        // right
        private void label2_Click(object sender, EventArgs e)
        {
            transport("right");
        }

        // left
        private void label3_Click(object sender, EventArgs e)
        {
            transport("left");
        }
    }
}
