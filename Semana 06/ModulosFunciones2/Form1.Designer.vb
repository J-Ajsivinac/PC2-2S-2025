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
        Panel1 = New Panel()
        Panel4 = New Panel()
        lblAreaResultado = New Label()
        btnCalcularArea = New Button()
        lblSumaResultado = New Label()
        btnSumar = New Button()
        txtRadio = New TextBox()
        Label6 = New Label()
        txtNum2 = New TextBox()
        Label5 = New Label()
        txtNum1 = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        txtInformacion = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        Panel2 = New Panel()
        Label12 = New Label()
        txtResultadoTexto = New TextBox()
        btnProcesarTexto = New Button()
        txtTextoEntrada = New TextBox()
        Label15 = New Label()
        Label16 = New Label()
        Panel3 = New Panel()
        btn_verForm2 = New Button()
        btnReiniciar = New Button()
        btnIncrementar = New Button()
        Label11 = New Label()
        Label9 = New Label()
        txtNumPrimo = New TextBox()
        Label10 = New Label()
        Label13 = New Label()
        btnVerificarPrimo = New Button()
        lblEsPrimo = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(lblAreaResultado)
        Panel1.Controls.Add(btnCalcularArea)
        Panel1.Controls.Add(lblSumaResultado)
        Panel1.Controls.Add(btnSumar)
        Panel1.Controls.Add(txtRadio)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(txtNum2)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(txtNum1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(txtInformacion)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(0, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(536, 480)
        Panel1.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(3, 486)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1066, 102)
        Panel4.TabIndex = 17
        ' 
        ' lblAreaResultado
        ' 
        lblAreaResultado.AutoSize = True
        lblAreaResultado.Location = New Point(412, 446)
        lblAreaResultado.Name = "lblAreaResultado"
        lblAreaResultado.Size = New Size(75, 20)
        lblAreaResultado.TabIndex = 13
        lblAreaResultado.Text = "Resultado"
        ' 
        ' btnCalcularArea
        ' 
        btnCalcularArea.Location = New Point(377, 401)
        btnCalcularArea.Name = "btnCalcularArea"
        btnCalcularArea.Size = New Size(129, 29)
        btnCalcularArea.TabIndex = 12
        btnCalcularArea.Text = "Calcular Area"
        btnCalcularArea.UseVisualStyleBackColor = True
        ' 
        ' lblSumaResultado
        ' 
        lblSumaResultado.AutoSize = True
        lblSumaResultado.Location = New Point(412, 334)
        lblSumaResultado.Name = "lblSumaResultado"
        lblSumaResultado.Size = New Size(75, 20)
        lblSumaResultado.TabIndex = 11
        lblSumaResultado.Text = "Resultado"
        ' 
        ' btnSumar
        ' 
        btnSumar.Location = New Point(412, 289)
        btnSumar.Name = "btnSumar"
        btnSumar.Size = New Size(94, 29)
        btnSumar.TabIndex = 10
        btnSumar.Text = "Sumar"
        btnSumar.UseVisualStyleBackColor = True
        ' 
        ' txtRadio
        ' 
        txtRadio.Location = New Point(130, 368)
        txtRadio.Name = "txtRadio"
        txtRadio.Size = New Size(376, 27)
        txtRadio.TabIndex = 9
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(33, 371)
        Label6.Name = "Label6"
        Label6.Size = New Size(48, 20)
        Label6.TabIndex = 8
        Label6.Text = "Radio"
        ' 
        ' txtNum2
        ' 
        txtNum2.Location = New Point(130, 245)
        txtNum2.Name = "txtNum2"
        txtNum2.Size = New Size(376, 27)
        txtNum2.TabIndex = 7
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(33, 248)
        Label5.Name = "Label5"
        Label5.Size = New Size(75, 20)
        Label5.TabIndex = 6
        Label5.Text = "Numero 2"
        ' 
        ' txtNum1
        ' 
        txtNum1.Location = New Point(130, 212)
        txtNum1.Name = "txtNum1"
        txtNum1.Size = New Size(376, 27)
        txtNum1.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(33, 215)
        Label4.Name = "Label4"
        Label4.Size = New Size(75, 20)
        Label4.TabIndex = 4
        Label4.Text = "Numero 1"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(25, 182)
        Label3.Name = "Label3"
        Label3.Size = New Size(197, 23)
        Label3.TabIndex = 3
        Label3.Text = "Operaciones Númericas"
        ' 
        ' txtInformacion
        ' 
        txtInformacion.Location = New Point(25, 76)
        txtInformacion.Multiline = True
        txtInformacion.Name = "txtInformacion"
        txtInformacion.ReadOnly = True
        txtInformacion.Size = New Size(481, 89)
        txtInformacion.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(25, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(100, 20)
        Label2.TabIndex = 1
        Label2.Text = "Estado Actual"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(25, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(107, 23)
        Label1.TabIndex = 0
        Label1.Text = "Información"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(txtResultadoTexto)
        Panel2.Controls.Add(btnProcesarTexto)
        Panel2.Controls.Add(txtTextoEntrada)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(Label16)
        Panel2.Location = New Point(542, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(527, 305)
        Panel2.TabIndex = 14
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(25, 208)
        Label12.Name = "Label12"
        Label12.Size = New Size(75, 20)
        Label12.TabIndex = 15
        Label12.Text = "Resultado"
        ' 
        ' txtResultadoTexto
        ' 
        txtResultadoTexto.Location = New Point(25, 231)
        txtResultadoTexto.Multiline = True
        txtResultadoTexto.Name = "txtResultadoTexto"
        txtResultadoTexto.ReadOnly = True
        txtResultadoTexto.Size = New Size(481, 60)
        txtResultadoTexto.TabIndex = 14
        ' 
        ' btnProcesarTexto
        ' 
        btnProcesarTexto.Location = New Point(189, 171)
        btnProcesarTexto.Name = "btnProcesarTexto"
        btnProcesarTexto.Size = New Size(150, 29)
        btnProcesarTexto.TabIndex = 10
        btnProcesarTexto.Text = "Procesar Texto"
        btnProcesarTexto.UseVisualStyleBackColor = True
        ' 
        ' txtTextoEntrada
        ' 
        txtTextoEntrada.Location = New Point(25, 76)
        txtTextoEntrada.Multiline = True
        txtTextoEntrada.Name = "txtTextoEntrada"
        txtTextoEntrada.Size = New Size(481, 89)
        txtTextoEntrada.TabIndex = 2
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(25, 53)
        Label15.Name = "Label15"
        Label15.Size = New Size(121, 20)
        Label15.TabIndex = 1
        Label15.Text = "Texto de Entrada"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(25, 22)
        Label16.Name = "Label16"
        Label16.Size = New Size(107, 23)
        Label16.TabIndex = 0
        Label16.Text = "Información"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(btn_verForm2)
        Panel3.Controls.Add(btnReiniciar)
        Panel3.Controls.Add(btnIncrementar)
        Panel3.Controls.Add(Label11)
        Panel3.Location = New Point(542, 314)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(527, 169)
        Panel3.TabIndex = 16
        ' 
        ' btn_verForm2
        ' 
        btn_verForm2.Location = New Point(345, 74)
        btn_verForm2.Name = "btn_verForm2"
        btn_verForm2.Size = New Size(148, 45)
        btn_verForm2.TabIndex = 3
        btn_verForm2.Text = "Ver Form2"
        btn_verForm2.UseVisualStyleBackColor = True
        ' 
        ' btnReiniciar
        ' 
        btnReiniciar.Location = New Point(189, 74)
        btnReiniciar.Name = "btnReiniciar"
        btnReiniciar.Size = New Size(150, 45)
        btnReiniciar.TabIndex = 2
        btnReiniciar.Text = "Reiniciar Datos"
        btnReiniciar.UseVisualStyleBackColor = True
        ' 
        ' btnIncrementar
        ' 
        btnIncrementar.Location = New Point(25, 74)
        btnIncrementar.Name = "btnIncrementar"
        btnIncrementar.Size = New Size(162, 45)
        btnIncrementar.TabIndex = 1
        btnIncrementar.Text = "Incrementar Contador"
        btnIncrementar.UseVisualStyleBackColor = True
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(25, 22)
        Label11.Name = "Label11"
        Label11.Size = New Size(127, 23)
        Label11.TabIndex = 0
        Label11.Text = "Control Global"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(25, 500)
        Label9.Name = "Label9"
        Label9.Size = New Size(197, 23)
        Label9.TabIndex = 17
        Label9.Text = "Operaciones Númericas"
        ' 
        ' txtNumPrimo
        ' 
        txtNumPrimo.Location = New Point(160, 540)
        txtNumPrimo.Name = "txtNumPrimo"
        txtNumPrimo.Size = New Size(376, 27)
        txtNumPrimo.TabIndex = 19
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(33, 544)
        Label10.Name = "Label10"
        Label10.Size = New Size(106, 20)
        Label10.TabIndex = 18
        Label10.Text = "Numero Primo"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(228, 503)
        Label13.Name = "Label13"
        Label13.Size = New Size(130, 20)
        Label13.TabIndex = 16
        Label13.Text = "(verificar si es par)"
        ' 
        ' btnVerificarPrimo
        ' 
        btnVerificarPrimo.Location = New Point(548, 540)
        btnVerificarPrimo.Name = "btnVerificarPrimo"
        btnVerificarPrimo.Size = New Size(94, 29)
        btnVerificarPrimo.TabIndex = 20
        btnVerificarPrimo.Text = "Verificar"
        btnVerificarPrimo.UseVisualStyleBackColor = True
        ' 
        ' lblEsPrimo
        ' 
        lblEsPrimo.AutoSize = True
        lblEsPrimo.Location = New Point(648, 544)
        lblEsPrimo.Name = "lblEsPrimo"
        lblEsPrimo.Size = New Size(81, 20)
        lblEsPrimo.TabIndex = 21
        lblEsPrimo.Text = "Resultados"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1073, 590)
        Controls.Add(lblEsPrimo)
        Controls.Add(btnVerificarPrimo)
        Controls.Add(Label13)
        Controls.Add(txtNumPrimo)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtNum2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNum1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtInformacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAreaResultado As Label
    Friend WithEvents btnCalcularArea As Button
    Friend WithEvents lblSumaResultado As Label
    Friend WithEvents btnSumar As Button
    Friend WithEvents txtRadio As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnProcesarTexto As Button
    Friend WithEvents txtTextoEntrada As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtResultadoTexto As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnIncrementar As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents btnReiniciar As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNumPrimo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnVerificarPrimo As Button
    Friend WithEvents lblEsPrimo As Label
    Friend WithEvents btn_verForm2 As Button

End Class
