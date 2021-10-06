namespace AdvShape {
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 

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
            this.components = new System.ComponentModel.Container();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.editBox4 = this.Factory.CreateRibbonEditBox();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.ShapeAlignDialog_RBPB = this.Factory.CreateRibbonButton();
            this.ShapeAlignMenu = this.Factory.CreateRibbonMenu();
            this.AlignTop_RBPB = this.Factory.CreateRibbonButton();
            this.AlignMid_RBPB = this.Factory.CreateRibbonButton();
            this.AlignBottom_RBPB = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.AlignLeft_RBPB = this.Factory.CreateRibbonButton();
            this.AlignCent_RBPB = this.Factory.CreateRibbonButton();
            this.AlignRight_RBPB = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.AlignTopLeft_RBPB = this.Factory.CreateRibbonButton();
            this.AlignMidLeft_RBPB = this.Factory.CreateRibbonButton();
            this.AlignBottomLeft_RBPB = this.Factory.CreateRibbonButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.AlignTopCent_RBPB = this.Factory.CreateRibbonButton();
            this.AlignMidCent_RBPB = this.Factory.CreateRibbonButton();
            this.AlignBottomCent_RBPB = this.Factory.CreateRibbonButton();
            this.separator4 = this.Factory.CreateRibbonSeparator();
            this.AlignTopRight_RBPB = this.Factory.CreateRibbonButton();
            this.AlignMidRight_RBPB = this.Factory.CreateRibbonButton();
            this.AlignBottomRight_RBPB = this.Factory.CreateRibbonButton();
            this.ShapeArrayDialog_RBPB = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.box2 = this.Factory.CreateRibbonBox();
            this.ShapeWidthDec_RBPB = this.Factory.CreateRibbonButton();
            this.label4 = this.Factory.CreateRibbonLabel();
            this.ShapeWidth_RBET = this.Factory.CreateRibbonEditBox();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.ShapeWidthInc_RBPB = this.Factory.CreateRibbonButton();
            this.box3 = this.Factory.CreateRibbonBox();
            this.ShapeHeightDec_RBPB = this.Factory.CreateRibbonButton();
            this.label5 = this.Factory.CreateRibbonLabel();
            this.ShapeHeight_RBET = this.Factory.CreateRibbonEditBox();
            this.label2 = this.Factory.CreateRibbonLabel();
            this.ShapeHeightInc_RBPB = this.Factory.CreateRibbonButton();
            this.box4 = this.Factory.CreateRibbonBox();
            this.ShapeAngleDec_RBPB = this.Factory.CreateRibbonButton();
            this.label6 = this.Factory.CreateRibbonLabel();
            this.ShapeAngle_RBET = this.Factory.CreateRibbonEditBox();
            this.label3 = this.Factory.CreateRibbonLabel();
            this.ShapeAngleInc_RBPB = this.Factory.CreateRibbonButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tab1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group1.SuspendLayout();
            this.box1.SuspendLayout();
            this.group3.SuspendLayout();
            this.box2.SuspendLayout();
            this.box3.SuspendLayout();
            this.box4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "AdvShape";
            this.tab1.Name = "tab1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.editBox4);
            this.group2.Label = "group2";
            this.group2.Name = "group2";
            // 
            // editBox4
            // 
            this.editBox4.Label = "editBox4";
            this.editBox4.Name = "editBox4";
            this.editBox4.Text = null;
            // 
            // group1
            // 
            this.group1.Items.Add(this.box1);
            this.group1.Items.Add(this.ShapeArrayDialog_RBPB);
            this.group1.Items.Add(this.button1);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // box1
            // 
            this.box1.Items.Add(this.ShapeAlignDialog_RBPB);
            this.box1.Items.Add(this.ShapeAlignMenu);
            this.box1.Name = "box1";
            // 
            // ShapeAlignDialog_RBPB
            // 
            this.ShapeAlignDialog_RBPB.Label = "Shape Align";
            this.ShapeAlignDialog_RBPB.Name = "ShapeAlignDialog_RBPB";
            this.ShapeAlignDialog_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAlignDialog_RBPB_Click);
            // 
            // ShapeAlignMenu
            // 
            this.ShapeAlignMenu.Items.Add(this.AlignTop_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignMid_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignBottom_RBPB);
            this.ShapeAlignMenu.Items.Add(this.separator1);
            this.ShapeAlignMenu.Items.Add(this.AlignLeft_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignCent_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignRight_RBPB);
            this.ShapeAlignMenu.Items.Add(this.separator2);
            this.ShapeAlignMenu.Items.Add(this.AlignTopLeft_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignMidLeft_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignBottomLeft_RBPB);
            this.ShapeAlignMenu.Items.Add(this.separator3);
            this.ShapeAlignMenu.Items.Add(this.AlignTopCent_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignMidCent_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignBottomCent_RBPB);
            this.ShapeAlignMenu.Items.Add(this.separator4);
            this.ShapeAlignMenu.Items.Add(this.AlignTopRight_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignMidRight_RBPB);
            this.ShapeAlignMenu.Items.Add(this.AlignBottomRight_RBPB);
            this.ShapeAlignMenu.Label = "Align";
            this.ShapeAlignMenu.Name = "ShapeAlignMenu";
            this.ShapeAlignMenu.ShowLabel = false;
            // 
            // AlignTop_RBPB
            // 
            this.AlignTop_RBPB.Label = "Align Top";
            this.AlignTop_RBPB.Name = "AlignTop_RBPB";
            this.AlignTop_RBPB.ShowImage = true;
            // 
            // AlignMid_RBPB
            // 
            this.AlignMid_RBPB.Label = "Align Mid";
            this.AlignMid_RBPB.Name = "AlignMid_RBPB";
            this.AlignMid_RBPB.ShowImage = true;
            // 
            // AlignBottom_RBPB
            // 
            this.AlignBottom_RBPB.Label = "Align Bottom";
            this.AlignBottom_RBPB.Name = "AlignBottom_RBPB";
            this.AlignBottom_RBPB.ShowImage = true;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // AlignLeft_RBPB
            // 
            this.AlignLeft_RBPB.Label = "Align Left";
            this.AlignLeft_RBPB.Name = "AlignLeft_RBPB";
            this.AlignLeft_RBPB.ShowImage = true;
            // 
            // AlignCent_RBPB
            // 
            this.AlignCent_RBPB.Label = "Align Center";
            this.AlignCent_RBPB.Name = "AlignCent_RBPB";
            this.AlignCent_RBPB.ShowImage = true;
            // 
            // AlignRight_RBPB
            // 
            this.AlignRight_RBPB.Label = "Align Right";
            this.AlignRight_RBPB.Name = "AlignRight_RBPB";
            this.AlignRight_RBPB.ShowImage = true;
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // AlignTopLeft_RBPB
            // 
            this.AlignTopLeft_RBPB.Label = "Align Top Left";
            this.AlignTopLeft_RBPB.Name = "AlignTopLeft_RBPB";
            this.AlignTopLeft_RBPB.ShowImage = true;
            // 
            // AlignMidLeft_RBPB
            // 
            this.AlignMidLeft_RBPB.Label = "Align Mid Left";
            this.AlignMidLeft_RBPB.Name = "AlignMidLeft_RBPB";
            this.AlignMidLeft_RBPB.ShowImage = true;
            // 
            // AlignBottomLeft_RBPB
            // 
            this.AlignBottomLeft_RBPB.Label = "Align Bottom Left";
            this.AlignBottomLeft_RBPB.Name = "AlignBottomLeft_RBPB";
            this.AlignBottomLeft_RBPB.ShowImage = true;
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // AlignTopCent_RBPB
            // 
            this.AlignTopCent_RBPB.Label = "Align Top Center";
            this.AlignTopCent_RBPB.Name = "AlignTopCent_RBPB";
            this.AlignTopCent_RBPB.ShowImage = true;
            // 
            // AlignMidCent_RBPB
            // 
            this.AlignMidCent_RBPB.Label = "Align Mid Center";
            this.AlignMidCent_RBPB.Name = "AlignMidCent_RBPB";
            this.AlignMidCent_RBPB.ShowImage = true;
            // 
            // AlignBottomCent_RBPB
            // 
            this.AlignBottomCent_RBPB.Label = "Align Bottom Center";
            this.AlignBottomCent_RBPB.Name = "AlignBottomCent_RBPB";
            this.AlignBottomCent_RBPB.ShowImage = true;
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            // 
            // AlignTopRight_RBPB
            // 
            this.AlignTopRight_RBPB.Label = "Align Top Right";
            this.AlignTopRight_RBPB.Name = "AlignTopRight_RBPB";
            this.AlignTopRight_RBPB.ShowImage = true;
            // 
            // AlignMidRight_RBPB
            // 
            this.AlignMidRight_RBPB.Label = "Align Mid Right";
            this.AlignMidRight_RBPB.Name = "AlignMidRight_RBPB";
            this.AlignMidRight_RBPB.ShowImage = true;
            // 
            // AlignBottomRight_RBPB
            // 
            this.AlignBottomRight_RBPB.Label = "Align Bottom Right";
            this.AlignBottomRight_RBPB.Name = "AlignBottomRight_RBPB";
            this.AlignBottomRight_RBPB.ShowImage = true;
            // 
            // ShapeArrayDialog_RBPB
            // 
            this.ShapeArrayDialog_RBPB.Label = "Shape Array";
            this.ShapeArrayDialog_RBPB.Name = "ShapeArrayDialog_RBPB";
            this.ShapeArrayDialog_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeArrayDialog_RBPB_Click);
            // 
            // button1
            // 
            this.button1.Label = "button1";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.box2);
            this.group3.Items.Add(this.box3);
            this.group3.Items.Add(this.box4);
            this.group3.Label = "Shape Attributes";
            this.group3.Name = "group3";
            // 
            // box2
            // 
            this.box2.Items.Add(this.ShapeWidthDec_RBPB);
            this.box2.Items.Add(this.label4);
            this.box2.Items.Add(this.ShapeWidth_RBET);
            this.box2.Items.Add(this.label1);
            this.box2.Items.Add(this.ShapeWidthInc_RBPB);
            this.box2.Name = "box2";
            // 
            // ShapeWidthDec_RBPB
            // 
            this.ShapeWidthDec_RBPB.Label = "◃";
            this.ShapeWidthDec_RBPB.Name = "ShapeWidthDec_RBPB";
            this.ShapeWidthDec_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeWidthDec_RBPB_Click);
            // 
            // label4
            // 
            this.label4.Label = "⇆";
            this.label4.Name = "label4";
            // 
            // ShapeWidth_RBET
            // 
            this.ShapeWidth_RBET.Label = "editBox1";
            this.ShapeWidth_RBET.Name = "ShapeWidth_RBET";
            this.ShapeWidth_RBET.ShowLabel = false;
            this.ShapeWidth_RBET.Text = null;
            this.ShapeWidth_RBET.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeWidth_RBET_TextChanged);
            // 
            // label1
            // 
            this.label1.Label = " cm";
            this.label1.Name = "label1";
            // 
            // ShapeWidthInc_RBPB
            // 
            this.ShapeWidthInc_RBPB.Label = "▸";
            this.ShapeWidthInc_RBPB.Name = "ShapeWidthInc_RBPB";
            this.ShapeWidthInc_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeWidthInc_RBPB_Click);
            // 
            // box3
            // 
            this.box3.Items.Add(this.ShapeHeightDec_RBPB);
            this.box3.Items.Add(this.label5);
            this.box3.Items.Add(this.ShapeHeight_RBET);
            this.box3.Items.Add(this.label2);
            this.box3.Items.Add(this.ShapeHeightInc_RBPB);
            this.box3.Name = "box3";
            // 
            // ShapeHeightDec_RBPB
            // 
            this.ShapeHeightDec_RBPB.Label = "◃";
            this.ShapeHeightDec_RBPB.Name = "ShapeHeightDec_RBPB";
            this.ShapeHeightDec_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeHeightDec_RBPB_Click);
            // 
            // label5
            // 
            this.label5.Label = "⇵";
            this.label5.Name = "label5";
            // 
            // ShapeHeight_RBET
            // 
            this.ShapeHeight_RBET.Label = "editBox2";
            this.ShapeHeight_RBET.Name = "ShapeHeight_RBET";
            this.ShapeHeight_RBET.ShowLabel = false;
            this.ShapeHeight_RBET.Text = null;
            this.ShapeHeight_RBET.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeHeight_RBET_TextChanged);
            // 
            // label2
            // 
            this.label2.Label = " cm";
            this.label2.Name = "label2";
            // 
            // ShapeHeightInc_RBPB
            // 
            this.ShapeHeightInc_RBPB.Label = "▸";
            this.ShapeHeightInc_RBPB.Name = "ShapeHeightInc_RBPB";
            this.ShapeHeightInc_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeHeightInc_RBPB_Click);
            // 
            // box4
            // 
            this.box4.Items.Add(this.ShapeAngleDec_RBPB);
            this.box4.Items.Add(this.label6);
            this.box4.Items.Add(this.ShapeAngle_RBET);
            this.box4.Items.Add(this.label3);
            this.box4.Items.Add(this.ShapeAngleInc_RBPB);
            this.box4.Name = "box4";
            // 
            // ShapeAngleDec_RBPB
            // 
            this.ShapeAngleDec_RBPB.Label = "◃";
            this.ShapeAngleDec_RBPB.Name = "ShapeAngleDec_RBPB";
            this.ShapeAngleDec_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAngleDec_RBPB_Click);
            // 
            // label6
            // 
            this.label6.Label = "⍉";
            this.label6.Name = "label6";
            // 
            // ShapeAngle_RBET
            // 
            this.ShapeAngle_RBET.Label = "editBox3";
            this.ShapeAngle_RBET.Name = "ShapeAngle_RBET";
            this.ShapeAngle_RBET.ShowLabel = false;
            this.ShapeAngle_RBET.Text = null;
            this.ShapeAngle_RBET.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAngle_RBET_TextChanged);
            // 
            // label3
            // 
            this.label3.Label = "deg";
            this.label3.Name = "label3";
            // 
            // ShapeAngleInc_RBPB
            // 
            this.ShapeAngleInc_RBPB.Label = "▸";
            this.ShapeAngleInc_RBPB.Name = "ShapeAngleInc_RBPB";
            this.ShapeAngleInc_RBPB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShapeAngleInc_RBPB_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
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
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu ShapeAlignMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeArrayDialog_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignTop_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignMid_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignBottom_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignLeft_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignRight_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignTopLeft_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignMidLeft_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignBottomLeft_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignTopCent_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignMidCent_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignCent_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignBottomCent_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignTopRight_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignMidRight_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAlignDialog_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AlignBottomRight_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeWidthDec_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox ShapeWidth_RBET;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeWidthInc_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeHeightDec_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox ShapeHeight_RBET;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeHeightInc_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label1;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label2;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAngleDec_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox ShapeAngle_RBET;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShapeAngleInc_RBPB;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox4;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label4;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label5;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label6;
    }

    partial class ThisRibbonCollection {
        internal Ribbon1 Ribbon1 {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
