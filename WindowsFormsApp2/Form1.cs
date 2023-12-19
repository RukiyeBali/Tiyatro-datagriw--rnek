using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Tiyatro tiyatro; // "tiyartro" Değişkeni Global bir şekilde oluşur.

         List<Tiyatro> tiyatroListesi = new List<Tiyatro>(); // list kullanılarak "tiyatrıListesi" Global şekilde oluşur.

        private void Form1_Load(object sender, EventArgs e)// Form Açıldığı zaman çalışacak koddur.
        {
            
            tiyatroListesi.Add(new Tiyatro(1, "Pamuk Prenses", "Ümraniye Sahnesi", 120, 250, true, (new DateTime(2023, 12, 25))));// Clas oluşturulurke yapılan sıraya Göre yazılır .
            tiyatroListesi.Add(new Tiyatro(2, "Rapunzel", "Gaziosmanpaşa Sahnesi", 140, 355, false, (new DateTime(2024, 03,18))));
            tiyatroListesi.Add(new Tiyatro(3, "Elsa And Anna", "Kağıthane Sadabad Sahnesi", 112, 125, true, (new DateTime(2024, 03, 21))));
            tiyatroListesi.Add(new Tiyatro(4, "Bekçi İle Postacı", "Üsküdar Kerem Yılmazer Sahnesi", 132, 258, false, (new DateTime(2024, 02, 12))));
            tiyatroListesi.Add(new Tiyatro(5, "Cin Ali", "Harbiye Muhsin Ertuğrul Sahnesi", 142, 150, true, (new DateTime(2024, 02, 17))));
            tiyatroListesi.Add(new Tiyatro(6, "Nasrettin Hoca", "Fatih Reşat Nuri Sahnesi", 130, 185, false, (new DateTime(2024, 01, 10))));
            tiyatroListesi.Add(new Tiyatro(7, "Kül Kedisi", "Müze Gazhane Meydan Sahne", 125, 235, true, (new DateTime(2024, 01, 29))));

            dgvTiyatro.DataSource = tiyatroListesi.ToList(); // Form load açıldığı zaman data griw de Göstermek için yazılan koddur.
        }

        private void dgvTiyatro_CellEnter(object sender, DataGridViewCellEventArgs e) // olayler kısmından açılan data griv enter bölümü dür olaylar dan şimşek simgesinden açılır.
        {
            txtId.Text = dgvTiyatro.CurrentRow.Cells["id"].Value.ToString();// Data Griw de bir satır seçildiğinde bilgileri yerlerine yerleştirecek koddur.
            cmbAd.Text = dgvTiyatro.CurrentRow.Cells["ad"].Value.ToString();
            cmbSahne.Text = dgvTiyatro.CurrentRow.Cells["sahne"].Value.ToString();
            nudSure.Value =Convert.ToInt32(dgvTiyatro.CurrentRow.Cells["sure"].Value);// convert.toint32 yerine şuda yazılabilir ''nud.Value=(int)dgvTiyatro.CurrentRow.Cells["sure"].Value;''
            txtFiyat.Text = dgvTiyatro.CurrentRow.Cells["fiyat"].Value.ToString();
            cbMuzikal.Checked =(bool)dgvTiyatro.CurrentRow.Cells["muzikal"].Value;
            dtpTarih.Value = (DateTime)dgvTiyatro.CurrentRow.Cells["tarih"].Value;


        }

        private void btnEkle_Click(object sender, EventArgs e) // Ekle butonuna basıldığı zaman çalışacak kod BÖLÜMÜDÜR.
        {
            int id = Convert.ToInt32(txtId.Text);
            string ad = cmbAd.Text;
            string sahne = cmbSahne.Text;
            int sure = Convert.ToInt32(nudSure.Value);
            double fiyat =Convert.ToDouble (txtFiyat.Text);
            bool muzikal= cbMuzikal.Checked;
            DateTime tarih=dtpTarih.Value;

            Tiyatro yenitiyatro=new Tiyatro(id,ad,sahne,sure,fiyat,muzikal,tarih);
            tiyatroListesi.Add(yenitiyatro);
            dgvTiyatro.DataSource = tiyatroListesi.ToList(); // Form load açıldığı zaman data griw de Göstermek için yazılan koddur.

        }

        private void btnGüncelle_Click(object sender, EventArgs e) // Güncelle butonuna basıldığı zaman çalışacak Kod BÖLÜMDÜR.
        {
            DataGridViewRow secilenSatir = dgvTiyatro.SelectedRows[0];

            Tiyatro secilenTiyatro = secilenSatir.DataBoundItem as Tiyatro;

            int id = Convert.ToInt32(txtId.Text);
            string ad = cmbAd.Text;
            string sahne = cmbSahne.Text;
            int sure = Convert.ToInt32(nudSure.Value);
            double fiyat = Convert.ToDouble(txtFiyat.Text);
            bool muzikal = cbMuzikal.Checked;
            DateTime tarih = dtpTarih.Value;

            secilenTiyatro.Id = id;
            secilenTiyatro.Ad = ad;
            secilenTiyatro.Sahne = sahne;
            secilenTiyatro.Sure = sure;
            secilenTiyatro.Fiyat = fiyat;
            secilenTiyatro.Muzikal = muzikal;
            secilenTiyatro.Tarih= tarih;    

            dgvTiyatro.DataSource = null;
            dgvTiyatro.DataSource = tiyatroListesi.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e) // Sil butonuna basıldığı zaman çalışacak kod BÖLÜMDÜR.
        {
            DataGridViewRow secilenSatir = dgvTiyatro.SelectedRows[0]; 

            Tiyatro secilenTiyatro = secilenSatir.DataBoundItem as Tiyatro; 

            DialogResult result = MessageBox.Show("Seçilen Tiyatro silinsin mi?", "Tiyatro Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // sil butonuna basıldığı zaman silsin mi silmesinmi onu sorsun evet ve hayır butonu oluştursun.

            if (result == DialogResult.Yes) // sil butonuna basıldığı zaman eğer evet butonuna basılırsa seçilen satır silinicek.
            {
                tiyatroListesi.Remove(secilenTiyatro); // sil.
            }

            dgvTiyatro.DataSource = tiyatroListesi.ToList(); // Yazdırma işlemi bu koddla yapılır.
        }
    }
}
