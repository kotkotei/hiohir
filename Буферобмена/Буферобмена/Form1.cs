using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Буферобмена
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      


       

        private void button4_Click(object sender, EventArgs e)
        {
            ushort secretKey = 0x0088;
            string str = Clipboard.GetText();

            str = EncodeDecrypt(str, secretKey);

            Clipboard.SetData(DataFormats.Text, (Object)str);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textData = textBox2.Text;

            Clipboard.SetData(DataFormats.Text, (Object)textData);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDataObject text = Clipboard.GetDataObject();
            if (text.GetDataPresent(DataFormats.Text))
            {
                textBox1.Text = (String)text.GetData(DataFormats.Text);
            }
            else
            {
                textBox1.Text = "Формат данных не поддерживается";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Clipboard.Clear();

        }
        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToArray();
            string newStr = "";
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);
            return newStr;
        }
        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey);
            return character;
        }


        private void button5_Click(object sender, EventArgs e)
        {

            ushort secretKey = 0x0088;
            string str = Clipboard.GetText();
            str = EncodeDecrypt(str, secretKey);

            Clipboard.SetData(DataFormats.Text, (Object)str);



        }
    }
}
