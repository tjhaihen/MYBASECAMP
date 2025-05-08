Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common
Imports System.Text


Namespace QIS.Web.Secure.Master.fa.assets


    Public Class PrintOtomatis


#Region "Declaration variable"
        Protected sqlCon As SqlConnection
        Protected strCon As String

#End Region

#Region "DesignConnection"
        Public Sub New()
            InitClass()
        End Sub
        Private Sub InitClass()
            ' // create all the objects and initialize other members.
            'sqlCon = New SqlConnection(HisConfiguration.ConnectionString)

        End Sub

        Public Sub dispose()
            isCloseConnectionDatabase()
            GC.SuppressFinalize(Me)


        End Sub
        Protected Overridable Overloads Sub isCloseConnectionDatabase()
            If sqlCon.State = ConnectionState.Open Then
                sqlCon.Dispose()
            End If
            sqlCon = Nothing
        End Sub


#End Region

#Region " Direct Print to Zebra "

        'Private Function GenerateFALabel(ByVal kdaktiva As String) As String
        'Dim br As New BussinessRules.FA.aktiva
        'br.KdAktiva = kdaktiva

        'If br.SelectOne.Rows.Count > 0 Then
        '    Dim command As New StringBuilder()

        '    command.AppendLine("^XA")
        '    command.AppendLine("^LL210")
        '    command.AppendLine("^PW600")
        '    command.AppendLine("^LH1,1^MD10")
        '    command.AppendLine("^CF030,30")
        '    command.AppendLine(String.Format("^FO2,71^FD{0}^FS", br.NmAktiva.Value.Trim))
        '    command.AppendLine("^CF020,20")
        '    command.AppendLine(String.Format("^FO2,100^BCN,90,N,N,N^FD{0}^FS", br.KdAktiva.Value.Trim))
        '    command.AppendLine(String.Format("^FO2,180^FD{0}^FS", br.KdAktiva.Value.Trim))
        '    command.AppendLine("^XZ")

        '    'command.AppendLine("^XA")
        '    'command.AppendLine("^LL210")
        '    'command.AppendLine("^PW600")
        '    'command.AppendLine("^LH1,1^MD10")
        '    'command.AppendLine("^CF042,42")
        '    'command.AppendLine(String.Format("^FB621,,,C^FO1,41^FD{0}^FS", br.NmAktiva.Value.Trim))
        '    'command.AppendLine("^CF026,28")
        '    'command.AppendLine(String.Format("^FO45,100^BCN,90,N,N,N^FD{0}^FS", br.KdAktiva.Value.Trim))
        '    'command.AppendLine(String.Format("^FB621,,,C^FO1,200^FD{0}^FS", br.KdAktiva.Value.Trim))
        '    'command.AppendLine("^XZ")

        '    Return command.ToString()
        'Else
        '    Return String.Empty
        'End If
        'End Function

        Public Function PrintLabelFA(ByVal kdaktiva As String) As Boolean
            'Dim prin As New DirectPrinting
            'Dim brStfield As New BussinessRules.stdField
            'Dim GetAddressPrinter As String
            'Dim CountPrint As Byte

            ' ''Untuk mendapatkan alamat Printer Zebra 
            'GetAddressPrinter = brStfield.GetValueStdfield("DirectPrint", "GLFALabel")
            'CountPrint = brStfield.GetValueStdfield("COUNTPRINTZEBRA", "GLFALabel")

            'Dim command As String
            'command = GenerateFALabel(kdaktiva)

            'For index As Integer = 1 To CountPrint

            '    Try
            '        prin.OpenPrinter(GetAddressPrinter)
            '        prin.StartDocPrinter()
            '        prin.Send(command.ToString())
            '        prin.EndDocPrinter()
            '    Catch ex As Exception
            '        ExceptionManager.Publish(ex)
            '    Finally
            '        brStfield.Dispose()
            '    End Try
            'Next
        End Function
#End Region



    End Class
End Namespace