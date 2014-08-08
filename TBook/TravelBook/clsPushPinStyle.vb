Public Class clsPushPinStyle

    Private mID As String
    Private mStyleIconLink As String
    Private mKMLString As String
    Public Sub New(tKMLString As String)
        mKMLString = tKMLString
    End Sub

    Public Sub New(tStyleReader As XmlReader)

        While tStyleReader.Read()
            If tStyleReader.IsStartElement Then
                Select Case tStyleReader.Name.ToLower
                    Case "style"
                        mID = tStyleReader("id")
                    Case "iconstyle" 
                    Case "icon" 
                    Case "href"
                        mStyleIconLink = tStyleReader.ReadElementContentAsString()
                    End Select
            End If
        End While
    End Sub
End Class
