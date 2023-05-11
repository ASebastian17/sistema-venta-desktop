Module panelEmpleadosController

    Public Sub Empleado_ShowEmpleados()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Empleados"

        formMain.lvwEmpleados.View = View.Details
        formMain.lvwEmpleados.GridLines = True

        formMain.txtBuscarNombreEmp.Clear()
        formMain.cmbBuscarCargoEmp.Text = "---"
        formMain.txtBuscarDireccionEmp.Clear()

        Empleado_BuscarEmpleado()

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelAddEmpleado.Hide()
        formMain.panelProductos.Hide()
        formMain.panelAddProdE.Hide()
        formMain.panelAddProdN.Hide()
        formMain.panelClientes.Hide()
        formMain.panelAddCliente.Hide()
        formMain.panelRlzVenta.Hide()

        'Mostramos el panel de empleados'
        formMain.panelEmpleado.Show()

    End Sub

    Public Sub Empleado_BuscarEmpleado()

        formMain.lvwEmpleados.Clear()

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_BuscarEmpleados '" & formMain.txtBuscarNombreEmp.Text & "', " &
            "'" & formMain.cmbBuscarCargoEmp.Text & "'," &
            "'" & formMain.txtBuscarDireccionEmp.Text & "'"

        shvConn.Open()

        Dim row As ListViewItem

        shvReader = shvCommand.ExecuteReader

        'Agregamos las columnas de la tabla Empleados'
        formMain.lvwEmpleados.Columns.Add("Id", 40, HorizontalAlignment.Left)
        formMain.lvwEmpleados.Columns.Add("Nombres", 160, HorizontalAlignment.Left)
        formMain.lvwEmpleados.Columns.Add("Edad", 50, HorizontalAlignment.Center)
        formMain.lvwEmpleados.Columns.Add("Dni", 70, HorizontalAlignment.Center)
        formMain.lvwEmpleados.Columns.Add("Género", 50, HorizontalAlignment.Center)
        formMain.lvwEmpleados.Columns.Add("Dirección", 70, HorizontalAlignment.Left)
        formMain.lvwEmpleados.Columns.Add("Teléfono", 70, HorizontalAlignment.Left)
        formMain.lvwEmpleados.Columns.Add("Email", 165, HorizontalAlignment.Left)
        formMain.lvwEmpleados.Columns.Add("Sueldo", 75, HorizontalAlignment.Left)
        formMain.lvwEmpleados.Columns.Add("Ingreso", 100, HorizontalAlignment.Center)
        formMain.lvwEmpleados.Columns.Add("Nacimiento", 100, HorizontalAlignment.Center)
        formMain.lvwEmpleados.Columns.Add("Cargo", 100, HorizontalAlignment.Center)

        Do While shvReader.Read
            row = New ListViewItem(shvReader(0).ToString)
            row.SubItems.Add(shvReader(1))
            row.SubItems.Add(shvReader(2))
            row.SubItems.Add(shvReader(3))
            row.SubItems.Add(shvReader(4))
            row.SubItems.Add(shvReader(5))
            row.SubItems.Add(shvReader(6))
            row.SubItems.Add(shvReader(7))
            row.SubItems.Add(FormatCurrency(shvReader(8)))
            row.SubItems.Add(shvReader(9))
            row.SubItems.Add(shvReader(10))
            row.SubItems.Add(shvReader(11))

            formMain.lvwEmpleados.Items.Add(row)
        Loop

        shvReader.Close()
        shvConn.Close()

    End Sub

End Module