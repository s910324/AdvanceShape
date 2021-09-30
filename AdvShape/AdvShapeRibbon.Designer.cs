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
            this.components = new System.ComponentModel.Container();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
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
            this.group3 = this.Factory.CreateRibbonGroup();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.box1.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group2
            // 
            this.group2.Label = "group2";
            this.group2.Name = "group2";
            // 
            // group1
            // 
            this.group1.Items.Add(this.box1);
            this.group1.Items.Add(this.ShapeArrayDialog_RBPB);
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
            // 
            // group3
            // 
            this.group3.Items.Add(this.button1);
            this.group3.Label = "group3";
            this.group3.Name = "group3";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // button1
            // 
            this.button1.Label = "button1";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
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
    }

    partial class ThisRibbonCollection {
        internal Ribbon1 Ribbon1 {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
