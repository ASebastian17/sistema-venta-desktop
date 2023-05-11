Module panelRlzVentaController

    Private total As Double = 0.0

    Private data As New List(Of VentaData)

    'Clase que se usara para almacenar los datos de las filas que iran en la tabla Detalle_Venta'
    Private Class VentaData

        Public Property idProducto As String
        Public Property cantidad As Integer
        Public Property precioVenta As Double

    End Class

    ''' <summary>
    ''' Muestra el panel para realizar ventas
    ''' </summary>
    Public Sub RlzVenta_Show()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Realizar Venta"

        If formMain.lvwRlzVentaList.Columns.Count < 4 Then

            formMain.lvwRlzVentaList.View = View.Details
            formMain.lvwRlzVentaList.GridLines = True
            'Agregamos las columnas al ListView'
            formMain.lvwRlzVentaList.Columns.Add("IdProducto", 100, HorizontalAlignment.Left)
            formMain.lvwRlzVentaList.Columns.Add("Descripción", 250, HorizontalAlignment.Left)
            formMain.lvwRlzVentaList.Columns.Add("Cantidad", 75, HorizontalAlignment.Center)
            formMain.lvwRlzVentaList.Columns.Add("Precio Unitario", 100, HorizontalAlignment.Left)
            formMain.lvwRlzVentaList.Columns.Add("Total", 100, HorizontalAlignment.Left)
        End If

        If shvCargoUser = "Cajero" Then

            formMain.txtRlzVentaEId.ReadOnly = True
            formMain.txtRlzVentaEId.Text = shvUsername

        End If

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelEmpleado.Hide()
        formMain.panelAddEmpleado.Hide()
        formMain.panelProductos.Hide()
        formMain.panelAddProdE.Hide()
        formMain.panelAddProdN.Hide()
        formMain.panelClientes.Hide()
        formMain.panelAddCliente.Hide()

        'Mostramos el panel para realizar ventas'
        formMain.panelRlzVenta.Show()

    End Sub

    ''' <summary>
    ''' Muestra los datos del cliente según el dni ingresado
    ''' </summary>
    Public Sub RlzVenta_ClienteShowData()

        formMain.txtRlzVentaNombre.Clear()
        formMain.txtRlzVentaCId.Clear()

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_RlzVentaClienteData " &
            "" & formMain.txtRlzVentaDniC.Text & ""

        shvConn.Open()

        Try
            shvReader = shvCommand.ExecuteReader
        Catch ex As Exception
            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        Try
            Do While shvReader.Read()

                formMain.txtRlzVentaNombre.Text = shvReader.GetString(0)
                formMain.txtRlzVentaCId.Text = shvReader.GetValue(1)

            Loop
        Catch ex As Exception

            shvReader.Close()
            shvConn.Close()

        End Try

        shvReader.Close()
        shvConn.Close()

    End Sub

    ''' <summary>
    ''' Muestra los datos del producto segun el id ingresado
    ''' </summary>
    Public Sub RlzVenta_ProductoShowData()

        formMain.txtRlzVentaDesc.Clear()
        formMain.txtRlzVentaPrecio.Clear()

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_RlzVentaProductoData " &
            "'" & formMain.txtRlzVentaPId.Text & "'"

        shvConn.Open()

        Try
            shvReader = shvCommand.ExecuteReader
        Catch ex As Exception
            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        Do While shvReader.Read()

            formMain.txtRlzVentaDesc.Text = shvReader.GetString(0)
            formMain.txtRlzVentaPrecio.Text = shvReader.GetValue(1)

        Loop

        shvReader.Close()
        shvConn.Close()

    End Sub

    ''' <summary>
    ''' Muestra los datos del empleado,
    ''' solo permite empleados con cargo = Cajero
    ''' </summary>
    Public Sub RlzVenta_EmpleadoShowData()

        formMain.txtRlzVentaNombreE.Clear()
        formMain.txtRlzVentaDniE.Clear()

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_RlzVentaEmpleadoData " &
            "'" & formMain.txtRlzVentaEId.Text & "'"

        shvConn.Open()
        Try
            shvReader = shvCommand.ExecuteReader
        Catch ex As Exception
            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        Try
            Do While shvReader.Read()

                formMain.txtRlzVentaNombreE.Text = shvReader.GetString(0)
                formMain.txtRlzVentaDniE.Text = shvReader.GetValue(1)

            Loop
        Catch ex As Exception

            shvReader.Close()
            shvConn.Close()

        End Try

        shvReader.Close()
        shvConn.Close()

    End Sub

    ''' <summary>
    ''' Añade un nuevo producto a la lista que se va a vender
    ''' </summary>
    Public Sub RlzVenta_Add()

        'Para verificar si se ingreso el Dni de un Cliente válido'
        If formMain.txtRlzVentaNombre.Text = "" Then
            MsgBox("Debe ingresar el Dni de un cliente válido", vbInformation, "")
            formMain.txtRlzVentaDniC.Focus()

            Exit Sub
        End If

        'Para verificar si se ingreso el Id de un Cajero válido'
        If formMain.txtRlzVentaNombreE.Text = "" Then
            MsgBox("Debe ingresar el id de un cajero", vbInformation, "")
            formMain.txtRlzVentaEId.Focus()

            Exit Sub
        End If

        'Para verificar si se ingreso el Id de un Producto válido'
        If formMain.txtRlzVentaDesc.Text = "" Then
            MsgBox("Debe ingresar el Id de un producto válido", vbInformation, "")
            formMain.txtRlzVentaPId.Focus()

            Exit Sub
        End If

        'Verificamos si el producto ya habia sido agregado al carrito de compras'
        For Each item As VentaData In data

            If item.idProducto = formMain.txtRlzVentaPId.Text Then
                MsgBox("Ya se había agregado ese producto al carrito de compras", vbInformation, "")
                formMain.txtRlzVentaPId.Clear()
                formMain.txtRlzVentaCant.Clear()
                formMain.txtRlzVentaPId.Focus()

                Exit Sub
            End If

        Next

        Try
            If formMain.txtRlzVentaCant.Text = "" Or formMain.txtRlzVentaCant.Text = 0 Then
                MsgBox("Debe Ingresar una cantidad válida", vbCritical, "Error")
                formMain.txtRlzVentaCant.Clear()
                formMain.txtRlzVentaCant.Focus()

                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Debe Ingresar una cantidad válida", vbCritical, "Error")
            formMain.txtRlzVentaCant.Clear()
            formMain.txtRlzVentaCant.Focus()

            Exit Sub
        End Try

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SELECT Stock FROM Producto
            WHERE IdProducto = '" & formMain.txtRlzVentaPId.Text & "'"

        shvConn.Open()

        shvReader = shvCommand.ExecuteReader

        Dim prodStock As Integer

        While shvReader.Read()

            prodStock = shvReader.GetValue(0)

        End While

        'Para comprobar que la cantidad ingresada sea un entero'
        Try
            'Comprobamos haya esa cantidad disponible en el almacén'
            If Convert.ToInt32(formMain.txtRlzVentaCant.Text) > prodStock Then
                MsgBox("No hay esa cantidad disponible en el almacén, la cantidad disponible es: " & prodStock, vbCritical, "Error")
                shvReader.Close()
                shvConn.Close()

                Exit Sub
            Else
                shvReader.Close()
                shvConn.Close()
            End If
        Catch ex As Exception
            MsgBox("Debe Ingresar una cantidad entera", vbCritical, "Error")
            shvReader.Close()
            shvConn.Close()

            Exit Sub
        End Try

        'Para que no se pueda cambiar de empleado o cliente en media venta'
        formMain.txtRlzVentaDniC.ReadOnly = True
        formMain.txtRlzVentaEId.ReadOnly = True

        Try
            'Actualizamos el total a pagar'
            total = total + Convert.ToDouble(formMain.txtRlzVentaCant.Text) * Convert.ToDouble(formMain.txtRlzVentaPrecio.Text)
            formMain.txtRlzVentaTotal.Text = total

            'Agregamos una producto a la lista'
            Dim row As ListViewItem

            row = New ListViewItem(formMain.txtRlzVentaPId.Text)
            row.SubItems.Add(formMain.txtRlzVentaDesc.Text)
            row.SubItems.Add(formMain.txtRlzVentaCant.Text)
            row.SubItems.Add(formMain.txtRlzVentaPrecio.Text)
            row.SubItems.Add(FormatCurrency(formMain.txtRlzVentaPrecio.Text * formMain.txtRlzVentaCant.Text))

            formMain.lvwRlzVentaList.Items.Add(row)

            'Se almacenan los datos ingresados en la tabla'
            data.Add(New VentaData With {
                     .idProducto = formMain.txtRlzVentaPId.Text,
                     .cantidad = Convert.ToInt32(formMain.txtRlzVentaCant.Text),
                     .precioVenta = Convert.ToDouble(formMain.txtRlzVentaPrecio.Text)
                     })

            formMain.txtRlzVentaCant.Clear()
            formMain.txtRlzVentaPId.Clear()
            formMain.txtRlzVentaPId.Focus()
        Catch ex As Exception
            MsgBox("Debe Ingresar una cantidad válida", vbCritical, "Error")
            formMain.txtRlzVentaCant.Clear()
            formMain.txtRlzVentaCant.Focus()

            Exit Sub
        End Try

    End Sub

    ''' <summary>
    ''' Completa la venta
    ''' </summary>
    Public Sub RlzVenta_Completar()

        If formMain.txtRlzVentaTotal.Text = "" Or formMain.txtRlzVentaTotal.Text = "0" Then
            MsgBox("Debe agregar productos a la lista", vbCritical, "Error")

            Exit Sub
        End If

        'Ingresamos datos a la tabla Venta'
        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_RlzVentaCompletarVenta " &
            "'" & formMain.txtRlzVentaCId.Text & "'," &
            "'" & formMain.txtRlzVentaEId.Text & "'," &
            "'" & total & "'"

        shvConn.Open()

        shvCommand.ExecuteNonQuery()

        shvConn.Close()

        'Ingresamos datos a la tabla Detalle_Venta'
        For Each item As VentaData In data

            shvCommand = shvConn.CreateCommand
            shvCommand.CommandText = "SP_RlzVentaIngresarDetalles " &
                "'" & item.idProducto & "'," &
                "'" & item.cantidad & "'," &
                "'" & item.precioVenta & "'"

            shvConn.Open()

            shvCommand.ExecuteNonQuery()

            shvConn.Close()

        Next

        MsgBox("Venta completada con éxito", vbInformation, "")

        'Limpiamos los valores'
        formMain.txtRlzVentaDniC.Clear()
        formMain.txtRlzVentaPId.Clear()
        formMain.lvwRlzVentaList.Clear()

        data.Clear()

        total = 0
        formMain.txtRlzVentaTotal.Clear()

        'Cargamos las columnas del ListView'
        formMain.lvwRlzVentaList.Columns.Add("IdProducto", 100, HorizontalAlignment.Left)
        formMain.lvwRlzVentaList.Columns.Add("Descripción", 250, HorizontalAlignment.Left)
        formMain.lvwRlzVentaList.Columns.Add("Cantidad", 75, HorizontalAlignment.Center)
        formMain.lvwRlzVentaList.Columns.Add("Precio Unitario", 100, HorizontalAlignment.Left)

        'Volvemos a habilitar los textBox del empleado y del cliente'
        formMain.txtRlzVentaDniC.ReadOnly = False

        If shvCargoUser <> "Cajero" Then
            formMain.txtRlzVentaEId.Clear()
            formMain.txtRlzVentaEId.ReadOnly = False
        End If


    End Sub

    ''' <summary>
    ''' Se cancela la venta
    ''' </summary>
    Public Sub RlzVenta_Cancelar()

        If MsgBox("Desea cancelar la venta actual", vbQuestion + vbYesNo, "") = vbYes Then

            'Limpiamos los valores'
            formMain.txtRlzVentaDniC.Clear()
            formMain.txtRlzVentaPId.Clear()
            formMain.lvwRlzVentaList.Clear()

            data.Clear()

            total = 0
            formMain.txtRlzVentaTotal.Clear()

            'Cargamos las columnas del ListView'
            formMain.lvwRlzVentaList.Columns.Add("IdProducto", 100, HorizontalAlignment.Left)
            formMain.lvwRlzVentaList.Columns.Add("Descripción", 250, HorizontalAlignment.Left)
            formMain.lvwRlzVentaList.Columns.Add("Cantidad", 75, HorizontalAlignment.Center)
            formMain.lvwRlzVentaList.Columns.Add("Precio Unitario", 100, HorizontalAlignment.Left)

            'Volvemos a habilitar los textBox del empleado y del cliente'
            formMain.txtRlzVentaDniC.ReadOnly = False

            If shvCargoUser <> "Cajero" Then
                formMain.txtRlzVentaEId.Clear()
                formMain.txtRlzVentaEId.ReadOnly = False
            End If

        End If

    End Sub

End Module