using ApplicationCore.Constants;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using ApplicationCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Forms;

namespace NetConvertImg
{
    public partial class Form1 : Form
    {
        private readonly IImageService _imageService;
        private readonly DbContext _context;

        private readonly BindingList<AddedFile> AddedFiles = new();
        private readonly BindingList<string> ExtensoesCombo = new(ImageExtensions.Extensions.Keys.ToList());

        public Form1(IImageService imageService, DbContext context)
        {
            InitializeComponent();

            _imageService = imageService;
            _context = context;

            var source = new BindingSource(AddedFiles, null);
            dataGridViewFiles.DataSource = source;
            dataGridViewFiles.AutoGenerateColumns = false;

            var comboSource = new BindingSource(ExtensoesCombo, null);
            cbbExtensao.DataSource = comboSource;

            var table = _context.Set<AppConfiguration>();
            AppConfiguration? config = (from item in table.AsNoTracking() select item).FirstOrDefault();
            if (config == null)
            {
                AppConfiguration conf = new();
                _context.Add(conf);
                _context.SaveChanges();
            }
            else
            {
                txtAltura.Value = Convert.ToDecimal(config.Height);
                txtLargura.Value = Convert.ToDecimal(config.Width);
                txtPastaSaida.Text = config.OutputFolder;
                cbbExtensao.Text = config.FileType;
            }
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
                int altura = Convert.ToInt32(txtAltura.Value);
                int largura = Convert.ToInt32(txtLargura.Value);
                string pastaSaida = txtPastaSaida.Text;
                string fileType = cbbExtensao.Text;
                if (!Directory.Exists(pastaSaida))
                {
                    MessageBox.Show("A pasta escolhida não existe.", "",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                }
                else if (altura < 1)
                {
                    MessageBox.Show("A altura deve ter 1 ou mais pixel.", "",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                }
                else if (largura < 1)
                {
                    MessageBox.Show("A largura deve ter 1 ou mais pixel.", "",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                }
                else
                {
                    _imageService.ConvertImage(AddedFiles.ToList(), pastaSaida, fileType, largura, altura);
                    try
                    {
                        var table = _context.Set<AppConfiguration>();
                        AppConfiguration? config = (from item in table select item).FirstOrDefault();
                        if (config != null)
                        {
                            config.OutputFolder = pastaSaida;
                            config.Width = largura;
                            config.Height = altura;
                            config.FileType = fileType;
                            _context.SaveChanges();
                        }
                    }
                    catch { }
                    ChangeRowColor();
                    dataGridViewFiles.Refresh();
                    MessageBox.Show("Conversão realizada com sucesso.", "",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Escolha pelo menos 1 arquivo.", "",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
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

        private void button4_Click(object sender, EventArgs e)
        {
            AddedFiles.Clear();
        }

        private void ChangeRowColor()
        {
            foreach (DataGridViewRow row in dataGridViewFiles.Rows)
            {
                if (row.Cells[2].Value.ToString() == "Success")
                {
                    row.Cells[0].Style.ForeColor = Color.DarkGreen;
                    row.Cells[1].Style.ForeColor = Color.DarkGreen;
                    row.Cells[2].Style.ForeColor = Color.DarkGreen;
                }
                else
                {
                    row.Cells[0].Style.ForeColor = Color.DarkRed;
                    row.Cells[1].Style.ForeColor = Color.DarkRed;
                    row.Cells[2].Style.ForeColor = Color.DarkRed;
                }
            }
        }
    }
}