Imports System.Configuration
Imports System.Data.Sql
Imports System.Data.SqlClient



Public Class Form1


    Dim CN As SqlConnection
    Dim dataTable As DataTable
    Dim dataAdapter As SqlDataAdapter
    Dim añoActual As Integer = DateTime.Now.Year



    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label2.Text = añoActual


        DataGridView1.MultiSelect = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        ' Leer la cadena de conexión desde el archivo de configuración.
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        ' Crear la conexión con la cadena de conexión leída.
        CN = New SqlConnection(connectionString)


        Try
            ' Abrir la conexión para poder acceder a sus propiedades.
            CN.Open()

            ' Obtener los datos del servidor y mostrarlos en el Label.
            Label3.Text = $"Conectado a: {CN.DataSource} | Base: {CN.Database}"

        Catch ex As Exception
            ' Manejar cualquier excepción (por ejemplo, si no se puede conectar al servidor).
            MessageBox.Show($"Error al conectar al servidor: {ex.Message}")

        Finally
            ' Cerrar la conexión si está abierta.
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try


        ' Llena el ComboBox con datos de la tabla AL_CICLOS_LECTIVOS (Descripcion)

        LlenarCombobox(cboCicloLectivo, "SELECT DISTINCT Descripcion FROM AL_CICLOS_LECTIVOS where Descripcion > 2022")

        ' Llena el ComboBox con datos de la tabla al_carreras (carrera_id)
        LlenarCboCarrera(cboCarrera, "Select DISTINCT al_carreras.Carrera_ID as ID, AL_CARRERAS.Descripcion As carrera
            From al_comisiones_mate
            INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
            INNER Join tg_dias ON tg_dias.Dia_ID = al_comisiones_mate_horarios.Dia_ID
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = (year(GetDate()))
            GROUP BY
			AL_CARRERAS.Descripcion,
			al_carreras.carrera_id
    		order by carrera asc")

        ' Llena el ComboBox con datos de la tabla al_docentes (docente_id)
        'LlenarCboDocente(cboDocente, "Select docente_id, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto FROM AL_Docentes where Activo LIKE '%S%' and Contratado LIKE '%S%' ORDER BY Apellido")
        LlenarCboDocente(cboDocente, "Select al_docentes.Docente_ID as docente_id, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto
            From al_comisiones_mate
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = (year(GetDate()))
            and al_docentes.Docente_ID <> 5130 and al_docentes.Docente_ID <> 99999999
            GROUP BY
			al_docentes.Docente_ID,
			al_docentes.Apellido,
			al_docentes.Nombre
			order by NombreCompleto asc")

        CboModuloId.Items.Add("1er Cuatrimestre")
        CboModuloId.Items.Add("2do Cuatrimestre")
        CboModuloId.SelectedIndex = 0

    End Sub
    Private Sub LlenarCboCarrera(combobox As ComboBox, consulta As String)
        Try
            ' Abre la conexión
            CN.Open()

            ' Crea un adaptador de datos
            Dim dataAdapter As New SqlDataAdapter(consulta, CN)

            ' Crea un DataTable para almacenar los resultados
            Dim dataTable As New DataTable()

            ' Llena el DataTable con los resultados de la consulta
            dataAdapter.Fill(dataTable)

            ' Limpia el ComboBox antes de agregar nuevos elementos
            combobox.Items.Clear()

            ' Agrega los elementos concatenados al ComboBox
            For Each row As DataRow In dataTable.Rows
                combobox.Items.Add(row(1).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Error al llenar el ComboBox: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cierra la conexión
            CN.Close()
        End Try
    End Sub

    Private Sub LlenarCboDocente(combobox As ComboBox, consulta As String)
        Try
            ' Abre la conexión
            CN.Open()

            ' Crea un adaptador de datos
            Dim dataAdapter As New SqlDataAdapter(consulta, CN)

            ' Crea un DataTable para almacenar los resultados
            Dim dataTable As New DataTable()

            ' Llena el DataTable con los resultados de la consulta
            dataAdapter.Fill(dataTable)

            ' Limpia el ComboBox antes de agregar nuevos elementos
            combobox.Items.Clear()

            ' Agrega los elementos concatenados al ComboBox
            For Each row As DataRow In dataTable.Rows
                combobox.Items.Add(row(1).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Error al llenar el ComboBox: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cierra la conexión
            CN.Close()
        End Try
    End Sub




    Private Sub LlenarCombobox(combobox As ComboBox, consulta As String)
        Try
            ' Abre la conexión
            CN.Open()

            ' Crea un adaptador de datos
            Dim dataAdapter As New SqlDataAdapter(consulta, CN)

            ' Crea un DataTable para almacenar los resultados
            Dim dataTable As New DataTable()

            ' Llena el DataTable con los resultados de la consulta
            dataAdapter.Fill(dataTable)

            ' Limpia el ComboBox antes de agregar nuevos elementos
            combobox.Items.Clear()

            ' Agrega los elementos concatenados al ComboBox
            For Each row As DataRow In dataTable.Rows
                combobox.Items.Add(row(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Error al llenar el ComboBox: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cierra la conexión
            CN.Close()
        End Try
    End Sub

    Private Function ObtenerValorSeleccionado(selectedIndex As Integer, consulta As String) As String
        Try
            ' Abre la conexión
            CN.Open()

            ' Crea un adaptador de datos
            Dim dataAdapter As New SqlDataAdapter(consulta, CN)

            ' Crea un DataTable para almacenar los resultados
            Dim dataTable As New DataTable()

            ' Llena el DataTable con los resultados de la consulta
            dataAdapter.Fill(dataTable)

            ' Obtiene el valor de la columna correspondiente al índice seleccionado
            Dim valorSeleccionado As String = dataTable.Rows(selectedIndex)(0).ToString()

            Return valorSeleccionado
        Catch ex As Exception
            MessageBox.Show("Error al obtener el valor seleccionado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            ' Cierra la conexión
            CN.Close()
        End Try
    End Function


    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        ' Obtener los valores seleccionados en los ComboBoxes
        If CheckBoxDocente.Checked Then
            cboDocente.Text = ""

            Dim cicloLectivo As String = añoActual
            'Dim cicloLectivo As String = cboCicloLectivo.SelectedItem.ToString()
            Dim moduloId As Integer = If(CboModuloId.SelectedIndex = 0, 1, 2)
            Dim carreraId As String = ObtenerValorSeleccionado(cboCarrera.SelectedIndex, "Select DISTINCT al_carreras.Carrera_ID as ID, AL_CARRERAS.Descripcion As carrera
            From al_comisiones_mate
            INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
            INNER Join tg_dias ON tg_dias.Dia_ID = al_comisiones_mate_horarios.Dia_ID
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = (year(GetDate()))
            GROUP BY
			AL_CARRERAS.Descripcion,
			al_carreras.carrera_id
    		order by carrera asc")
            EjecutarConsultaSQL3(cicloLectivo, moduloId, carreraId)

        ElseIf CheckBoxCarrera.Checked Then
            cboCarrera.Text = ""
            Dim cicloLectivo As String = añoActual
            'Dim cicloLectivo As String = cboCicloLectivo.SelectedItem.ToString()
            Dim moduloId As Integer = If(CboModuloId.SelectedIndex = 0, 1, 2)
            Dim docente_Id As String = ObtenerValorSeleccionado(cboDocente.SelectedIndex, "Select DISTINCT al_docentes.Docente_ID as docente_id, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto
            From al_comisiones_mate
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = (year(GetDate()))
            and al_docentes.Docente_ID <> 5130 and al_docentes.Docente_ID <> 99999999
            GROUP BY
			al_docentes.Docente_ID,
			al_docentes.Apellido,
			al_docentes.Nombre
			order by NombreCompleto asc")

            ' Ejecutar la consulta SQL con parámetros cicloLectivo y moduloId
            EjecutarConsultaSQL2(cicloLectivo, moduloId, docente_Id)
            ContarComisionesConV(cicloLectivo, moduloId, docente_Id)
        Else
            Dim cicloLectivo As String = añoActual
            Dim moduloId As Integer = If(CboModuloId.SelectedIndex = 0, 1, 2) ' Asumiendo que el ComboBox CboModuloId contiene valores numéricos.
            Dim carreraId As String = ObtenerValorSeleccionado(cboCarrera.SelectedIndex, "Select DISTINCT al_carreras.Carrera_ID as ID, AL_CARRERAS.Descripcion As carrera
            From al_comisiones_mate
            INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
            INNER Join tg_dias ON tg_dias.Dia_ID = al_comisiones_mate_horarios.Dia_ID
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = (year(GetDate()))
            GROUP BY
			AL_CARRERAS.Descripcion,
			al_carreras.carrera_id
    		order by carrera asc")
            Dim docente_Id As String = ObtenerValorSeleccionado(cboDocente.SelectedIndex, "Select DISTINCT al_docentes.Docente_ID as docente_id, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto
            From al_comisiones_mate
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = (year(GetDate()))
            and al_docentes.Docente_ID <> 5130 and al_docentes.Docente_ID <> 99999999
            GROUP BY
			al_docentes.Docente_ID,
			al_docentes.Apellido,
			al_docentes.Nombre
			order by NombreCompleto asc")


            ' Ejecutar la consulta SQL con parámetros
            EjecutarConsultaSQL(carreraId, cicloLectivo, moduloId, docente_Id)
        End If






    End Sub

    Private Sub ContarComisionesConV(cicloLectivo As Integer, moduloId As Integer, docente_id As Integer)
        ' Conexión a la base de datos


        ' Leer la cadena de conexión desde el archivo de configuración.
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        ' Crear la conexión con la cadena de conexión leída.
        CN = New SqlConnection(connectionString)

        Try
            ' Abre la conexión
            CN.Open()

            ' Consulta SQL para contar las comisiones con "-V" en la división
            Dim consulta As String = "SELECT COUNT(*) 
                                  FROM al_comisiones_mate
                                  INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
                                  INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
                                  INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
                                  INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id  
                                  INNER JOIN AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
                                  INNER JOIN AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
                                  WHERE Division LIKE '%-V%'
                                  AND AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
                                  AND AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
                                  AND AL_DOCENTES.Docente_ID = @DocenteId
                                  AND al_docentes.Docente_ID <> 5130
                                  AND al_docentes.Docente_ID <> 99999999"

            ' Crea un comando SQL con la consulta y la conexión
            Dim comando As New SqlCommand(consulta, CN)

            ' Asigna valores a los parámetros
            comando.Parameters.AddWithValue("@CicloLectivo", cicloLectivo)
            comando.Parameters.AddWithValue("@ModuloId", moduloId)
            comando.Parameters.AddWithValue("@DocenteId", docente_id)

            ' Ejecuta el comando y obtén el resultado
            Dim contador As Integer = Convert.ToInt32(comando.ExecuteScalar())

            ' Muestra el resultado
            MessageBox.Show("Cantidad de comisiones con '-V' en la división: " & contador.ToString())
        Catch ex As Exception
            MessageBox.Show("Error al contar las comisiones: " & ex.Message)
        Finally
            ' Cierra la conexión si está abierta
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

    End Sub


    Private Sub EjecutarConsultaSQL(carreraId As Integer, cicloLectivo As Integer, moduloId As Integer, docente_Id As Integer)
        Try
            ' Abrir la conexión a la base de datos
            CN.Open()

            ' Crear un objeto SqlCommand para ejecutar la consulta
            Dim cmdConsulta As New SqlCommand()
            cmdConsulta.Connection = CN

            Dim consultaSQL As String = "Select DISTINCT al_docentes.docente_id, al_docentes.combo As docente, AL_PLANES_EST_CARRE.Combo As carrera, AL_COMISIONES.Comision_ID, al_comisiones.anio, al_comisiones.division,AL_TURNOS.Descripcion As turno, al_materias.descripcion As materia, tg_dias.nombredia, al_docentes.contratado 
            From al_comisiones_mate
            INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
            INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id
            INNER Join TG_TIPOS_DOCUMENTO on TG_TIPOS_DOCUMENTO.TIPO_DOCUMENTO_ID = al_docentes.TipoDoc_ID
            INNER Join tg_dias ON tg_dias.Dia_ID = al_comisiones_mate_horarios.Dia_ID
            INNER Join tg_sexos ON tg_sexos.Sexo_ID = al_docentes.Sexo_ID
            INNER Join al_materias ON al_materias.materia_id = al_comisiones_mate.materia_id
            INNER Join al_horarios ON al_horarios.Horario_ID = al_comisiones_mate_horarios.Horario_ID
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            INNER Join AL_TURNOS ON AL_TURNOS.Turno_ID=AL_COMISIONES.Turno_ID
            INNER Join AL_PLANES_EST_CARRE_MATE ON AL_PLANES_EST_CARRE_MATE.Materia_ID=AL_MATERIAS.materia_ID
			INNER JOIN AL_PLANES_EST_CARRE ON AL_PLANES_EST_CARRE.PlanEstCarrera_ID=AL_PLANES_EST_CARRE_MATE.PlanEstCarrera_ID
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And (AL_DOCENTES.Docente_ID = @DocenteId OR @DocenteId IS NULL)
            And (al_comisiones.carrera_id = @CarreraId OR @CarreraId IS NULL)
            GROUP BY
    al_docentes.docente_id,
    al_docentes.combo,
    AL_PLANES_EST_CARRE.Combo,
    al_turnos.Descripcion,
	AL_COMISIONES.Comision_ID,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    al_docentes.contratado
    order by carrera asc, anio asc,Division asc ,turno asc, nombreDia asc;"



            cmdConsulta.CommandText = consultaSQL

            ' Agregar parámetros

            cmdConsulta.Parameters.Add(New SqlParameter("@CicloLectivo", cicloLectivo))
            cmdConsulta.Parameters.Add(New SqlParameter("@ModuloId", moduloId))
            cmdConsulta.Parameters.Add(New SqlParameter("@CarreraId", carreraId))
            cmdConsulta.Parameters.Add(New SqlParameter("@DocenteId", docente_Id))




            ' Ejecutar la consulta y obtener resultados en un DataTable
            dataTable = New DataTable()
            dataAdapter = New SqlDataAdapter(cmdConsulta)
            dataAdapter.Fill(dataTable)

            ' Asignar el DataTable como fuente de datos para el DataGridView
            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar la consulta SQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión después de usarla
            CN.Close()
        End Try
    End Sub

    Private Sub EjecutarConsultaSQL1(cicloLectivo As Integer, moduloId As Integer)
        Try
            ' Abrir la conexión a la base de datos
            CN.Open()

            ' Crear un objeto SqlCommand para ejecutar la consulta
            Dim cmdConsulta As New SqlCommand()
            cmdConsulta.Connection = CN

            Dim consultaSQL As String = "Select DISTINCT al_docentes.docente_id, al_docentes.combo As docente, AL_PLANES_EST_CARRE.Combo As carrera, AL_COMISIONES.Comision_ID, al_comisiones.anio, al_comisiones.division,AL_TURNOS.Descripcion As turno, al_materias.descripcion As materia, tg_dias.nombredia, al_docentes.contratado 
            From al_comisiones_mate
            INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
            INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id
            INNER Join TG_TIPOS_DOCUMENTO on TG_TIPOS_DOCUMENTO.TIPO_DOCUMENTO_ID = al_docentes.TipoDoc_ID
            INNER Join tg_dias ON tg_dias.Dia_ID = al_comisiones_mate_horarios.Dia_ID
            INNER Join tg_sexos ON tg_sexos.Sexo_ID = al_docentes.Sexo_ID
            INNER Join al_materias ON al_materias.materia_id = al_comisiones_mate.materia_id
            INNER Join al_horarios ON al_horarios.Horario_ID = al_comisiones_mate_horarios.Horario_ID
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            INNER Join AL_TURNOS ON AL_TURNOS.Turno_ID=AL_COMISIONES.Turno_ID
            INNER Join AL_PLANES_EST_CARRE_MATE ON AL_PLANES_EST_CARRE_MATE.Materia_ID=AL_MATERIAS.materia_ID
			INNER JOIN AL_PLANES_EST_CARRE ON AL_PLANES_EST_CARRE.PlanEstCarrera_ID=AL_PLANES_EST_CARRE_MATE.PlanEstCarrera_ID
            WHERE
        AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And al_docentes.Docente_ID <> 5130
            And  al_docentes.Docente_ID <> 99999999
            GROUP BY
    al_docentes.docente_id,
    al_docentes.combo,
    AL_PLANES_EST_CARRE.Combo,
    al_turnos.Descripcion,
	AL_COMISIONES.Comision_ID,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    al_docentes.contratado
    order by carrera asc, anio asc,Division asc ,turno asc, nombreDia asc;"




            cmdConsulta.CommandText = consultaSQL

            ' Agregar parámetros

            cmdConsulta.Parameters.Add(New SqlParameter("@CicloLectivo", cicloLectivo))
            cmdConsulta.Parameters.Add(New SqlParameter("@ModuloId", moduloId))




            ' Ejecutar la consulta y obtener resultados en un DataTable
            dataTable = New DataTable()
            dataAdapter = New SqlDataAdapter(cmdConsulta)
            dataAdapter.Fill(dataTable)

            ' Asignar el DataTable como fuente de datos para el DataGridView
            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar la consulta SQL:  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión después de usarla
            CN.Close()
        End Try
    End Sub

    Private Sub EjecutarConsultaSQL2(cicloLectivo As Integer, moduloId As Integer, docente_id As Integer)
        Try
            ' Abrir la conexión a la base de datos
            CN.Open()

            ' Crear un objeto SqlCommand para ejecutar la consulta
            Dim cmdConsulta As New SqlCommand()
            cmdConsulta.Connection = CN

            Dim consultaSQL As String = "Select DISTINCT al_docentes.docente_id,al_docentes.combo As docente, AL_PLANES_EST_CARRE.Combo As carrera, AL_COMISIONES.Comision_ID, al_comisiones.anio, al_comisiones.division,AL_TURNOS.Descripcion As turno, al_materias.descripcion As materia, tg_dias.nombredia, al_docentes.contratado  
            From al_comisiones_mate
            INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
            INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id
            INNER Join TG_TIPOS_DOCUMENTO on TG_TIPOS_DOCUMENTO.TIPO_DOCUMENTO_ID = al_docentes.TipoDoc_ID
            INNER Join tg_dias ON tg_dias.Dia_ID = al_comisiones_mate_horarios.Dia_ID
            INNER Join tg_sexos ON tg_sexos.Sexo_ID = al_docentes.Sexo_ID
            INNER Join al_materias ON al_materias.materia_id = al_comisiones_mate.materia_id
            INNER Join al_horarios ON al_horarios.Horario_ID = al_comisiones_mate_horarios.Horario_ID
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            INNER Join AL_TURNOS ON AL_TURNOS.Turno_ID=AL_COMISIONES.Turno_ID
            INNER Join AL_PLANES_EST_CARRE_MATE ON AL_PLANES_EST_CARRE_MATE.Materia_ID=AL_MATERIAS.materia_ID
			INNER JOIN AL_PLANES_EST_CARRE ON AL_PLANES_EST_CARRE.PlanEstCarrera_ID=AL_PLANES_EST_CARRE_MATE.PlanEstCarrera_ID
            WHERE
        AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And AL_DOCENTES.Docente_ID = @DocenteId
            And al_docentes.Docente_ID <> 5130
            And  al_docentes.Docente_ID <> 99999999
            GROUP BY
    al_docentes.docente_id,
    al_docentes.combo,
    AL_PLANES_EST_CARRE.Combo,
    al_turnos.Descripcion,
	AL_COMISIONES.Comision_ID,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    al_docentes.contratado
    order by carrera asc, anio asc,Division asc ,turno asc, nombreDia asc;"




            cmdConsulta.CommandText = consultaSQL

            ' Agregar parámetros

            cmdConsulta.Parameters.Add(New SqlParameter("@CicloLectivo", cicloLectivo))
            cmdConsulta.Parameters.Add(New SqlParameter("@ModuloId", moduloId))
            cmdConsulta.Parameters.Add(New SqlParameter("@DocenteId", docente_id))




            ' Ejecutar la consulta y obtener resultados en un DataTable
            dataTable = New DataTable()
            dataAdapter = New SqlDataAdapter(cmdConsulta)
            dataAdapter.Fill(dataTable)

            ' Asignar el DataTable como fuente de datos para el DataGridView
            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar la consulta SQL:  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión después de usarla
            CN.Close()
        End Try
    End Sub

    Private Sub EjecutarConsultaSQL3(cicloLectivo As Integer, moduloId As Integer, carreraId As Integer)
        Try
            ' Abrir la conexión a la base de datos
            CN.Open()

            ' Crear un objeto SqlCommand para ejecutar la consulta
            Dim cmdConsulta As New SqlCommand()
            cmdConsulta.Connection = CN
            'El de abajo select original
            'Select DISTINCT al_docentes.combo As docente, AL_PLANES_EST_CARRE.Combo As carrera, AL_COMISIONES.Comision_ID, al_comisiones.anio, al_comisiones.division,AL_TURNOS.Descripcion As turno, al_materias.descripcion As materia, tg_dias.nombredia,tg_tipos_documento.nombre_abr, al_docentes.numdoc, tg_sexos.abreviatura, al_docentes.contratado
            Dim consultaSQL As String = "Select DISTINCT al_docentes.docente_id, al_docentes.combo As docente, AL_PLANES_EST_CARRE.Combo As carrera, AL_COMISIONES.Comision_ID, al_comisiones.anio, al_comisiones.division,AL_TURNOS.Descripcion As turno, al_materias.descripcion As materia, tg_dias.nombredia, al_docentes.contratado 
            From al_comisiones_mate
            INNER Join al_comisiones_mate_horarios ON al_comisiones_mate.comisionmate_id = al_comisiones_mate_horarios.comisionmate_id 
            INNER Join al_comisiones ON al_comisiones_mate.comision_id = al_comisiones.comision_id 
            INNER Join al_carreras ON al_comisiones.carrera_id = al_carreras.carrera_id 
            INNER Join al_docentes ON al_docentes.Docente_ID = al_comisiones_mate.docente_id
            INNER Join TG_TIPOS_DOCUMENTO on TG_TIPOS_DOCUMENTO.TIPO_DOCUMENTO_ID = al_docentes.TipoDoc_ID
            INNER Join tg_dias ON tg_dias.Dia_ID = al_comisiones_mate_horarios.Dia_ID
            INNER Join tg_sexos ON tg_sexos.Sexo_ID = al_docentes.Sexo_ID
            INNER Join al_materias ON al_materias.materia_id = al_comisiones_mate.materia_id
            INNER Join al_horarios ON al_horarios.Horario_ID = al_comisiones_mate_horarios.Horario_ID
            INNER Join AL_CICLOS_LECTIVOS_MODULOS ON AL_CICLOS_LECTIVOS_MODULOS.CicloLectModulo_ID = al_comisiones.CicloLectModulo_ID
            INNER Join AL_CICLOS_LECTIVOS ON AL_CICLOS_LECTIVOS.CicloLectivo_ID = AL_CICLOS_LECTIVOS_MODULOS.CicloLectivo_ID
            INNER Join AL_TURNOS ON AL_TURNOS.Turno_ID=AL_COMISIONES.Turno_ID
            INNER Join AL_PLANES_EST_CARRE_MATE ON AL_PLANES_EST_CARRE_MATE.Materia_ID=AL_MATERIAS.materia_ID
			INNER JOIN AL_PLANES_EST_CARRE ON AL_PLANES_EST_CARRE.PlanEstCarrera_ID=AL_PLANES_EST_CARRE_MATE.PlanEstCarrera_ID
            WHERE
        AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And al_comisiones.carrera_id = @CarreraId
            And al_docentes.Docente_ID <> 5130
            And  al_docentes.Docente_ID <> 99999999
            GROUP BY
    al_docentes.docente_id, 
    al_docentes.combo,
    AL_PLANES_EST_CARRE.Combo,
    al_turnos.Descripcion,
	AL_COMISIONES.Comision_ID,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    al_docentes.contratado
    order by carrera asc, anio asc,Division asc ,turno asc, nombreDia asc;"




            cmdConsulta.CommandText = consultaSQL

            ' Agregar parámetros

            cmdConsulta.Parameters.Add(New SqlParameter("@CicloLectivo", cicloLectivo))
            cmdConsulta.Parameters.Add(New SqlParameter("@ModuloId", moduloId))
            cmdConsulta.Parameters.Add(New SqlParameter("@CarreraId", carreraId))




            ' Ejecutar la consulta y obtener resultados en un DataTable
            dataTable = New DataTable()
            dataAdapter = New SqlDataAdapter(cmdConsulta)
            dataAdapter.Fill(dataTable)

            ' Asignar el DataTable como fuente de datos para el DataGridView
            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar la consulta SQL:  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión después de usarla
            CN.Close()
        End Try
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Crear un DataTable para almacenar los datos de las filas seleccionadas
        Dim dataTable As New DataTable("DatosReporte")

        ' Agregar columnas al DataTable
        dataTable.Columns.Add("docenteId")
        dataTable.Columns.Add("docente")
        dataTable.Columns.Add("carrera")
        dataTable.Columns.Add("Comision_ID")
        dataTable.Columns.Add("anio")
        dataTable.Columns.Add("division")
        dataTable.Columns.Add("turno")
        dataTable.Columns.Add("materia")
        dataTable.Columns.Add("dia")
        dataTable.Columns.Add("contratado")

        Try
            ' Verificar si se seleccionaron filas
            If DataGridView1.SelectedRows.Count > 0 Then
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    ' Obtener los valores de las celdas y agregar una nueva fila al DataTable
                    Dim newRow As DataRow = dataTable.NewRow()
                    newRow("docenteId") = row.Cells(0).Value.ToString()
                    newRow("docente") = row.Cells(1).Value.ToString()
                    newRow("carrera") = row.Cells(2).Value.ToString()
                    newRow("Comision_ID") = row.Cells(3).Value.ToString()
                    newRow("anio") = row.Cells(4).Value.ToString()
                    newRow("division") = row.Cells(5).Value.ToString()
                    newRow("turno") = row.Cells(6).Value.ToString()
                    newRow("materia") = row.Cells(7).Value.ToString()
                    newRow("dia") = row.Cells(8).Value.ToString()
                    newRow("contratado") = row.Cells(9).Value.ToString()
                    ' Agregar el resto de los valores de las celdas al newRow según las columnas definidas

                    ' Agregar newRow al DataTable
                    dataTable.Rows.Add(newRow)

                Next

                ' Crear un nuevo informe y asignar los datos
                Dim reporte As New Microsoft.Reporting.WinForms.LocalReport
                reporte.ReportPath = "C:\Users\Cristian\source\repos\Contratos\Informe.rdlc"

                ' Asignar el DataTable como origen de datos para el informe
                reporte.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DatosReporte", dataTable))

                ' Mostrar el formulario con el ReportViewer
                Form3.AgregarDatosAlDataGridView(dataTable)
                Form3.Show()

            Else
                MsgBox("Seleccione al menos una fila")
            End If
        Catch ex As Exception

            ' Manejar cualquier excepción que pueda ocurrir
            MessageBox.Show("Error al cargar el informe: " & ex.Message)
        End Try
    End Sub


    Public Shared Property Rows As Object

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class





