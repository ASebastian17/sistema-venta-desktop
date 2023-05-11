Module panelProductosController

    Public Sub Productos_ShowProductos()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Lista de Productos"

        formMain.lvwProductos.View = View.Details
        formMain.lvwProductos.GridLines = True

        Productos_BuscarProducto()

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelEmpleado.Hide()
        formMain.panelAddEmpleado.Hide()
        formMain.panelAddProdE.Hide()
        formMain.panelAddProdN.Hide()
        formMain.panelClientes.Hide()
        formMain.panelAddCliente.Hide()
        formMain.panelRlzVenta.Hide()

        'Mostramos el panel de productos'
        formMain.panelProductos.Show()

    End Sub

    Public Sub Productos_BuscarProducto()

        formMain.lvwProductos.Clear()

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_BuscarProductos " &
            "'" & formMain.txtProdNombre.Text & "'," &
            "'" & formMain.txtProdMarca.Text & "'," &
            "'" & formMain.cmbProdCategoria.Text & "'," &
            "'" & formMain.cmbProdProv.Text & "'," &
            "'" & formMain.txtProdPreMayorA.Text & "'," &
            "'" & formMain.txtProdPreMenorA.Text & "'"

        shvConn.Open()

        Dim row As ListViewItem

        Try
            shvReader = shvCommand.ExecuteReader
        Catch ex As Exception
            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        'Agregamos las columnas de la tabla Productos'
        formMain.lvwProductos.Columns.Add("Id", 50, HorizontalAlignment.Left)
        formMain.lvwProductos.Columns.Add("Descripción", 230, HorizontalAlignment.Left)
        formMain.lvwProductos.Columns.Add("Marca", 100, HorizontalAlignment.Left)
        formMain.lvwProductos.Columns.Add("Stock", 50, HorizontalAlignment.Center)
        formMain.lvwProductos.Columns.Add("PrecioUnit", 75, HorizontalAlignment.Center)
        formMain.lvwProductos.Columns.Add("Categoría", 130, HorizontalAlignment.Left)
        formMain.lvwProductos.Columns.Add("Proveedor", 90, HorizontalAlignment.Left)

        Do While shvReader.Read
            row = New ListViewItem(shvReader(0).ToString)
            row.SubItems.Add(shvReader(1))
            row.SubItems.Add(shvReader(2))
            row.SubItems.Add(shvReader(3))
            row.SubItems.Add(FormatCurrency(shvReader(4)))
            row.SubItems.Add(shvReader(5))
            row.SubItems.Add(shvReader(6))

            formMain.lvwProductos.Items.Add(row)
        Loop

        shvReader.Close()
        shvConn.Close()

    End Sub

End Module