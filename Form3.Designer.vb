<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.docente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.carrera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.horario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.división = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.materia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombredia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monbre_abr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.número_dni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Contratos.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 230)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1071, 208)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.docente, Me.carrera, Me.horario, Me.anio, Me.división, Me.materia, Me.nombredia, Me.monbre_abr, Me.número_dni, Me.sexo})
        Me.DataGridView1.Location = New System.Drawing.Point(13, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1071, 207)
        Me.DataGridView1.TabIndex = 1
        '
        'docente
        '
        Me.docente.HeaderText = "docente"
        Me.docente.Name = "docente"
        '
        'carrera
        '
        Me.carrera.HeaderText = "carrera"
        Me.carrera.Name = "carrera"
        '
        'horario
        '
        Me.horario.HeaderText = "horario"
        Me.horario.Name = "horario"
        '
        'anio
        '
        Me.anio.HeaderText = "año"
        Me.anio.Name = "anio"
        '
        'división
        '
        Me.división.HeaderText = "división"
        Me.división.Name = "división"
        '
        'materia
        '
        Me.materia.HeaderText = "materia"
        Me.materia.Name = "materia"
        '
        'nombredia
        '
        Me.nombredia.HeaderText = "día"
        Me.nombredia.Name = "nombredia"
        '
        'monbre_abr
        '
        Me.monbre_abr.HeaderText = "tipo_doc"
        Me.monbre_abr.Name = "monbre_abr"
        '
        'número_dni
        '
        Me.número_dni.HeaderText = "DNI"
        Me.número_dni.Name = "número_dni"
        '
        'sexo
        '
        Me.sexo.HeaderText = "sexo"
        Me.sexo.Name = "sexo"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Form3"
        Me.Text = "Reporte"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents docente As DataGridViewTextBoxColumn
    Friend WithEvents carrera As DataGridViewTextBoxColumn
    Friend WithEvents horario As DataGridViewTextBoxColumn
    Friend WithEvents anio As DataGridViewTextBoxColumn
    Friend WithEvents división As DataGridViewTextBoxColumn
    Friend WithEvents materia As DataGridViewTextBoxColumn
    Friend WithEvents nombredia As DataGridViewTextBoxColumn
    Friend WithEvents monbre_abr As DataGridViewTextBoxColumn
    Friend WithEvents número_dni As DataGridViewTextBoxColumn
    Friend WithEvents sexo As DataGridViewTextBoxColumn
End Class
