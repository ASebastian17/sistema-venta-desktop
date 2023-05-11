Module panelAddProdNController

    Private descripcion As String = ""
    Private categoria As Integer = 0
    Private marca As String = ""
    Private idNum As Integer
    Private id As String
    Private cantidad As Integer
    Private precio As Double
    Private proveedor As String = ""

    Public Sub AddProdN_Show()

        'Configuraciones previas'
        formMain.gbxMain.Text = "Agregar Nuevo Producto"

        'Ocultamos los demas paneles'
        formMain.panelWelcome.Hide()
        formMain.panelEmpleado.Hide()
        formMain.panelAddEmpleado.Hide()
        formMain.panelProductos.Hide()
        formMain.panelAddProdE.Hide()
        formMain.panelClientes.Hide()
        formMain.panelAddCliente.Hide()
        formMain.panelRlzVenta.Hide()

        'Mostramos el panel para agregar nuevos productos'
        formMain.panelAddProdN.Show()

    End Sub

    Public Sub AddProdN_cmbAddProdNCat()

        Select Case formMain.cmbAddProdNCat.Text

            Case "Cuadernos y Blocks"
                categoria = 1
                formMain.lblAddProdNCatID.Text = "P - 1"

            Case "Útiles"
                categoria = 2
                formMain.lblAddProdNCatID.Text = "P - 2"

            Case "Papelería"
                categoria = 3
                formMain.lblAddProdNCatID.Text = "P - 3"

            Case "Cintas y Pegamentos"
                categoria = 4
                formMain.lblAddProdNCatID.Text = "P - 4"

            Case "Pintura"
                categoria = 5
                formMain.lblAddProdNCatID.Text = "P - 5"

            Case "Archivo"
                categoria = 6
                formMain.lblAddProdNCatID.Text = "P - 6"

            Case "Articulos de Escritorio"
                categoria = 7
                formMain.lblAddProdNCatID.Text = "P - 7"

        End Select

    End Sub

    Public Sub AddProdN_cmbAddProdNProv()

        Select Case formMain.cmbAddProdNProv.Text

            Case "Proveedor A"
                proveedor = "S0001"

            Case "Proveedor B"
                proveedor = "S0002"

            Case "Proveedor C"
                proveedor = "S0003"

            Case "Proveedor D"
                proveedor = "S0004"

        End Select

    End Sub

    Public Sub AddProdN_Add()

        'Asignamos valores a las variables'
        descripcion = formMain.txtAddProdNDesc.Text
        marca = formMain.txtAddProdNMarca.Text

        'Hacemos las verificaciones'
        If descripcion = "" Then
            MsgBox("Debe ingresar una descripción o nombre del producto", vbCritical, "Error")

            Exit Sub
        End If

        If marca = "" Then
            MsgBox("Debe ingresar la marca del producto", vbCritical, "Error")

            Exit Sub
        End If

        If categoria = 0 Then
            MsgBox("Debe seleccionar una categoría", vbCritical, "Error")

            Exit Sub
        End If

        If proveedor = "" Then
            MsgBox("Debe seleccionar un proveedor", vbCritical, "Error")

            Exit Sub
        End If

        'Verificamos que los valores ingresados sean números'
        Try
            precio = formMain.txtAddProdNPrecio.Text
            cantidad = formMain.txtAddProdNCant.Text
            idNum = formMain.txtAddProdNId.Text
        Catch ex As Exception
            MsgBox("Ingrese correctamente los datos", vbCritical, "Error")

            Exit Sub
        End Try

        id = "P" & categoria & formMain.txtAddProdNId.Text

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_AddProdNuevo " &
            "'" & id & "'," &
            "'" & descripcion & "'," &
            "'" & marca & "'," &
            "'" & cantidad & "'," &
            "'" & precio & "'," &
            "'" & categoria & "'," &
            "'" & proveedor & "'"

        'Abrimos una conexión'
        shvConn.Open()

        Try
            'Ejecución del procedimiento almacenado'
            shvCommand.ExecuteNonQuery()
            MsgBox("Producto Agregado con éxito", vbInformation, "")

            'Limpiamos los valores'
            formMain.txtAddProdNCant.Clear()
            formMain.txtAddProdNDesc.Clear()
            formMain.txtAddProdNId.Clear()
            formMain.txtAddProdNPrecio.Clear()
            formMain.txtAddProdNMarca.Clear()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        Finally
            shvConn.Close()
        End Try

    End Sub

End Module