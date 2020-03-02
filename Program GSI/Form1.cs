using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_GSI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Points_List all_list = new Points_List();
        int n_files = 0;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Open_Click(object sender, EventArgs e)
        {

        }

        private void button_fixmeas_fix_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void open_button_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                all_list.poits_list.Clear();
                button_gsi_fix.Enabled = false;
                button_fix_meas.Enabled = false;
                button_add_file.Enabled = false;
                checkBox_del_null.Enabled = false;
                checkBox_del_repeat.Enabled = false;
                n_files = 0;

                if (all_list.Open_File_Points(openFileDialog1.FileName))
                {
                    button_add_file.Enabled = true;
                    button_gsi_fix.Enabled = true;
                    button_fix_meas.Enabled = true;
                    checkBox_del_null.Enabled = true;
                    checkBox_del_repeat.Enabled = true;

                    n_files++;
                    label_Nopen_files.Text = $"Открытых файлов: {n_files}";
                    MessageBox.Show("Файл успешно открыт");
                }
                else
                {
                    label_Nopen_files.Text = $"Открытых файлов: {n_files}";
                    MessageBox.Show($"Ошибка");
                }
            }
        }

        private void button_gsi_fix_MouseClick(object sender, MouseEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                all_list.Save_GSI_fix(saveFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Сохранение не выполнилось");
            }
        }

        private void button_fix_autoCAD_MouseClick(object sender, MouseEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                all_list.Save_GSI_Meas(saveFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Сохранение не выполнилось");
            }
        }

        private void button_add_file_MouseClick(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (all_list.Open_File_Points(openFileDialog1.FileName))
                {
                    n_files++;
                    label_Nopen_files.Text = $"Открытых файлов: {n_files}";
                    MessageBox.Show("Файл успешно открыт");
                }
                else
                {
                    MessageBox.Show($"Ошибка");
                }
            }
        }

        private void checkBox_del_repeat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check_repeat = (CheckBox)sender;
            if(check_repeat.Checked == true)
            {
                Points_List.delete_repeat = true;
            }
            else
            {
                Points_List.delete_repeat = false;
            }
        }

        private void checkBox_del_null_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check_null = (CheckBox)sender;
            if(check_null.Checked == true)
            {
                Points_List.delete_null = true;
            }
            else
            {
                Points_List.delete_null = false;
            }
        }
    }
}
