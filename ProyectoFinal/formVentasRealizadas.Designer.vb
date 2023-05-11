<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formVentasRealizadas
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
        Me.lvwVentasR = New System.Windows.Forms.ListView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvwVentasR
        '
        Me.lvwVentasR.HideSelection = False
        Me.lvwVentasR.Location = New System.Drawing.Point(12, 55)
        Me.lvwVentasR.Name = "lvwVentasR"
        Me.lvwVentasR.Size = New System.Drawing.Size(709, 349)
        Me.lvwVentasR.TabIndex = 0
        Me.lvwVentasR.UseCompatibleStateImageBehavior = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(620, 415)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(79, 23)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ventas realizadas:"
        '
        'formVentasRealizadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lvwVentasR)
        Me.Name = "formVentasRealizadas"
        Me.Text = "Ventas Realizadas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvwVentasR As ListView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label1 As Label
End Class
