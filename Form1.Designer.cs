namespace Rx_des_capteurs_sans_fils
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.linearGauge1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.linearScaleBackgroundLayerComponent2 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.linearScaleComponent3 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.linearScaleLevelComponent2 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.linearScaleComponent4 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linearScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.linearScaleComponent2 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.linearScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.linearScaleLevelComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 109);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(320, 212);
            this.textBox1.TabIndex = 1;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(9, 32);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(233, 21);
            this.textBoxInput.TabIndex = 2;
            this.textBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInput_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Text a envoyer :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Envoyer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 372);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messages";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(73, 57);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 22);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Image = global::Rx_des_capteurs_sans_fils.Properties.Resources.description;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(9, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(320, 39);
            this.button2.TabIndex = 10;
            this.button2.Text = "Paramétrage";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fréquence:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gaugeControl1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(364, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 372);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consommation";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.linearGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(6, 19);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(157, 302);
            this.gaugeControl1.TabIndex = 11;
            // 
            // linearGauge1
            // 
            this.linearGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.linearScaleBackgroundLayerComponent2});
            this.linearGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 145, 288);
            this.linearGauge1.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.linearScaleLevelComponent2});
            this.linearGauge1.Name = "lGauge1";
            this.linearGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.linearScaleComponent3,
            this.linearScaleComponent4});
            // 
            // linearScaleBackgroundLayerComponent2
            // 
            this.linearScaleBackgroundLayerComponent2.LinearScale = this.linearScaleComponent3;
            this.linearScaleBackgroundLayerComponent2.Name = "bg1";
            this.linearScaleBackgroundLayerComponent2.ScaleEndPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.15F);
            this.linearScaleBackgroundLayerComponent2.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.85F);
            this.linearScaleBackgroundLayerComponent2.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style4;
            this.linearScaleBackgroundLayerComponent2.ZOrder = 1000;
            // 
            // linearScaleComponent3
            // 
            this.linearScaleComponent3.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.linearScaleComponent3.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.linearScaleComponent3.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 37F);
            this.linearScaleComponent3.MajorTickCount = 6;
            this.linearScaleComponent3.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent3.MajorTickmark.ShapeOffset = 5F;
            this.linearScaleComponent3.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_2;
            this.linearScaleComponent3.MajorTickmark.TextOffset = 31F;
            this.linearScaleComponent3.MaxValue = 500F;
            this.linearScaleComponent3.MinorTickCount = 4;
            this.linearScaleComponent3.MinorTickmark.ShapeOffset = 5F;
            this.linearScaleComponent3.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_1;
            this.linearScaleComponent3.Name = "scale1";
            this.linearScaleComponent3.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 213F);
            this.linearScaleComponent3.Value = 500F;
            // 
            // linearScaleLevelComponent2
            // 
            this.linearScaleLevelComponent2.LinearScale = this.linearScaleComponent3;
            this.linearScaleLevelComponent2.Name = "level1";
            this.linearScaleLevelComponent2.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style4;
            this.linearScaleLevelComponent2.ZOrder = -50;
            // 
            // linearScaleComponent4
            // 
            this.linearScaleComponent4.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.linearScaleComponent4.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 37F);
            this.linearScaleComponent4.MajorTickCount = 6;
            this.linearScaleComponent4.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent4.MajorTickmark.ShapeOffset = -17F;
            this.linearScaleComponent4.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_2;
            this.linearScaleComponent4.MajorTickmark.TextOffset = -30F;
            this.linearScaleComponent4.MaxValue = 50F;
            this.linearScaleComponent4.MinorTickCount = 4;
            this.linearScaleComponent4.MinorTickmark.ShapeOffset = -11F;
            this.linearScaleComponent4.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_1;
            this.linearScaleComponent4.Name = "scale2";
            this.linearScaleComponent4.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 213F);
            this.linearScaleComponent4.Value = 50F;
            // 
            // button3
            // 
            this.button3.Image = global::Rx_des_capteurs_sans_fils.Properties.Resources.description;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(6, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 39);
            this.button3.TabIndex = 10;
            this.button3.Text = "Info Radio";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // linearScaleComponent1
            // 
            this.linearScaleComponent1.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.linearScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.linearScaleComponent1.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 37F);
            this.linearScaleComponent1.MajorTickCount = 6;
            this.linearScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent1.MajorTickmark.ShapeOffset = 5F;
            this.linearScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_2;
            this.linearScaleComponent1.MajorTickmark.TextOffset = 31F;
            this.linearScaleComponent1.MaxValue = 500F;
            this.linearScaleComponent1.MinorTickCount = 4;
            this.linearScaleComponent1.MinorTickmark.ShapeOffset = 5F;
            this.linearScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_1;
            this.linearScaleComponent1.Name = "scale1";
            this.linearScaleComponent1.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 213F);
            this.linearScaleComponent1.Value = 250F;
            // 
            // linearScaleComponent2
            // 
            this.linearScaleComponent2.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.linearScaleComponent2.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 37F);
            this.linearScaleComponent2.MajorTickCount = 6;
            this.linearScaleComponent2.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent2.MajorTickmark.ShapeOffset = -17F;
            this.linearScaleComponent2.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_2;
            this.linearScaleComponent2.MajorTickmark.TextOffset = -30F;
            this.linearScaleComponent2.MaxValue = 50F;
            this.linearScaleComponent2.MinorTickCount = 4;
            this.linearScaleComponent2.MinorTickmark.ShapeOffset = -11F;
            this.linearScaleComponent2.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style4_1;
            this.linearScaleComponent2.Name = "scale2";
            this.linearScaleComponent2.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 213F);
            // 
            // linearScaleBackgroundLayerComponent1
            // 
            this.linearScaleBackgroundLayerComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleBackgroundLayerComponent1.Name = "bg1";
            this.linearScaleBackgroundLayerComponent1.ScaleEndPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.15F);
            this.linearScaleBackgroundLayerComponent1.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.85F);
            this.linearScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style4;
            this.linearScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // linearScaleLevelComponent1
            // 
            this.linearScaleLevelComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleLevelComponent1.Name = "level1";
            this.linearScaleLevelComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style13;
            this.linearScaleLevelComponent1.ZOrder = -50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 396);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Réseaux de Capteurs BlueTooth";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}

