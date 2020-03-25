Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Public Class frmRelatorios2

    Private Sub frmRelatorios2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '       Dim sqlClientes As String = "SELECT ROW_NUMBER() OVER (ORDER BY VENDEDOR)N,RTRIM(CONVERT(VARCHAR,VENDEDOR))VENDEDOR,SUM(VENDAS) VENDAS,SUM(DESCONTOVALOR) DESCONTOS,SUM(CANCELADAS) CANCELADAS FROM  " &
        '"( SELECT RTRIM(MC.VENDEDOR)+'-'+RTRIM(V.NOME)VENDEDOR, CASE WHEN MV.ESTATUS='N' THEN VALOR else 0 END VENDAS, CASE WHEN MV.ESTATUS='N' THEN DESCONTOVALOR else 0 END DESCONTOVALOR,  " &
        '"CASE WHEN MV.ESTATUS='C' THEN VALOR else 0 END CANCELADAS   " &
        '"FROM MV MV INNER JOIN MVCLIENTES MC ON MC.SEQNOTA=MV.SEQ LEFT JOIN VENDEDORES V ON V.CODIGO=MC.VENDEDOR  " &
        '"WHERE MV.FATO='SC' AND MV.FILIAL='01' AND MV.DATTAEMISSAO BETWEEN '2019-04-01' AND '2019-04-30'    )A GROUP BY VENDEDOR ORDER BY N"
        '       GeraRelatorio(sqlClientes, "Report2.rdlc", "A", "DataSet1")
    End Sub
    Private Sub frmRelatorios2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MenuPrincipal()
    End Sub

    Public Sub GeraRelatorio(CONEXAO As String, SQL As String, RELATORIO As String, TABELA As String, DATTASET As String, DT_IN As String, DT_OUT As String)
        ' CONEXÃO = DBIXE OU LOCAL
        'http://www.jorgepaulino.com/2009/06/vbnet-microsoft-reporting-services.html

        Dim StrConn As New SqlConnection
        Dim StrConexao As String = ""
        If CONEXAO = "DBIXE" Then
            StrConexao = "Data Source=192.168.0.225" &
            ";Initial Catalog=dbixe" &
            ";Persist Security Info=True" &
            ";User ID=sysdba" &
            ";Password=masterkey"
        ElseIf CONEXAO = "LOCAL" Then
            StrConexao = StringConexaoGERAL
        End If

        '----
        With Me.rvPrintPreview.LocalReport
            ' Caminho para o relatório 
            .ReportPath = Application.StartupPath & "\" & RELATORIO
            .DataSources.Clear()

            If DT_IN.Length > 2 Then
                Dim parameters(1) As ReportParameter
                parameters(0) = New ReportParameter("DT_IN", DT_IN)
                parameters(1) = New ReportParameter("DT_OUT", DT_OUT)

                .SetParameters(parameters)
            End If

        End With
        '----

        '2° passo, passar os dados para o relatorio, abrindo a conexao com o banco de dados
        StrConn.ConnectionString = StrConexao
        StrConn.Open()

        '3° passo, definindo o SQL do relatorio
        '       Dim sqlClientes As String = "SELECT ROW_NUMBER() OVER (ORDER BY VENDEDOR)N,RTRIM(CONVERT(VARCHAR,VENDEDOR))VENDEDOR,SUM(VENDAS) VENDAS,SUM(DESCONTOVALOR) DESCONTOS,SUM(CANCELADAS) CANCELADAS FROM  " &
        '"( SELECT RTRIM(MC.VENDEDOR)+'-'+RTRIM(V.NOME)VENDEDOR, CASE WHEN MV.ESTATUS='N' THEN VALOR else 0 END VENDAS, CASE WHEN MV.ESTATUS='N' THEN DESCONTOVALOR else 0 END DESCONTOVALOR,  " &
        '"CASE WHEN MV.ESTATUS='C' THEN VALOR else 0 END CANCELADAS   " &
        '"FROM MV MV INNER JOIN MVCLIENTES MC ON MC.SEQNOTA=MV.SEQ LEFT JOIN VENDEDORES V ON V.CODIGO=MC.VENDEDOR  " &
        '"WHERE MV.FATO='SC' AND MV.FILIAL='01' AND MV.DATTAEMISSAO BETWEEN '2019-04-01' AND '2019-04-30'    )A GROUP BY VENDEDOR ORDER BY N"


        Using da As New SqlDataAdapter(SQL, StrConexao)
            'da.SelectCommand.Parameters.Add("@price", SqlDbType.Int).Value = 200

            Using ds As New DataSet
                da.Fill(ds, TABELA)

                ' É preciso usar o mesmo nome como foi de definido  
                ' no Data Source Definition 
                Dim rptDataSource As New ReportDataSource _
                                          (DATTASET, ds.Tables(TABELA))
                Me.rvPrintPreview.LocalReport.DataSources.Add(rptDataSource)

            End Using

        End Using

        rvPrintPreview.RefreshReport()

        StrConn.Dispose()
        StrConn = Nothing

        Me.rvPrintPreview.SetDisplayMode(DisplayMode.PrintLayout)
        rvPrintPreview.ZoomMode = ZoomMode.Percent

    End Sub



End Class