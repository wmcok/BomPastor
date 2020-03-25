Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports System.Data.SqlClient

Public Class frmMovimentacoes

    Public CNX = New System.Data.SqlClient.SqlConnection(My.Settings.CNXX)
    Private Sub frmMovimentacoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        SideNavItem2.Select()


        'dtFinalVendas.Value = Date.DaysInMonth(Now.Year, Now.Month) DateAdd(DateInterval.Month, 0, Now).AddDays(-(Now.Day - 1))
        dtInicioVendas.Value = DateValue(Now.Year & "/" & Now.Month & "/01")
        dtFinalVendas.Value = DateValue(Now.Year & "/" & Now.Month & "/" & Date.DaysInMonth(Now.Year, Now.Month))
        cboxFilialVendas.SelectedIndex = 0

        dtInicioVend.Value = DateValue(Now.Year & "/" & Now.Month & "/01")
        dtFinalVend.Value = DateValue(Now.Year & "/" & Now.Month & "/" & Date.DaysInMonth(Now.Year, Now.Month))
        cboxTipoVend.SelectedIndex = 0

        'ConectarData()
    End Sub

    Public Sub ConectarData(DG As DataGridViewX, QUERY As String)
        If QUERY.Length < 2 Then
            Exit Sub
        End If
        If CNX.State = System.Data.ConnectionState.Closed Then
            CNX.Open()
            'MsgBox("conecção aberta")
        Else
            'MsgBox("conexão aberta")
        End If
        If CNX.State = System.Data.ConnectionState.Open Then
            Using C = New System.Data.SqlClient.SqlCommand()
                C.Connection = CNX
                C.CommandText = QUERY
                Dim dt = New DataTable()
                dt.Load(C.ExecuteReader())
                DG.DataSource = Nothing
                DG.AutoGenerateColumns = True
                DG.DataSource = dt
                DG.Refresh()
            End Using
            CNX.close()
        End If
    End Sub
    Public Sub PREENCHERCBOX2(CBOX As Object, QUERY As String, COLUNA As String)
        If CNX.State = System.Data.ConnectionState.Closed Then
            CNX.Open()
            'MsgBox("conecção aberta")
        Else
            'MsgBox("conexão aberta")
        End If
        If CNX.State = System.Data.ConnectionState.Open Then
            Using C = New System.Data.SqlClient.SqlCommand()
                C.Connection = CNX
                C.CommandText = QUERY
                Dim reader As SqlDataReader
                reader = C.ExecuteReader
                CBOX.Items.Clear()
                While (reader.Read)
                    CBOX.Items.Add(reader(COLUNA))
                End While
                CBOX.Refresh()
                reader.Close()
            End Using
        End If
    End Sub

    Private Function MontarQueryVendas()
        Dim QUERY As String = ""
        Dim Fato As String = "  MV.FATO IN ("
        Dim Fato_Count As Integer = 0
        Dim Estatus As String = " AND MV.ESTATUS IN ("
        Dim Estatus_Count As Integer = 0
        Dim Tipo_NF As String = ""
        Dim Filial As String = ""
        Dim N_NF As String = ""
        If checkSCVendas.CheckState = CheckState.Checked Then
            Fato = Fato & "'SC',"
            Fato_Count = Fato_Count + 1
        End If
        If checkECVendas.CheckState = CheckState.Checked Then
            Fato = Fato & "'EC',"
            Fato_Count = Fato_Count + 1
        End If
        If checkEFVendas.CheckState = CheckState.Checked Then
            Fato = Fato & "'EF',"
            Fato_Count = Fato_Count + 1
        End If
        If checkSFVendas.CheckState = CheckState.Checked Then
            Fato = Fato & "'SF',"
            Fato_Count = Fato_Count + 1
        End If
        Fato = Fato.Remove(Fato.Length - 1, 1) & ") "
        If Fato_Count = 0 Then
            MessageBoxEx.Show("Favor Escolha um Fato!")
            Exit Function
        End If


        If checkNormalVendas.CheckState = CheckState.Checked Then
            Estatus = Estatus & "'N',"
            Estatus_Count = Estatus_Count + 1
        End If
        If checkCanceladaVendas.CheckState = CheckState.Checked Then
            Estatus = Estatus & "'C',"
            Estatus_Count = Estatus_Count + 1
        End If
        Estatus = Estatus.Remove(Estatus.Length - 1, 1) & ") "
        If Estatus_Count = 0 Then
            MessageBoxEx.Show("Favor Escolha um Estatus da NF!")
            Exit Function
        End If

        If checkCupomVendas.CheckState = CheckState.Checked Then
            Tipo_NF = " AND MV. SERIE = 'CF1' "
        ElseIf checkNFeVendas.CheckState = CheckState.Checked Then
            Tipo_NF = " "
        End If
        If cboxFilialVendas.SelectedIndex = 0 Then

            Filial = "01"
        ElseIf cboxFilialVendas.SelectedIndex = 1 Then
            Filial = "02"
        Else
            Filial = "01"
        End If

        If txtNFVendas.TextLength > 1 Then
            N_NF = "AND MV.NUMERO IN (" & TrataCodigos(txtNFVendas.Text) & ")"
        End If


        QUERY = " SELECT rtrim(MV.FATO)FATO,RTRIM(MV.FILIAL)FILIAL,RTRIM(MV.SERIE)SERIE,RTRIM(MV.NUMERO) NOTA,CONVERT(VARCHAR,MV.DATTAEMISSAO,103)EMISSAO,CONVERT(VARCHAR,MV.DATTASAIDA,103)DT_MOV, " &
                 "CASE RTRIM(MV.ESTATUS) WHEN 'C' THEN 'CANCELADO' WHEN 'N' THEN 'NORMAL' ELSE 'OUTRO' END ESTATUS,REPLACE(MV.VALOR,'.',',')VALOR,REPLACE(MV.DESCONTOCALC,'.',',')DESCONTO, " &
                 "RTRIM(MC.CLIENTE)+'-'+RTRIM(C.NOME)AGENTE,RTRIM(MC.VENDEDOR)+'-'+RTRIM(V.NOME) VENDEDOR  " &
                 "FROM  MV MV " &
                 "INNER JOIN DBIXE.DBO.MVCLIENTES MC ON MC.SEQNOTA=MV.SEQ " &
                 "LEFT JOIN DBIXE.DBO.CLIENTES C ON C.CODIGO=MC.CLIENTE " &
                 "LEFT JOIN DBIXE.DBO.VENDEDORES V ON V.CODIGO=MC.VENDEDOR " &
                 "WHERE " &
                 Fato &
                 " AND MV.FILIAL ='" & Filial & "' " &
                 " AND DATTAEMISSAO BETWEEN '" & dtInicioVendas.Value.ToString("yyyy-MM-dd") & "' AND '" & dtFinalVendas.Value.ToString("yyyy-MM-dd") & "' " &
                 Tipo_NF &
                 Estatus &
                 N_NF &
                 " ORDER BY MV.FATO,MV.FILIAL,MV.DATTASAIDA,MV.NUMERO "

        'MsgBox(QUERY & vbCrLf & cboxFilialVendas.SelectedIndex)
        Return QUERY
    End Function

    Private Sub btnVisualizarVendas_Click(sender As Object, e As EventArgs) Handles btnVisualizarVendas.Click
        ConectarData(dgVendas, MontarQueryVendas)
        COLORIRGRD(dgVendas)
    End Sub



    Private Sub frmMovimentacoes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MenuPrincipal()
    End Sub

    Private Sub cboxTipoVend_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxTipoVend.SelectedIndexChanged
        If cboxTipoVend.SelectedIndex = 0 Then
            cboxVendedores.Visible = False
            btnImprimirVend.Visible = True
        ElseIf cboxTipoVend.SelectedIndex = 1 Then
            btnImprimirVend.Visible = False
            cboxVendedores.Visible = True
            Dim TEXTO As String = " SELECT RTRIM(MC.VENDEDOR)+'-'+RTRIM(V.NOME)VENDEDOR FROM MV " &
 "INNER JOIN MVCLIENTES MC ON MC.SEQNOTA=MV.SEQ " &
 "LEFT JOIN VENDEDORES V ON V.CODIGO=MC.VENDEDOR " &
 "WHERE MV.FILIAL='01' AND MV.FATO='SC' AND MV.DATTAEMISSAO>GETDATE()-365 " &
  " GROUP BY MC.VENDEDOR,V.NOME " &
  " ORDER BY MC.VENDEDOR DESC"
            PREENCHERCBOX2(cboxVendedores, TEXTO, "VENDEDOR")
            cboxVendedores.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnVisualizarVend_Click(sender As Object, e As EventArgs) Handles btnVisualizarVend.Click
        Dim TEXTO As String = ""
        Dim SERIE As String = ""
        Dim VEND As String = ""
        If checkCupomVend.CheckState = CheckState.Checked Then
            SERIE = " AND SERIE='CF1' "
        ElseIf checkTodosVend.CheckState = CheckState.Checked Then
            SERIE = ""
        End If

        If cboxTipoVend.SelectedIndex = 0 Then
            TEXTO = " SELECT ROW_NUMBER() OVER (ORDER BY VENDEDOR)N,VENDEDOR,REPLACE(SUM(VENDAS),'.',',')VENDAS,REPLACE(SUM(DESCONTOVALOR),'.',',')DESCONTOS,REPLACE(SUM(CANCELADAS),'.',',')CANCELADAS FROM ( " &
