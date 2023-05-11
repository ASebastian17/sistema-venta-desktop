Module panelAddClientesController

    Private nombre As String
    Private apellido As String
    Private dni As Integer
    Private telefono As String
    Private email As String
    Private edad As Integer
    Private direccion As String
    Private day As Integer
    Private month As Integer
    Private year As Integer
    Private genero As String
    Private ruc As String

    Private fechaN As String

    Public Sub AddClientes_Show()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Agregar Cliente"

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelEmpleado.Hide()
        formMain.panelAddEmpleado.Hide()
        formMain.panelProductos.Hide()
        formMain.panelAddProdE.Hide()
        formMain.panelAddProdN.Hide()
        formMain.panelClientes.Hide()
        formMain.panelRlzVenta.Hide()

        'Mostramos el panel para agregar clientes'
        formMain.panelAddCliente.Show()

    End Sub

    Public Sub AddClientes_Add()

        'Asignamos valores a las variables'
        nombre = formMain.txtAddClienteNombre.Text
        apellido = formMain.txtAddClienteApellido.Text
        telefono = formMain.txtAddClienteTelf.Text
        email = formMain.txtAddClienteEmail.Text
        direccion = formMain.txtAddClienteDir.Text

        genero = formMain.cmbAddClienteGenero.Text

        'Verificamos que los datos ingresados sean enteros'
        Try
            dni = formMain.txtAddClienteDni.Text
            edad = formMain.txtAddClienteEdad.Text
            day = formMain.txtAddClienteFNDay.Text
            month = formMain.txtAddClienteFNMonth.Text
            year = formMain.txtAddClienteFNYear.Text
        Catch ex As Exception
            MsgBox("Ingrese correctamente los datos", vbCritical, "Error")

            Exit Sub
        End Try

        fechaN = month & "-" & day & "-" & year

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_AgregarCliente " &
            "'" & nombre & "'," &
            "'" & apellido & "'," &
            "'" & edad & "'," &
            "'" & dni & "'," &
            "'" & genero & "'," &
            "'" & direccion & "'," &
            "'" & telefono & "'," &
            "'" & email & "'," &
            "'" & ruc & "'," &
            "'" & fechaN & "'"

        'Abrimos una conexión'
        shvConn.Open()

        Try
            'Ejecución del procedimiento almacenado'
            shvCommand.ExecuteNonQuery()
            MsgBox("Cliente registrado con exito", vbInformation, "")

            'Limpiamos los valores'
            formMain.txtAddClienteNombre.Clear()
            formMain.txtAddClienteApellido.Clear()
            formMain.txtAddClienteEdad.Clear()
            formMain.txtAddClienteDni.Clear()
            formMain.txtAddClienteDir.Clear()
            formMain.txtAddClienteTelf.Clear()
            formMain.txtAddClienteEmail.Clear()
            formMain.txtAddClienteFNDay.Clear()
            formMain.txtAddClienteFNMonth.Clear()
            formMain.txtAddClienteFNYear.Clear()
            formMain.txtAddClienteRuc.Clear()

            formMain.txtAddClienteNombre.Focus()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        Finally
            shvConn.Close()
        End Try

    End Sub

End Module