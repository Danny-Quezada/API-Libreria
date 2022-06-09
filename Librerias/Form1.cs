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
            Id = 0;
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
            using (var Client = new HttpClient())
            {
                var serialization = JsonConvert.SerializeObject(librosWiewModel);
                var content = new StringContent(serialization, Encoding.UTF8, "application/json");
                var result = await Client.PostAsync("https://localhost:44397/api/Libros/", content);
                if (result.IsSuccessStatusCode)
                    MessageBox.Show("Libro registrado correctamente");
                else
                    MessageBox.Show("Libro no aceptado" + result.Content.ReadAsStringAsync().Result);
            }
            CleanForm();
            GetAllLibros();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllLibros();
        }
        private void FillForm(LibrosWiewModel librosWiewModel)
        {
            txtAutor.Text = librosWiewModel.Autor;
            txtEditorial.Text = librosWiewModel.Editorial;
            txtISBN.Text = librosWiewModel.ISBN;
            txtTemas.Text = librosWiewModel.Temas;
            txtTitulo.Text = librosWiewModel.Titulo;
        }
        private async void GetLibroById(int id)
        {
            using (var Client = new HttpClient())
            {
                string URI = "https://localhost:44397/api/Libros/" + id.ToString();
                HttpResponseMessage responseMessage = await Client.GetAsync(URI);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var libroJsonString = await responseMessage.Content.ReadAsStringAsync();
                    LibrosWiewModel oLibro = JsonConvert.DeserializeObject<LibrosWiewModel>(libroJsonString);
                    FillForm(oLibro);
                }
                else
                    MessageBox.Show($"No hay libro con id {id.ToString()}");
            }
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
                        MessageBox.Show("No se puede obtener los libross" + response.StatusCode);
                    }
                }
            }
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private async void UpdateLibro(int id)
        {
            LibrosWiewModel librosWiewModel = new LibrosWiewModel
            {
                Id = id,
                Autor = txtAutor.Text,
                Editorial = txtEditorial.Text,
                ISBN = txtISBN.Text,
                Temas = txtTemas.Text,
                Titulo = txtTitulo.Text
            };
            using(var Client =new HttpClient())
            {
                var serialization = JsonConvert.SerializeObject(librosWiewModel);
                var content = new StringContent(serialization, Encoding.UTF8, "application/json");
                var result = await Client.PutAsync("https://localhost:44397/api/Libros/", content);
                if (result.IsSuccessStatusCode)
                    MessageBox.Show("Libro actualizado correctamente");
                else
                    MessageBox.Show("Libro no aceptado" + result.Content.ReadAsStringAsync().Result);
            }
            CleanForm();
            GetAllLibros();
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Id = (int)dgvLibros.Rows[e.RowIndex].Cells[0].Value;
                GetLibroById(Id);
            }
        }
        private static int Id = 0;

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Id != 0)
                UpdateLibro(Id);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(Id!=0)
            {
                DeleteLibro(Id);
            }
        }

        private async void DeleteLibro(int id)
        {
            using(var Client =new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44397/api/Libros/");
                HttpResponseMessage responseMessage = await Client.DeleteAsync(String.Format("{0}/{1}", "https://localhost:44397/api/Libros/", id));
                if (responseMessage.IsSuccessStatusCode)
                    MessageBox.Show("Libro eliminado correctamente");
                else
                    MessageBox.Show($"Libro con Id {Id.ToString()} no se encuentra y no se elimino");
            }
            CleanForm();
            GetAllLibros();
        }
    }
}
