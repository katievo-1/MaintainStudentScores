using System;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class txtScore : Form
    {
        public txtScore(string score)
        {
            InitializeComponent();
            txtScores.Text = score;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtScores.Text)
                || !double.TryParse(txtScores.Text, out var score))
            {
                MessageBox.Show("Score must be a number.", "Invalid score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtScores.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Tag = score;
        }

        private void txtScore_Load(object sender, EventArgs e)
        {
            if (Text == "UpdateScore")
            {
                btnAdd.Text = "Update";
                txtScores.Text = Tag.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
