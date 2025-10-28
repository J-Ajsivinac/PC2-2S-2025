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
        txtInput = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        btnBubbleSort = New Button()
        btnQuickSort = New Button()
        rtbOutput = New RichTextBox()
        btnLimpiar = New Button()
        SuspendLayout()
        ' 
        ' txtInput
        ' 
        txtInput.Location = New Point(87, 74)
        txtInput.Name = "txtInput"
        txtInput.Size = New Size(354, 27)
        txtInput.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(134, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(189, 20)
        Label1.TabIndex = 1
        Label1.Text = "Métodos de Ordenamiento"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 77)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 20)
        Label2.TabIndex = 2
        Label2.Text = "Números"
        ' 
        ' btnBubbleSort
        ' 
        btnBubbleSort.Location = New Point(12, 131)
        btnBubbleSort.Name = "btnBubbleSort"
        btnBubbleSort.Size = New Size(180, 36)
        btnBubbleSort.TabIndex = 3
        btnBubbleSort.Text = "Ordenar con Burbuja"
        btnBubbleSort.UseVisualStyleBackColor = True
        ' 
        ' btnQuickSort
        ' 
        btnQuickSort.Location = New Point(263, 131)
        btnQuickSort.Name = "btnQuickSort"
        btnQuickSort.Size = New Size(178, 36)
        btnQuickSort.TabIndex = 4
        btnQuickSort.Text = "Ordenar con QuickSort"
        btnQuickSort.UseVisualStyleBackColor = True
        ' 
        ' rtbOutput
        ' 
        rtbOutput.Location = New Point(12, 184)
        rtbOutput.Name = "rtbOutput"
        rtbOutput.Size = New Size(429, 178)
        rtbOutput.TabIndex = 5
        rtbOutput.Text = ""
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Location = New Point(347, 377)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(94, 29)
        btnLimpiar.TabIndex = 6
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(459, 418)
        Controls.Add(btnLimpiar)
        Controls.Add(rtbOutput)
        Controls.Add(btnQuickSort)
        Controls.Add(btnBubbleSort)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtInput)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtInput As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBubbleSort As Button
    Friend WithEvents btnQuickSort As Button
    Friend WithEvents rtbOutput As RichTextBox
    Friend WithEvents btnLimpiar As Button

End Class
