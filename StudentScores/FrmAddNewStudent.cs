using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class FrmAddNewStudent : Form
    {
        private Student student = new Student("", new List<double>());
        public FrmAddNewStudent()
        {
            InitializeComponent();
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtScore.Text)
                || !double.TryParse(txtScore.Text, out var score))
            {
                MessageBox.Show("Score must be a number.", "Invalid score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtScore.Focus();
                return;
            }

            student.Scores.Add(score);

            DisplayScores();
            txtScore.Focus();
        }
        private void DisplayScores()
        {
            txtScores.Text = string.Join(" | ", student.Scores);
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            student.Scores.Clear();
            DisplayScores();
            txtScore.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Student must have a name.", "Missing student name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            student.Name = txtName.Text;
            DialogResult = DialogResult.OK;
            Tag = student;
        }
    }
   
}
