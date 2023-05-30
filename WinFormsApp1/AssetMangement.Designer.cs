using ModelLiberary;

namespace WinFormsApp1
{
    partial class AssetMangement
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
            this.Titlelbl = new System.Windows.Forms.Label();
            this.namelbl = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.counterpartcmb = new System.Windows.Forms.ComboBox();
            this.areacmb = new System.Windows.Forms.ComboBox();
            this.counterpartlbl = new System.Windows.Forms.Label();
            this.arealbl = new System.Windows.Forms.Label();
            this.assetTypecmb = new System.Windows.Forms.ComboBox();
            this.assetTypelbl = new System.Windows.Forms.Label();
            this.TechTypecmb = new System.Windows.Forms.ComboBox();
            this.techTypelbl = new System.Windows.Forms.Label();
            this.latitudetxt = new System.Windows.Forms.TextBox();
            this.latitudelbl = new System.Windows.Forms.Label();
            this.longitudetxt = new System.Windows.Forms.TextBox();
            this.longitudelbl = new System.Windows.Forms.Label();
            this.startDatedtp = new System.Windows.Forms.DateTimePicker();
            this.startDatelbl = new System.Windows.Forms.Label();
            this.endDatedtp = new System.Windows.Forms.DateTimePicker();
            this.endDatelbl = new System.Windows.Forms.Label();
            this.capacitylbl = new System.Windows.Forms.Label();
            this.notestext = new System.Windows.Forms.RichTextBox();
            this.noteslbl = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.capacityNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // Titlelbl
            // 
            this.Titlelbl.AutoSize = true;
            this.Titlelbl.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Titlelbl.Location = new System.Drawing.Point(12, 9);
            this.Titlelbl.Name = "Titlelbl";
            this.Titlelbl.Size = new System.Drawing.Size(301, 47);
            this.Titlelbl.TabIndex = 0;
            this.Titlelbl.Text = "Asset Mangement";
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Location = new System.Drawing.Point(18, 65);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(39, 15);
            this.namelbl.TabIndex = 1;
            this.namelbl.Text = "Name";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(20, 83);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(248, 23);
            this.nametxt.TabIndex = 2;
            this.nametxt.TextChanged += new System.EventHandler(this.NameTxtChanged);
            // 
            // counterpartcmb
            // 
            this.counterpartcmb.FormattingEnabled = true;
            this.counterpartcmb.Location = new System.Drawing.Point(274, 83);
            this.counterpartcmb.Name = "counterpartcmb";
            this.counterpartcmb.Size = new System.Drawing.Size(121, 23);
            this.counterpartcmb.TabIndex = 3;
            this.counterpartcmb.SelectedIndexChanged += new System.EventHandler(this.ChangeCounterpart);
            // 
            // areacmb
            // 
            this.areacmb.FormattingEnabled = true;
            this.areacmb.Location = new System.Drawing.Point(401, 83);
            this.areacmb.Name = "areacmb";
            this.areacmb.Size = new System.Drawing.Size(121, 23);
            this.areacmb.TabIndex = 4;
            this.areacmb.SelectedIndexChanged += new System.EventHandler(this.ChangeArea);
            // 
            // counterpartlbl
            // 
            this.counterpartlbl.AutoSize = true;
            this.counterpartlbl.Location = new System.Drawing.Point(274, 65);
            this.counterpartlbl.Name = "counterpartlbl";
            this.counterpartlbl.Size = new System.Drawing.Size(71, 15);
            this.counterpartlbl.TabIndex = 5;
            this.counterpartlbl.Text = "Counterpart";
            // 
            // arealbl
            // 
            this.arealbl.AutoSize = true;
            this.arealbl.Location = new System.Drawing.Point(401, 65);
            this.arealbl.Name = "arealbl";
            this.arealbl.Size = new System.Drawing.Size(31, 15);
            this.arealbl.TabIndex = 6;
            this.arealbl.Text = "Area";
            // 
            // assetTypecmb
            // 
            this.assetTypecmb.FormattingEnabled = true;
            this.assetTypecmb.Location = new System.Drawing.Point(20, 134);
            this.assetTypecmb.Name = "assetTypecmb";
            this.assetTypecmb.Size = new System.Drawing.Size(121, 23);
            this.assetTypecmb.TabIndex = 7;
            this.assetTypecmb.SelectedIndexChanged += new System.EventHandler(this.ChangeAssetType);
            // 
            // assetTypelbl
            // 
            this.assetTypelbl.AutoSize = true;
            this.assetTypelbl.Location = new System.Drawing.Point(20, 116);
            this.assetTypelbl.Name = "assetTypelbl";
            this.assetTypelbl.Size = new System.Drawing.Size(62, 15);
            this.assetTypelbl.TabIndex = 8;
            this.assetTypelbl.Text = "Asset Type";
            // 
            // TechTypecmb
            // 
            this.TechTypecmb.FormattingEnabled = true;
            this.TechTypecmb.Location = new System.Drawing.Point(147, 134);
            this.TechTypecmb.Name = "TechTypecmb";
            this.TechTypecmb.Size = new System.Drawing.Size(121, 23);
            this.TechTypecmb.TabIndex = 9;
            this.TechTypecmb.SelectedIndexChanged += new System.EventHandler(this.ChangeTechType);
            // 
            // techTypelbl
            // 
            this.techTypelbl.AutoSize = true;
            this.techTypelbl.Location = new System.Drawing.Point(147, 116);
            this.techTypelbl.Name = "techTypelbl";
            this.techTypelbl.Size = new System.Drawing.Size(95, 15);
            this.techTypelbl.TabIndex = 10;
            this.techTypelbl.Text = "Technology Type";
            // 
            // latitudetxt
            // 
            this.latitudetxt.Location = new System.Drawing.Point(274, 134);
            this.latitudetxt.Name = "latitudetxt";
            this.latitudetxt.Size = new System.Drawing.Size(121, 23);
            this.latitudetxt.TabIndex = 11;
            this.latitudetxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckDecimalInput);
            // 
            // latitudelbl
            // 
            this.latitudelbl.AutoSize = true;
            this.latitudelbl.Location = new System.Drawing.Point(274, 116);
            this.latitudelbl.Name = "latitudelbl";
            this.latitudelbl.Size = new System.Drawing.Size(50, 15);
            this.latitudelbl.TabIndex = 12;
            this.latitudelbl.Text = "Latitude";
            // 
            // longitudetxt
            // 
            this.longitudetxt.Location = new System.Drawing.Point(401, 134);
            this.longitudetxt.Name = "longitudetxt";
            this.longitudetxt.Size = new System.Drawing.Size(121, 23);
            this.longitudetxt.TabIndex = 13;
            this.longitudetxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckDecimalInput);
            // 
            // longitudelbl
            // 
            this.longitudelbl.AutoSize = true;
            this.longitudelbl.Location = new System.Drawing.Point(402, 117);
            this.longitudelbl.Name = "longitudelbl";
            this.longitudelbl.Size = new System.Drawing.Size(61, 15);
            this.longitudelbl.TabIndex = 14;
            this.longitudelbl.Text = "Longitude";
            // 
            // startDatedtp
            // 
            this.startDatedtp.Location = new System.Drawing.Point(20, 183);
            this.startDatedtp.Name = "startDatedtp";
            this.startDatedtp.Size = new System.Drawing.Size(187, 23);
            this.startDatedtp.TabIndex = 15;
            this.startDatedtp.ValueChanged += new System.EventHandler(this.StartDate_ValueChanged);
            // 
            // startDatelbl
            // 
            this.startDatelbl.AutoSize = true;
            this.startDatelbl.Location = new System.Drawing.Point(20, 165);
            this.startDatelbl.Name = "startDatelbl";
            this.startDatelbl.Size = new System.Drawing.Size(58, 15);
            this.startDatelbl.TabIndex = 16;
            this.startDatelbl.Text = "Start Date";
            // 
            // endDatedtp
            // 
            this.endDatedtp.Location = new System.Drawing.Point(213, 183);
            this.endDatedtp.Name = "endDatedtp";
            this.endDatedtp.Size = new System.Drawing.Size(182, 23);
            this.endDatedtp.TabIndex = 17;
            this.endDatedtp.ValueChanged += new System.EventHandler(this.EndDateChange);
            // 
            // endDatelbl
            // 
            this.endDatelbl.AutoSize = true;
            this.endDatelbl.Location = new System.Drawing.Point(213, 165);
            this.endDatelbl.Name = "endDatelbl";
            this.endDatelbl.Size = new System.Drawing.Size(54, 15);
            this.endDatelbl.TabIndex = 18;
            this.endDatelbl.Text = "End Date";
            // 
            // capacitylbl
            // 
            this.capacitylbl.AutoSize = true;
            this.capacitylbl.Location = new System.Drawing.Point(401, 165);
            this.capacitylbl.Name = "capacitylbl";
            this.capacitylbl.Size = new System.Drawing.Size(86, 15);
            this.capacitylbl.TabIndex = 20;
            this.capacitylbl.Text = "Capacity (MW)";
            // 
            // notestext
            // 
            this.notestext.Location = new System.Drawing.Point(20, 234);
            this.notestext.Name = "notestext";
            this.notestext.Size = new System.Drawing.Size(502, 204);
            this.notestext.TabIndex = 21;
            this.notestext.Text = "";
            this.notestext.TextChanged += new System.EventHandler(this.NotesChanged);
            // 
            // noteslbl
            // 
            this.noteslbl.AutoSize = true;
            this.noteslbl.Location = new System.Drawing.Point(20, 216);
            this.noteslbl.Name = "noteslbl";
            this.noteslbl.Size = new System.Drawing.Size(38, 15);
            this.noteslbl.TabIndex = 22;
            this.noteslbl.Text = "Notes";
            // 
            // savebtn
            // 
            this.savebtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.savebtn.Location = new System.Drawing.Point(447, 444);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 23;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.SaveAsset);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(357, 444);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 24;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // capacityNumeric
            // 
            this.capacityNumeric.DecimalPlaces = 1;
            this.capacityNumeric.Location = new System.Drawing.Point(401, 183);
            this.capacityNumeric.Name = "capacityNumeric";
            this.capacityNumeric.Size = new System.Drawing.Size(120, 23);
            this.capacityNumeric.TabIndex = 25;
            this.capacityNumeric.ValueChanged += new System.EventHandler(this.CapacityChanged);
            // 
            // AssetMangement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 477);
            this.Controls.Add(this.capacityNumeric);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.noteslbl);
            this.Controls.Add(this.notestext);
            this.Controls.Add(this.capacitylbl);
            this.Controls.Add(this.endDatelbl);
            this.Controls.Add(this.endDatedtp);
            this.Controls.Add(this.startDatelbl);
            this.Controls.Add(this.startDatedtp);
            this.Controls.Add(this.longitudelbl);
            this.Controls.Add(this.longitudetxt);
            this.Controls.Add(this.latitudelbl);
            this.Controls.Add(this.latitudetxt);
            this.Controls.Add(this.techTypelbl);
            this.Controls.Add(this.TechTypecmb);
            this.Controls.Add(this.assetTypelbl);
            this.Controls.Add(this.assetTypecmb);
            this.Controls.Add(this.arealbl);
            this.Controls.Add(this.counterpartlbl);
            this.Controls.Add(this.areacmb);
            this.Controls.Add(this.counterpartcmb);
            this.Controls.Add(this.nametxt);
            this.Controls.Add(this.namelbl);
            this.Controls.Add(this.Titlelbl);
            this.Name = "AssetMangement";
            this.Text = "AssetMangement";
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label AssetNamelbl;
        private Label namelbl;
        private TextBox nametxt;
        private ComboBox counterpartcmb;
        private ComboBox areacmb;
        private Label counterpartlbl;
        private Label arealbl;
        private ComboBox assetTypecmb;
        private Label assetTypelbl;
        private ComboBox TechTypecmb;
        private Label techTypelbl;
        private TextBox latitudetxt;
        private Label latitudelbl;
        private TextBox longitudetxt;
        private Label longitudelbl;
        private DateTimePicker startDatedtp;
        private Label startDatelbl;
        private DateTimePicker endDatedtp;
        private Label endDatelbl;
        private Label capacitylbl;
        private RichTextBox notestext;
        private Label noteslbl;
        private Button savebtn;
        private Button cancelbtn;
        private NumericUpDown capacityNumeric;
        private Label Titlelbl;
    }
}