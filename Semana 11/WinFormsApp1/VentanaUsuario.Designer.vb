<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentanaUsuario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        lblName = New Label()
        btnLogout = New Button()
        btnCrear = New Button()
        btnActualizar = New Button()
        btnEliminar = New Button()
        dataView = New DataGridView()
        btnSearch = New Button()
        txtID = New TextBox()
        btnView = New Button()
        Label1 = New Label()
        CType(dataView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(254, 29)
        lblName.Name = "lblName"
        lblName.Size = New Size(53, 20)
        lblName.TabIndex = 0
        lblName.Text = "Label1"
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(476, 20)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(94, 29)
        btnLogout.TabIndex = 1
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnCrear
        ' 
        btnCrear.Location = New Point(39, 64)
        btnCrear.Name = "btnCrear"
        btnCrear.Size = New Size(531, 33)
        btnCrear.TabIndex = 2
        btnCrear.Text = "Crear"
        btnCrear.UseVisualStyleBackColor = True
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Location = New Point(39, 152)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(161, 42)
        btnActualizar.TabIndex = 3
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(225, 152)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(161, 42)
        btnEliminar.TabIndex = 4
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' dataView
        ' 
        dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataView.Location = New Point(39, 208)
        dataView.Name = "dataView"
        dataView.RowHeadersWidth = 51
        dataView.Size = New Size(531, 169)
        dataView.TabIndex = 5
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(409, 157)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(161, 37)
        btnSearch.TabIndex = 6
        btnSearch.Text = "Buscar ID"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' txtID
        ' 
        txtID.Location = New Point(80, 119)
        txtID.Name = "txtID"
        txtID.Size = New Size(490, 27)
        txtID.TabIndex = 7
        ' 
        ' btnView
        ' 
        btnView.Location = New Point(452, 394)
        btnView.Name = "btnView"
        btnView.Size = New Size(118, 44)
        btnView.TabIndex = 8
        btnView.Text = "Ver Todos"
        btnView.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(39, 119)
        Label1.Name = "Label1"
        Label1.Size = New Size(24, 20)
        Label1.TabIndex = 9
        Label1.Text = "ID"
        ' 
        ' VentanaUsuario
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(605, 450)
        Controls.Add(Label1)
        Controls.Add(btnView)
        Controls.Add(txtID)
        Controls.Add(btnSearch)
        Controls.Add(dataView)
        Controls.Add(btnEliminar)
        Controls.Add(btnActualizar)
        Controls.Add(btnCrear)
        Controls.Add(btnLogout)
        Controls.Add(lblName)
        Name = "VentanaUsuario"
        Text = "VentanaUsuario"
        CType(dataView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnCrear As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents dataView As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnView As Button
    Friend WithEvents Label1 As Label
End Class
