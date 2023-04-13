using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace WebsiteRunner
{
    public partial class FormUI : Form
    {
        public FormUI()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // Declare and define a variable that contains the entered URL in the searchbox
            string url = Searchbox.Text;

            try
            {
                if (Uri.TryCreate("http://" + url, UriKind.Absolute, out Uri uriResult)
        || Uri.TryCreate("https://" + url, UriKind.Absolute, out uriResult))
                {
                    Process.Start(url);
                }
                else
                    MessageBox.Show("Please enter a valid URL link!", "Error - Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid URL link!", "Error - Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Searchbox_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user presses the Enter key, the application will behave as if the search button was clicked.
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}