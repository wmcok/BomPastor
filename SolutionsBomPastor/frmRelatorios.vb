Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frmRelatorios


    Private Sub frmRelatorios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
    End Sub

    Private Sub btnVisualizarVendas_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmRelatorios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MenuPrincipal()
    End Sub




    Public Sub ABRE_RELATORIO(QUERY As String, TABELA As String, BINDING As BindingSource)
        Using Cnx = New System.Data.SqlClient.SqlCommand()
            Cnx.Connection = New System.Data.SqlClient.SqlConnection(My.Settings.CNXX)
            Cnx.CommandText = QUERY
            Cnx.Connection.Open()
            Dim ds = New DataSet()
            ds.Load(Cnx.ExecuteReader(), LoadOption.OverwriteChanges, TABELA)
            Dim datasource As New BindingSource(ds, TABELA)
            BINDING.DataSource = datasource
            Cnx.Connection.Close()
        End Using
        'Me.ReportViewer1.rep
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
    End Sub

    Public Sub ABRE_RELATORIO2(QUERY As String, TABELA As String, BINDING As BindingSource)
        Using Cnx = New System.Data.SqlClient.SqlCommand()
            Cnx.Connection = New System.Data.SqlClient.SqlConnection(StringConexaoGERAL)
            Cnx.CommandText = QUERY
            Cnx.Connection.Open()
            Dim ds = New DataSet()
            ds.Load(Cnx.ExecuteReader(), LoadOption.OverwriteChanges, TABELA)
            Dim datasource As New BindingSource(ds, TABELA)
            BINDING.DataSource = datasource
            Cnx.Connection.Close()
        End Using

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
    End Sub

    Private Sub ReflectionImage1_Click(sender As Object, e As EventArgs) Handles ReflectionImage1.Click
        Me.Close()
        'MenuPrincipal()
    End Sub


End Class