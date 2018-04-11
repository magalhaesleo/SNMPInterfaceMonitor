namespace SNMPMonitor.WinApp
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCommunit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtResumeInterface = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtErrorRateIn = new System.Windows.Forms.TextBox();
            this.txtErrorRateOut = new System.Windows.Forms.TextBox();
            this.taxa = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiscardOut = new System.Windows.Forms.TextBox();
            this.txtDiscardIn = new System.Windows.Forms.TextBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.numTimeOut = new System.Windows.Forms.NumericUpDown();
            this.numRestransmitions = new System.Windows.Forms.NumericUpDown();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.numVersion = new System.Windows.Forms.NumericUpDown();
            this.chtInterface = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerUpdateGraphInterface = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.maskedIP = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestransmitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtInterface)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dados do Equipamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Versão:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Communit:";
            // 
            // txtCommunit
            // 
            this.txtCommunit.Location = new System.Drawing.Point(158, 40);
            this.txtCommunit.Name = "txtCommunit";
            this.txtCommunit.Size = new System.Drawing.Size(112, 20);
            this.txtCommunit.TabIndex = 3;
            this.txtCommunit.Text = "public";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Porta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Retransmissões:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(325, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Timeout:";
            // 
            // txtResume
            // 
            this.txtResume.Location = new System.Drawing.Point(6, 79);
            this.txtResume.Multiline = true;
            this.txtResume.Name = "txtResume";
            this.txtResume.ReadOnly = true;
            this.txtResume.Size = new System.Drawing.Size(544, 99);
            this.txtResume.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Resumo Do Equipamento";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(475, 38);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Interfaces";
            // 
            // cmbInterfaces
            // 
            this.cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaces.FormattingEnabled = true;
            this.cmbInterfaces.Location = new System.Drawing.Point(6, 199);
            this.cmbInterfaces.Name = "cmbInterfaces";
            this.cmbInterfaces.Size = new System.Drawing.Size(461, 21);
            this.cmbInterfaces.TabIndex = 17;
            this.cmbInterfaces.SelectedIndexChanged += new System.EventHandler(this.cmbInterfaces_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(472, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Intervalo";
            // 
            // txtResumeInterface
            // 
            this.txtResumeInterface.Location = new System.Drawing.Point(6, 248);
            this.txtResumeInterface.Multiline = true;
            this.txtResumeInterface.Name = "txtResumeInterface";
            this.txtResumeInterface.ReadOnly = true;
            this.txtResumeInterface.Size = new System.Drawing.Size(544, 99);
            this.txtResumeInterface.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Resumo Interface";
            // 
            // txtErrorRateIn
            // 
            this.txtErrorRateIn.Enabled = false;
            this.txtErrorRateIn.Location = new System.Drawing.Point(102, 551);
            this.txtErrorRateIn.Name = "txtErrorRateIn";
            this.txtErrorRateIn.ReadOnly = true;
            this.txtErrorRateIn.Size = new System.Drawing.Size(35, 20);
            this.txtErrorRateIn.TabIndex = 1;
            // 
            // txtErrorRateOut
            // 
            this.txtErrorRateOut.Enabled = false;
            this.txtErrorRateOut.Location = new System.Drawing.Point(149, 551);
            this.txtErrorRateOut.Name = "txtErrorRateOut";
            this.txtErrorRateOut.ReadOnly = true;
            this.txtErrorRateOut.Size = new System.Drawing.Size(35, 20);
            this.txtErrorRateOut.TabIndex = 2;
            // 
            // taxa
            // 
            this.taxa.AutoSize = true;
            this.taxa.Location = new System.Drawing.Point(103, 519);
            this.taxa.Name = "taxa";
            this.taxa.Size = new System.Drawing.Size(70, 13);
            this.taxa.TabIndex = 23;
            this.taxa.Text = "Taxa de erro:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(370, 519);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Taxa de descarte:";
            // 
            // txtDiscardOut
            // 
            this.txtDiscardOut.Enabled = false;
            this.txtDiscardOut.Location = new System.Drawing.Point(432, 553);
            this.txtDiscardOut.Name = "txtDiscardOut";
            this.txtDiscardOut.ReadOnly = true;
            this.txtDiscardOut.Size = new System.Drawing.Size(35, 20);
            this.txtDiscardOut.TabIndex = 25;
            // 
            // txtDiscardIn
            // 
            this.txtDiscardIn.Enabled = false;
            this.txtDiscardIn.Location = new System.Drawing.Point(373, 553);
            this.txtDiscardIn.Name = "txtDiscardIn";
            this.txtDiscardIn.ReadOnly = true;
            this.txtDiscardIn.Size = new System.Drawing.Size(35, 20);
            this.txtDiscardIn.TabIndex = 24;
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(102, 40);
            this.numPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.ReadOnly = true;
            this.numPort.Size = new System.Drawing.Size(50, 20);
            this.numPort.TabIndex = 2;
            this.numPort.Value = new decimal(new int[] {
            161,
            0,
            0,
            0});
            // 
            // numTimeOut
            // 
            this.numTimeOut.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimeOut.Location = new System.Drawing.Point(328, 40);
            this.numTimeOut.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTimeOut.Name = "numTimeOut";
            this.numTimeOut.ReadOnly = true;
            this.numTimeOut.Size = new System.Drawing.Size(62, 20);
            this.numTimeOut.TabIndex = 5;
            this.numTimeOut.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numRestransmitions
            // 
            this.numRestransmitions.Location = new System.Drawing.Point(396, 40);
            this.numRestransmitions.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRestransmitions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRestransmitions.Name = "numRestransmitions";
            this.numRestransmitions.ReadOnly = true;
            this.numRestransmitions.Size = new System.Drawing.Size(69, 20);
            this.numRestransmitions.TabIndex = 6;
            this.numRestransmitions.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(475, 200);
            this.numInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.ReadOnly = true;
            this.numInterval.Size = new System.Drawing.Size(75, 20);
            this.numInterval.TabIndex = 18;
            this.numInterval.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.numInterval_ValueChanged);
            // 
            // numVersion
            // 
            this.numVersion.Location = new System.Drawing.Point(276, 40);
            this.numVersion.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numVersion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVersion.Name = "numVersion";
            this.numVersion.ReadOnly = true;
            this.numVersion.Size = new System.Drawing.Size(46, 20);
            this.numVersion.TabIndex = 4;
            this.numVersion.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chtInterface
            // 
            this.chtInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chtInterface.BorderSkin.BorderColor = System.Drawing.Color.White;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "chtAreaUtilizationInterface";
            this.chtInterface.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtInterface.Legends.Add(legend1);
            this.chtInterface.Location = new System.Drawing.Point(6, 353);
            this.chtInterface.Name = "chtInterface";
            this.chtInterface.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "chtAreaUtilizationInterface";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.LegendText = "Entrada de Dados";
            series1.Name = "GraphInterfaceIn";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.ChartArea = "chtAreaUtilizationInterface";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.LegendText = "Saida de Dados";
            series2.Name = "GraphInterfaceOut";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chtInterface.Series.Add(series1);
            this.chtInterface.Series.Add(series2);
            this.chtInterface.Size = new System.Drawing.Size(544, 150);
            this.chtInterface.TabIndex = 27;
            this.chtInterface.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Taxa de Utilização";
            this.chtInterface.Titles.Add(title1);
            // 
            // timerUpdateGraphInterface
            // 
            this.timerUpdateGraphInterface.Interval = 2000;
            this.timerUpdateGraphInterface.Tick += new System.EventHandler(this.timerUpdateGraphInterface_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(149, 535);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Saida";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 535);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Entrada";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(370, 535);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Entrada";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(432, 537);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Saida";
            // 
            // maskedIP
            // 
            this.maskedIP.Location = new System.Drawing.Point(6, 38);
            this.maskedIP.Mask = "###.###.###.###";
            this.maskedIP.Name = "maskedIP";
            this.maskedIP.Size = new System.Drawing.Size(88, 20);
            this.maskedIP.TabIndex = 1;
            this.maskedIP.Text = "000000000000";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 585);
            this.Controls.Add(this.maskedIP);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chtInterface);
            this.Controls.Add(this.numVersion);
            this.Controls.Add(this.numInterval);
            this.Controls.Add(this.numRestransmitions);
            this.Controls.Add(this.numTimeOut);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDiscardOut);
            this.Controls.Add(this.txtDiscardIn);
            this.Controls.Add(this.taxa);
            this.Controls.Add(this.txtErrorRateOut);
            this.Controls.Add(this.txtErrorRateIn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtResumeInterface);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbInterfaces);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtResume);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCommunit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de Interface";
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestransmitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtInterface)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCommunit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtResumeInterface;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtErrorRateIn;
        private System.Windows.Forms.TextBox txtErrorRateOut;
        private System.Windows.Forms.Label taxa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDiscardOut;
        private System.Windows.Forms.TextBox txtDiscardIn;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.NumericUpDown numTimeOut;
        private System.Windows.Forms.NumericUpDown numRestransmitions;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.NumericUpDown numVersion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtInterface;
        private System.Windows.Forms.Timer timerUpdateGraphInterface;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox maskedIP;
    }
}

