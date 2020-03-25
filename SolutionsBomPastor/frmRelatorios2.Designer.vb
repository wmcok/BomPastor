<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorios2
    'Inherits System.Windows.Forms.Form
    Inherits DevComponents.DotNetBar.Metro.MetroForm
    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rvPrintPreview = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvPrintPreview
        '
        Me.rvPrintPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvPrintPreview.ForeColor = System.Drawing.Color.Black
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Nothing
        Me.rvPrintPreview.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvPrintPreview.LocalReport.ReportEmbeddedResource = "SolutionsBomPastor.Report3.rdlc"
        Me.rvPrintPreview.Location = New System.Drawing.Point(0, 0)
        Me.rvPrintPreview.Name = "rvPrintPreview"
        Me.rvPrintPreview.ServerReport.BearerToken = Nothing
        Me.rvPrintPreview.Size = New System.Drawing.Size(872, 526)
        Me.rvPrintPreview.TabIndex = 19
        '
        'frmRelatorios2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 526)
        Me.Controls.Add(Me.rvPrintPreview)
        Me.DoubleBuffered = True
        Me.Name = "frmRelatorios2"
        Me.Text = "Relatorios Gerais"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rvPrintPreview As Microsoft.Reporting.WinForms.ReportViewer
End Class
