using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        void button1_Click(object sender, EventArgs e)
        {
            long sum = 0;
            
            for (long i = 0; i <= 100000000; i++)
            {
                sum += i;
            }
            button1.Text = sum.ToString();
        }

        async void button2_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(GetSum);
            await task;
            
        }
        void GetSum()
        {
            long sum = 0;
            for (long i = 0; i <10000000; i++)
            {
                sum += i;
            }
            button2.Invoke((MethodInvoker)(() => { button2.Text = sum.ToString(); }));  
        }
        async Task<long> GetSum2(long range)
        {
            long sum = 0;
            Task task = Task.Run(() => {

                for (long i = 0; i < 10000000; i++)
                {
                    sum += i;
                }

            });
            await task;
            return sum;
        }

        async void button3_Click(object sender, EventArgs e)
        {
            long result = await GetSum2(10000000);

            button3.Text = result.ToString();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            List<Task<string>> taskList = new List<Task<string>>();
            taskList.Add(httpClient.GetStringAsync(arr[0]));
            taskList.Add(httpClient.GetStringAsync(arr[1]));
            taskList.Add(httpClient.GetStringAsync(arr[2]));

            var result = await Task.WhenAll(taskList);

            foreach (var item in result)
            {
                listBox1.Items.Add(item.Length);
            }

        }
        string[] arr =
        {
            "https://www.youtube.com/","https://tap.az/","https://oxu.az/"
        };

    }
}
