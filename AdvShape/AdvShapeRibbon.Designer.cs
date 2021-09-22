
namespace AdvShape {
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon1));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.comboBox1 = this.Factory.CreateRibbonComboBox();
            this.buttonGroup7 = this.Factory.CreateRibbonButtonGroup();
            this.button7 = this.Factory.CreateRibbonButton();
            this.button8 = this.Factory.CreateRibbonButton();
            this.button9 = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.ShapeAlignTopLeft = this.Factory.CreateRibbonButton();
            this.ShapeAlignTopCent = this.Factory.CreateRibbonButton();
            this.ShapeAlignTopRight = this.Factory.CreateRibbonButton();
            this.buttonGroup2 = this.Factory.CreateRibbonButtonGroup();
            this.ShapeAlignMidLeft = this.Factory.CreateRibbonButton();
            this.ShapeAlignMidCent = this.Factory.CreateRibbonButton();
            this.ShapeAlignMidRight = this.Factory.CreateRibbonButton();
            this.buttonGroup3 = this.Factory.CreateRibbonButtonGroup();
            this.ShapeAlignBotLeft = this.Factory.CreateRibbonButton();
            this.ShapeAlignBotCent = this.Factory.CreateRibbonButton();
            this.ShapeAlignBotRight = this.Factory.CreateRibbonButton();
            this.buttonGroup6 = this.Factory.CreateRibbonButtonGroup();
            this.buttonGroup5 = this.Factory.CreateRibbonButtonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.buttonGroup4 = this.Factory.CreateRibbonButtonGroup();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button5 = this.Factory.CreateRibbonButton();
            this.button6 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group2.SuspendLayout();
            this.buttonGroup7.SuspendLayout();
            this.group1.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            this.buttonGroup2.SuspendLayout();
            this.buttonGroup3.SuspendLayout();
            this.buttonGroup5.SuspendLayout();
            this.buttonGroup4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.comboBox1);
            this.group2.Items.Add(this.buttonGroup7);
            this.group2.Label = "group2";
            this.group2.Name = "group2";
            // 
            // comboBox1
            // 
            this.comboBox1.Label = "comboBox1";
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.ShowLabel = false;
            this.comboBox1.Text = null;
            this.comboBox1.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.comboBox1_TextChanged);
            // 
            // buttonGroup7
            // 
            this.buttonGroup7.Items.Add(this.button7);
            this.buttonGroup7.Items.Add(this.button8);
            this.buttonGroup7.Items.Add(this.button9);
            this.buttonGroup7.Name = "buttonGroup7";
            // 
            // button7
            // 
            this.button7.Label = "button7";
            this.button7.Name = "button7";
            this.button7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Label = "button8";
            this.button8.Name = "button8";
            // 
            // button9
            // 
            this.button9.Label = "button9";
            this.button9.Name = "button9";
            // 
            // group1
            // 
            this.group1.Items.Add(this.buttonGroup1);
            this.group1.Items.Add(this.buttonGroup2);
            this.group1.Items.Add(this.buttonGroup3);
            this.group1.Items.Add(this.buttonGroup6);
            this.group1.Items.Add(this.buttonGroup5);
            this.group1.Items.Add(this.buttonGroup4);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Items.Add(this.ShapeAlignTopLeft);
            this.buttonGroup1.Items.Add(this.ShapeAlignTopCent);
            this.buttonGroup1.Items.Add(this.ShapeAlignTopRight);
            this.buttonGroup1.Name = "buttonGroup1";
            // 
            // ShapeAlignTopLeft
            // 
            this.ShapeAlignTopLeft.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignTopLeft.Image")));
            this.ShapeAlignTopLeft.Label = "ShapeAlignTopLeft";
            this.ShapeAlignTopLeft.Name = "ShapeAlignTopLeft";
            this.ShapeAlignTopLeft.ShowImage = true;
            this.ShapeAlignTopLeft.ShowLabel = false;
            this.ShapeAlignTopLeft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAlignTopLeft_Click);
            // 
            // ShapeAlignTopCent
            // 
            this.ShapeAlignTopCent.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignTopCent.Image")));
            this.ShapeAlignTopCent.Label = "ShapeAlignTopCent";
            this.ShapeAlignTopCent.Name = "ShapeAlignTopCent";
            this.ShapeAlignTopCent.ShowImage = true;
            this.ShapeAlignTopCent.ShowLabel = false;
            this.ShapeAlignTopCent.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAlignTopCent_Click);
            // 
            // ShapeAlignTopRight
            // 
            this.ShapeAlignTopRight.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignTopRight.Image")));
            this.ShapeAlignTopRight.Label = "ShapeAlignTopRight";
            this.ShapeAlignTopRight.Name = "ShapeAlignTopRight";
            this.ShapeAlignTopRight.ShowImage = true;
            this.ShapeAlignTopRight.ShowLabel = false;
            // 
            // buttonGroup2
            // 
            this.buttonGroup2.Items.Add(this.ShapeAlignMidLeft);
            this.buttonGroup2.Items.Add(this.ShapeAlignMidCent);
            this.buttonGroup2.Items.Add(this.ShapeAlignMidRight);
            this.buttonGroup2.Name = "buttonGroup2";
            // 
            // ShapeAlignMidLeft
            // 
            this.ShapeAlignMidLeft.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignMidLeft.Image")));
            this.ShapeAlignMidLeft.Label = "button3";
            this.ShapeAlignMidLeft.Name = "ShapeAlignMidLeft";
            this.ShapeAlignMidLeft.ShowImage = true;
            this.ShapeAlignMidLeft.ShowLabel = false;
            this.ShapeAlignMidLeft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAlignMidLeft_Click);
            // 
            // ShapeAlignMidCent
            // 
            this.ShapeAlignMidCent.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignMidCent.Image")));
            this.ShapeAlignMidCent.Label = "button4";
            this.ShapeAlignMidCent.Name = "ShapeAlignMidCent";
            this.ShapeAlignMidCent.ShowImage = true;
            this.ShapeAlignMidCent.ShowLabel = false;
            // 
            // ShapeAlignMidRight
            // 
            this.ShapeAlignMidRight.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignMidRight.Image")));
            this.ShapeAlignMidRight.Label = "ShapeAlignMidRight";
            this.ShapeAlignMidRight.Name = "ShapeAlignMidRight";
            this.ShapeAlignMidRight.ShowImage = true;
            this.ShapeAlignMidRight.ShowLabel = false;
            // 
            // buttonGroup3
            // 
            this.buttonGroup3.Items.Add(this.ShapeAlignBotLeft);
            this.buttonGroup3.Items.Add(this.ShapeAlignBotCent);
            this.buttonGroup3.Items.Add(this.ShapeAlignBotRight);
            this.buttonGroup3.Name = "buttonGroup3";
            // 
            // ShapeAlignBotLeft
            // 
            this.ShapeAlignBotLeft.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignBotLeft.Image")));
            this.ShapeAlignBotLeft.Label = "ShapeAlignBotLeft";
            this.ShapeAlignBotLeft.Name = "ShapeAlignBotLeft";
            this.ShapeAlignBotLeft.ShowImage = true;
            this.ShapeAlignBotLeft.ShowLabel = false;
            this.ShapeAlignBotLeft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAlignBotLeft_Click);
            // 
            // ShapeAlignBotCent
            // 
            this.ShapeAlignBotCent.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignBotCent.Image")));
            this.ShapeAlignBotCent.Label = "ShapeAlignBotCent";
            this.ShapeAlignBotCent.Name = "ShapeAlignBotCent";
            this.ShapeAlignBotCent.ShowImage = true;
            this.ShapeAlignBotCent.ShowLabel = false;
            // 
            // ShapeAlignBotRight
            // 
            this.ShapeAlignBotRight.Image = ((System.Drawing.Image)(resources.GetObject("ShapeAlignBotRight.Image")));
            this.ShapeAlignBotRight.Label = "ShapeAlignBotRight";
            this.ShapeAlignBotRight.Name = "ShapeAlignBotRight";
            this.ShapeAlignBotRight.ShowImage = true;
            this.ShapeAlignBotRight.ShowLabel = false;
            // 
            // buttonGroup6
            // 
            this.buttonGroup6.Name = "buttonGroup6";
            // 
            // buttonGroup5
            // 
            this.buttonGroup5.Items.Add(this.button1);
            this.buttonGroup5.Items.Add(this.button2);
            this.buttonGroup5.Items.Add(this.button3);
            this.buttonGroup5.Name = "buttonGroup5";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "button1";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.ShowLabel = false;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Label = "button2";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.ShowLabel = false;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Label = "button3";
            this.button3.Name = "button3";
            this.button3.ShowImage = true;
            this.button3.ShowLabel = false;
            // 
            // buttonGroup4
            // 
            this.buttonGroup4.Items.Add(this.button4);
            this.buttonGroup4.Items.Add(this.button5);
            this.buttonGroup4.Items.Add(this.button6);
            this.buttonGroup4.Name = "buttonGroup4";
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Label = "button4";
            this.button4.Name = "button4";
            this.button4.ShowImage = true;
            this.button4.ShowLabel = false;
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Label = "button5";
            this.button5.Name = "button5";
            this.button5.ShowImage = true;
            this.button5.ShowLabel = false;
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Label = "button6";
            this.button6.Name = "button6";
            this.button6.ShowImage = true;
            this.button6.ShowLabel = false;
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.buttonGroup7.ResumeLayout(false);
            this.buttonGroup7.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();
            this.buttonGroup2.ResumeLayout(false);
            this.buttonGroup2.PerformLayout();
            this.buttonGroup3.ResumeLayout(false);
            this.buttonGroup3.PerformLayout();
            this.buttonGroup5.ResumeLayout(false);
            this.buttonGroup5.PerformLayout();
            this.buttonGroup4.ResumeLayout(false);
            this.buttonGroup4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignTopLeft;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignTopCent;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignTopRight;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignMidLeft;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignMidCent;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignMidRight;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignBotLeft;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignBotCent;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignBotRight;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup7;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button8;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button9;
    }

    partial class ThisRibbonCollection {
        internal Ribbon1 Ribbon1 {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
