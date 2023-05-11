Module panelAddProdEController

    Public Sub AddProdE_Show()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Agregar Producto Existente"

        formMain.txtAddProdEId.Clear()
        formMain.txtAddProdECantidad.Clear()

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelEmpleado.Hide()
        formMain.panelAddEmpleado.Hide()
        formMain.panelProductos.Hide()
        formMain.panelAddProdN.Hide()
        formMain.panelClientes.Hide()
        formMain.panelAddCliente.Hide()
        formMain.panelRlzVenta.Hide()

        'Mostramos el panel para agregar productos existentes'
        formMain.panelAddProdE.Show()

    End Sub

    Public Sub AddProdE_ShowData()

        formMain.txtAddProdENombre.Clear()
        formMain.txtAddProdEMarca.Clear()
        formMain.txtAddProdEStockA.Clear()
        formMain.txtAddProdECat.Clear()

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_MostrarDatosProductoE " &
            "'" & "P" & formMain.txtAddProdEId.Text & "'"

        shvConn.Open()

        Try
            shvReader = shvCommand.ExecuteReader
        Catch ex As Exception
            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        Do While shvReader.Read()

            formMain.txtAddProdENombre.Text = shvReader.GetString(0)
            formMain.txtAddProdEMarca.Text = shvReader.GetString(1)
            formMain.txtAddProdEStockA.Text = shvReader.GetValue(2)
            formMain.txtAddProdECat.Text = shvReader.GetString(3)

        Loop

        shvReader.Close()
        shvConn.Close()

    End Sub

    Public Sub AddProdE_Add()

        Dim cantidad As Integer

        If formMain.txtAddProdENombre.Text = "" Then
            MsgBox("Debe ingresar un Id válido", vbInformation, "")
            formMain.txtAddProdEId.Focus()

            Exit Sub
        End If

        Try
            cantidad = formMain.txtAddProdECantidad.Text
        Catch ex As Exception
            MsgBox("Ingrese correctamente la cantidad que desea agregar", vbCritical, "Error")
            formMain.txtAddProdECantidad.Clear()
            formMain.txtAddProdECantidad.Focus()

            Exit Sub
        End Try

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_AddProdExistente " &
            "'" & "P" & formMain.txtAddProdEId.Text & "'," &
            "'" & cantidad & "'"

        shvConn.Open()

        shvCommand.ExecuteNonQuery()
        MsgBox("Producto agregado con éxito", vbInformation, "")
        shvConn.Close()

        formMain.txtAddProdECantidad.Clear()

        AddProdE_ShowData()

    End Sub

End Module