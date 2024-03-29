﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace CSVToQuery
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //open file dialog and take path to txtFiePath.Text
            OpenFileDialog ofd = new OpenFileDialog();
            //also add txt in filter
            ofd.Filter =
                "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<string> linesIgnores = new List<string>();

            //read all the text from the file
            string[] lines = System.IO.File.ReadAllLines(txtFilePath.Text);
            //create a new string builder
            StringBuilder sb = new StringBuilder();
            //loop through all the lines



            //initialize datagrid with header of the csv file
            string[] headers = lines[0].Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
                sb.Append(header);
                sb.Append(","); 
            }
             

            //put datatable in datagrid
            dataGridWithCheckbox.DataSource = dt;
            //make it not new row addable
            dataGridWithCheckbox.AllowUserToAddRows = false;

             

            lines = lines.Skip(1).ToArray();

            foreach (string line in lines)
            {
                //split the line by comma
                string[] parts = line.Split(',');
                //create a new string builder
                StringBuilder sb2 = new StringBuilder();

                //loop through all the parts
                foreach (string part in parts)
                {

                    int n;
                    bool isNumeric = int.TryParse(part, out n);
                    if (isNumeric)
                    {
                        sb2.Append(part + ",");
                    }
                    else
                    {
                        //append the part to the string builder
                        sb2.Append("'" + part + "',");
                    }

                }
                //remove the last comma
                sb2.Remove(sb2.Length - 1, 1);
                //append the string builder to the string builder 

                //if parts are greatet than columns then ignore the rest
                if (parts.Length > headers.Length)
                {
                    linesIgnores.Add(line);   
                    //remove last items from parts
                    //int remove = parts.Length - headers.Length;
                    // parts = parts.Take(parts.Length - remove).ToArray();
                    continue;
                }

                //put the line in datagri
                dt.Rows.Add(parts);
                //datagrid checkbox should be seelcted 
            }


            if(linesIgnores.Count>0)
            {
                MessageBox.Show("Error in Decoding, Total Lines Ignored : " + linesIgnores.Count + " / " + lines.Count(),"Error", buttons : MessageBoxButtons.OK,icon: MessageBoxIcon.Error);
                string listOgIgnore = string.Join("\n", linesIgnores); 
                MessageBox.Show("Following lines are ignore due to bad encoding:\n" + listOgIgnore);
            } 
        }

        private void btnConvertTable_Click(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();

            // Add columns to the DataTable based on the columns in the DataGridView
            foreach (DataGridViewColumn column in dataGridWithCheckbox.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            // Add rows to the DataTable
            foreach (DataGridViewRow row in dataGridWithCheckbox.Rows)
            {
                DataRow dataRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dataRow);
            }
            //convert datatable to mysql query

            string fileName = System.IO.Path.GetFileNameWithoutExtension(txtFilePath.Text);

            //iterate datatable rows and make mysql query for each row

            StringBuilder sb2 = new StringBuilder();

             



            foreach (DataRow row in dt.Rows)
            { 
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO " + fileName + " (");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append(column.ColumnName + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(") VALUES (");

                foreach (DataColumn column in dt.Columns)
                {

                    string columnValue = row[column].ToString();

                    //sanitize the column value
                    columnValue = columnValue.Replace("'", "");
                     //test // test
                    int n;
                    bool isNumeric = int.TryParse(columnValue, out n);
                    if (isNumeric)
                    {
                        sb.Append(columnValue + ",");
                    }
                    else
                    {
                        //check if the value is true or false
                        if (columnValue.ToLower() == "true" || columnValue.ToLower() == "false")
                        {
                            sb.Append((columnValue.ToLower()=="true"?"1":"0") + ",");
                        }
                        else
                        {
                            sb.Append("'" + columnValue + "',");
                        } 
                       
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(");");
                sb2.Append(sb.ToString() + "\n");
            }

            //set to clipboard
            Clipboard.SetText(sb2.ToString()); 
            MessageBox.Show("SQL Copied to Clipboard ");
             
        }
    }
}
