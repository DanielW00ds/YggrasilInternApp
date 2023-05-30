using ModelLiberary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace WinFormsApp1
{
    public partial class AssetMangement : Form
    {
        private Asset m_asset;
        private List<Asset> m_assetList;
        private bool newAsset = true;
        private bool datechange = false;
        private bool firstLaunch = true;
        public AssetMangement(Asset? asset, List<Asset> assets)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            DataInit(asset, assets);
        }
        private void InsertAssetData(Asset? asset)
        {
            if(asset != null)
            {
                m_asset = asset;
                nametxt.Text = asset.Name;
                latitudetxt.Text = asset.Latitude.ToString();
                longitudetxt.Text = asset.Longtitude.ToString();
                capacityNumeric.Value = asset.Capacity;
                startDatedtp.Value = asset.ContractStart;
                endDatedtp.Value = asset.ContractEnd;
                notestext.Text = asset.Notes;
                counterpartcmb.SelectedIndex = counterpartcmb.FindStringExact(asset.Counterpart.Name);
                areacmb.SelectedIndex = areacmb.FindStringExact(asset.Area.Name);
                assetTypecmb.SelectedIndex = assetTypecmb.FindStringExact(asset.AssetType.Name);
                TechTypecmb.SelectedIndex = TechTypecmb.FindStringExact(asset.technologyType.Name);
            }
            else
            {
                notestext.Text = "";
            }
        }
        private async void DataInit(Asset? asset, List<Asset> assets)
        {
            m_assetList = assets;
            CounterpartController cpController = new CounterpartController();
            List<Counterpart> counterparts = await cpController.GetCounterpartsAsync();
            counterpartcmb.ValueMember = null;
            counterpartcmb.DataSource = counterparts;
            counterpartcmb.DisplayMember = "Name";
            counterpartcmb.SelectedIndex = -1;

            AreaController areaController = new AreaController();
            List<Area> areas = await areaController.GetAreasAsync();
            areacmb.ValueMember = null;
            areacmb.DataSource = areas;
            areacmb.DisplayMember = "Name";
            areacmb.SelectedIndex = -1;
            
            AssetTypeController atController = new AssetTypeController();
            List<AssetType> assetTypes = await atController.GetAssetTypesAsync();
            assetTypecmb.ValueMember = null;
            assetTypecmb.DataSource = assetTypes;
            assetTypecmb.DisplayMember = "Name";
            assetTypecmb.SelectedIndex = -1;

            TechTypeController ttController = new TechTypeController();
            List<TechnologyType> techTypes = await ttController.GetTechTypesAsync();
            TechTypecmb.ValueMember = null;
            TechTypecmb.DataSource = techTypes;
            TechTypecmb.DisplayMember = "Name";
            TechTypecmb.SelectedIndex = -1;
            if(asset != null)
            {
                InsertAssetData(asset);
                if (asset.state.ID.Equals(2))
                {
                    counterpartcmb.Enabled = false;
                    areacmb.Enabled = false;
                    assetTypecmb.Enabled = false;
                    TechTypecmb.Enabled = false;
                    nametxt.Enabled = false;
                    latitudetxt.Enabled = false;
                    longitudetxt.Enabled = false;
                    startDatedtp.Enabled = false;
                    endDatedtp.Enabled = false;
                    capacityNumeric.Enabled = false;
                    notestext.Enabled = false;
                    savebtn.Enabled = false;
                }
            }
            else
            {
                newAsset = true;
                m_asset = new Asset();
                m_asset.state = new State();
            }
        }
        private async void SaveAsset(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save the changes?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SetAssetAttributes();
                List<Asset> cpdates = CheckCounterpartDateOverlaps();
                if (cpdates.Count > 0)
                {
                    string cpDatesString = "The chosen counterpart is already in use within your selected dates, the following dates are already in use:";
                    foreach (Asset asset in cpdates)
                    {
                        string dates = $"@{asset.ContractStart.ToShortDateString()} - {asset.ContractEnd.ToShortDateString()}";
                        cpDatesString += dates;
                    }
                    cpDatesString = cpDatesString.Replace("@", Environment.NewLine);
                    MessageBox.Show(cpDatesString);
                }
                else
                {
                    AssetController assetController = new AssetController();
                    if (newAsset)
                    {
                        bool succes = await assetController.AddAsset(m_asset);
                    }
                    else
                    {
                        bool succes = await assetController.UpdateAsset(m_asset);
                    }
                    this.Close();
                }
            }
        }

        private List<Asset> CheckCounterpartDateOverlaps()
        {
            List<Asset> counterpartInUse = new List<Asset>();
            foreach (Asset asset in m_assetList)
            {
                if(asset.Counterpart.ID == m_asset.Counterpart.ID)
                {
                    if(asset.ContractStart > m_asset.ContractStart && asset.ContractStart < m_asset.ContractEnd)
                    {
                        counterpartInUse.Add(asset);
                    }
                    else if(asset.ContractEnd > m_asset.ContractStart && asset.ContractEnd < m_asset.ContractEnd)
                    {
                        counterpartInUse.Add(asset);
                    }
                }
            }
            return counterpartInUse;
        }
        public void SetAssetAttributes()
        {
            m_asset.Latitude = decimal.Parse(latitudetxt.Text);
            m_asset.Longtitude = decimal.Parse(longitudetxt.Text);
            m_asset.ContractStart = startDatedtp.Value;
            m_asset.ContractEnd = endDatedtp.Value;
            if (newAsset)
            {
                m_asset.state.ID = 1;
                m_asset.state.Name = "Draft";
                m_asset.ApprovedAt = null;
                m_asset.ApprovedBy = null;
            }
            // Hardcoded data for nonimplementet asset attributes

            m_asset.ModifiedBy = "Daniel";
            m_asset.ModifiedAt = DateTime.Now;
            
        }

        private void ChangeArea(object sender, EventArgs e)
        {
            if (m_asset != null)
            {
                if (areacmb.SelectedValue != null)
                {
                    Area area = (Area)areacmb.SelectedValue;
                    m_asset.Area = area;
                }
            }
        }
        private void ChangeCounterpart(object sender, EventArgs e)
        {
            if (m_asset != null)
            {
                if (counterpartcmb.SelectedValue != null)
                {
                    Counterpart counterpart = (Counterpart)counterpartcmb.SelectedValue;
                    m_asset.Counterpart = counterpart;
                }
            }
        }

        private void ChangeAssetType(object sender, EventArgs e)
        {
            if (m_asset != null)
            {
                if (assetTypecmb.SelectedValue != null)
                {
                    AssetType assetType = (AssetType)assetTypecmb.SelectedValue;
                    m_asset.AssetType = assetType;
                }
            }
        }

        private void ChangeTechType(object sender, EventArgs e)
        {
            if (m_asset != null)
            {
                if (TechTypecmb.SelectedValue != null)
                {
                    TechnologyType techType = (TechnologyType)TechTypecmb.SelectedValue;
                    m_asset.technologyType = techType;
                }
            }
        }
        private void NameTxtChanged(object sender, EventArgs e)
        {
            if (m_asset != null)
            {
                m_asset.Name = (string)nametxt.Text;
            }

        }

        private void CheckDecimalInput(object sender, KeyPressEventArgs e)
        {
            if (m_asset != null)
            {
                // allows 0-9, backspace, and decimal
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }

                // checks to make sure only 1 decimal is allowed
                if (e.KeyChar == 46)
                {
                    if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                        e.Handled = true;
                }
            }
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (!datechange)
            {
                if (DateChecker())
                {
                    m_asset.ContractStart = startDatedtp.Value;
                }
                else
                {
                    ChangeDateToEndDate();
                    MessageBox.Show("Please ensure a that the End Date is later than the Start Date");
                }
            }
        }
        private void ChangeDateToEndDate()
        {
            datechange = true;
            startDatedtp.Value = endDatedtp.Value;
            datechange = false;
        }

        private void EndDateChange(object sender, EventArgs e)
        {
            if (!datechange)
            {
                if (DateChecker())
                {
                    m_asset.ContractEnd = endDatedtp.Value;
                }
                else
                {
                    ChangeDateToStartDate();
                    MessageBox.Show("Please ensure a that the End Date is later than the Start Date");
                }
            }
        }

        private void ChangeDateToStartDate()
        {
            datechange = true;
            endDatedtp.Value = startDatedtp.Value;
            datechange = false;
        }

        private void NotesChanged(object sender, EventArgs e)
        {
            m_asset.Notes = notestext.Text;
        }

        private void CapacityChanged(object sender, EventArgs e)
        {
            m_asset.Capacity = capacityNumeric.Value;
        }

        private bool DateChecker()
        {
            bool succes = false;
            if (!firstLaunch)
            {
                DateTime startDate = startDatedtp.Value;
                DateTime endDate = endDatedtp.Value;
                if (startDate < endDate)
                {
                    succes = true;
                }
            } else
            {
                firstLaunch = false;
                succes = true;
            }
            return succes;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            if (m_asset.state.ID.Equals(2))
            {
                this.Close();
            } 
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to discard any changes?", "Cancel", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
