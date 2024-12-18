using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;




namespace ReminderApp
{
    partial class RminderGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Liftpanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComplete = new FontAwesome.Sharp.IconButton();
            this.btnTask = new FontAwesome.Sharp.IconButton();
            this.Fullpanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtaddtask = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Liftpanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Fullpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // Liftpanel
            // 
            this.Liftpanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Liftpanel.Controls.Add(this.panel1);
            this.Liftpanel.Controls.Add(this.btnComplete);
            this.Liftpanel.Controls.Add(this.btnTask);
            this.Liftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Liftpanel.Location = new System.Drawing.Point(0, 0);
            this.Liftpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Liftpanel.Name = "Liftpanel";
            this.Liftpanel.Size = new System.Drawing.Size(319, 640);
            this.Liftpanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 54);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(57, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "REMINTER APP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnComplete.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnComplete.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnComplete.IconColor = System.Drawing.SystemColors.Highlight;
            this.btnComplete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnComplete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComplete.Location = new System.Drawing.Point(0, 128);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(312, 60);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click_1);
            // 
            // btnTask
            // 
            this.btnTask.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTask.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnTask.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnTask.IconColor = System.Drawing.SystemColors.Highlight;
            this.btnTask.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTask.Location = new System.Drawing.Point(0, 62);
            this.btnTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(312, 62);
            this.btnTask.TabIndex = 0;
            this.btnTask.Text = "Tasks";
            this.btnTask.UseVisualStyleBackColor = false;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click_1);
            // 
            // Fullpanel
            // 
            this.Fullpanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Fullpanel.Controls.Add(this.panel2);
            this.Fullpanel.Controls.Add(this.dataGridView1);
            this.Fullpanel.Controls.Add(this.button1);
            this.Fullpanel.Controls.Add(this.label2);
            this.Fullpanel.Controls.Add(this.dateTimePicker1);
            this.Fullpanel.Controls.Add(this.txtaddtask);
            this.Fullpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fullpanel.Location = new System.Drawing.Point(319, 0);
            this.Fullpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fullpanel.Name = "Fullpanel";
            this.Fullpanel.Size = new System.Drawing.Size(1163, 640);
            this.Fullpanel.TabIndex = 1;
            this.Fullpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Fullpanel_Paint_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Description,
            this.EndDateTime,
            this.action});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(24, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 274);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.Width = 160;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // EndDateTime
            // 
            this.EndDateTime.HeaderText = "EndDateTime";
            this.EndDateTime.MinimumWidth = 6;
            this.EndDateTime.Name = "EndDateTime";
            this.EndDateTime.Width = 160;
            // 
            // action
            // 
            this.action.HeaderText = "action";
            this.action.MinimumWidth = 6;
            this.action.Name = "action";
            this.action.Width = 150;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(24, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add Task";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "ADD NEW REMINDER TASK";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(526, 35);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 22);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // txtaddtask
            // 
            this.txtaddtask.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtaddtask.Location = new System.Drawing.Point(24, 61);
            this.txtaddtask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtaddtask.Name = "txtaddtask";
            this.txtaddtask.Size = new System.Drawing.Size(752, 52);
            this.txtaddtask.TabIndex = 2;
            this.txtaddtask.Text = "";
            this.txtaddtask.TextChanged += new System.EventHandler(this.txtaddtask_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1030, 637);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.delete});
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView2.Location = new System.Drawing.Point(3, 63);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1018, 292);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Title";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "EndDateTime";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 160;
            // 
            // delete
            // 
            this.delete.HeaderText = "action";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.Width = 125;
            // 
            // RminderGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 640);
            this.Controls.Add(this.Fullpanel);
            this.Controls.Add(this.Liftpanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RminderGui";
            this.Text = "Reminder app";
            this.Load += new System.EventHandler(this.RminderGui_Load);
            this.Liftpanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Fullpanel.ResumeLayout(false);
            this.Fullpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel Liftpanel;
        private FontAwesome.Sharp.IconButton btnTask;
        private Panel Fullpanel;
        private FontAwesome.Sharp.IconButton btnComplete;
        private RichTextBox txtaddtask;
        private DateTimePicker dateTimePicker1;
        private Panel panel1;
        private Label label1;
        private Button button1;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn EndDateTime;
        private DataGridViewButtonColumn action;
        private Panel panel2;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewButtonColumn delete;
    }
}