using SNMPMonitor.Domain;
using SNMPMonitor.Services;
using System;
using System.Windows.Forms;

namespace SNMPMonitor.WinApp
{
    public partial class Principal : Form
    {
        private GetData getData;
        private Interface _interface;

        public Principal()
        {
            InitializeComponent();
        }

        private void ValidateFields()
        {
            if (!maskedIP.MaskFull)
                throw new Exception("O endereço IP não foi preenchido corretamente!");

            if (string.IsNullOrEmpty(txtCommunit.Text))
                throw new Exception("O campo comunidade deve estar preenchido!");

            if (txtCommunit.Text.Contains(" "))
                throw new Exception("O campo comunidade não deve possuir espaços!");
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClearFields();
            try
            {
                ValidateFields();
                getData = new GetData(maskedIP.Text.Replace(",", "."), (int)numPort.Value, txtCommunit.Text, (int)numVersion.Value,
                        (int)numTimeOut.Value, (int)numRestransmitions.Value);

                Equipment equip = getData.GetResumeOfEquipment();
                txtResume.Text = "Descrição: " + equip.Description + "\r\n";

                txtResume.Text += "Contato: " + equip.Contact + "\r\n";
                txtResume.Text += "Nome: " + equip.Name + "\r\n";
                txtResume.Text += "Local: " + equip.Location + "\r\n";
                txtResume.Text += "Tempo Ligado: " + equip.UpTime;

                int index = getData.GetIndexOfInterfaces();

                cmbInterfaces.Items.Clear();

                for (int i = 1; i <= index; i++)
                {
                    Interface inter = getData.GetResumeOfInterface(i);
                    if (inter.Description.Length > 0)
                        cmbInterfaces.Items.Add(inter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }

        }

        private void ClearFields()
        {
            timerUpdateGraphInterface.Enabled = false;
            txtResume.Text = "";
            txtResumeInterface.Text = "";
            cmbInterfaces.Items.Clear();
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
            int Speed;
            int.TryParse(_interface.Speed, out Speed);
            txtResumeInterface.AppendText("Velocidade: " + (Speed > 0 ? (Speed / 1024) / 8 : 0) + "Mb/s");
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("MAC: " + _interface.MAC);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status Administrativos: " + _interface.AdministrativeStatus);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status Operacional: " + _interface.OperationalStatus);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status da Interface: " + _interface.Status);

        }
        private void timerUpdateGraphInterface_Tick(object sender, EventArgs e)
        {
            try
            {
                Interface inter = getData.GetUsageDetailsOfInterface(_interface);

                if (chtInterface.Series[0].Points.Count > 4)
                {
                    chtInterface.Series[0].Points.RemoveAt(0);
                    chtInterface.Series[1].Points.RemoveAt(0);
                    chtInterface.Update();
                }

                string hourNow = DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString();
                chtInterface.Series[0].Points.AddXY(hourNow, inter.IfInOctets);
                chtInterface.Series[1].Points.AddXY(hourNow, inter.IfOutOctets);

                txtErrorRateIn.Text = inter.ErrorRateIn.ToString() + "%";
                txtErrorRateOut.Text = inter.ErrorRateOut.ToString() + "%";
                txtDiscardIn.Text = inter.DiscardRateIn.ToString() + "%";
                txtDiscardOut.Text = inter.DiscardRateOut.ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            timerUpdateGraphInterface.Interval = (int)(numInterval.Value * 1000);
        }

    }
}
