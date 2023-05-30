
using ModelLiberary;
using System.Data;
using System.Windows.Forms;
using TestData;
using WinFormsApp1.Controllers;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private AssetController assetController = new AssetController();
        private List<Asset>? assets;
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            LoadAssets();
        }

        public async void LoadAssets()
        {
            assets = await assetController.GetAssetsAsync();
            SetupTitles();
            FlowLayoutInit(assets);
            FlowLayoutInit(assets);
        }

        public void SetupTitles()
        {
            Label nameTitlelbl = new Label();
            nameTitlelbl.Text = "Name";
            titlesflp.Controls.Add(nameTitlelbl);

            Label counterpartTitlelbl = new Label();
            counterpartTitlelbl.Text = "Counterpart";
            titlesflp.Controls.Add(counterpartTitlelbl);

            Label areaTitlelbl = new Label();
            areaTitlelbl.Text = "Area";
            titlesflp.Controls.Add(areaTitlelbl);

            Label assetTypeTitlelbl = new Label();
            assetTypeTitlelbl.Text = "Asset Type";
            titlesflp.Controls.Add(assetTypeTitlelbl);

            Label techTypeTitlelbl = new Label();
            techTypeTitlelbl.Text = "Technology Type";
            titlesflp.Controls.Add(techTypeTitlelbl);

            Label capacityTitlelbl = new Label();
            capacityTitlelbl.Text = "Capacity";
            capacityTitlelbl.TextAlign = ContentAlignment.TopCenter;
            titlesflp.Controls.Add(capacityTitlelbl);

            Label startDateTitlelbl = new Label();
            startDateTitlelbl.Text = "Start Date";
            titlesflp.Controls.Add(startDateTitlelbl);

            Label endDateTitlelbl = new Label();
            endDateTitlelbl.Text = "End Date";
            titlesflp.Controls.Add(endDateTitlelbl);

            Label stateTitlelbl = new Label();
            stateTitlelbl.Text = "State";
            titlesflp.Controls.Add(stateTitlelbl);
        }

        public void FlowLayoutInit(List<Asset> assets)
        {
            const int CB_SETCUEBANNER = 0x1703;

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);
            foreach (Asset asset in assets)
            {
                AddLabels(asset);
                ComboBox comboBox = new ComboBox();
                comboBox.Items.Add("View");
                if(asset.state.ID.Equals(1))
                {
                    comboBox.Items.Add("Approve");
                    comboBox.Items.Add("Delete");
                }
                comboBox.Name = asset.Name;
                comboBox.SelectedIndexChanged += new EventHandler((object o, EventArgs e) =>
                {
                    if (comboBox.SelectedIndex.Equals(0))
                    {
                        AssetMangement assetMangement = new AssetMangement(asset, assets);
                        assetMangement.ShowDialog();
                    }
                    else if (comboBox.SelectedIndex.Equals(1))
                    {
                        DialogResult dialogResult = MessageBox.Show($"Do you wish to approve the following asset: {asset.Name}", "Approve", MessageBoxButtons.YesNo);
                        if(dialogResult == DialogResult.Yes)
                        {
                            ApproveAsset(asset);
                        }
                        else if(dialogResult == DialogResult.No)
                        {

                        }
                    }
                    else if (comboBox.SelectedIndex.Equals(2))
                    {
                        DialogResult dialogResult = MessageBox.Show($"Do you wish to delete the following asset: {asset.Name}", "Delete", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DeleteAsset(asset.ID);

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    
                });
                comboBox.MouseWheel += new MouseEventHandler(comboBox_MouseWheel);
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                SendMessage(comboBox.Handle, CB_SETCUEBANNER, 0, "Actions");
                flowLayoutPanel1.Controls.Add(comboBox);
            }

            void comboBox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }
        private async void DeleteAsset(int id)
        {
            bool succes = await assetController.DeleteAsset(id);
            if (succes)
            {
                MessageBox.Show("Asset has been deleted");
                Updatelist();
            }
            else
            {
                MessageBox.Show("Asset could not be deleted, try again later");
            }
        }
        private async void ApproveAsset(Asset asset)
        {
            asset.state.ID = 2;
            asset.ApprovedAt = DateTime.Now;
            asset.ApprovedBy = "Jens";  //Hardcoded value since no User funktionalitet implementet
            bool succes = await assetController.UpdateAsset(asset);
            if (succes)
            {
                MessageBox.Show("Asset has been approved");
                Updatelist();
            }
            else 
            { 
                MessageBox.Show("Asset could not be approved, try again later"); 
            }
        }
        private void AddLabels(Asset asset)
        {
            Label namelbl = new Label();
            namelbl.Text = asset.Name;
            namelbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(namelbl);
            new ToolTip().SetToolTip(namelbl, namelbl.Text);

            Label counterpartlbl = new Label();
            counterpartlbl.Text = asset.Counterpart.Name;
            counterpartlbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(counterpartlbl);
            new ToolTip().SetToolTip(counterpartlbl, counterpartlbl.Text);

            Label arealbl = new Label();
            arealbl.Text = asset.Area.Name;
            arealbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(arealbl);
            new ToolTip().SetToolTip(arealbl, arealbl.Text);

            Label assetTypelbl = new Label();
            assetTypelbl.Text = asset.AssetType.Name;
            assetTypelbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(assetTypelbl);
            new ToolTip().SetToolTip(assetTypelbl, assetTypelbl.Text);

            Label technologyTypelbl = new Label();
            if(asset.technologyType.Name.Length > 13)
            {
                technologyTypelbl.Text = $"{asset.technologyType.Name.Substring(0, 13)}...";
            }
            else
            {
                technologyTypelbl.Text = asset.technologyType.Name;
            }
            technologyTypelbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(technologyTypelbl);
            new ToolTip().SetToolTip(technologyTypelbl, asset.technologyType.Name);

            Label capacitylbl = new Label();
            capacitylbl.Text = $"{asset.Capacity} MW";
            capacitylbl.TextAlign = ContentAlignment.MiddleRight;
            flowLayoutPanel1.Controls.Add(capacitylbl);
            new ToolTip().SetToolTip(capacitylbl, capacitylbl.Text);

            Label startDatelbl = new Label();
            startDatelbl.Text = asset.ContractStart.ToShortDateString();
            startDatelbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(startDatelbl);
            new ToolTip().SetToolTip(startDatelbl, startDatelbl.Text);

            Label endDatelbl = new Label();
            endDatelbl.Text = asset.ContractEnd.ToShortDateString();
            endDatelbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(endDatelbl);
            new ToolTip().SetToolTip(endDatelbl, endDatelbl.Text);

            Label statelbl = new Label();
            statelbl.Text = asset.state.Name;
            statelbl.TextAlign = ContentAlignment.MiddleLeft;
            flowLayoutPanel1.Controls.Add(statelbl);
            new ToolTip().SetToolTip(statelbl, statelbl.Text);
        }

        private void NewAsset(Object sender, EventArgs e)
        {
            AssetMangement assetMangement = new AssetMangement(null, assets);
            assetMangement.ShowDialog();
            Updatelist();
        }

        private void Updatelist()
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }
            LoadAssets();
        }

    }
}