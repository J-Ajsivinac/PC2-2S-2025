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
        TxtChlorine = New TextBox()
        Label7 = New Label()
        TxtSoftener = New TextBox()
        Label6 = New Label()
        TxtGlassCleaner = New TextBox()
        Label5 = New Label()
        TxtDeodorant = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        TxtDetergent = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        CmbClientType = New ComboBox()
        Panel2 = New Panel()
        BtnExit = New Button()
        BtnClear = New Button()
        BtnCalculate = New Button()
        Panel3 = New Panel()
        LblTotal = New Label()
        Label12 = New Label()
        LblDiscount2 = New Label()
        Label13 = New Label()
        LblDiscount1 = New Label()
        Label11 = New Label()
        LblSubtotal = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TxtChlorine)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(TxtSoftener)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(TxtGlassCleaner)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(TxtDeodorant)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(TxtDetergent)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(CmbClientType)
        Panel1.Location = New Point(2, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(557, 328)
        Panel1.TabIndex = 0
        ' 
        ' TxtChlorine
        ' 
        TxtChlorine.Location = New Point(157, 284)
        TxtChlorine.Name = "TxtChlorine"
        TxtChlorine.Size = New Size(364, 27)
        TxtChlorine.TabIndex = 12
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(29, 287)
        Label7.Name = "Label7"
        Label7.Size = New Size(45, 20)
        Label7.TabIndex = 11
        Label7.Text = "Cloro"
        ' 
        ' TxtSoftener
        ' 
        TxtSoftener.Location = New Point(157, 241)
        TxtSoftener.Name = "TxtSoftener"
        TxtSoftener.Size = New Size(364, 27)
        TxtSoftener.TabIndex = 10
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(29, 244)
        Label6.Name = "Label6"
        Label6.Size = New Size(80, 20)
        Label6.TabIndex = 9
        Label6.Text = "Suavizante"
        ' 
        ' TxtGlassCleaner
        ' 
        TxtGlassCleaner.Location = New Point(157, 195)
        TxtGlassCleaner.Name = "TxtGlassCleaner"
        TxtGlassCleaner.Size = New Size(364, 27)
        TxtGlassCleaner.TabIndex = 8
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(29, 198)
        Label5.Name = "Label5"
        Label5.Size = New Size(98, 20)
        Label5.TabIndex = 7
        Label5.Text = "Limpiavidrios"
        ' 
        ' TxtDeodorant
        ' 
        TxtDeodorant.Location = New Point(157, 151)
        TxtDeodorant.Name = "TxtDeodorant"
        TxtDeodorant.Size = New Size(364, 27)
        TxtDeodorant.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(29, 154)
        Label4.Name = "Label4"
        Label4.Size = New Size(100, 20)
        Label4.TabIndex = 5
        Label4.Text = "Desinfectante"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Cascadia Code SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(29, 66)
        Label3.Name = "Label3"
        Label3.Size = New Size(372, 27)
        Label3.TabIndex = 4
        Label3.Text = "Ingrese el numero de Productos"
        ' 
        ' TxtDetergent
        ' 
        TxtDetergent.Location = New Point(157, 109)
        TxtDetergent.Name = "TxtDetergent"
        TxtDetergent.Size = New Size(364, 27)
        TxtDetergent.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(29, 112)
        Label2.Name = "Label2"
        Label2.Size = New Size(84, 20)
        Label2.TabIndex = 2
        Label2.Text = "Detergente"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(29, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 20)
        Label1.TabIndex = 1
        Label1.Text = "Tipo de Cliente"
        ' 
        ' CmbClientType
        ' 
        CmbClientType.FormattingEnabled = True
        CmbClientType.Items.AddRange(New Object() {"Regular", "Mayorista", "Premium"})
        CmbClientType.Location = New Point(157, 19)
        CmbClientType.Name = "CmbClientType"
        CmbClientType.Size = New Size(364, 28)
        CmbClientType.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(BtnExit)
        Panel2.Controls.Add(BtnClear)
        Panel2.Controls.Add(BtnCalculate)
        Panel2.Location = New Point(2, 327)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(557, 53)
        Panel2.TabIndex = 1
        ' 
        ' BtnExit
        ' 
        BtnExit.Location = New Point(366, 18)
        BtnExit.Name = "BtnExit"
        BtnExit.Size = New Size(94, 29)
        BtnExit.TabIndex = 2
        BtnExit.Text = "Cerrar"
        BtnExit.UseVisualStyleBackColor = True
        ' 
        ' BtnClear
        ' 
        BtnClear.Location = New Point(214, 17)
        BtnClear.Name = "BtnClear"
        BtnClear.Size = New Size(94, 29)
        BtnClear.TabIndex = 1
        BtnClear.Text = "Limpiar"
        BtnClear.UseVisualStyleBackColor = True
        ' 
        ' BtnCalculate
        ' 
        BtnCalculate.Location = New Point(62, 15)
        BtnCalculate.Name = "BtnCalculate"
        BtnCalculate.Size = New Size(94, 29)
        BtnCalculate.TabIndex = 0
        BtnCalculate.Text = "Calcular"
        BtnCalculate.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(LblTotal)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(LblDiscount2)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(LblDiscount1)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(LblSubtotal)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label8)
        Panel3.Location = New Point(3, 382)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(556, 145)
        Panel3.TabIndex = 2
        ' 
        ' LblTotal
        ' 
        LblTotal.AutoSize = True
        LblTotal.Location = New Point(421, 73)
        LblTotal.Name = "LblTotal"
        LblTotal.Size = New Size(18, 20)
        LblTotal.TabIndex = 8
        LblTotal.Text = "..."
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(303, 73)
        Label12.Name = "Label12"
        Label12.Size = New Size(97, 20)
        Label12.TabIndex = 7
        Label12.Text = "Total a pagar"
        ' 
        ' LblDiscount2
        ' 
        LblDiscount2.AutoSize = True
        LblDiscount2.Location = New Point(177, 103)
        LblDiscount2.Name = "LblDiscount2"
        LblDiscount2.Size = New Size(18, 20)
        LblDiscount2.TabIndex = 6
        LblDiscount2.Text = "..."
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(80, 103)
        Label13.Name = "Label13"
        Label13.Size = New Size(91, 20)
        Label13.TabIndex = 5
        Label13.Text = "Descuento 2"
        ' 
        ' LblDiscount1
        ' 
        LblDiscount1.AutoSize = True
        LblDiscount1.Location = New Point(177, 73)
        LblDiscount1.Name = "LblDiscount1"
        LblDiscount1.Size = New Size(18, 20)
        LblDiscount1.TabIndex = 4
        LblDiscount1.Text = "..."
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(80, 73)
        Label11.Name = "Label11"
        Label11.Size = New Size(91, 20)
        Label11.TabIndex = 3
        Label11.Text = "Descuento 1"
        ' 
        ' LblSubtotal
        ' 
        LblSubtotal.AutoSize = True
        LblSubtotal.Location = New Point(177, 40)
        LblSubtotal.Name = "LblSubtotal"
        LblSubtotal.Size = New Size(18, 20)
        LblSubtotal.TabIndex = 2
        LblSubtotal.Text = "..."
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(80, 40)
        Label9.Name = "Label9"
        Label9.Size = New Size(65, 20)
        Label9.TabIndex = 1
        Label9.Text = "Subtotal"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(28, 10)
        Label8.Name = "Label8"
        Label8.Size = New Size(81, 20)
        Label8.TabIndex = 0
        Label8.Text = "Resultados"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(561, 529)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbClientType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtDetergent As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtChlorine As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtSoftener As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtGlassCleaner As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtDeodorant As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnExit As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnCalculate As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LblDiscount2 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LblDiscount1 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblSubtotal As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label

End Class
