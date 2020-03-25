<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorios
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

    'OBSERVAÇÃO: O procedimento a seguir é exigido pelo Windows Form Designer
    'Ele pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatorios))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.RELMOVIMENTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TOTALVENDEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.barraTituloGeral = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.RELMOVIMENTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTALVENDEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barraTituloGeral.SuspendLayout()
        Me.SuspendLayout()
        '
        'RELMOVIMENTOSBindingSource
        '
        Me.RELMOVIMENTOSBindingSource.DataSource = GetType(SolutionsBomPastor.RELMOVIMENTOS)
        '
        'barraTituloGeral
        '
        Me.barraTituloGeral.CanvasColor = System.Drawing.Color.Transparent
        Me.barraTituloGeral.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.barraTituloGeral.Controls.Add(Me.LabelX1)
        Me.barraTituloGeral.Controls.Add(Me.ReflectionImage1)
        Me.barraTituloGeral.DisabledBackColor = System.Drawing.Color.Empty
        Me.barraTituloGeral.Dock = System.Windows.Forms.DockStyle.Top
        Me.barraTituloGeral.Location = New System.Drawing.Point(0, 0)
        Me.barraTituloGeral.Name = "barraTituloGeral"
        Me.barraTituloGeral.Size = New System.Drawing.Size(733, 27)
        Me.barraTituloGeral.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.barraTituloGeral.Style.BackColor1.Color = System.Drawing.Color.White
        Me.barraTituloGeral.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.barraTituloGeral.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.barraTituloGeral.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.barraTituloGeral.Style.GradientAngle = 90
        Me.barraTituloGeral.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 1)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(252, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Relatorios"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(707, 4)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(21, 20)
        Me.ReflectionImage1.TabIndex = 0
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandablePanel1.Expanded = False
        Me.ExpandablePanel1.ExpandedBounds = New System.Drawing.Rectangle(0, 27, 733, 108)
        Me.ExpandablePanel1.ExpandOnTitleClick = True
        Me.ExpandablePanel1.HideControlsWhenCollapsed = True
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 27)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.ShowFocusRectangle = True
        Me.ExpandablePanel1.Size = New System.Drawing.Size(733, 26)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 11
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "<b>Gerar Relatorios</b>"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.ForeColor = System.Drawing.Color.Black
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.TOTALVENDEDORBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SolutionsBomPastor.Report3.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 53)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(733, 365)
        Me.ReportViewer1.TabIndex = 18
        '
        'frmRelatorios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 418)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.barraTituloGeral)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelatorios"
        Me.Text = "frmRelatorios"
        CType(Me.RELMOVIMENTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTALVENDEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barraTituloGeral.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TOTALVENDEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents barraTituloGeral As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RELMOVIMENTOSBindingSource As System.Windows.Forms.BindingSource
End Class
