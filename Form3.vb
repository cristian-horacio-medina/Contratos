Imports Microsoft.Reporting.WinForms
Imports Contratos.Form1
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtén los datos actuales del DataGridView1
        Dim datos As DataTable = TryCast(DataGridView1.DataSource, DataTable)

        ' Llama al método para cargar los datos en el ReportViewer
        ActualizarReportViewerConDatos(datos)
    End Sub

    Public Sub AgregarDatosAlDataGridView(data As DataTable)
        DataGridView1.DataSource = data
        ' Llama al método para actualizar el ReportViewer con los datos
        ActualizarReportViewerConDatos(data)
    End Sub
    Private Sub ActualizarReportViewerConDatos(data As DataTable)
        'Verifica si los datos no son nulos
        If data IsNot Nothing Then
            ' Mapear datos del DataTable a una lista de DatosReporte
            Dim listaDatos As New List(Of DatosparaReporte)()

            For Each row As DataRow In data.Rows
                Dim datos As New DatosparaReporte()
                datos.docente = row("docente").ToString()
                datos.carrera = row("carrera").ToString()
                datos.horario = row("horario").ToString()
                datos.anio = row("anio").ToString()
                datos.division = row("division").ToString()
                datos.materia = row("materia").ToString()
                datos.nombre_abr = row("nombre_abr").ToString()
                datos.numdoc = row("numdoc").ToString()
                datos.sexo = row("sexo").ToString()

                ' ... Continúa con las demás propiedades según la estructura de tu DataTable y DatosReporte

                listaDatos.Add(datos)
            Next

            ' Reemplaza "DatosReporte" con el nombre de tu ReportDataSource en el informe .rdlc
            Dim nombreDataSource As String = "DatosReporte"
            Dim reportDataSource As New ReportDataSource(nombreDataSource, listaDatos)

            ' Limpia los DataSources existentes y agrega el nuevo ReportDataSource al ReportViewer
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource)

            ' Refresca el ReportViewer para mostrar los nuevos datos
            ReportViewer1.RefreshReport()
        End If
    End Sub



End Class