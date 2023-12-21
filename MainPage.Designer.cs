namespace C969Tpennartz
{
    partial class MainPage
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
            this.Customerdgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Appointmentsdgv = new System.Windows.Forms.Label();
            this.weekly_radio = new System.Windows.Forms.RadioButton();
            this.Monthly_Radio = new System.Windows.Forms.RadioButton();
            this.Add_appointment_button = new System.Windows.Forms.Button();
            this.Modify_appointment_button = new System.Windows.Forms.Button();
            this.Delete_appointment_button = new System.Windows.Forms.Button();
            this.Add_customer_button = new System.Windows.Forms.Button();
            this.Modify_customer_button = new System.Windows.Forms.Button();
            this.Delete_customer_button = new System.Windows.Forms.Button();
            this.App_search_label = new System.Windows.Forms.Label();
            this.Exit_button = new System.Windows.Forms.Button();
            this.monthCalandar1 = new System.Windows.Forms.MonthCalendar();
            this.dgvcustapp = new System.Windows.Forms.DataGridView();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.tbCustAddress = new System.Windows.Forms.TextBox();
            this.tbCustAddress2 = new System.Windows.Forms.TextBox();
            this.tbCustCity = new System.Windows.Forms.TextBox();
            this.tbCustZip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCustPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbApptTitle = new System.Windows.Forms.TextBox();
            this.tbApptDescription = new System.Windows.Forms.TextBox();
            this.tbApptLocation = new System.Windows.Forms.TextBox();
            this.tbApptContact = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbApptType = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpAppointEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpAppointStart = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.cbCountry = new System.Windows.Forms.TextBox();
            this.ApptUrl = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.save_appt = new System.Windows.Forms.Button();
            this.Save_cust = new System.Windows.Forms.Button();
            this.Clear_Fields = new System.Windows.Forms.Button();
            this.AllReportGenerator = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Customerdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustapp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // Customerdgv
            // 
            this.Customerdgv.AllowUserToAddRows = false;
            this.Customerdgv.AllowUserToDeleteRows = false;
            this.Customerdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Customerdgv.Location = new System.Drawing.Point(12, 248);
            this.Customerdgv.MultiSelect = false;
            this.Customerdgv.Name = "Customerdgv";
            this.Customerdgv.ReadOnly = true;
            this.Customerdgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Customerdgv.Size = new System.Drawing.Size(370, 209);
            this.Customerdgv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer";
            // 
            // Appointmentsdgv
            // 
            this.Appointmentsdgv.AutoSize = true;
            this.Appointmentsdgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appointmentsdgv.Location = new System.Drawing.Point(754, 209);
            this.Appointmentsdgv.Name = "Appointmentsdgv";
            this.Appointmentsdgv.Size = new System.Drawing.Size(155, 25);
            this.Appointmentsdgv.TabIndex = 4;
            this.Appointmentsdgv.Text = "Appointments";
            // 
            // weekly_radio
            // 
            this.weekly_radio.AutoSize = true;
            this.weekly_radio.Location = new System.Drawing.Point(437, 277);
            this.weekly_radio.Name = "weekly_radio";
            this.weekly_radio.Size = new System.Drawing.Size(61, 17);
            this.weekly_radio.TabIndex = 5;
            this.weekly_radio.TabStop = true;
            this.weekly_radio.Text = "Weekly";
            this.weekly_radio.UseVisualStyleBackColor = true;
            this.weekly_radio.CheckedChanged += new System.EventHandler(this.Weekly_Radio_CheckedChanged);
            // 
            // Monthly_Radio
            // 
            this.Monthly_Radio.AutoSize = true;
            this.Monthly_Radio.Location = new System.Drawing.Point(541, 277);
            this.Monthly_Radio.Name = "Monthly_Radio";
            this.Monthly_Radio.Size = new System.Drawing.Size(62, 17);
            this.Monthly_Radio.TabIndex = 6;
            this.Monthly_Radio.TabStop = true;
            this.Monthly_Radio.Text = "Monthly";
            this.Monthly_Radio.UseVisualStyleBackColor = true;
            this.Monthly_Radio.CheckedChanged += new System.EventHandler(this.Monthly_Radio_CheckedChanged);
            // 
            // Add_appointment_button
            // 
            this.Add_appointment_button.Location = new System.Drawing.Point(929, 144);
            this.Add_appointment_button.Name = "Add_appointment_button";
            this.Add_appointment_button.Size = new System.Drawing.Size(75, 23);
            this.Add_appointment_button.TabIndex = 7;
            this.Add_appointment_button.Text = "Add";
            this.Add_appointment_button.UseVisualStyleBackColor = true;
            this.Add_appointment_button.Click += new System.EventHandler(this.Add_appointment_button_Click);
            // 
            // Modify_appointment_button
            // 
            this.Modify_appointment_button.Location = new System.Drawing.Point(929, 170);
            this.Modify_appointment_button.Name = "Modify_appointment_button";
            this.Modify_appointment_button.Size = new System.Drawing.Size(75, 23);
            this.Modify_appointment_button.TabIndex = 8;
            this.Modify_appointment_button.Text = "Modify";
            this.Modify_appointment_button.UseVisualStyleBackColor = true;
            this.Modify_appointment_button.Click += new System.EventHandler(this.Modify_appointment_button_Click);
            // 
            // Delete_appointment_button
            // 
            this.Delete_appointment_button.Location = new System.Drawing.Point(929, 118);
            this.Delete_appointment_button.Name = "Delete_appointment_button";
            this.Delete_appointment_button.Size = new System.Drawing.Size(75, 23);
            this.Delete_appointment_button.TabIndex = 9;
            this.Delete_appointment_button.Text = "Delete";
            this.Delete_appointment_button.UseVisualStyleBackColor = true;
            this.Delete_appointment_button.Click += new System.EventHandler(this.Delete_appointment_button_Click);
            // 
            // Add_customer_button
            // 
            this.Add_customer_button.Location = new System.Drawing.Point(12, 151);
            this.Add_customer_button.Name = "Add_customer_button";
            this.Add_customer_button.Size = new System.Drawing.Size(75, 23);
            this.Add_customer_button.TabIndex = 10;
            this.Add_customer_button.Text = "Add";
            this.Add_customer_button.UseVisualStyleBackColor = true;
            this.Add_customer_button.Click += new System.EventHandler(this.Add_customer_button_Click);
            // 
            // Modify_customer_button
            // 
            this.Modify_customer_button.Location = new System.Drawing.Point(12, 180);
            this.Modify_customer_button.Name = "Modify_customer_button";
            this.Modify_customer_button.Size = new System.Drawing.Size(75, 23);
            this.Modify_customer_button.TabIndex = 11;
            this.Modify_customer_button.Text = "Modify";
            this.Modify_customer_button.UseVisualStyleBackColor = true;
            this.Modify_customer_button.Click += new System.EventHandler(this.Modify_customer_button_Click);
            // 
            // Delete_customer_button
            // 
            this.Delete_customer_button.Location = new System.Drawing.Point(12, 122);
            this.Delete_customer_button.Name = "Delete_customer_button";
            this.Delete_customer_button.Size = new System.Drawing.Size(75, 23);
            this.Delete_customer_button.TabIndex = 12;
            this.Delete_customer_button.Text = "Delete";
            this.Delete_customer_button.UseVisualStyleBackColor = true;
            this.Delete_customer_button.Click += new System.EventHandler(this.Delete_customer_button_Click);
            // 
            // App_search_label
            // 
            this.App_search_label.AutoSize = true;
            this.App_search_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.App_search_label.Location = new System.Drawing.Point(414, 237);
            this.App_search_label.Name = "App_search_label";
            this.App_search_label.Size = new System.Drawing.Size(224, 25);
            this.App_search_label.TabIndex = 13;
            this.App_search_label.Text = "Appointment Search";
            // 
            // Exit_button
            // 
            this.Exit_button.Location = new System.Drawing.Point(865, 9);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(155, 47);
            this.Exit_button.TabIndex = 14;
            this.Exit_button.Text = "Exit";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // monthCalandar1
            // 
            this.monthCalandar1.Location = new System.Drawing.Point(411, 295);
            this.monthCalandar1.MaxSelectionCount = 1;
            this.monthCalandar1.Name = "monthCalandar1";
            this.monthCalandar1.TabIndex = 0;
            this.monthCalandar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalandar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dgvcustapp
            // 
            this.dgvcustapp.AllowUserToAddRows = false;
            this.dgvcustapp.AllowUserToDeleteRows = false;
            this.dgvcustapp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcustapp.Location = new System.Drawing.Point(922, 379);
            this.dgvcustapp.Name = "dgvcustapp";
            this.dgvcustapp.Size = new System.Drawing.Size(98, 78);
            this.dgvcustapp.TabIndex = 17;
            // 
            // tbCustName
            // 
            this.tbCustName.Location = new System.Drawing.Point(175, 23);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(100, 20);
            this.tbCustName.TabIndex = 18;
            // 
            // tbCustAddress
            // 
            this.tbCustAddress.Location = new System.Drawing.Point(175, 47);
            this.tbCustAddress.Name = "tbCustAddress";
            this.tbCustAddress.Size = new System.Drawing.Size(100, 20);
            this.tbCustAddress.TabIndex = 19;
            // 
            // tbCustAddress2
            // 
            this.tbCustAddress2.Location = new System.Drawing.Point(175, 73);
            this.tbCustAddress2.Name = "tbCustAddress2";
            this.tbCustAddress2.Size = new System.Drawing.Size(100, 20);
            this.tbCustAddress2.TabIndex = 20;
            // 
            // tbCustCity
            // 
            this.tbCustCity.Location = new System.Drawing.Point(175, 99);
            this.tbCustCity.Name = "tbCustCity";
            this.tbCustCity.Size = new System.Drawing.Size(100, 20);
            this.tbCustCity.TabIndex = 21;
            // 
            // tbCustZip
            // 
            this.tbCustZip.Location = new System.Drawing.Point(175, 125);
            this.tbCustZip.Name = "tbCustZip";
            this.tbCustZip.Size = new System.Drawing.Size(100, 20);
            this.tbCustZip.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Address 2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "City:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "ZipCode:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Country:";
            // 
            // tbCustPhone
            // 
            this.tbCustPhone.Location = new System.Drawing.Point(175, 177);
            this.tbCustPhone.Name = "tbCustPhone";
            this.tbCustPhone.Size = new System.Drawing.Size(100, 20);
            this.tbCustPhone.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(128, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Phone:";
            // 
            // tbApptTitle
            // 
            this.tbApptTitle.Location = new System.Drawing.Point(759, 72);
            this.tbApptTitle.Name = "tbApptTitle";
            this.tbApptTitle.Size = new System.Drawing.Size(100, 20);
            this.tbApptTitle.TabIndex = 32;
            // 
            // tbApptDescription
            // 
            this.tbApptDescription.Location = new System.Drawing.Point(759, 102);
            this.tbApptDescription.Name = "tbApptDescription";
            this.tbApptDescription.Size = new System.Drawing.Size(100, 20);
            this.tbApptDescription.TabIndex = 33;
            // 
            // tbApptLocation
            // 
            this.tbApptLocation.Location = new System.Drawing.Point(759, 128);
            this.tbApptLocation.Name = "tbApptLocation";
            this.tbApptLocation.Size = new System.Drawing.Size(100, 20);
            this.tbApptLocation.TabIndex = 34;
            // 
            // tbApptContact
            // 
            this.tbApptContact.Location = new System.Drawing.Point(759, 154);
            this.tbApptContact.Name = "tbApptContact";
            this.tbApptContact.Size = new System.Drawing.Size(100, 20);
            this.tbApptContact.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(682, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Appointment:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(688, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Description:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(700, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Location:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(704, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Contact:";
            // 
            // tbApptType
            // 
            this.tbApptType.Location = new System.Drawing.Point(759, 183);
            this.tbApptType.Name = "tbApptType";
            this.tbApptType.Size = new System.Drawing.Size(100, 20);
            this.tbApptType.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(717, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Type:";
            // 
            // dtpAppointEnd
            // 
            this.dtpAppointEnd.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtpAppointEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointEnd.Location = new System.Drawing.Point(680, 44);
            this.dtpAppointEnd.Name = "dtpAppointEnd";
            this.dtpAppointEnd.Size = new System.Drawing.Size(179, 20);
            this.dtpAppointEnd.TabIndex = 38;
            this.dtpAppointEnd.Value = new System.DateTime(2023, 12, 12, 0, 0, 0, 0);
            // 
            // dtpAppointStart
            // 
            this.dtpAppointStart.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtpAppointStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointStart.Location = new System.Drawing.Point(680, 18);
            this.dtpAppointStart.Name = "dtpAppointStart";
            this.dtpAppointStart.Size = new System.Drawing.Size(179, 20);
            this.dtpAppointStart.TabIndex = 37;
            this.dtpAppointStart.Value = new System.DateTime(2023, 12, 12, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(580, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "Appointment Start:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(583, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Appointment End:";
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.Location = new System.Drawing.Point(674, 238);
            this.dgvCalendar.MultiSelect = false;
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.ReadOnly = true;
            this.dgvCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalendar.Size = new System.Drawing.Size(346, 220);
            this.dgvCalendar.TabIndex = 46;
            // 
            // cbCountry
            // 
            this.cbCountry.Location = new System.Drawing.Point(175, 151);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(100, 20);
            this.cbCountry.TabIndex = 48;
            // 
            // ApptUrl
            // 
            this.ApptUrl.Location = new System.Drawing.Point(894, 69);
            this.ApptUrl.Name = "ApptUrl";
            this.ApptUrl.Size = new System.Drawing.Size(126, 20);
            this.ApptUrl.TabIndex = 49;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(865, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "Url:";
            // 
            // save_appt
            // 
            this.save_appt.Location = new System.Drawing.Point(929, 199);
            this.save_appt.Name = "save_appt";
            this.save_appt.Size = new System.Drawing.Size(75, 23);
            this.save_appt.TabIndex = 51;
            this.save_appt.Text = "Save";
            this.save_appt.UseVisualStyleBackColor = true;
            this.save_appt.Click += new System.EventHandler(this.Appt_Save);
            // 
            // Save_cust
            // 
            this.Save_cust.Location = new System.Drawing.Point(12, 209);
            this.Save_cust.Name = "Save_cust";
            this.Save_cust.Size = new System.Drawing.Size(75, 23);
            this.Save_cust.TabIndex = 52;
            this.Save_cust.Text = "Save";
            this.Save_cust.UseVisualStyleBackColor = true;
            this.Save_cust.Click += new System.EventHandler(this.Save_cust_Click);
            // 
            // Clear_Fields
            // 
            this.Clear_Fields.Location = new System.Drawing.Point(307, 12);
            this.Clear_Fields.Name = "Clear_Fields";
            this.Clear_Fields.Size = new System.Drawing.Size(75, 23);
            this.Clear_Fields.TabIndex = 53;
            this.Clear_Fields.Text = "Clear All";
            this.Clear_Fields.UseVisualStyleBackColor = true;
            this.Clear_Fields.Click += new System.EventHandler(this.ClearFields);
            // 
            // AllReportGenerator
            // 
            this.AllReportGenerator.Location = new System.Drawing.Point(454, 28);
            this.AllReportGenerator.Name = "AllReportGenerator";
            this.AllReportGenerator.Size = new System.Drawing.Size(93, 36);
            this.AllReportGenerator.TabIndex = 54;
            this.AllReportGenerator.Text = "Generate All Reports";
            this.AllReportGenerator.UseVisualStyleBackColor = true;
            this.AllReportGenerator.Click += new System.EventHandler(this.AllReports_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(476, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 57;
            this.label17.Text = "Reports";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 469);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.AllReportGenerator);
            this.Controls.Add(this.Clear_Fields);
            this.Controls.Add(this.Save_cust);
            this.Controls.Add(this.save_appt);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ApptUrl);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.dgvCalendar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtpAppointStart);
            this.Controls.Add(this.dtpAppointEnd);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbApptType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbApptContact);
            this.Controls.Add(this.tbApptLocation);
            this.Controls.Add(this.tbApptDescription);
            this.Controls.Add(this.tbApptTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbCustPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCustZip);
            this.Controls.Add(this.tbCustCity);
            this.Controls.Add(this.tbCustAddress2);
            this.Controls.Add(this.tbCustAddress);
            this.Controls.Add(this.tbCustName);
            this.Controls.Add(this.dgvcustapp);
            this.Controls.Add(this.monthCalandar1);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.App_search_label);
            this.Controls.Add(this.Delete_customer_button);
            this.Controls.Add(this.Modify_customer_button);
            this.Controls.Add(this.Add_customer_button);
            this.Controls.Add(this.Delete_appointment_button);
            this.Controls.Add(this.Modify_appointment_button);
            this.Controls.Add(this.Add_appointment_button);
            this.Controls.Add(this.Monthly_Radio);
            this.Controls.Add(this.weekly_radio);
            this.Controls.Add(this.Appointmentsdgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Customerdgv);
            this.Name = "MainPage";
            this.Text = "MainPage";
            ((System.ComponentModel.ISupportInitialize)(this.Customerdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustapp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Customerdgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Appointmentsdgv;
        private System.Windows.Forms.RadioButton weekly_radio;
        private System.Windows.Forms.RadioButton Monthly_Radio;
        private System.Windows.Forms.Button Add_appointment_button;
        private System.Windows.Forms.Button Modify_appointment_button;
        private System.Windows.Forms.Button Delete_appointment_button;
        private System.Windows.Forms.Button Add_customer_button;
        private System.Windows.Forms.Button Modify_customer_button;
        private System.Windows.Forms.Button Delete_customer_button;
        private System.Windows.Forms.Label App_search_label;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.MonthCalendar monthCalandar1;
        private System.Windows.Forms.DataGridView dgvcustapp;
        private System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.TextBox tbCustAddress;
        private System.Windows.Forms.TextBox tbCustAddress2;
        private System.Windows.Forms.TextBox tbCustCity;
        private System.Windows.Forms.TextBox tbCustZip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCustPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbApptTitle;
        private System.Windows.Forms.TextBox tbApptDescription;
        private System.Windows.Forms.TextBox tbApptLocation;
        private System.Windows.Forms.TextBox tbApptContact;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbApptType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpAppointEnd;
        private System.Windows.Forms.DateTimePicker dtpAppointStart;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.TextBox cbCountry;
        private System.Windows.Forms.TextBox ApptUrl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button save_appt;
        private System.Windows.Forms.Button Save_cust;
        private System.Windows.Forms.Button Clear_Fields;
        private System.Windows.Forms.Button AllReportGenerator;
        private System.Windows.Forms.Label label17;
    }
}