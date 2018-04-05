using SNMPMonitor.Domain;
using SNMPMonitor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNMPMonitor.WinApp
{
    public partial class Principal : Form
    {
        GetData getData;
        Interface inter;
        public Principal()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            getData = new GetData(txtIP.Text, int.Parse(txtPort.Text), txtCommunit.Text, int.Parse(txtVersion.Text), int.Parse(txtTimeOut.Text), int.Parse(txtRetransmitions.Text));
            Equipment equip = getData.GetResumeOfEquipment();
            txtResume.Text = "Descrição " + equip.Description + "\r\n";

            txtResume.Text += "Contato " + equip.Contact + "\r\n";

            txtResume.Text += "Nome " + equip.Name + "\r\n";
            txtResume.Text += "Local " + equip.Location + "\r\n";
            txtResume.Text += "Tempo Ligado " + equip.UpTime;
            

            int index = getData.GetIndexOfInterfaces();

            cmbInterfaces.Items.Clear();

            for (int i = 1; i <=index; i++)
            {
                inter = getData.GetResumeOfInterface(i);
                if(inter.Index.Length > 0)
                    cmbInterfaces.Items.Add(inter);
            }


        }      

        private void cmbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtResumeInterface.Text = "Indice " + inter.Index + "\r\n";
            txtResumeInterface.Text += "Descrição " + inter.Description + "\r\n";
            txtResumeInterface.Text += "Tipo " + inter.Type + "\r\n";
            txtResumeInterface.Text += "Velocidade " + inter.Speed + "\r\n";
            txtResumeInterface.Text += "MAC " + inter.MAC + "\r\n";
            txtResumeInterface.Text += "Status Administrativos " + inter.Administrative + "\r\n";
            txtResumeInterface.Text += "Status Operacional " + inter.Operational;
            txtErrorRateIn.Text = inter.ErrorRateIn.ToString() + "%";
            txtErrorRateOut.Text = inter.ErrorRateOut.ToString() + "%";
            txtDiscardIn.Text   = inter.DiscardIn.ToString() + "%";
            txtDiscardOut.Text = inter.DiscardOut.ToString() + "%";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtErrorRateIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtErrorRateOut_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
