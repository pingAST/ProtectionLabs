using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectionLabs
{
    public partial class FormFreqLetters : Form
    {
        
        public FormFreqLetters()
        {
            InitializeComponent();
        }

        private BindingSource bs;
        private BindingSource bsAll;
        private string Alph { get; set; } = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private bool FlgLoadForm = false;


        private void FormFreqLetters_Load(object sender, EventArgs e)
        {
            if (FormCeaserCiper.GramSize == 1)
            {
                this.Text = "Частота букв";
                this.buttonDecrypt.Text = "Расшифровать на основе частоты букв";
                this.label2.Text = "Частота букв в зашифрованой части";
                this.label1.Text = "Частота букв во всем романе";


                Dictionary<string, int> freqAllText = FrequencyAnalys.CalculateLetterFrequencies(FormCeaserCiper.TextAllNovela, FormCeaserCiper.GramSize);
                var resultAllText = freqAllText.Where(c => !string.IsNullOrEmpty(c.Key)).OrderByDescending(x => x.Value);
                bsAll = new BindingSource();
                dataGridViewAllLetersNovel.DataSource = bsAll;
                bsAll.DataSource = resultAllText;

                Dictionary<string, int> freqEncryptText = FrequencyAnalys.CalculateLetterFrequencies(FormCeaserCiper.TextEncryptPart, FormCeaserCiper.GramSize);
                var resultEncryptText = freqEncryptText.Where(c => !string.IsNullOrEmpty(c.Key)).OrderByDescending(x => x.Value);
                bs = new BindingSource();
                dataGridViewPart.DataSource = bs;
                bs.DataSource = resultEncryptText;
                
            }
            else
            {
                this.Text = "Частота биграм";
                this.buttonDecrypt.Text = "Расшифровать на основе частоты биграм";
                this.label2.Text = "Частота биграм в зашифрованой части";
                this.label1.Text = "Частота биграм во всем романе";

                Dictionary<string, int> freqAllText = FrequencyAnalys.CalculateLetterFrequencies(FormCeaserCiper.TextAllNovela, FormCeaserCiper.GramSize);
                var resultAllText = freqAllText.Where(c => !string.IsNullOrEmpty(c.Key)).OrderByDescending(x => x.Value);
                 bsAll = new BindingSource();
                dataGridViewAllLetersNovel.DataSource = bsAll;
                bsAll.DataSource = resultAllText;

                Dictionary<string, int> freqEncryptText = FrequencyAnalys.CalculateLetterFrequencies(FormCeaserCiper.TextEncryptPart, FormCeaserCiper.GramSize);
                var resultEncryptText = freqEncryptText.Where(c => !string.IsNullOrEmpty(c.Key)).OrderByDescending(x => x.Value);
                bs = new BindingSource();
                dataGridViewPart.DataSource = bs;
                bs.DataSource = resultEncryptText;
            }

            FlgLoadForm = true;
        }

        private void buttonUP_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (bs.Count <= 1)
                {
                    return;
                }
                // один или ноль элементов

                int position = bs.Position;
                if (position <= 0)
                {
                    return;
                }
                // уже вверху

                bs.RaiseListChangedEvents = false;

                var current = bs.Current;
                bs.Remove(current);

                position--;

                bs.Insert(position, current);
                bs.Position = position;

                bs.RaiseListChangedEvents = true;
                bs.ResetBindings(false);
            }
            catch { }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridViewPart;
            try
            {
                if (bs.Count <= 1)
                {
                    return;
                }
                // один или ноль элементов

                int position = bs.Position;
                if (position == bs.Count - 1)
                {
                    return;
                }
                // уже внизу

                bs.RaiseListChangedEvents = false;

                var current = bs.Current;
                bs.Remove(current);

                position++;

                bs.Insert(position, current);
                bs.Position = position;

                bs.RaiseListChangedEvents = true;
                bs.ResetBindings(false);
            }
            catch { }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string textEncrypt = File.ReadAllText(FormCeaserCiper.TextEncryptPart).ToLower(CultureInfo.CurrentCulture);
            var res = new StringBuilder();
            string buferEndLeter = string.Empty;
            int rowindex;
            dataGridViewPart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < textEncrypt.Length; i++)
            {
                if (FormCeaserCiper.GramSize == 1)
                {
                    var c = textEncrypt[i];
                    var index = Alph.IndexOf(c);
                    if (index < 0)
                    {
                        //если символ не найден, то добавляем его в неизменном виде
                        res.Append(c.ToString(CultureInfo.CurrentCulture));
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridViewPart.Rows)
                        {
                            if (row.Cells[0].Value.ToString().Equals(c.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture))
                            {
                                rowindex = row.Index;
                                res.Append(dataGridViewAllLetersNovel.Rows[rowindex].Cells[0].Value);

                            }
                        }
                    }
                }
                else
                {
                    var c = textEncrypt[i];
                    
                    var index = Alph.IndexOf(c);
                    if (index < 0)
                    {
                        //если символ не найден, то добавляем его в неизменном виде
                        res.Append(c.ToString(CultureInfo.CurrentCulture));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(buferEndLeter) || buferEndLeter.Length < FormCeaserCiper.GramSize)
                        {

                            buferEndLeter = buferEndLeter + c.ToString(CultureInfo.CurrentCulture);
                                
                        }
                        //TODO надо подумать как связывать последнию букву первой биграмы первую букву последующей биграмы
                        if (!string.IsNullOrEmpty(buferEndLeter) && buferEndLeter.Length == FormCeaserCiper.GramSize)
                        {
                            foreach (DataGridViewRow row in dataGridViewPart.Rows)
                            {
                                if (row.Cells[0].Value.ToString().Equals(buferEndLeter, StringComparison.CurrentCulture))
                                {
                                    rowindex = row.Index;
                                    res.Append((dataGridViewAllLetersNovel.Rows[rowindex].Cells[0].Value).ToString().Substring(0,1));
                                    buferEndLeter = buferEndLeter.Substring(1, 1);

                                }
                            }
                        }    
                            
                    }
                }
                
            }
            var path = Path.GetTempPath();
            var sfileName = Guid.NewGuid().ToString() + ".txt";
            var fileName = Path.Combine(path, sfileName);
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, res.ToString());
                textBoxEncryptText.Text = fileName;
            }

        }

        private void buttonViewText_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBoxEncryptText.Text);
        }

        private void dataGridViewPart_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewAllLetersNovel_SelectionChanged(object sender, EventArgs e)
        {
            if (FlgLoadForm)
            {
                int selectIndex1 = dataGridViewAllLetersNovel.CurrentCell.RowIndex;

                bs.Position = selectIndex1;
                bs.RaiseListChangedEvents = true;
                bs.ResetBindings(false);

            }
            
           
        }
    }
}
