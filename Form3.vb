Imports Microsoft.Reporting.WinForms
Imports Contratos.Form1
Imports System.Net.Mime.MediaTypeNames
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Form3
    Dim conexion As SqlConnection
    Dim comision_id_original As Integer
    Dim division_original As String
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtén los datos actuales del DataGridView1
        Dim datos As DataTable = TryCast(DataGridView1.DataSource, DataTable)

    End Sub

    Public Sub AgregarDatosAlDataGridView(data As DataTable)
        DataGridView1.DataSource = data
        ' Llama al método para actualizar el ReportViewer con los datos

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        TextBox1.Text = DataGridView1.Item(5, i).Value()
        Label1.Text = DataGridView1.Item(5, i).Value()
        Label3.Text = DataGridView1.Item(3, i).Value()

        ' Guarda los valores originales de comision_id y division
        comision_id_original = CInt(DataGridView1.Item(3, i).Value())
        division_original = DataGridView1.Item(5, i).Value().ToString()

        TextBox2.Text = DataGridView1.Item(9, i).Value()
        Label9.Text = DataGridView1.Item(0, i).Value()

    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim textoOriginal As String = TextBox1.Text
        Dim textoModificado As String = textoOriginal.Replace("-V", "")


        Dim valorDeComisionId As Integer

        If Not Integer.TryParse(Label3.Text, valorDeComisionId) Then
            MessageBox.Show("Por favor seleccione una comisión.")
            Return
        End If

        ' Asigna el texto modificado de vuelta al TextBox
        TextBox1.Text = textoModificado
        Label3.Text = valorDeComisionId


        ' Leer la cadena de conexión desde el archivo de configuración.
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        Dim conexion As New SqlConnection(connectionString)

        Try
            ' Abre la conexión
            conexion.Open()

            ' Consulta SQL de actualización con filtro WHERE
            Dim consulta As String = "UPDATE AL_COMISIONES SET division = @nuevaDivisión WHERE Comision_ID = @comisionId"

            ' Crea un comando SQL con la consulta y la conexión
            Dim comando As New SqlCommand(consulta, conexion)

            ' Agrega parámetros
            comando.Parameters.AddWithValue("@nuevaDivisión", textoModificado)
            ' Aquí debes proporcionar el valor correcto de comision_id
            comando.Parameters.AddWithValue("@comisionId", valorDeComisionId)

            ' Ejecuta la consulta de actualización
            comando.ExecuteNonQuery()

            ' Cierra la conexión
            conexion.Close()

            MessageBox.Show("La división se ha modificado correctamente.")
        Catch ex As Exception
            MessageBox.Show("Error al modificar la división: " & ex.Message)
        Finally
            ' Cierra la conexión si está abierta
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If

        End Try



        reloaddata()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim textoOriginal As String = TextBox1.Text.Trim()
        Dim textoModificado As String = textoOriginal & "-V"
        ' Muestra los valores originales guardados
        Label4.Text = division_original
        Label5.Text = comision_id_original
        Label6.Text = textoModificado

        ' Leer la cadena de conexión desde el archivo de configuración.
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        ' Crear la conexión con la cadena de conexión leída.
        conexion = New SqlConnection(connectionString)

        Try
            ' Abre la conexión
            conexion.Open()

            ' Consulta SQL de actualización con filtro WHERE
            Dim consulta As String = "UPDATE AL_COMISIONES SET division = @nuevaDivisión WHERE Comision_ID = @comisionId"

            ' Crea un comando SQL con la consulta y la conexión
            Dim comando As New SqlCommand(consulta, conexion)

            ' Agrega parámetros
            comando.Parameters.AddWithValue("@nuevaDivisión", textoModificado)
            ' Aquí debes proporcionar el valor correcto de comision_id
            comando.Parameters.AddWithValue("@comisionId", comision_id_original
                                            )

            ' Ejecuta la consulta de actualización
            comando.ExecuteNonQuery()

            ' Cierra la conexión
            conexion.Close()

            MessageBox.Show("La división se ha modificado correctamente.")
        Catch ex As Exception
            MessageBox.Show("Error al modificar la división: " & ex.Message)
        Finally
            ' Cierra la conexión si está abierta
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try

        reloaddata()
    End Sub
    Private Sub reloaddata()
        ' coloca aquí el código para cargar nuevamente los datos en el datagridview
        Dim datos As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        DataGridView1.DataSource = datos
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim textoOriginal As String = TextBox2.Text
        Dim contratado As String = "S"

        Dim valorDeDocenteId As Integer


        If Not Integer.TryParse(Label9.Text, valorDeDocenteId) Then
            MessageBox.Show("Por favor seleccione un docente.")
            Return
        End If

        ' Asigna el texto modificado de vuelta al TextBox
        TextBox2.Text = contratado
        Label9.Text = valorDeDocenteId


        ' Leer la cadena de conexión desde el archivo de configuración.
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        Dim conexion As New SqlConnection(connectionString)

        Try
            ' Abre la conexión
            conexion.Open()

            ' Consulta SQL de actualización con filtro WHERE
            Dim consulta As String = "UPDATE AL_DOCENTES SET contratado = @contratado WHERE Docente_ID = @docenteId"

            ' Crea un comando SQL con la consulta y la conexión
            Dim comando As New SqlCommand(consulta, conexion)

            ' Agrega parámetros
            comando.Parameters.AddWithValue("@contratado", contratado)
            ' Aquí debes proporcionar el valor correcto de comision_id
            comando.Parameters.AddWithValue("@docenteId", valorDeDocenteId)

            ' Ejecuta la consulta de actualización
            comando.ExecuteNonQuery()

            ' Cierra la conexión
            conexion.Close()

            MessageBox.Show("Se ha modificado correctamente.")
        Catch ex As Exception
            MessageBox.Show("Error al modificar la división: " & ex.Message)
        Finally
            ' Cierra la conexión si está abierta
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If

        End Try



        reloaddata()
    End Sub
End Class
