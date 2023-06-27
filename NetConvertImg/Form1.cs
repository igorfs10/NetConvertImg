using ApplicationCore.Constants;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using System.ComponentModel;
using System.Reflection;

namespace NetConvertImg
{
    public partial class Form1 : Form
    {
        private readonly IImageService _imageService;

        private readonly BindingList<AddedFile> AddedFiles = new();
        private readonly BindingList<string> ExtensoesCombo = new(ImageExtensions.Extensions.Keys.ToList());
        private static readonly string AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        public Form1(IImageService imageService)
        {
            InitializeComponent();

            _imageService = imageService;

            var source = new BindingSource(AddedFiles, null);
            dataGridViewFiles.DataSource = source;
            dataGridViewFiles.AutoGenerateColumns = false;

            var comboSource = new BindingSource(ExtensoesCombo, null);
            cbbExtensao.DataSource = comboSource;
        }

        private void AddFileToList(string inputPath)
        {
            if (File.Exists(inputPath))
            {
                FileInfo fi = new(inputPath);
                if (ImageExtensions.Extensions.Keys.Any(ext => ext.ToUpper().Contains(fi.Extension.ToUpper())))
                {
                    string fileSize = string.Format("{0:#,##0}", new FileInfo(inputPath).Length) + " Bytes";
                    AddedFiles.Add(new() { FilePath = inputPath, FileSize = fileSize });
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog1.FileNames)
                {
                    if (File.Exists(file))
                    {
                        AddFileToList(file);
                    }
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            foreach (string file in files)
            {
                AddFileToList(file);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (AddedFiles.Any())
            {
                _imageService.ConvertImage(AddedFiles.ToList(), AssemblyPath, "jpg");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                {
                    txtPastaSaida.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
    }
}