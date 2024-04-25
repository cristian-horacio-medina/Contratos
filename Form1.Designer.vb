<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BtnConsultar = New System.Windows.Forms.Button()
        Me.CboModuloId = New System.Windows.Forms.ComboBox()
        Me.cboCicloLectivo = New System.Windows.Forms.ComboBox()
        Me.cboDocente = New System.Windows.Forms.ComboBox()
        Me.cboCarrera = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CheckBoxCarrera = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDocente = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Location = New System.Drawing.Point(795, 350)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(85, 29)
        Me.BtnConsultar.TabIndex = 0
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'CboModuloId
        '
        Me.CboModuloId.FormattingEnabled = True
        Me.CboModuloId.Location = New System.Drawing.Point(9, 75)
        Me.CboModuloId.Name = "CboModuloId"
        Me.CboModuloId.Size = New System.Drawing.Size(192, 21)
        Me.CboModuloId.TabIndex = 2
        '
        'cboCicloLectivo
        '
        Me.cboCicloLectivo.FormattingEnabled = True
        Me.cboCicloLectivo.Location = New System.Drawing.Point(9, 36)
        Me.cboCicloLectivo.Name = "cboCicloLectivo"
        Me.cboCicloLectivo.Size = New System.Drawing.Size(192, 21)
        Me.cboCicloLectivo.TabIndex = 3
        '
        'cboDocente
        '
        Me.cboDocente.FormattingEnabled = True
        Me.cboDocente.Location = New System.Drawing.Point(9, 159)
        Me.cboDocente.Name = "cboDocente"
        Me.cboDocente.Size = New System.Drawing.Size(222, 21)
        Me.cboDocente.TabIndex = 4
        '
        'cboCarrera
        '
        Me.cboCarrera.DropDownWidth = 286
        Me.cboCarrera.FormattingEnabled = True
        Me.cboCarrera.Location = New System.Drawing.Point(9, 114)
        Me.cboCarrera.Name = "cboCarrera"
        Me.cboCarrera.Size = New System.Drawing.Size(222, 21)
        Me.cboCarrera.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(295, 10)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1061, 329)
        Me.DataGridView1.TabIndex = 6
        '
        'CheckBoxCarrera
        '
        Me.CheckBoxCarrera.AutoSize = True
        Me.CheckBoxCarrera.Location = New System.Drawing.Point(237, 118)
        Me.CheckBoxCarrera.Name = "CheckBoxCarrera"
        Me.CheckBoxCarrera.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxCarrera.TabIndex = 7
        Me.CheckBoxCarrera.Text = "todas"
        Me.CheckBoxCarrera.UseVisualStyleBackColor = True
        '
        'CheckBoxDocente
        '
        Me.CheckBoxDocente.AutoSize = True
        Me.CheckBoxDocente.Location = New System.Drawing.Point(237, 163)
        Me.CheckBoxDocente.Name = "CheckBoxDocente"
        Me.CheckBoxDocente.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxDocente.TabIndex = 8
        Me.CheckBoxDocente.Text = "todos"
        Me.CheckBoxDocente.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(893, 350)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 28)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Seleccionados"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 390)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBoxDocente)
        Me.Controls.Add(Me.CheckBoxCarrera)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cboCarrera)
        Me.Controls.Add(Me.cboDocente)
        Me.Controls.Add(Me.cboCicloLectivo)
        Me.Controls.Add(Me.CboModuloId)
        Me.Controls.Add(Me.BtnConsultar)
        Me.Name = "Form1"
        Me.Text = "Contratos_docentes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnConsultar As Button
    Friend WithEvents CboModuloId As ComboBox
    Friend WithEvents cboCicloLectivo As ComboBox
    Friend WithEvents cboDocente As ComboBox
    Friend WithEvents cboCarrera As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CheckBoxCarrera As CheckBox
    Friend WithEvents CheckBoxDocente As CheckBox
    Friend WithEvents Button1 As Button
End Class
