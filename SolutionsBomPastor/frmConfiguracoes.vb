Imports DevComponents.DotNetBar
Public Class frmConfiguracoes
    Public Sub PINGAR()
        If CheckBoxX1.CheckState = CheckState.Checked And CheckBoxX2.CheckState = CheckState.Checked Then
            Try
                If My.Computer.Network.Ping(TextBoxX2.Text, 1433) Then
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX2.Text & ":1433: Acessível."
                Else
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX2.Text & ":1433: Host de destino inacessível."
                End If
            Catch ex As Exception
                TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX2.Text & ":1433: Host de destino inacessível."
            End Try

        ElseIf CheckBoxX1.CheckState = CheckState.Checked Then
            Try
                If My.Computer.Network.Ping(TextBoxX1.Text, 1433) Then
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ":1433: Acessível."
                Else
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ":1433: Host de destino inacessível."
                End If
            Catch ex As Exception
                TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ":1433: Host de destino inacessível."
            End Try

        ElseIf CheckBoxX2.CheckState = CheckState.Checked Then
            Try
                If My.Computer.Network.Ping(TextBoxX2.Text) Then
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX2.Text & ": Acessível."
                Else
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX2.Text & ": Host de destino inacessível."
                End If
            Catch ex As Exception
                TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX2.Text & ": Host de destino inacessível."
            End Try

        Else
            Try
                If My.Computer.Network.Ping(TextBoxX1.Text) Then
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ": Acessível."
                Else
                    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ": Host de destino inacessível."
                End If
            Catch ex As Exception
                TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ": Host de destino inacessível."
            End Try
            'If My.Computer.Network.Ping(TextBoxX1.Text) Then
            '    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ": Acessível."
            'Else
            '    TextBoxX3.Text = TextBoxX3.Text & vbLf & Now.Date.ToShortDateString & " - " & Now.ToLongTimeString & "  Resposta de " & TextBoxX1.Text & ": Host de destino inacessível."
            'End If
        End If
        'Me.Refresh()
        Me.TextBoxX3.Focus()
        Me.TextBoxX3.SelectionStart = Len(Me.TextBoxX3.Text)
        Me.TextBoxX3.ScrollToCaret()
    End Sub
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If timerPing.Enabled = False Then
            timerPing.Enabled = True
            timerPing.Start()
            ButtonX1.Text = "Parar Teste"
        Else
            timerPing.Enabled = False
            timerPing.Stop()
            ButtonX1.Text = "Testar Ping"
        End If


    End Sub



    Private Sub frmConfiguracoes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MenuPrincipal()
    End Sub

    Private Sub timerPing_Tick(sender As Object, e As EventArgs) Handles timerPing.Tick
        PINGAR()
    End Sub

    Private Sub btnExecutarQuery_Click(sender As Object, e As EventArgs) Handles btnExecutarQuery.Click
        Try
            If checkSemRetorno.CheckState = CheckState.Checked Then
                EXECUTARQUERY(txtQuery.Text.ToString)
            ElseIf checkComRetorno.CheckState = CheckState.Checked Then
                PREENCHERGRID(dgResultados, txtQuery.Text.ToString)
                lblTotalizador.Text = dgResultados.Rows.Count & "  Linhas"
                SuperTabControl1.SelectedTab = SuperTabItem3
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBoxEx.Show("Erro ao Executar a Query" & vbCrLf & ex.ToString)
        End Try

    End Sub

    Private Sub btnListarTabelas_Click(sender As Object, e As EventArgs) Handles btnListarTabelas.Click
        PREENCHERGRID(dgResultados, "SELECT  TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE,TABLE_CATALOG FROM information_schema.tables")
        lblTotalizador.Text = dgResultados.Rows.Count & "  Linhas"
        SuperTabControl1.SelectedTab = SuperTabItem3
    End Sub

    Private Sub btnListarColunas_Click(sender As Object, e As EventArgs) Handles btnListarColunas.Click
        Dim Col As String = TrataCodigos(txtQuery.Text)
        Dim Q As String = " select TABLE_NAME,ORDINAL_POSITION N,COLUMN_NAME,DATA_TYPE, " &
                             "ISNULL(CHARACTER_MAXIMUM_LENGTH,'') CHARACTER_MAXIMUM_LENGTH, " &
                             "ISNULL(NUMERIC_PRECISION,0) NUMERIC_PRECISION,ISNULL(NUMERIC_SCALE,0) NUMERIC_SCALE  " &
                             "from information_schema.columns where table_name in (" & Col & " )" &
                             "order by TABLE_NAME,ORDINAL_POSITION"

        PREENCHERGRID(dgResultados, Q)
        lblTotalizador.Text = dgResultados.Rows.Count & "  Linhas"
        SuperTabControl1.SelectedTab = SuperTabItem3
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        MessageBoxEx.Show("Função Desabilitada!")
    End Sub
End Class