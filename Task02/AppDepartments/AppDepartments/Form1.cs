namespace AppDepartments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage resp = client.GetAsync("https://localhost:7263/api/departments").Result;
            if (resp.IsSuccessStatusCode)
            {
               List<departmentdata> dps = resp.Content.ReadAsAsync<List<departmentdata>>().Result;
                DGV_departments.DataSource = dps;
            }
        }
    }
}
