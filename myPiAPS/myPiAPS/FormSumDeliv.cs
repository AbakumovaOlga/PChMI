﻿using myPiAPS_Service.BindingModels;
using myPiAPS_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace myPiAPS
{
    public partial class FormSumDeliv : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IProductService _serviceP;
        private readonly IProdGroupService _servicePG;
        private readonly IWaybillService _serviceW;

        private readonly IMainService _serviceM;
        public FormSumDeliv(IMainService serviceM, IWaybillService serviceW)
        {
            _serviceM = serviceM;
            _serviceW = serviceW;
            InitializeComponent();
        }

        private void FormSumDeliv_Load(object sender, EventArgs e)
        {
            try
            {
                List<WaybillBM> list = _serviceW.GetListDeliv();
                if (list != null)
                {
                    F_Delivs.DataSource = list;
                   // F_Delivs.Columns[0].Visible = false;
                  //  F_GoodsList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void F_OK_Click(object sender, EventArgs e)
        {
            if (F_Number.Text == "")
            {
                return;
            }
            try
            {
                Convert.ToInt32(F_Number.Text);
            }
            catch
            {
                MessageBox.Show("Указан неверный номер", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                List<WaybillBM> list = _serviceW.FindWaybill(Convert.ToInt32(F_Number.Text));
                if (list != null)
                {
                    F_Delivs.DataSource = list;
                    F_Delivs.Columns[0].Visible = false;
                    //  F_GoodsList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
