Module panelClientesController

    Public Sub Clientes_ShowClientes()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Clientes"

        formMain.lvwClientes.View = View.Details
        formMain.lvwClientes.GridLines = True

        Clientes_BuscarClientes()

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelEmpleado.Hide()
        formMain.panelAddEmpleado.Hide()
        formMain.panelProductos.Hide()
        formMain.panelAddProdE.Hide()
        formMain.panelAddProdN.Hide()
        formMain.panelAddCliente.Hide()
        formMain.panelRlzVenta.Hide()

        'Mostramos el panel de clientes'
        formMain.panelClientes.Show()

    End Sub

    Public Sub Clientes_BuscarClientes()

        formMain.lvwClientes.Clear()

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_BuscarClientes " &
            "'" & formMain.txtClienteNombre.Text & "'," &
            "'" & formMain.txtClienteDir.Text & "'"

        shvConn.Open()

        Dim row As ListViewItem

        'Agregamos las columnas de la tabla Productos'
        formMain.lvwClientes.Columns.Add("Id", 30, HorizontalAlignment.Left)
        formMain.lvwClientes.Columns.Add("Nombres", 200, HorizontalAlignment.Left)
        formMain.lvwClientes.Columns.Add("Edad", 50, HorizontalAlignment.Center)
        formMain.lvwClientes.Columns.Add("Dni", 100, HorizontalAlignment.Center)
        formMain.lvwClientes.Columns.Add("Genero", 50, HorizontalAlignment.Center)
        formMain.lvwClientes.Columns.Add("Dirección", 85, HorizontalAlignment.Left)
        formMain.lvwClientes.Columns.Add("Teléfono", 90, HorizontalAlignment.Left)
        formMain.lvwClientes.Columns.Add("Email", 120, HorizontalAlignment.Left)
        formMain.lvwClientes.Columns.Add("Ruc", 120, HorizontalAlignment.Left)
        formMain.lvwClientes.Columns.Add("Nacimiento", 100, HorizontalAlignment.Left)

        Try
            shvReader = shvCommand.ExecuteReader
        Catch ex As Exception
            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        Do While shvReader.Read()
            row = New ListViewItem(shvReader(0).ToString)

            row.SubItems.Add(shvReader(1))
            row.SubItems.Add(shvReader(2))
            row.SubItems.Add(shvReader(3))
            row.SubItems.Add(shvReader(4))
            row.SubItems.Add(shvReader(5))
            row.SubItems.Add(shvReader(6).ToString)
            row.SubItems.Add(shvReader(7).ToString)
            row.SubItems.Add(shvReader(8).ToString)
            row.SubItems.Add(shvReader(9))

            formMain.lvwClientes.Items.Add(row)
        Loop

        shvReader.Close()
        shvConn.Close()

    End Sub

End Module