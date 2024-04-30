namespace AlumnosArbolesAVLyABB
{
    public partial class Form1 : Form
    {
        private ArbolAVL arbolAVL;
        private ArbolABB arbolABB;
        private List<Alumno> alumnos;

        public Form1()
        {
            InitializeComponent();

            arbolAVL = new ArbolAVL();
            arbolABB = new ArbolABB();
            alumnos = new List<Alumno>();

            LlenarArboles();
        }

        private void LlenarArboles()
        {
            // Cargar datos del archivo
            string archivo = "DATOS.txt";
            Alumno[] alumnosCargados = CargarAlumnosDesdeArchivo(archivo);

            // Insertar datos en los árboles
            foreach (var alumno in alumnosCargados)
            {
                arbolAVL.Insertar(alumno);
                arbolABB.Insertar(alumno);
            }
        }

        private static Alumno[] CargarAlumnosDesdeArchivo(string archivo)
        {
            List<Alumno> alumnos = new List<Alumno>();

            using (StreamReader sr = new StreamReader(archivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    // Omitir la línea de encabezados
                    if (linea.StartsWith("Carné")) continue;

                    string[] campos = linea.Split(',');
                    if (campos.Length == 8)
                    {
                        try
                        {
                            // Utilizar int.TryParse para manejar mejor los números
                            int.TryParse(campos[3], out int parcial1);
                            int.TryParse(campos[4], out int parcial2);
                            int.TryParse(campos[5], out int zona);
                            int.TryParse(campos[6], out int final);
                            int.TryParse(campos[7], out int total);

                            Alumno alumno = new Alumno(
                                campos[0], // Carné
                                campos[1], // Estudiante
                                campos[2], // Correo Electrónico
                                parcial1,  // Parcial 1
                                parcial2,  // Parcial 2
                                zona,      // Zona
                                final,     // Final
                                total      // Total
                            );
                            alumnos.Add(alumno);
                        }
                        catch (FormatException fe)
                        {
                            // Manejar el error de formato aquí
                            Console.WriteLine("Error de formato en la línea: " + linea);
                        }
                        catch (Exception ex)
                        {
                            // Manejar otros errores aquí
                            Console.WriteLine("Error al procesar la línea: " + linea);
                        }
                    }
                    else
                    {
                        // Manejar el error de longitud de campos aquí
                        Console.WriteLine("Número incorrecto de campos en la línea: " + linea);
                    }
                }
            }

            return alumnos.ToArray();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string carnet = txtCarnet.Text;

            Alumno alumnoAVL = arbolAVL.Buscar(carnet);
            Alumno alumnoABB = arbolABB.Buscar(carnet);

            if (alumnoAVL != null)
            {
                int saltosAVL = arbolAVL.ContarSaltos(carnet);
                MostrarResultado("Árbol AVL", alumnoAVL, saltosAVL);
            }
            else
            {
                MessageBox.Show("No se encontró el alumno en el Árbol AVL");
            }

            if (alumnoABB != null)
            {
                int saltosABB = arbolABB.ContarSaltos(carnet);
                MostrarResultado("Árbol ABB", alumnoABB, saltosABB);
            }
            else
            {
                MessageBox.Show("No se encontró el alumno en el Árbol ABB");
            }
        }

        private void MostrarResultado(string tipoArbol, Alumno alumno, int saltos)
        {
            string resultado = $"{tipoArbol}:\n";
            resultado += $"Carnet: {alumno.Carnet}\n";
            resultado += $"Nombre: {alumno.Nombre}\n";
            resultado += $"Correo: {alumno.Correo}\n";
            resultado += $"Parcial 1: {alumno.Parcial1}\n"; // Asegúrate de que Alumno tenga una propiedad Parcial1
            resultado += $"Parcial 2: {alumno.Parcial2}\n"; // Asegúrate de que Alumno tenga una propiedad Parcial2
            resultado += $"Zona: {alumno.Zona}\n";         // Asegúrate de que Alumno tenga una propiedad Zona
            resultado += $"Final: {alumno.Final}\n";        // Asegúrate de que Alumno tenga una propiedad Final
            resultado += $"Total: {alumno.Total}\n";        // Asegúrate de que Alumno tenga una propiedad Total
            resultado += $"Saltos: {saltos}\n";

            MessageBox.Show(resultado);
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            // Asumiendo que tienes un ListBox llamado lstDatos para mostrar la información
            lstDatos.Items.Clear(); // Limpiar los datos existentes

            string archivo = "DATOS.txt";
            using (StreamReader sr = new StreamReader(archivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    lstDatos.Items.Add(linea); // Agregar cada línea al ListBox
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            LlenarArboles();
        }
    }
}

