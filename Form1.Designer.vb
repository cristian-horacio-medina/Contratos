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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsultar.Location = New System.Drawing.Point(81, 256)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(98, 29)
        Me.BtnConsultar.TabIndex = 0
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'CboModuloId
        '
        Me.CboModuloId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboModuloId.FormattingEnabled = True
        Me.CboModuloId.Location = New System.Drawing.Point(12, 102)
        Me.CboModuloId.Name = "CboModuloId"
        Me.CboModuloId.Size = New System.Drawing.Size(222, 24)
        Me.CboModuloId.TabIndex = 2
        '
        'cboCicloLectivo
        '
        Me.cboCicloLectivo.FormattingEnabled = True
        Me.cboCicloLectivo.Location = New System.Drawing.Point(12, 326)
        Me.cboCicloLectivo.Name = "cboCicloLectivo"
        Me.cboCicloLectivo.Size = New System.Drawing.Size(192, 21)
        Me.cboCicloLectivo.TabIndex = 3
        Me.cboCicloLectivo.Visible = False
        '
        'cboDocente
        '
        Me.cboDocente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDocente.FormattingEnabled = True
        Me.cboDocente.Location = New System.Drawing.Point(9, 212)
        Me.cboDocente.Name = "cboDocente"
        Me.cboDocente.Size = New System.Drawing.Size(222, 23)
        Me.cboDocente.TabIndex = 4
        '
        'cboCarrera
        '
        Me.cboCarrera.DropDownWidth = 286
        Me.cboCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarrera.FormattingEnabled = True
        Me.cboCarrera.Location = New System.Drawing.Point(12, 156)
        Me.cboCarrera.Name = "cboCarrera"
        Me.cboCarrera.Size = New System.Drawing.Size(222, 23)
        Me.cboCarrera.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(308, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1048, 358)
        Me.DataGridView1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(806, 427)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 28)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "&Seleccionado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 22)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ciclo Lectivo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 22)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "                      "
        '
        'CheckBoxCarrera
        '
        Me.CheckBoxCarrera.AutoSize = True
        Me.CheckBoxCarrera.Location = New System.Drawing.Point(240, 162)
        Me.CheckBoxCarrera.Name = "CheckBoxCarrera"
        Me.CheckBoxCarrera.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxCarrera.TabIndex = 12
        Me.CheckBoxCarrera.Text = "todos"
        Me.CheckBoxCarrera.UseVisualStyleBackColor = True
        '
        'CheckBoxDocente
        '
        Me.CheckBoxDocente.AutoSize = True
        Me.CheckBoxDocente.Location = New System.Drawing.Point(237, 212)
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
        Me.Label3.Location = New System.Drawing.Point(6, 435)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(308, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(738, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Para cambiar el nombre, haga clic en la comisión deseada. Luego clic en el botón " &
    "Seleccionado."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Cuatrimestre"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Carrera"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Docente"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1368, 493)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
