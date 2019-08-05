using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetImagesApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new MyForm());
        }
    }

    class MyForm : Form
    {
        public MyForm()
        {
            var label = new Label();
            label.Location = new Point(0, 0);
            label.Size = new Size(ClientSize.Width, 40);
            label.Font = new Font("Arial", 20);
            label.Text = "           GET GIFS";
            Controls.Add(label);

            var inputNumber = new TextBox();
            inputNumber.Location = new Point(label.Right, label.Bottom);
            inputNumber.Size = label.Size;
            Controls.Add(inputNumber);

            var inputText = new TextBox();
            inputText.Location = new Point(inputNumber.Right, inputNumber.Bottom);
            inputText.Size = label.Size;
            Controls.Add(inputText);

            var button = new Button();
            button.Location = new Point(0, label.Bottom);
            button.Size = label.Size;
            button.Text = "CLICK FOR DOWNLOAD";
            button.Click += (sender, args) =>
            {
                var number = int.Parse(inputNumber.Text);
                var text = inputText.Text;
                //Kek(number);
                GetPictures(number, text);
                GetNewDirectoryOfFiles();
            };
            Controls.Add(button);
        }

        public void GetNewDirectoryOfFiles()
        {
            int count = 0;
            int ox = 0;
            int oy = 50;
            string rootFolderPath = @"C:\Users\Админ\source\repos\GetImagesApp\GetImagesApp\bin\Debug";
            string[] fileList = Directory.GetFiles(rootFolderPath);
            var newFileList = fileList.Where(x => x.Substring(x.Length - 4) == ".gif").ToArray();
            foreach (string file in newFileList)
            {
                Bitmap image = new Bitmap(file);
                var pictureBox1 = new PictureBox();
                pictureBox1.Size = image.Size;
                pictureBox1.Location = new Point(ox, oy);
                if (count % 2 == 0)
                    ox += 200;
                else
                    oy += 200;
                count++;
                pictureBox1.Image = image;
                pictureBox1.Invalidate();
                Controls.Add(pictureBox1);
            }
        }

        //public void GetGifs(string str)
        //{
        //    var website = "https://giphy.com/search/"; ;
        //    var item = website + str;
        //    var link = new Uri(item);
        //    WebClient load = new WebClient();
        //    var json = load.DownloadString(link);
        //    var list = new List<string>();
        //    var kk = json.Split('"');
        //    var kg = kk.Where(x => x.Length >= 5);
        //    var listOfGIFS = kg.Where(x => x.Substring(x.Length - 4) == ".gif").ToArray();
        //}

        public void GetPictures(int countOfPictures,string stringOfSearch)
        {
            var website = "https://giphy.com/search/"; 
            var item = website + stringOfSearch;
            var link = new Uri(item);
            WebClient load = new WebClient();
            var json = load.DownloadString(link);
            var splitStrings = json.Split('"');
            //иначе ошибка при второй лямбде, потому что есть строки, у которых длина меньше 4 и до .jpg ничего нет, точнее это просто другие имена 
            var LongStrings = splitStrings.Where(x => x.Length >= 5);
            var listOfGIFS = LongStrings.Where(x => x.Substring(x.Length - 4) == ".gif").ToArray();
            var list = new List<Task>();

            for (int j = 0; j < countOfPictures; j++)
            {
                var webClient = new WebClient();
                list.Add(webClient.DownloadFileTaskAsync(listOfGIFS[j], Path.GetFileName(listOfGIFS[j])));
            }
            Task.WaitAll(list.ToArray(), 5000);
        }

        //static IEnumerable<String> GetImageLinks(String inputHTML)
        //{
        //    const string pattern = @"<img\b[^\<\>]+?\bsrc\s*=\s*[""'](?<L>.+?)[""'][^\<\>]*?\>";

        //    foreach (Match match in Regex.Matches(inputHTML, pattern, RegexOptions.IgnoreCase))
        //    {
        //        var imageLink = match.Groups["L"].Value;
        //        yield return imageLink;
        //    }
        //}
    }
}