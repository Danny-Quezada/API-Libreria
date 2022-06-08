using Newtonsoft.Json;
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
using ViewModel;

namespace Librerias
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool VerificationForms()
        {
            if (string.IsNullOrEmpty(txtISBN.Text) || string.IsNullOrEmpty(txtEditorial.Text)
                || string.IsNullOrEmpty(txtTemas.Text) || string.IsNullOrEmpty(txtTitulo.Text)
                || string.IsNullOrEmpty(txtAutor.Text))
            {
                return false;
            }
            return true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!VerificationForms())
            {
                MessageBox.Show("Rellene todos los formularios, por favor.");
                return;
            }
            AddLibros();
        }
        private void CleanForm()
        {
            txtAutor.Clear();
            txtEditorial.Clear();
            txtISBN.Clear();
            txtTemas.Clear();
            txtTitulo.Clear();
        }
        private async void AddLibros()
        {
            LibrosWiewModel librosWiewModel = new LibrosWiewModel
            {
                Autor = txtAutor.Text,
                Editorial = txtEditorial.Text,
                ISBN = txtISBN.Text,
                Temas = txtTemas.Text,
                Titulo = txtTitulo.Text
            };
           using(var Client=new HttpClient())
            {
                var serialization = JsonConvert.SerializeObject(librosWiewModel);
                var content = new StringContent(serialization,Encoding.UTF8,"application/json");
                var result = await Client.PostAsync("https://localhost:44397/api/Libros/", content);
            }
            CleanForm();
            GetAllLibros();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllLibros();
        }

        private async void GetAllLibros()
        {
            using (var Client = new HttpClient())
            {
                using (var response = await Client.GetAsync(@"https://localhost:44397/api/Libros/"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var LibrosJsonString = await response.Content.ReadAsStringAsync();
                        dgvLibros.DataSource = JsonConvert.DeserializeObject<List<LibrosWiewModel>>(LibrosJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("No se puede obtener los libross"+response.StatusCode);
                    }
                }
            }
        }
    }
}
