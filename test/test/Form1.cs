using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text += Getstringadddot("Eurker") + "\r\n";
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now+"\r\n";
            textBox1.Text += await GetTitleAsync("SY-190") + "\r\n";
            textBox1.Text += DateTime.Now + "\r\n";
        }

        public async Task<string> GetTitleAsync(string PN)
        {
            HttpClient _Client = new HttpClient();
            string str = await _Client.GetStringAsync($"https://www.javbus.com/{PN}");
            
            return GetTitle(str);
        }

        public string GetTitle(string str)
        {
            string title = str.Substring(str.IndexOf("<title>")+7, str.IndexOf("</title>") - str.IndexOf("<title>")-7- " - JavBus".Length);
            return title;
        }

        public string Getstringadddot(string str)
        {
            string stradddot = "";
            char[] strbyte = str.ToCharArray();
            for(int i=0;i<strbyte.Length-1;i++)
            {
                stradddot += strbyte[i] + ",";
            }
            stradddot += strbyte[strbyte.Length - 1];
            return stradddot;
        }

 
    }

 
}
