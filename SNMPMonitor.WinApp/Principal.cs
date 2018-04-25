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
        private Equipment _equip;
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

                _equip = getData.GetResumeOfEquipment();


                timerMemory.Enabled = true;

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


            _interface = (Interface)cmbInterfaces.SelectedItem;


            txtResumeInterface.Text = "Indice: " + _interface.Index;
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Descrição: " + _interface.Description);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Tipo: " + _interface.Type);
            txtResumeInterface.AppendText(Environment.NewLine);
            int Speed = _interface.Speed;
            txtResumeInterface.AppendText("Velocidade: " + (Speed > 0 ? (Speed / 1024) / 8 : 0) + "Mb/s");
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("MAC: " + _interface.MAC);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status Administrativos: " + _interface.AdministrativeStatus);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status Operacional: " + _interface.OperationalStatus);
            txtResumeInterface.AppendText(Environment.NewLine);
            txtResumeInterface.AppendText("Status da Interface: " + _interface.Status);

            if (_interface.Status != "Operational")
            {
                timerUpdateGraphInterface.Enabled = false;
                return;
            }
            timerUpdateGraphInterface.Enabled = true;

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
                chtInterface.Series[0].Points.AddXY(hourNow, System.Math.Round(inter.InputUtilization, 2));
                chtInterface.Series[1].Points.AddXY(hourNow, System.Math.Round(inter.OutputUtilization, 2));

                txtErrorRateIn.Text = inter.ErrorRateIn.ToString() + "%";
                txtErrorRateOut.Text = inter.ErrorRateOut.ToString() + "%";
                txtDiscardIn.Text = inter.DiscardRateIn.ToString() + "%";
                txtDiscardOut.Text = inter.DiscardRateOut.ToString() + "%";
            }
            catch (Exception ex)
            {
                timerUpdateGraphInterface.Stop();
                MessageBox.Show(ex.Message, "Atenção");
                timerUpdateGraphInterface.Start();
            }
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            timerUpdateGraphInterface.Interval = (int)(numInterval.Value * 1000);
        }

        private void cbTemperature_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTemperature.Checked)
                txtOIDTemperature.Enabled = true;
            else
                txtOIDTemperature.Enabled = false;


        }

        private void cbCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCPU.Checked)
                txtOIDCPU.Enabled = true;
            else
                txtOIDCPU.Enabled = false;
        }

        private void cbMemory_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMemory.Checked)
                txtOIDMemory.Enabled = true;
            else
                txtOIDMemory.Enabled = false;
        }


        private void timerMemory_Tick(object sender, EventArgs e)
        {
            txtResume.Text = "Descrição: " + _equip.Description + "\r\n";

            txtResume.Text += "Contato: " + _equip.Contact + "\r\n";
            txtResume.Text += "Nome: " + _equip.Name + "\r\n";
            txtResume.Text += "Local: " + _equip.Location + "\r\n";
            txtResume.Text += "Tempo Ligado: " + _equip.UpTime + "\r\n";

            try
            {
                if (cbTemperature.Checked)
                    txtResume.Text += "Temperatura: " + getData.GetTemperature(txtOIDTemperature.Text) + "º Celsius\r\n";

                if (cbMemory.Checked)
                    txtResume.Text += "Memória: " + getData.GetMemory(txtOIDMemory.Text) + "% \r\n";

                if (cbCPU.Checked)
                    txtResume.Text += "CPU: " + getData.GetCPUUsage(txtOIDCPU.Text) + "%";
            }
            catch (Exception ex)
            {
                timerMemory.Stop();
                MessageBox.Show(ex.Message, "Atenção");
                timerMemory.Start();
            }

        }
    }
}
