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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBoxCarrera = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDocente = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsultar.Location = New System.Drawing.Point(682, 427)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(85, 29)
        Me.BtnConsultar.TabIndex = 0
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'CboModuloId
        '
        Me.CboModuloId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboModuloId.FormattingEnabled = True
        Me.CboModuloId.Location = New System.Drawing.Point(9, 75)
        Me.CboModuloId.Name = "CboModuloId"
        Me.CboModuloId.Size = New System.Drawing.Size(222, 24)
        Me.CboModuloId.TabIndex = 2
        '
        'cboCicloLectivo
        '
        Me.cboCicloLectivo.FormattingEnabled = True
        Me.cboCicloLectivo.Location = New System.Drawing.Point(9, 267)
        Me.cboCicloLectivo.Name = "cboCicloLectivo"
        Me.cboCicloLectivo.Size = New System.Drawing.Size(192, 21)
        Me.cboCicloLectivo.TabIndex = 3
        Me.cboCicloLectivo.Visible = False
        '
        'cboDocente
        '
        Me.cboDocente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDocente.FormattingEnabled = True
        Me.cboDocente.Location = New System.Drawing.Point(9, 159)
        Me.cboDocente.Name = "cboDocente"
        Me.cboDocente.Size = New System.Drawing.Size(222, 23)
        Me.cboDocente.TabIndex = 4
        '
        'cboCarrera
        '
        Me.cboCarrera.DropDownWidth = 286
        Me.cboCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarrera.FormattingEnabled = True
        Me.cboCarrera.Location = New System.Drawing.Point(9, 116)
        Me.cboCarrera.Name = "cboCarrera"
        Me.cboCarrera.Size = New System.Drawing.Size(222, 23)
        Me.cboCarrera.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(308, 10)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1048, 401)
        Me.DataGridView1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(806, 427)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 28)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Seleccionados"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 19)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ciclo Lectivo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(111, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 19)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "                      "
        '
        'CheckBoxCarrera
        '
        Me.CheckBoxCarrera.AutoSize = True
        Me.CheckBoxCarrera.Location = New System.Drawing.Point(249, 121)
        Me.CheckBoxCarrera.Name = "CheckBoxCarrera"
        Me.CheckBoxCarrera.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxCarrera.TabIndex = 12
        Me.CheckBoxCarrera.Text = "todos"
        Me.CheckBoxCarrera.UseVisualStyleBackColor = True
        '
        'CheckBoxDocente
        '
        Me.CheckBoxDocente.AutoSize = True
        Me.CheckBoxDocente.Location = New System.Drawing.Point(250, 161)
        Me.CheckBoxDocente.Name = "CheckBoxDocente"
        Me.CheckBoxDocente.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxDocente.TabIndex = 13
        Me.CheckBoxDocente.Text = "todos"
        Me.CheckBoxDocente.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 364)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Label3"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1250, 439)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 36)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "&Salir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1368, 493)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBoxDocente)
        Me.Controls.Add(Me.CheckBoxCarrera)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
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
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBoxCarrera As CheckBox
    Friend WithEvents CheckBoxDocente As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
End Class
