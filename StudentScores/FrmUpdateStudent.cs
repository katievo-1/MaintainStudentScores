using System;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class FrmUpdateStudent : Form
    {
        public Student student;
        private Student studentUpdate;

        public FrmUpdateStudent(Student student)
        {
            InitializeComponent();
            this.student = new Student(student);
            studentUpdate = new Student(student);
            txtName.Text = this.student.Name;
            DisplayScores();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(lstStudentScores.SelectedItem == null)
            {
                MessageBox.Show("Select a score to update.", "No score is selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedStudent = (double)lstStudentScores.SelectedItem;
            var updateForm = new txtScore(selectedStudent.ToString());
            updateForm.Text = "Update Score";

            var button = updateForm.ShowDialog();
            if (button == DialogResult.OK)
            {
                var score = (double)updateForm.Tag;
                studentUpdate.Scores[lstStudentScores.SelectedIndex] = score;
                DisplayScores();
            }
        }
        private void DisplayScores()
        {
            lstStudentScores.Items.Clear();

            if (studentUpdate.Scores.Count > 0)
            {
                foreach (double score in studentUpdate.Scores)
                {
                    lstStudentScores.Items.Add(score);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new txtScore("");
            addForm.Text = "Add Score";

            var button = addForm.ShowDialog();

            if(button == DialogResult.OK)
            {
                var score = (double)addForm.Tag;
                studentUpdate.Scores.Add(score);
                DisplayScores();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstStudentScores.SelectedItem == null)
            {
                MessageBox.Show("Select a score to remove.", "No score is selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                studentUpdate.Scores.RemoveAt(lstStudentScores.SelectedIndex);
                DisplayScores();
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            studentUpdate.Scores.Clear();
            DisplayScores();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            student = studentUpdate;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
