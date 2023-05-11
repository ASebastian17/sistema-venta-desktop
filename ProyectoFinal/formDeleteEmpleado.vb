Public Class formDeleteEmpleado

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Close()

    End Sub

    Private Sub btnDeleteEmpleado_Click(sender As Object, e As EventArgs) Handles btnDeleteEmpleado.Click

        If txtDeleteEmpleado.Text = "" Then
            MsgBox("Debe ingresar el Id de algun Empleado", vbInformation, "Error")

            Exit Sub
        End If

        shvConn.Open()
        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SELECT IdEmpleado FROM Empleado WHERE IdEmpleado = '" & txtDeleteEmpleado.Text & "'"

        Dim idEmpleadoDelete As String

        idEmpleadoDelete = shvCommand.ExecuteScalar

        If txtDeleteEmpleado.Text = idEmpleadoDelete Then

            If MsgBox("Seguro que desea eliminar este empleado", vbQuestion + vbYesNo, "Eliminar empleado") = vbYes Then

                shvCommand.CommandText = "DELETE FROM Empleado WHERE IdEmpleado = '" & idEmpleadoDelete & "'"
                shvCommand.ExecuteNonQuery()

                shvConn.Close()
                'Actualizamos el panel de empleados'
                Empleado_BuscarEmpleado()

                MsgBox("Usuario Eliminado", vbInformation, "")

            End If
        Else

            MsgBox("El Id que ingreso no existe")
            txtDeleteEmpleado.Clear()
            txtDeleteEmpleado.Focus()

        End If

        shvConn.Close()

    End Sub

End Class