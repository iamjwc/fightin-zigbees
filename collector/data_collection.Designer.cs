namespace FightinZigbees
{
    partial class DataCollection
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataCollection));
          this.nud_y_coord = new System.Windows.Forms.NumericUpDown();
          this.nud_x_coord = new System.Windows.Forms.NumericUpDown();
          this.lst_orientation = new System.Windows.Forms.ListBox();
          this.btn_start_collecting = new System.Windows.Forms.Button();
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.label5 = new System.Windows.Forms.Label();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.pictureBox2 = new System.Windows.Forms.PictureBox();
          this.pictureBox3 = new System.Windows.Forms.PictureBox();
          this.pictureBox4 = new System.Windows.Forms.PictureBox();
          this.pictureBox5 = new System.Windows.Forms.PictureBox();
          this.pictureBox6 = new System.Windows.Forms.PictureBox();
          this.pictureBox7 = new System.Windows.Forms.PictureBox();
          this.pictureBox8 = new System.Windows.Forms.PictureBox();
          this.pictureBox9 = new System.Windows.Forms.PictureBox();
          this.label6 = new System.Windows.Forms.Label();
          this.label7 = new System.Windows.Forms.Label();
          this.label8 = new System.Windows.Forms.Label();
          this.label9 = new System.Windows.Forms.Label();
          this.label10 = new System.Windows.Forms.Label();
          this.label11 = new System.Windows.Forms.Label();
          this.label12 = new System.Windows.Forms.Label();
          this.label13 = new System.Windows.Forms.Label();
          this.label14 = new System.Windows.Forms.Label();
          this.lbl_node_1_status = new System.Windows.Forms.Label();
          this.lbl_node_8_status = new System.Windows.Forms.Label();
          this.lbl_node_6_status = new System.Windows.Forms.Label();
          this.lbl_node_4_status = new System.Windows.Forms.Label();
          this.lbl_node_2_status = new System.Windows.Forms.Label();
          this.lbl_node_9_status = new System.Windows.Forms.Label();
          this.lbl_node_7_status = new System.Windows.Forms.Label();
          this.lbl_node_5_status = new System.Windows.Forms.Label();
          this.lbl_node_3_status = new System.Windows.Forms.Label();
          this.pictureBox10 = new System.Windows.Forms.PictureBox();
          ((System.ComponentModel.ISupportInitialize)(this.nud_y_coord)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.nud_x_coord)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
          this.SuspendLayout();
          // 
          // nud_y_coord
          // 
          this.nud_y_coord.Location = new System.Drawing.Point(254, 174);
          this.nud_y_coord.Name = "nud_y_coord";
          this.nud_y_coord.Size = new System.Drawing.Size(64, 20);
          this.nud_y_coord.TabIndex = 3;
          this.nud_y_coord.ValueChanged += new System.EventHandler(this.nud_coord_ValueChanged);
          // 
          // nud_x_coord
          // 
          this.nud_x_coord.Location = new System.Drawing.Point(254, 132);
          this.nud_x_coord.Name = "nud_x_coord";
          this.nud_x_coord.Size = new System.Drawing.Size(64, 20);
          this.nud_x_coord.TabIndex = 2;
          this.nud_x_coord.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
          this.nud_x_coord.ValueChanged += new System.EventHandler(this.nud_coord_ValueChanged);
          // 
          // lst_orientation
          // 
          this.lst_orientation.FormattingEnabled = true;
          this.lst_orientation.Items.AddRange(new object[] {
            "North",
            "East",
            "South",
            "West"});
          this.lst_orientation.Location = new System.Drawing.Point(254, 51);
          this.lst_orientation.Name = "lst_orientation";
          this.lst_orientation.Size = new System.Drawing.Size(64, 56);
          this.lst_orientation.TabIndex = 1;
          // 
          // btn_start_collecting
          // 
          this.btn_start_collecting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
          this.btn_start_collecting.Location = new System.Drawing.Point(254, 209);
          this.btn_start_collecting.Name = "btn_start_collecting";
          this.btn_start_collecting.Size = new System.Drawing.Size(64, 50);
          this.btn_start_collecting.TabIndex = 4;
          this.btn_start_collecting.Text = "Start";
          this.btn_start_collecting.UseVisualStyleBackColor = true;
          this.btn_start_collecting.Click += new System.EventHandler(this.btn_start_collecting_Click);
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(248, 35);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(58, 13);
          this.label1.TabIndex = 4;
          this.label1.Text = "Orientation";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(248, 116);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(68, 13);
          this.label2.TabIndex = 5;
          this.label2.Text = "X Coordinate";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(248, 158);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(68, 13);
          this.label3.TabIndex = 6;
          this.label3.Text = "Y Coordinate";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label4.Location = new System.Drawing.Point(43, 4);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(254, 23);
          this.label4.TabIndex = 7;
          this.label4.Text = "Signal Strength Data Collection";
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(9, 35);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(37, 13);
          this.label5.TabIndex = 10;
          this.label5.Text = "Status";
          // 
          // pictureBox1
          // 
          this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
          this.pictureBox1.Location = new System.Drawing.Point(12, 51);
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.Size = new System.Drawing.Size(21, 22);
          this.pictureBox1.TabIndex = 11;
          this.pictureBox1.TabStop = false;
          // 
          // pictureBox2
          // 
          this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
          this.pictureBox2.Location = new System.Drawing.Point(12, 79);
          this.pictureBox2.Name = "pictureBox2";
          this.pictureBox2.Size = new System.Drawing.Size(21, 22);
          this.pictureBox2.TabIndex = 12;
          this.pictureBox2.TabStop = false;
          // 
          // pictureBox3
          // 
          this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
          this.pictureBox3.Location = new System.Drawing.Point(12, 107);
          this.pictureBox3.Name = "pictureBox3";
          this.pictureBox3.Size = new System.Drawing.Size(21, 22);
          this.pictureBox3.TabIndex = 13;
          this.pictureBox3.TabStop = false;
          // 
          // pictureBox4
          // 
          this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
          this.pictureBox4.Location = new System.Drawing.Point(12, 135);
          this.pictureBox4.Name = "pictureBox4";
          this.pictureBox4.Size = new System.Drawing.Size(21, 22);
          this.pictureBox4.TabIndex = 14;
          this.pictureBox4.TabStop = false;
          // 
          // pictureBox5
          // 
          this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
          this.pictureBox5.Location = new System.Drawing.Point(122, 135);
          this.pictureBox5.Name = "pictureBox5";
          this.pictureBox5.Size = new System.Drawing.Size(21, 22);
          this.pictureBox5.TabIndex = 15;
          this.pictureBox5.TabStop = false;
          // 
          // pictureBox6
          // 
          this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
          this.pictureBox6.Location = new System.Drawing.Point(122, 107);
          this.pictureBox6.Name = "pictureBox6";
          this.pictureBox6.Size = new System.Drawing.Size(21, 22);
          this.pictureBox6.TabIndex = 16;
          this.pictureBox6.TabStop = false;
          // 
          // pictureBox7
          // 
          this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
          this.pictureBox7.Location = new System.Drawing.Point(122, 79);
          this.pictureBox7.Name = "pictureBox7";
          this.pictureBox7.Size = new System.Drawing.Size(21, 22);
          this.pictureBox7.TabIndex = 17;
          this.pictureBox7.TabStop = false;
          // 
          // pictureBox8
          // 
          this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
          this.pictureBox8.Location = new System.Drawing.Point(122, 51);
          this.pictureBox8.Name = "pictureBox8";
          this.pictureBox8.Size = new System.Drawing.Size(21, 22);
          this.pictureBox8.TabIndex = 18;
          this.pictureBox8.TabStop = false;
          // 
          // pictureBox9
          // 
          this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
          this.pictureBox9.Location = new System.Drawing.Point(12, 163);
          this.pictureBox9.Name = "pictureBox9";
          this.pictureBox9.Size = new System.Drawing.Size(21, 22);
          this.pictureBox9.TabIndex = 19;
          this.pictureBox9.TabStop = false;
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label6.Location = new System.Drawing.Point(39, 51);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(13, 13);
          this.label6.TabIndex = 20;
          this.label6.Text = "1";
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label7.Location = new System.Drawing.Point(39, 79);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(13, 13);
          this.label7.TabIndex = 21;
          this.label7.Text = "3";
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label8.Location = new System.Drawing.Point(39, 107);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(13, 13);
          this.label8.TabIndex = 22;
          this.label8.Text = "5";
          // 
          // label9
          // 
          this.label9.AutoSize = true;
          this.label9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label9.Location = new System.Drawing.Point(39, 163);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(13, 13);
          this.label9.TabIndex = 23;
          this.label9.Text = "9";
          // 
          // label10
          // 
          this.label10.AutoSize = true;
          this.label10.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label10.Location = new System.Drawing.Point(39, 135);
          this.label10.Name = "label10";
          this.label10.Size = new System.Drawing.Size(13, 13);
          this.label10.TabIndex = 24;
          this.label10.Text = "7";
          // 
          // label11
          // 
          this.label11.AutoSize = true;
          this.label11.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label11.Location = new System.Drawing.Point(149, 51);
          this.label11.Name = "label11";
          this.label11.Size = new System.Drawing.Size(13, 13);
          this.label11.TabIndex = 25;
          this.label11.Text = "2";
          // 
          // label12
          // 
          this.label12.AutoSize = true;
          this.label12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label12.Location = new System.Drawing.Point(149, 79);
          this.label12.Name = "label12";
          this.label12.Size = new System.Drawing.Size(13, 13);
          this.label12.TabIndex = 26;
          this.label12.Text = "4";
          // 
          // label13
          // 
          this.label13.AutoSize = true;
          this.label13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label13.Location = new System.Drawing.Point(149, 107);
          this.label13.Name = "label13";
          this.label13.Size = new System.Drawing.Size(13, 13);
          this.label13.TabIndex = 27;
          this.label13.Text = "6";
          // 
          // label14
          // 
          this.label14.AutoSize = true;
          this.label14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label14.Location = new System.Drawing.Point(149, 135);
          this.label14.Name = "label14";
          this.label14.Size = new System.Drawing.Size(13, 13);
          this.label14.TabIndex = 28;
          this.label14.Text = "8";
          // 
          // lbl_node_1_status
          // 
          this.lbl_node_1_status.AutoSize = true;
          this.lbl_node_1_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_1_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_1_status.Location = new System.Drawing.Point(55, 51);
          this.lbl_node_1_status.Name = "lbl_node_1_status";
          this.lbl_node_1_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_1_status.TabIndex = 29;
          this.lbl_node_1_status.Text = "Incomplete";
          // 
          // lbl_node_8_status
          // 
          this.lbl_node_8_status.AutoSize = true;
          this.lbl_node_8_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_8_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_8_status.Location = new System.Drawing.Point(165, 135);
          this.lbl_node_8_status.Name = "lbl_node_8_status";
          this.lbl_node_8_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_8_status.TabIndex = 30;
          this.lbl_node_8_status.Text = "Incomplete";
          // 
          // lbl_node_6_status
          // 
          this.lbl_node_6_status.AutoSize = true;
          this.lbl_node_6_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_6_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_6_status.Location = new System.Drawing.Point(165, 107);
          this.lbl_node_6_status.Name = "lbl_node_6_status";
          this.lbl_node_6_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_6_status.TabIndex = 31;
          this.lbl_node_6_status.Text = "Incomplete";
          // 
          // lbl_node_4_status
          // 
          this.lbl_node_4_status.AutoSize = true;
          this.lbl_node_4_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_4_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_4_status.Location = new System.Drawing.Point(165, 79);
          this.lbl_node_4_status.Name = "lbl_node_4_status";
          this.lbl_node_4_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_4_status.TabIndex = 32;
          this.lbl_node_4_status.Text = "Incomplete";
          // 
          // lbl_node_2_status
          // 
          this.lbl_node_2_status.AutoSize = true;
          this.lbl_node_2_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_2_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_2_status.Location = new System.Drawing.Point(165, 51);
          this.lbl_node_2_status.Name = "lbl_node_2_status";
          this.lbl_node_2_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_2_status.TabIndex = 33;
          this.lbl_node_2_status.Text = "Incomplete";
          // 
          // lbl_node_9_status
          // 
          this.lbl_node_9_status.AutoSize = true;
          this.lbl_node_9_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_9_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_9_status.Location = new System.Drawing.Point(55, 163);
          this.lbl_node_9_status.Name = "lbl_node_9_status";
          this.lbl_node_9_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_9_status.TabIndex = 34;
          this.lbl_node_9_status.Text = "Incomplete";
          // 
          // lbl_node_7_status
          // 
          this.lbl_node_7_status.AutoSize = true;
          this.lbl_node_7_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_7_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_7_status.Location = new System.Drawing.Point(55, 135);
          this.lbl_node_7_status.Name = "lbl_node_7_status";
          this.lbl_node_7_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_7_status.TabIndex = 35;
          this.lbl_node_7_status.Text = "Incomplete";
          // 
          // lbl_node_5_status
          // 
          this.lbl_node_5_status.AutoSize = true;
          this.lbl_node_5_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_5_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_5_status.Location = new System.Drawing.Point(55, 107);
          this.lbl_node_5_status.Name = "lbl_node_5_status";
          this.lbl_node_5_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_5_status.TabIndex = 36;
          this.lbl_node_5_status.Text = "Incomplete";
          // 
          // lbl_node_3_status
          // 
          this.lbl_node_3_status.AutoSize = true;
          this.lbl_node_3_status.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lbl_node_3_status.ForeColor = System.Drawing.Color.Maroon;
          this.lbl_node_3_status.Location = new System.Drawing.Point(55, 79);
          this.lbl_node_3_status.Name = "lbl_node_3_status";
          this.lbl_node_3_status.Size = new System.Drawing.Size(61, 13);
          this.lbl_node_3_status.TabIndex = 37;
          this.lbl_node_3_status.Text = "Incomplete";
          // 
          // pictureBox10
          // 
          this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
          this.pictureBox10.Location = new System.Drawing.Point(12, 209);
          this.pictureBox10.Name = "pictureBox10";
          this.pictureBox10.Size = new System.Drawing.Size(217, 50);
          this.pictureBox10.TabIndex = 38;
          this.pictureBox10.TabStop = false;
          // 
          // DataCollection
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
          this.ClientSize = new System.Drawing.Size(330, 268);
          this.Controls.Add(this.pictureBox10);
          this.Controls.Add(this.lbl_node_3_status);
          this.Controls.Add(this.lbl_node_5_status);
          this.Controls.Add(this.lbl_node_7_status);
          this.Controls.Add(this.lbl_node_9_status);
          this.Controls.Add(this.lbl_node_2_status);
          this.Controls.Add(this.lbl_node_4_status);
          this.Controls.Add(this.lbl_node_6_status);
          this.Controls.Add(this.lbl_node_8_status);
          this.Controls.Add(this.lbl_node_1_status);
          this.Controls.Add(this.label14);
          this.Controls.Add(this.label13);
          this.Controls.Add(this.label12);
          this.Controls.Add(this.label11);
          this.Controls.Add(this.label10);
          this.Controls.Add(this.label9);
          this.Controls.Add(this.label8);
          this.Controls.Add(this.label7);
          this.Controls.Add(this.label6);
          this.Controls.Add(this.pictureBox9);
          this.Controls.Add(this.pictureBox8);
          this.Controls.Add(this.pictureBox7);
          this.Controls.Add(this.pictureBox6);
          this.Controls.Add(this.pictureBox5);
          this.Controls.Add(this.pictureBox4);
          this.Controls.Add(this.pictureBox3);
          this.Controls.Add(this.pictureBox2);
          this.Controls.Add(this.pictureBox1);
          this.Controls.Add(this.label5);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.btn_start_collecting);
          this.Controls.Add(this.lst_orientation);
          this.Controls.Add(this.nud_x_coord);
          this.Controls.Add(this.nud_y_coord);
          this.MaximizeBox = false;
          this.Name = "DataCollection";
          this.Text = "Form1";
          this.Load += new System.EventHandler(this.data_collection_Load);
          ((System.ComponentModel.ISupportInitialize)(this.nud_y_coord)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.nud_x_coord)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_y_coord;
        private System.Windows.Forms.NumericUpDown nud_x_coord;
        private System.Windows.Forms.ListBox lst_orientation;
        private System.Windows.Forms.Button btn_start_collecting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_node_1_status;
        private System.Windows.Forms.Label lbl_node_8_status;
        private System.Windows.Forms.Label lbl_node_6_status;
        private System.Windows.Forms.Label lbl_node_4_status;
        private System.Windows.Forms.Label lbl_node_2_status;
        private System.Windows.Forms.Label lbl_node_9_status;
        private System.Windows.Forms.Label lbl_node_7_status;
        private System.Windows.Forms.Label lbl_node_5_status;
        private System.Windows.Forms.Label lbl_node_3_status;
        private System.Windows.Forms.PictureBox pictureBox10;
    }
}

