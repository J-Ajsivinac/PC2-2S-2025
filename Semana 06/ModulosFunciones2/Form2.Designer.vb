<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Label1 = New Label()
        btnVerFormualrioPrincipal = New Button()
        cmbRoles = New ComboBox()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(292, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(156, 20)
        Label1.TabIndex = 0
        Label1.Text = "Este es el formulario 2"
        ' 
        ' btnVerFormualrioPrincipal
        ' 
        btnVerFormualrioPrincipal.Location = New Point(35, 96)
        btnVerFormualrioPrincipal.Name = "btnVerFormualrioPrincipal"
        btnVerFormualrioPrincipal.Size = New Size(158, 46)
        btnVerFormualrioPrincipal.TabIndex = 1
        btnVerFormualrioPrincipal.Text = "Ver Principal"
        btnVerFormualrioPrincipal.UseVisualStyleBackColor = True
        ' 
        ' cmbRoles
        ' 
        cmbRoles.FormattingEnabled = True
        cmbRoles.Items.AddRange(New Object() {"Administrador", "Estudiante"})
        cmbRoles.Location = New Point(292, 106)
        cmbRoles.Name = "cmbRoles"
        cmbRoles.Size = New Size(217, 28)
        cmbRoles.TabIndex = 2
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(292, 156)
        Button1.Name = "Button1"
        Button1.Size = New Size(217, 29)
        Button1.TabIndex = 3
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(cmbRoles)
        Controls.Add(btnVerFormualrioPrincipal)
        Controls.Add(Label1)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnVerFormualrioPrincipal As Button
    Friend WithEvents cmbRoles As ComboBox
    Friend WithEvents Button1 As Button
End Class
