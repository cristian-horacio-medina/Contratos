Imports Microsoft.Reporting.WinForms
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim param1 As New ReportParameter("docente", "Docente: " & Form1.SelectedRows.Cells(0).Value.ToString)
        ReportViewer1.LocalReport.SetParameters(param1)
        Me.ReportViewer1.RefreshReport()

    End Sub


End Class