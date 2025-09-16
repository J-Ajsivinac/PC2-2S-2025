<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Label1 = New Label()
        txtNombre = New TextBox()
        txtCalificaciones = New Label()
        txtCalif = New TextBox()
        btnAgregar = New Button()
        btnCalcular = New Button()
        btnEstadistica = New Button()
        btnLimpiar = New Button()
        btnCargar = New Button()
        dgvDatos = New DataGridView()
        txtBuscar = New TextBox()
        btnBuscar = New Button()
        chkEditMode = New CheckBox()
        CType(dgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(32, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 20)
        Label1.TabIndex = 0
        Label1.Text = "Nombre"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(102, 23)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(219, 27)
        txtNombre.TabIndex = 1
        ' 
        ' txtCalificaciones
        ' 
        txtCalificaciones.AutoSize = True
        txtCalificaciones.Location = New Point(403, 26)
        txtCalificaciones.Name = "txtCalificaciones"
        txtCalificaciones.Size = New Size(100, 20)
        txtCalificaciones.TabIndex = 2
        txtCalificaciones.Text = "Calificaciones"
        ' 
        ' txtCalif
        ' 
        txtCalif.Location = New Point(526, 27)
        txtCalif.Name = "txtCalif"
        txtCalif.Size = New Size(256, 27)
        txtCalif.TabIndex = 3
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Location = New Point(32, 94)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(137, 55)
        btnAgregar.TabIndex = 4
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnCalcular
        ' 
        btnCalcular.Location = New Point(184, 94)
        btnCalcular.Name = "btnCalcular"
        btnCalcular.Size = New Size(137, 55)
        btnCalcular.TabIndex = 5
        btnCalcular.Text = "Calcular"
        btnCalcular.UseVisualStyleBackColor = True
        ' 
        ' btnEstadistica
        ' 
        btnEstadistica.Location = New Point(340, 94)
        btnEstadistica.Name = "btnEstadistica"
        btnEstadistica.Size = New Size(137, 55)
        btnEstadistica.TabIndex = 6
        btnEstadistica.Text = "Estadistica"
        btnEstadistica.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Location = New Point(483, 94)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(137, 55)
        btnLimpiar.TabIndex = 7
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' btnCargar
        ' 
        btnCargar.Location = New Point(627, 94)
        btnCargar.Name = "btnCargar"
        btnCargar.Size = New Size(137, 55)
        btnCargar.TabIndex = 8
        btnCargar.Text = "Cargar"
        btnCargar.UseVisualStyleBackColor = True
        ' 
        ' dgvDatos
        ' 
        dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDatos.Location = New Point(32, 188)
        dgvDatos.Name = "dgvDatos"
        dgvDatos.RowHeadersWidth = 51
        dgvDatos.Size = New Size(732, 178)
        dgvDatos.TabIndex = 9
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(32, 421)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(271, 27)
        txtBuscar.TabIndex = 10
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Location = New Point(329, 419)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(94, 29)
        btnBuscar.TabIndex = 11
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' chkEditMode
        ' 
        chkEditMode.AutoSize = True
        chkEditMode.Location = New Point(32, 381)
        chkEditMode.Name = "chkEditMode"
        chkEditMode.Size = New Size(124, 24)
        chkEditMode.TabIndex = 12
        chkEditMode.Text = "Modo edición"
        chkEditMode.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 488)
        Controls.Add(chkEditMode)
        Controls.Add(btnBuscar)
        Controls.Add(txtBuscar)
        Controls.Add(dgvDatos)
        Controls.Add(btnCargar)
        Controls.Add(btnLimpiar)
        Controls.Add(btnEstadistica)
        Controls.Add(btnCalcular)
        Controls.Add(btnAgregar)
        Controls.Add(txtCalif)
        Controls.Add(txtCalificaciones)
        Controls.Add(txtNombre)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        CType(dgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtCalificaciones As Label
    Friend WithEvents txtCalif As TextBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnCalcular As Button
    Friend WithEvents btnEstadistica As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCargar As Button
    Friend WithEvents dgvDatos As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents chkEditMode As CheckBox

End Class
