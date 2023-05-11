Module panelAddEmpleadosController

    Private nombre As String
    Private apellido As String
    Private id As String
    Private dni As Integer
    Private telefono As String
    Private email As String
    Private edad As Integer
    Private direccion As String
    Private day As Integer
    Private month As Integer
    Private year As Integer
    Private genero As String
    Private sueldo As Integer
    Private cargo As Integer

    Private fechaN As String

    'Opcional'
    Private contraseña As String

    Private confContraseña As String

    Public Sub AddEmpleado_Show()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Agregar Empleado"

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelEmpleado.Hide()
        formMain.panelProductos.Hide()
        formMain.panelAddProdE.Hide()
        formMain.panelAddProdN.Hide()
        formMain.panelClientes.Hide()
        formMain.panelAddCliente.Hide()
        formMain.panelRlzVenta.Hide()

        'Mostramos el panel para agregar empleados'
        formMain.panelAddEmpleado.Show()

    End Sub

    Public Sub AddEmpleado_Add()

        'Asignamos valores a las variables'
        id = "E" & formMain.txtAddEmpId.Text
        nombre = formMain.txtAddEmpNombre.Text
        apellido = formMain.txtAddEmpApellido.Text
        telefono = formMain.txtAddEmpTelef.Text
        email = formMain.txtAddEmpEmail.Text
        direccion = formMain.txtAddEmpDir.Text

        genero = formMain.cmbAddEmpGenero.Text

        contraseña = formMain.txtAddEmpCont.Text
        confContraseña = formMain.txtAddEmpConfCont.Text

        If id = "E0000" Or Len(id) <> 5 Then
            MsgBox("Id invalido")
            formMain.txtAddEmpId.Clear()
            formMain.txtAddEmpId.Focus()

            Exit Sub
        End If

        'Para verificar que los datos ingresados sean números'
        Try
            dni = formMain.txtAddEmpDni.Text
            edad = formMain.txtAddEmpEdad.Text
            day = formMain.txtAddEmpFNDay.Text
            month = formMain.txtAddEmpFNMonth.Text
            year = formMain.txtAddEmpFNYear.Text
            sueldo = formMain.txtAddEmpSueldo.Text
        Catch ex As Exception
            MsgBox("Ingrese correctamente los datos", vbCritical, "Error")

            Exit Sub
        End Try

        fechaN = month & "-" & day & "-" & year

        If contraseña <> confContraseña Then
            MsgBox("Las contraseñas no coinciden", vbCritical, "Error")
            formMain.txtAddEmpConfCont.Focus()

            Exit Sub
        End If

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_AgregarEmpleados " &
            "'" & id & "'," &
            "'" & contraseña & "'," &
            "'" & nombre & "'," &
            "'" & apellido & "'," &
            "'" & edad & "'," &
            "'" & dni & "'," &
            "'" & genero & "'," &
            "'" & direccion & "'," &
            "'" & telefono & "'," &
            "'" & email & "'," &
            "'" & sueldo & "'," &
            "'" & fechaN & "'," &
            "'" & cargo & "'"

        'Abrimos una conexión'
        shvConn.Open()

        Try
            'Ejecución del procedimiento almacenado'
            shvCommand.ExecuteNonQuery()
            MsgBox("Usuario registrado con exito", vbInformation, "")

            'Limpiamos los valores'
            formMain.txtAddEmpNombre.Clear()
            formMain.txtAddEmpApellido.Clear()
            formMain.txtAddEmpId.Clear()
            formMain.txtAddEmpEdad.Clear()
            formMain.txtAddEmpDni.Clear()
            formMain.txtAddEmpDir.Clear()
            formMain.txtAddEmpTelef.Clear()
            formMain.txtAddEmpEmail.Clear()
            formMain.txtAddEmpSueldo.Clear()
            formMain.txtAddEmpFNDay.Clear()
            formMain.txtAddEmpFNMonth.Clear()
            formMain.txtAddEmpFNYear.Clear()
            formMain.txtAddEmpCont.Clear()
            formMain.txtAddEmpConfCont.Clear()

            formMain.txtAddEmpNombre.Focus()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        Finally
            shvConn.Close()
        End Try

    End Sub

    Public Sub AddEmpleado_cmbAddEmpCargo()

        Select Case formMain.cmbAddEmpCargo.Text

            Case "Administrador"
                cargo = 1
            Case "Cajero"
                cargo = 2
            Case "Personal de Limpieza"
                cargo = 3
            Case "Personal de Seguridad"
                cargo = 4
            Case "Encargado de Almacén"
                cargo = 5

        End Select

        If cargo = 1 Or cargo = 2 Or cargo = 5 Then

            formMain.txtAddEmpCont.Enabled = True
            formMain.txtAddEmpConfCont.Enabled = True
        Else
            formMain.txtAddEmpCont.Enabled = False
            formMain.txtAddEmpConfCont.Enabled = False
            formMain.txtAddEmpCont.Clear()
            formMain.txtAddEmpConfCont.Clear()

        End If

    End Sub

End Module