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
        private GetData getData;
        private Interface _interface;
        int time = 100;
        public Principal()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            getData = new GetData(txtIP.Text, (int)numPort.Value, txtCommunit.Text, (int)numVersion.Value, 
                (int)numTimeOut.Value, (int)numRestransmitions.Value);
            Equipment equip = getData.GetResumeOfEquipment();
            txtResume.Text = "Descrição: " + equip.Description + "\r\n";

            txtResume.Text += "Contato: " + equip.Contact + "\r\n";
            txtResume.Text += "Nome: " + equip.Name + "\r\n";
            txtResume.Text += "Local: " + equip.Location + "\r\n";
            txtResume.Text += "Tempo Ligado: " + equip.UpTime;
            
            int index = getData.GetIndexOfInterfaces();

            cmbInterfaces.Items.Clear();

            for (int i = 1; i <=index; i++)
            {
                Interface inter = getData.GetResumeOfInterface(i);
                if(inter.Description.Length > 0)
                    cmbInterfaces.Items.Add(inter);
            }
        }      

        private void cmbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerUpdateGraphInterface.Enabled = true;
            _interface = (Interface)cmbInterfaces.SelectedItem;
            txtResumeInterface.Text = "Indice: " + _interface.Index;
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Descrição: " + _interface.Description);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Tipo: " + _interface.Type);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Velocidade: " + _interface.Speed);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("MAC: " + _interface.MAC);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status Administrativos: " + _interface.Administrative);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status Operacional: " + _interface.Operational);

        }
        private void timerUpdateGraphInterface_Tick(object sender, EventArgs e)
        {
            Interface inter = getData.GetUsageDetailsOfInterface(_interface);

            if (chtInterface.Series[0].Points.Count > 5)
            {
                chtInterface.Series[0].Points.RemoveAt(0);
                chtInterface.Series[1].Points.RemoveAt(0);
                chtInterface.Update();
            }
            time++;
            chtInterface.Series[0].Points.AddXY(time, inter.InUCastPkts);
            chtInterface.Series[1].Points.AddXY(time, inter.OutUCastPkts);
            txtErrorRateIn.Text = inter.ErrorRateIn.ToString() + "%";
            txtErrorRateOut.Text = inter.ErrorRateOut.ToString() + "%";
            txtDiscardIn.Text = inter.DiscardIn.ToString() + "%";
            txtDiscardOut.Text = inter.DiscardOut.ToString() + "%";
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            timerUpdateGraphInterface.Interval = (int)(numInterval.Value);
            
        }
    }
}
