<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formDeleteEmpleado
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDeleteEmpleado = New System.Windows.Forms.TextBox()
        Me.btnDeleteEmpleado = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese el ID del empleado que desea eliminar:"
        '
        'txtDeleteEmpleado
        '
        Me.txtDeleteEmpleado.Location = New System.Drawing.Point(271, 32)
        Me.txtDeleteEmpleado.Name = "txtDeleteEmpleado"
        Me.txtDeleteEmpleado.Size = New System.Drawing.Size(132, 20)
        Me.txtDeleteEmpleado.TabIndex = 1
        '
        'btnDeleteEmpleado
        '
        Me.btnDeleteEmpleado.Location = New System.Drawing.Point(51, 87)
        Me.btnDeleteEmpleado.Name = "btnDeleteEmpleado"
        Me.btnDeleteEmpleado.Size = New System.Drawing.Size(125, 23)
        Me.btnDeleteEmpleado.TabIndex = 2
        Me.btnDeleteEmpleado.Text = "Aceptar"
        Me.btnDeleteEmpleado.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(253, 87)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(125, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'formDeleteEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 143)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnDeleteEmpleado)
        Me.Controls.Add(Me.txtDeleteEmpleado)
        Me.Controls.Add(Me.Label1)
        Me.Name = "formDeleteEmpleado"
        Me.Text = "Eliminar Empleado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtDeleteEmpleado As TextBox
    Friend WithEvents btnDeleteEmpleado As Button
    Friend WithEvents btnCancelar As Button
End Class
