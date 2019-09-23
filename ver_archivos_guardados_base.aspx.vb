Imports System.Data.SqlClient

Partial Class gestion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack()) Then
            datasource1.SelectCommand = "select id_archivo, nombre, id_ticket from tbl_archivo where id_ticket=128"
            datasource1.DataBind()
            grid1.DataBind()
        End If
    End Sub


    Protected Sub grid1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grid1.RowCommand
        Dim id As Integer
        If (e.CommandName = "Descargar") Then
            id = Convert.ToInt32(e.CommandArgument)
            descargar(id)
        End If
    End Sub

    Protected Sub descargar(ByVal id As Integer)
        'Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim bytes As Byte()
        Dim fileName As String, contentType As String
        Dim constr As String = ConfigurationManager.ConnectionStrings("CRM_CorporativoConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select replace(nombre,' ','_') as nombre, contenido, tipo_contenido from tbl_archivo where id_archivo=@Id"
                cmd.Parameters.AddWithValue("@Id", id) '/******LO DESCARGA POR ID
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    sdr.Read()
                    bytes = DirectCast(sdr("contenido"), Byte())
                    fileName = sdr("nombre").ToString()
                    contentType = sdr("tipo_contenido").ToString()
                End Using
                con.Close()
            End Using
        End Using

        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = contentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName)
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub

End Class
