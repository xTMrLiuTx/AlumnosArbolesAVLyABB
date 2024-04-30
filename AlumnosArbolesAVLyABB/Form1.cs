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

            // Insertar datos en los �rboles
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
                    // Omitir la l�nea de encabezados
                    if (linea.StartsWith("Carn�")) continue;

                    string[] campos = linea.Split(',');
                    if (campos.Length == 8)
                    {
                        try
                        {
                            // Utilizar int.TryParse para manejar mejor los n�meros
                            int.TryParse(campos[3], out int parcial1);
                            int.TryParse(campos[4], out int parcial2);
                            int.TryParse(campos[5], out int zona);
                            int.TryParse(campos[6], out int final);
                            int.TryParse(campos[7], out int total);

                            Alumno alumno = new Alumno(
                                campos[0], // Carn�
                                campos[1], // Estudiante
                                campos[2], // Correo Electr�nico
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
                            // Manejar el error de formato aqu�
                            Console.WriteLine("Error de formato en la l�nea: " + linea);
                        }
                        catch (Exception ex)
                        {
                            // Manejar otros errores aqu�
                            Console.WriteLine("Error al procesar la l�nea: " + linea);
                        }
                    }
                    else
                    {
                        // Manejar el error de longitud de campos aqu�
                        Console.WriteLine("N�mero incorrecto de campos en la l�nea: " + linea);
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
                MostrarResultado("�rbol AVL", alumnoAVL, saltosAVL);
            }
            else
            {
                MessageBox.Show("No se encontr� el alumno en el �rbol AVL");
            }

            if (alumnoABB != null)
            {
                int saltosABB = arbolABB.ContarSaltos(carnet);
                MostrarResultado("�rbol ABB", alumnoABB, saltosABB);
            }
            else
            {
                MessageBox.Show("No se encontr� el alumno en el �rbol ABB");
            }
        }

        private void MostrarResultado(string tipoArbol, Alumno alumno, int saltos)
        {
            string resultado = $"{tipoArbol}:\n";
            resultado += $"Carnet: {alumno.Carnet}\n";
            resultado += $"Nombre: {alumno.Nombre}\n";
            resultado += $"Correo: {alumno.Correo}\n";
            resultado += $"Parcial 1: {alumno.Parcial1}\n"; // Aseg�rate de que Alumno tenga una propiedad Parcial1
            resultado += $"Parcial 2: {alumno.Parcial2}\n"; // Aseg�rate de que Alumno tenga una propiedad Parcial2
            resultado += $"Zona: {alumno.Zona}\n";         // Aseg�rate de que Alumno tenga una propiedad Zona
            resultado += $"Final: {alumno.Final}\n";        // Aseg�rate de que Alumno tenga una propiedad Final
            resultado += $"Total: {alumno.Total}\n";        // Aseg�rate de que Alumno tenga una propiedad Total
            resultado += $"Saltos: {saltos}\n";

            MessageBox.Show(resultado);
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            // Asumiendo que tienes un ListBox llamado lstDatos para mostrar la informaci�n
            lstDatos.Items.Clear(); // Limpiar los datos existentes

            string archivo = "DATOS.txt";
            using (StreamReader sr = new StreamReader(archivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    lstDatos.Items.Add(linea); // Agregar cada l�nea al ListBox
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            LlenarArboles();
        }
    }
}

