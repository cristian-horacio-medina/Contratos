Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Form1


Dim CN As SqlConnection
Dim dataTable As DataTable
Dim dataAdapter As SqlDataAdapter

Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CN = New SqlConnection("Data Source=FAE08\FAE08;Initial Catalog=Gestion;User ID=sa;Password=sql3")

    DataGridView1.Columns.Add(New DataGridViewCheckBoxColumn With {
        .HeaderText = "Seleccione",
        .Name = "ColumnaCheckBox",
        .TrueValue = True,
        .FalseValue = False
    }) ' Columna de CheckBox


    ' Llena el ComboBox con datos de la tabla AL_CICLOS_LECTIVOS (Descripcion)

    LlenarCombobox(cboCicloLectivo, "SELECT DISTINCT Descripcion FROM AL_CICLOS_LECTIVOS where Descripcion > 2022")

    ' Llena el ComboBox con datos de la tabla al_carreras (carrera_id)
    LlenarCboCarrera(cboCarrera, "SELECT carrera_id, nombrecompleto FROM al_carreras where Activo LIKE '%S%'")

    ' Llena el ComboBox con datos de la tabla al_docentes (docente_id)
    LlenarCboDocente(cboDocente, "Select docente_id, CONCAT(Apellido, ', ' ,Nombre) As NombreCompleto FROM AL_Docentes where Activo LIKE '%S%' and Contratado LIKE '%S%' ORDER BY Apellido")

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
        Dim cicloLectivo As String = cboCicloLectivo.SelectedItem.ToString()
        Dim moduloId As Integer = If(CboModuloId.SelectedIndex = 0, 1, 2)
        Dim carreraId As String = ObtenerValorSeleccionado(cboCarrera.SelectedIndex, "SELECT carrera_id, nombrecompleto FROM al_carreras where Activo LIKE '%S%'")
        'Dim docente_Id As String = ObtenerValorSeleccionado(cboDocente.SelectedIndex, "Select docente_id, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto FROM AL_Docentes where Activo LIKE '%S%' and Contratado LIKE '%S%' ORDER BY Apellido")
        ' Ejecutar la consulta SQL con parámetros cicloLectivo y moduloId
        EjecutarConsultaSQL3(cicloLectivo, moduloId, carreraId)

    ElseIf CheckBoxCarrera.Checked Then
        cboCarrera.Text = ""
        Dim cicloLectivo As String = cboCicloLectivo.SelectedItem.ToString()
        Dim moduloId As Integer = If(CboModuloId.SelectedIndex = 0, 1, 2)
        Dim docente_Id As String = ObtenerValorSeleccionado(cboDocente.SelectedIndex, "Select docente_id, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto FROM AL_Docentes where Activo LIKE '%S%' and Contratado LIKE '%S%' ORDER BY Apellido")
        ' Ejecutar la consulta SQL con parámetros cicloLectivo y moduloId
        EjecutarConsultaSQL2(cicloLectivo, moduloId, docente_Id)


    Else

        Dim cicloLectivo As String = cboCicloLectivo.SelectedItem.ToString()
        Dim moduloId As Integer = If(CboModuloId.SelectedIndex = 0, 1, 2) ' Asumiendo que el ComboBox CboModuloId contiene valores numéricos.
        Dim carreraId As String = ObtenerValorSeleccionado(cboCarrera.SelectedIndex, "SELECT carrera_id, nombrecompleto FROM al_carreras where Activo LIKE '%S%'")
        Dim docente_Id As String = ObtenerValorSeleccionado(cboDocente.SelectedIndex, "Select docente_id, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto FROM AL_Docentes where Activo LIKE '%S%' and Contratado LIKE '%S%' ORDER BY Apellido")


        ' Ejecutar la consulta SQL con parámetros
        EjecutarConsultaSQL(carreraId, cicloLectivo, moduloId, docente_Id)
    End If
End Sub