"SELECT RTRIM(MC.VENDEDOR)+'-'+RTRIM(V.NOME)VENDEDOR, " &
"CASE WHEN MV.ESTATUS='N' THEN VALOR else 0 END VENDAS, " &
"CASE WHEN MV.ESTATUS='N' THEN DESCONTOVALOR else 0 END DESCONTOVALOR, " &
"CASE WHEN MV.ESTATUS='C' THEN VALOR else 0 END CANCELADAS  " &
"FROM MV MV " &
"INNER JOIN MVCLIENTES MC ON MC.SEQNOTA=MV.SEQ " &
"LEFT JOIN VENDEDORES V ON V.CODIGO=MC.VENDEDOR " &
"WHERE MV.FATO='SC' AND MV.FILIAL='01' AND MV.DATTAEMISSAO BETWEEN '" & dtInicioVend.Value.ToString("yyyy-MM-dd") & "' AND '" & dtFinalVend.Value.ToString("yyyy-MM-dd") & "'  " & SERIE & " " &
")A " &
"GROUP BY VENDEDOR"
        ElseIf cboxTipoVend.SelectedIndex = 1 Then
            Dim T As String() = Split(cboxVendedores.Text, "-")
            VEND = " AND MC.VENDEDOR='" & T(0).ToString & "' "
            TEXTO = "  SELECT CONVERT(VARCHAR,MV.DATTAEMISSAO,103) EMISSAO,RTRIM(MV.NUMERO) NOTA,CASE MV.ESTATUS WHEN 'N' THEN 'NORMAL' WHEN 'C' THEN 'CANCEL.' ELSE 'OUTRO' END ESTATUS, " &
 " RTRIM(MC.VENDEDOR)+'-'+RTRIM(V.NOME)VENDEDOR,  " &
 "CASE WHEN MV.ESTATUS='N' THEN VALOR else 0 END VALOR,  " &
 "CASE WHEN MV.ESTATUS='N' THEN DESCONTOVALOR else 0 END DESCONTO,  " &
 "CASE WHEN MV.ESTATUS='C' THEN VALOR else 0 END CANCELADAS   " &
 "FROM MV MV INNER JOIN MVCLIENTES MC ON MC.SEQNOTA=MV.SEQ LEFT JOIN VENDEDORES V ON V.CODIGO=MC.VENDEDOR  " &
 "WHERE MV.FATO='SC' AND MV.FILIAL='01' AND MV.DATTAEMISSAO BETWEEN '" & dtInicioVend.Value.ToString("yyyy-MM-dd") & "' AND '" & dtFinalVend.Value.ToString("yyyy-MM-dd") & "'  " & SERIE & " " & VEND & " " &
 "ORDER BY MV.DATTAEMISSAO DESC"
        End If
        ConectarData(dgVendedores, TEXTO)
        COLORIRGRD(dgVendedores)

    End Sub

    Private Sub dtInicioVendas_ValueChanged(sender As Object, e As EventArgs) Handles dtInicioVendas.ValueChanged
        dtFinalVendas.Value = DateValue(dtInicioVendas.Value.Year & "/" & dtInicioVendas.Value.Month & "/" & Date.DaysInMonth(dtInicioVendas.Value.Year, dtInicioVendas.Value.Month))
    End Sub

    Private Sub dtInicioVend_ValueChanged(sender As Object, e As EventArgs) Handles dtInicioVend.ValueChanged
        dtFinalVend.Value = DateValue(dtInicioVend.Value.Year & "/" & dtInicioVend.Value.Month & "/" & Date.DaysInMonth(dtInicioVend.Value.Year, dtInicioVend.Value.Month))
    End Sub

    Private Sub btnImprimirVend_Click(sender As Object, e As EventArgs) Handles btnImprimirVend.Click
        frmRelatorios2.Close()
        Dim SERIE As String = ""
        If checkCupomVend.CheckState = CheckState.Checked Then
            SERIE = " AND SERIE='CF1' "
        ElseIf checkTodosVend.CheckState = CheckState.Checked Then
            SERIE = ""
        End If
        VALIDA_ACESSO(frmRelatorios2, MOD_USUARIO, "ABRIR")
        Dim Q As String = " SELECT ROW_NUMBER() OVER (ORDER BY VENDEDOR)N,RTRIM(CONVERT(VARCHAR,VENDEDOR))VENDEDOR,SUM(VENDAS) VENDAS,SUM(DESCONTOVALOR) DESCONTOS,SUM(CANCELADAS) CANCELADAS FROM  " &
 "( SELECT RTRIM(MC.VENDEDOR)+'-'+RTRIM(V.NOME)VENDEDOR, CASE WHEN MV.ESTATUS='N' THEN VALOR else 0 END VENDAS, CASE WHEN MV.ESTATUS='N' THEN DESCONTOVALOR else 0 END DESCONTOVALOR,  " &
 "CASE WHEN MV.ESTATUS='C' THEN VALOR else 0 END CANCELADAS   " &
 "FROM MV MV INNER JOIN MVCLIENTES MC ON MC.SEQNOTA=MV.SEQ LEFT JOIN VENDEDORES V ON V.CODIGO=MC.VENDEDOR  " &
 "WHERE MV.FATO='SC' AND MV.FILIAL='01' AND MV.DATTAEMISSAO BETWEEN '" & dtInicioVend.Value.ToString("yyyy-MM-dd") & "' AND '" & dtFinalVend.Value.ToString("yyyy-MM-dd") & "'   " & SERIE & "  )A GROUP BY VENDEDOR ORDER BY N"

        frmRelatorios2.GeraRelatorio("DBIXE", Q, "Report2.rdlc", "A", "DataSet1", dtInicioVend.Value.ToString("yyyy-MM-dd"), dtFinalVend.Value.ToString("yyyy-MM-dd"))
        'ABRE_RELATORIO(Q, "A", frmRelatorios.TOTALVENDEDORBindingSource)
    End Sub

    Private Sub ReflectionImage2_Click(sender As Object, e As EventArgs) Handles ReflectionImage2.Click
        Me.Close()
        'MenuPrincipal()
    End Sub


End Class