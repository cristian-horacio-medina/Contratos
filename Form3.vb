Imports Microsoft.Reporting.WinForms

Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.ReportViewer1.RefreshReport

        Me.ReportViewer1.RefreshReport()

    End Sub

    Public Sub AgregarDatosAlDataGridView(data As DataTable)
        DataGridView1.DataSource = data
    End Sub

    Public Sub MostrarDatosEnDataGridViewYReporte(datos As List(Of DatosReporte))
        ' Mostrar datos en el DataGridView
        DataGridView1.DataSource = datos

        ' Mostrar datos en el informe
        Dim reporte As New Microsoft.Reporting.WinForms.LocalReport
        reporte.ReportPath = "C:\Users\Papá\source\repos\cristian-horacio-medina\Contratos\Informe.rdlc"

        ' Crear un origen de datos para el informe
        Dim dataSource As New Microsoft.Reporting.WinForms.ReportDataSource("DatosReporte", datos)
        reporte.DataSources.Add(dataSource)

        ' Asignar el informe al ReportViewer
        ReportViewer1.LocalReport.ReportPath = reporte.ReportPath
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dataSource)

        ' Refrescar el ReportViewer
        ReportViewer1.RefreshReport()

        ' Mostrar el formulario con el ReportViewer
        Me.Show()
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        TextBox1.Text = DataGridView1.Item(4, i).Value()
        Label1.Text = DataGridView1.Item(4, i).Value()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim textoOriginal As String = TextBox1.Text
        Dim textoModificado As String = textoOriginal.Replace("-V", "")

        ' Asigna el texto modificado de vuelta al TextBox
        TextBox1.Text = textoModificado

    End Sub
End Class

