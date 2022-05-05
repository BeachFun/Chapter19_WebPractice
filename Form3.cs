using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter19_WebPractice
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            resultListBox.Items.Clear();

            // Загрузка страницы в браузер
            WebBrowser browser = new WebBrowser();
            browser.Navigate(urlTextBox.Text);
            while (browser.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();

            // Получение всех тэгов <a> и перебор их
            HtmlElementCollection elementsByTagName = browser.Document.GetElementsByTagName("a");
            foreach (HtmlElement element in elementsByTagName)
                resultListBox.Items.Add(element.GetAttribute("href"));

            // Отключение всех элементов на панеле
            foreach (Control c in panel1.Controls)
                c.Dispose();

            // Добавление динамически созданного браузера
            panel1.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
    }
}
