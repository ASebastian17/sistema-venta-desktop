'' Proyecto Final de Apicación de Base de Datos
'' Alumno: Guerra Morales Armando Sebastian
''
'' Grupo: 01S
''
'' NET Framework 4.6.1
'' 
'' Creado en Visual Studio 2019
''
'' 21/08/2020
''
Public Class formLogin

    Private Sub btnIn_Click(sender As Object, e As EventArgs) Handles btnIn.Click

        Dim password As String = ""

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_LoginValidation '" & txtUsername.Text & "'"

        shvConn.Open()

        shvReader = shvCommand.ExecuteReader

        Try
            Do While shvReader.Read()
                shvUsername = shvReader.GetString(0)
                password = shvReader.GetString(1)
                shvCargoUser = shvReader.GetString(2)
                shvNombre = shvReader.GetString(3)
            Loop
        Catch ex As Exception
            'En caso el usuario no tenga una contraseña asignada'
            MsgBox("Este usuario no tiene acceso al sistema", vbCritical, "Error")

            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Rellene todos los campos", vbCritical, "Error")
            txtUsername.Focus()
        Else
            If shvUsername = txtUsername.Text And password = txtPassword.Text Then
                'Ocultar la ventana de Iniciar Sesión'
                Hide()

                'Mostrar la ventana principal'
                formMain.Show()
            Else
                MsgBox("Usuario o contraseña incorrectos", vbCritical, "Error")
                txtUsername.Focus()

            End If
        End If

        shvReader.Close()
        shvConn.Close()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Close()

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub
End Class