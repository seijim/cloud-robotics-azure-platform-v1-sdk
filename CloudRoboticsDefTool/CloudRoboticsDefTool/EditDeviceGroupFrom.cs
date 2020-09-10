using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace CloudRoboticsDefTool
{
    public partial class EditDeviceGroupFrom : Form
    {
        private string sqlConnectionString;
        private string deviceGroupId;
        private bool createStatus;
        private DataSet dataSet;
        private string deviceGroupIdName = "DeviceGroupId";
        private string deviceIdName = "DeviceId";
        private string Registered_DateTime_Name = "Registered_DateTime";
        private List<OperationLog> operationList;
        private class OperationLog
        {
            public string Key { set; get; }
            public string Operation { set; get; }
        }

        public EditDeviceGroupFrom(string sqlConnectionString)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            this.deviceGroupId = string.Empty;
            this.createStatus = true;
        }

        public EditDeviceGroupFrom(string sqlConnectionString, string deviceGroupId)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            this.deviceGroupId = deviceGroupId;
            if (deviceGroupId == string.Empty)
            {
                throw (new ApplicationException("Device Group ID is nothing !!"));
            }
            this.createStatus = false;
        }

        private void EditDeviceGroupFrom_Load(object sender, EventArgs e)
        {
            if (createStatus)
            {
                createButton.Enabled = true;
                updateButton.Enabled = false;
            }
            else
            {
                createButton.Enabled = false;
                updateButton.Enabled = true;
            }
            comboBoxDeviceGroupId.Text = this.deviceGroupId;
            operationList = new List<OperationLog>();

            dataSet = getDataSet(comboBoxDeviceGroupId.Text);
            // Device List
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                listBoxDevices.Items.Add(dr[deviceIdName]);
            }
            // Selected Device List
            foreach (DataRow dr in dataSet.Tables[1].Rows)
            {
                listBoxSelectedDevices.Items.Add(dr[deviceIdName]);
            }

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (comboBoxDeviceGroupId.Text == string.Empty)
            {
                MessageBox.Show("Device Group ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                deviceGroupId = comboBoxDeviceGroupId.Text;
            }

            try
            {
                DataTable dataTable = makeNewDeviceDataTable();
                updateDeviceGroupOnDb(dataTable);
                MessageBox.Show("Device Group created successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (comboBoxDeviceGroupId.Text == string.Empty)
            {
                MessageBox.Show("Device Group ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                deviceGroupId = comboBoxDeviceGroupId.Text;
            }

            try
            {
                DataTable dataTable = makeUpdatedDeviceDataTable();
                updateDeviceGroupOnDb(dataTable);
                MessageBox.Show("Device Group updated successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataSet getDataSet(string deviceGroupId)
        {
            string sqltext1 = "SELECT DeviceId FROM RBFX.DeviceMaster AS a WHERE NOT EXISTS "
               + "(SELECT DeviceId FROM RBFX.DeviceGroup AS b WHERE b.DeviceGroupId = @p1 AND a.DeviceId = b.DeviceId) "
               + "ORDER BY DeviceId";
            string sqltext2 = "SELECT DeviceGroupId,DeviceId,Registered_DateTime FROM RBFX.DeviceGroup "
               + "WHERE DeviceGroupId = @p1 ORDER BY DeviceGroupId,DeviceId";

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                // Device list except for target device group
                var da1 = new SqlDataAdapter(sqltext1, conn);
                AddSqlParameter(ref da1, "@p1", SqlDbType.NVarChar, deviceGroupId);
                var cmdBuilder1 = new SqlCommandBuilder(da1);
                DataTable table1 = new DataTable();
                table1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                da1.Fill(table1);
                ds.Tables.Add(table1);

                // Device list in target device group
                var da2 = new SqlDataAdapter(sqltext2, conn);
                AddSqlParameter(ref da2, "@p1", SqlDbType.NVarChar, deviceGroupId);
                var cmdBuilder2 = new SqlCommandBuilder(da2);
                DataTable table2 = new DataTable();
                table2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                da2.Fill(table2);
                ds.Tables.Add(table2);

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }

            return ds;
        }

        private void AddSqlParameter(ref SqlDataAdapter da, string ParameterName, SqlDbType type, Object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            param.SqlDbType = type;
            param.Direction = ParameterDirection.Input;
            param.Value = value;
            da.SelectCommand.Parameters.Add(param);
        }

        private void joinListButton_Click(object sender, EventArgs e)
        {
            int cnt = listBoxDevices.SelectedItems.Count;

            try
            {
                // Add to Selected Device List
                for (int i = 0; i < cnt; i++)
                {
                    OperationLog ope = new OperationLog();
                    ope.Key = listBoxDevices.SelectedItems[i].ToString();
                    ope.Operation = "INSERT";
                    operationList.Add(ope);
                    listBoxSelectedDevices.Items.Add(listBoxDevices.SelectedItems[i]);
                }
                listBoxSelectedDevices.Sorted = true;

                // Remove from Device List
                for (int i = cnt - 1; i >= 0; i--)
                {
                    listBoxDevices.Items.Remove(listBoxDevices.SelectedItems[i]);
                }
                listBoxDevices.Sorted = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeListButton_Click(object sender, EventArgs e)
        {
            int cnt = listBoxSelectedDevices.SelectedItems.Count;

            try
            {
                // Add to Selected Device List
                for (int i = 0; i < cnt; i++)
                {
                    listBoxDevices.Items.Add(listBoxSelectedDevices.SelectedItems[i]);
                }
                listBoxDevices.Sorted = true;

                // Remove from Device List
                for (int i = cnt - 1; i >= 0; i--)
                {
                    OperationLog ope = new OperationLog();
                    ope.Key = listBoxSelectedDevices.SelectedItems[i].ToString();
                    ope.Operation = "DELETE";
                    operationList.Add(ope);
                    listBoxSelectedDevices.Items.Remove(listBoxSelectedDevices.SelectedItems[i]);
                }
                listBoxSelectedDevices.Sorted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable makeNewDeviceDataTable()
        {
            DataTable dataTable = dataSet.Tables[1];
            DateTime curdt = DateTime.Now;

            try
            {
                for (int i = 0; i < listBoxSelectedDevices.Items.Count; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    dr[deviceGroupIdName] = deviceGroupId;
                    dr[deviceIdName] = listBoxSelectedDevices.Items[i];
                    dr[Registered_DateTime_Name] = curdt;
                    dataTable.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private DataTable makeUpdatedDeviceDataTable()
        {
            DataTable dataTable = dataSet.Tables[1];
            DateTime curdt = DateTime.Now;

            try
            {
                foreach(OperationLog ope in operationList)
                {
                    if (ope.Operation == "INSERT")
                    {
                        DataRow dr = dataTable.NewRow();
                        dr[deviceGroupIdName] = deviceGroupId;
                        dr[deviceIdName] = ope.Key;
                        dr[Registered_DateTime_Name] = curdt;
                        dataTable.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow[] rows = dataTable.Select($"DeviceId='{ope.Key}'");
                        
                        foreach(DataRow row in rows)
                        {
                            row.Delete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private void updateDeviceGroupOnDb(DataTable dataTable)
        {
            string sqltext = "SELECT DeviceGroupId,DeviceId,Registered_DateTime FROM RBFX.DeviceGroup";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                var da = new SqlDataAdapter(sqltext, conn);
                AddSqlParameter(ref da, "@p1", SqlDbType.NVarChar, deviceGroupId);
                var cmdBuilder = new SqlCommandBuilder(da);
                da.DeleteCommand = cmdBuilder.GetDeleteCommand();
                da.InsertCommand = cmdBuilder.GetInsertCommand();
                da.UpdateCommand = cmdBuilder.GetUpdateCommand();
                da.Update(dataTable);

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }

        }

        private void EditDeviceGroupFrom_Activated(object sender, EventArgs e)
        {
            comboBoxDeviceGroupId.Focus();
        }
    }
}