Private Sub EjecutarConsultaSQL(carreraId As Integer, cicloLectivo As Integer, moduloId As Integer, docente_Id As Integer)
    Try
        ' Abrir la conexión a la base de datos
        CN.Open()

        ' Crear un objeto SqlCommand para ejecutar la consulta
        Dim cmdConsulta As New SqlCommand()
        cmdConsulta.Connection = CN

        Dim consultaSQL As String = "Select DISTINCT al_docentes.combo As docente, al_carreras.Nombrecompleto As carrera, al_horarios.combo As horario, al_comisiones.anio, al_comisiones.division, al_materias.descripcion As materia, tg_dias.nombredia,tg_tipos_documento.nombre_abr, al_docentes.numdoc, tg_sexos.abreviatura 
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
            WHERE 
            AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And (AL_DOCENTES.Docente_ID = @DocenteId OR @DocenteId IS NULL)
            And (al_comisiones.carrera_id = @CarreraId OR @CarreraId IS NULL)
            GROUP BY
    al_docentes.combo,
    al_carreras.Nombrecompleto,
    al_horarios.combo,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    tg_tipos_documento.nombre_abr,
    al_docentes.numdoc,
    tg_sexos.abreviatura;"



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

        Dim consultaSQL As String = "Select DISTINCT al_docentes.combo As docente, al_carreras.Nombrecompleto As carrera, al_horarios.combo As horario, al_comisiones.anio, al_comisiones.division, al_materias.descripcion As materia, tg_dias.nombredia,tg_tipos_documento.nombre_abr as tipo_documento, al_docentes.numdoc, tg_sexos.abreviatura as sexo
 
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
            WHERE
        AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And al_docentes.Docente_ID <> 5130
            And  al_docentes.Docente_ID <> 99999999
            GROUP BY
    al_docentes.combo,
    al_carreras.Nombrecompleto,
    al_horarios.combo,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    tg_tipos_documento.nombre_abr,
    al_docentes.numdoc,
    tg_sexos.abreviatura;"




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

            Dim consultaSQL As String = "Select DISTINCT al_docentes.combo As docente, al_carreras.Nombrecompleto As carrera, al_horarios.combo As horario, al_comisiones.anio, al_comisiones.division, al_materias.descripcion As materia, tg_dias.nombredia,tg_tipos_documento.nombre_abr as tipo_documento, al_docentes.numdoc, tg_sexos.abreviatura as sexo

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
            WHERE
        AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And (AL_DOCENTES.Docente_ID = @DocenteId OR @DocenteId IS NULL)
            And al_docentes.Docente_ID <> 5130
            And  al_docentes.Docente_ID <> 99999999
            GROUP BY
    al_docentes.combo,
    al_carreras.Nombrecompleto,
    al_horarios.combo,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    tg_tipos_documento.nombre_abr,
    al_docentes.numdoc,
    tg_sexos.abreviatura;"




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

            Dim consultaSQL As String = "Select DISTINCT al_docentes.combo As docente, al_carreras.Nombrecompleto As carrera, al_horarios.combo As horario, al_comisiones.anio, al_comisiones.division, al_materias.descripcion As materia, tg_dias.nombredia,tg_tipos_documento.nombre_abr, al_docentes.numdoc, tg_sexos.abreviatura as sexo
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
            WHERE
        AL_CICLOS_LECTIVOS.Descripcion = @CicloLectivo
            And AL_CICLOS_LECTIVOS_MODULOS.Modulo_ID = @ModuloId
            And al_comisiones.carrera_id = @CarreraId
            And al_docentes.Docente_ID <> 5130
            And  al_docentes.Docente_ID <> 99999999
            GROUP BY
    al_docentes.combo,
    al_carreras.Nombrecompleto,
    al_horarios.combo,
    al_comisiones.anio,
    al_comisiones.division,
    al_materias.descripcion,
    tg_dias.nombredia,
    tg_tipos_documento.nombre_abr,
    al_docentes.numdoc,
    tg_sexos.abreviatura;"




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
        Dim docente, nombre_abr, numdoc, carrera As String
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim indice As Integer = DataGridView1.CurrentRow.Index
                docente = DataGridView1.Rows(indice).Cells(1).Value
                nombre_abr = DataGridView1.Rows(indice).Cells(8).Value
                numdoc = DataGridView1.Rows(indice).Cells(9).Value
                carrera = DataGridView1.Rows(indice).Cells(2).Value
                Form3.DataGridView1.Rows.Add(docente)


            Else
                MsgBox("Por favor seleccionar un docente")
            End If

        Catch ex As Exception

        End Try
        Form3.Show()

    End Sub


End Class


'Este va en el Contratos_docentes (doble click en el proyecto)<TargetFramework>net8.0-windows7.0</TargetFramework>



