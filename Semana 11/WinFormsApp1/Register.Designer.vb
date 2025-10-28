<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
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
        btnRegistrar = New Button()
        btnLogin = New Button()
        SuspendLayout()
        ' 
        ' btnRegistrar
        ' 
        btnRegistrar.Location = New Point(33, 36)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(314, 42)
        btnRegistrar.TabIndex = 0
        btnRegistrar.Text = "Registrar"
        btnRegistrar.UseVisualStyleBackColor = True
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(33, 144)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(314, 29)
        btnLogin.TabIndex = 1
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' Register
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 194)
        Controls.Add(btnLogin)
        Controls.Add(btnRegistrar)
        Name = "Register"
        Text = "Register"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnRegistrar As Button
    Friend WithEvents btnLogin As Button
End Class
