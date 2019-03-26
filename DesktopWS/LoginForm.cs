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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            addPlaceholder(login);
            addPlaceholder(password);
        }

        public void removePlaceholder(TextBox textbox)
        {
            if (textbox.Text == "Login")
                textbox.Text = "";
        }

        public void addPlaceholder(TextBox textbox)
        {
            if (textbox.Text == "")
                textbox.Text = "Login";
        }

        public bool loginDataChecker(string username, string password)
        {
            if (username == "student" && password == "123")
                return true;
            return false;
        }

        //_______________________________________
        private void login_Enter(object sender, EventArgs e)
        {
            removePlaceholder(login);
        }

        private void login_Leave(object sender, EventArgs e)
        {
            addPlaceholder(login);
        }

        private void password_Enter(object sender, EventArgs e)
        {
            removePlaceholder(password);
        }

        private void password_Leave(object sender, EventArgs e)
        {
            addPlaceholder(password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true || loginDataChecker(login.Text, password.Text))
            {
                Hide();
                MainForm mainForm = new MainForm(true);
                mainForm.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
