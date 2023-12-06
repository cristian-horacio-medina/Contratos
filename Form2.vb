Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New SqlConnection("Data Source=PAPA-PC\SQL;Initial Catalog=Gestion;User ID=sa;Password=$sql3")
        Dim dt As New DataTable
        Dim cmdConsulta2 As New SqlCommand("Select Descripcion, Abreviatura FROM Al_turnos", conn)
        Dim da As New SqlDataAdapter(cmdConsulta2)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Private Sub GenerarReporteDesdeSeleccion()
        ' Crear una lista para almacenar las filas seleccionadas
        Dim filasSeleccionadas As New List(Of DataGridViewRow)

        ' Recorrer el DataGridView para encontrar las filas seleccionadas
        For Each fila As DataGridViewRow In DataGridView1.Rows
            ' Verificar si la celda del CheckBox está marcada
            If Convert.ToBoolean(fila.Cells("Seleccione").Value) Then
                ' Agregar la fila a la lista de filas seleccionadas
                filasSeleccionadas.Add(fila)
            End If
        Next

        ' Crear un nuevo origen de datos para el informe
        Dim dataSource As New ReportDataSource("NombreDataSet", filasSeleccionadas)

        ' Limpiar el control ReportViewer antes de cargar el informe
        ReportViewer1.LocalReport.DataSources.Clear()

        ' Asignar el origen de datos al informe
        ReportViewer1.LocalReport.DataSources.Add(dataSource)

        ' Asignar la ruta del informe a cargar (ruta relativa al proyecto)
        ReportViewer1.LocalReport.ReportPath = "RutaAlInforme\Informe1.rdlc"

        ' Refrescar el control ReportViewer para mostrar el informe
        ReportViewer1.RefreshReport()
    End Sub
End Class