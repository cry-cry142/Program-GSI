namespace Program_GSI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Text_title = new System.Windows.Forms.Label();
            this.checkBox_del_repeat = new System.Windows.Forms.CheckBox();
            this.button_gsi_fix = new System.Windows.Forms.Button();
            this.button_fix_meas = new System.Windows.Forms.Button();
            this.checkBox_del_null = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.open_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_add_file = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label_Nopen_files = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Text_title
            // 
            resources.ApplyResources(this.Text_title, "Text_title");
            this.Text_title.Name = "Text_title";
            // 
            // checkBox_del_repeat
            // 
            resources.ApplyResources(this.checkBox_del_repeat, "checkBox_del_repeat");
            this.checkBox_del_repeat.Name = "checkBox_del_repeat";
            this.checkBox_del_repeat.UseVisualStyleBackColor = true;
            this.checkBox_del_repeat.CheckedChanged += new System.EventHandler(this.checkBox_del_repeat_CheckedChanged);
            // 
            // button_gsi_fix
            // 
            resources.ApplyResources(this.button_gsi_fix, "button_gsi_fix");
            this.button_gsi_fix.Name = "button_gsi_fix";
            this.button_gsi_fix.UseVisualStyleBackColor = true;
            this.button_gsi_fix.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_gsi_fix_MouseClick);
            // 
            // button_fix_meas
            // 
            resources.ApplyResources(this.button_fix_meas, "button_fix_meas");
            this.button_fix_meas.Name = "button_fix_meas";
            this.button_fix_meas.UseVisualStyleBackColor = true;
            this.button_fix_meas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_fix_autoCAD_MouseClick);
            // 
            // checkBox_del_null
            // 
            resources.ApplyResources(this.checkBox_del_null, "checkBox_del_null");
            this.checkBox_del_null.Name = "checkBox_del_null";
            this.checkBox_del_null.UseVisualStyleBackColor = true;
            this.checkBox_del_null.CheckedChanged += new System.EventHandler(this.checkBox_del_null_CheckedChanged);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // open_button
            // 
            resources.ApplyResources(this.open_button, "open_button");
            this.open_button.Name = "open_button";
            this.open_button.UseVisualStyleBackColor = true;
            this.open_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.open_button_MouseClick_1);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button_add_file
            // 
            resources.ApplyResources(this.button_add_file, "button_add_file");
            this.button_add_file.Name = "button_add_file";
            this.button_add_file.UseVisualStyleBackColor = true;
            this.button_add_file.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_add_file_MouseClick);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // label_Nopen_files
            // 
            resources.ApplyResources(this.label_Nopen_files, "label_Nopen_files");
            this.label_Nopen_files.Name = "label_Nopen_files";
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Nopen_files);
            this.Controls.Add(this.button_add_file);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.open_button);
            this.Controls.Add(this.checkBox_del_null);
            this.Controls.Add(this.button_fix_meas);
            this.Controls.Add(this.button_gsi_fix);
            this.Controls.Add(this.checkBox_del_repeat);
            this.Controls.Add(this.Text_title);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Text_title;
        private System.Windows.Forms.CheckBox checkBox_del_repeat;
        private System.Windows.Forms.Button button_gsi_fix;
        private System.Windows.Forms.Button button_fix_meas;
        private System.Windows.Forms.CheckBox checkBox_del_null;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_add_file;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label_Nopen_files;
    }
}

