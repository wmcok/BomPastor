Public Class clBiblioteca
    
End Class

Public Class TOTALVENDEDOR
    Public Property N As Int32
    Public Property VENDEDOR As String
    Public Property VENDAS As Double
    Public Property DESCONTOS As Double
    Public Property CANCELADAS As Double

End Class

Public Class RELMOVIMENTOS
    Public Property TIPO As String
    Public Property FINANC As String
    Public Property EMISSAO As String
    Public Property PARCELAS As String
    Public Property TOTAL As Double
    Public Property PAGO As Double
    Public Property VENCIDO As Double
    Public Property NATUREZA As String
    Public Property OBSERVACAO As String
    Public Property ESTATUS As String
End Class


Public Class RELMOVIMENTOS_NAT
    Public Property TIPO As String
    Public Property TOTAL As Double
    Public Property PAGO As Double
    Public Property VENCIDO As Double
    Public Property NATUREZA As String

End Class

Public Class RELMOVIMENTOS_SALDO
    Public Property NATUREZA As String
    Public Property ENTRADAS As Double
    Public Property SAIDAS As Double
    Public Property SALDO As Double


End Class
